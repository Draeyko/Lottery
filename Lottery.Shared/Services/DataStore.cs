using Lottery.Shared.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Lottery.Shared.Services
{
    public class DataStore
    {
        private readonly IFileService _fileService;
        private readonly IDatabaseService _databaseService;

        public DataStore(IFileService fileService, IDatabaseService databaseService)
        {
            _fileService = fileService ?? throw new ArgumentNullException(nameof(fileService));
            _databaseService = databaseService ?? throw new ArgumentNullException(nameof(databaseService));
        }

        public async Task<List<Draw>> LoadDrawsAsync()
        {
            List<Draw> draws = await _databaseService.GetDrawsAsync();
            if (draws == null || draws.Count == 0)
            {
                try
                {
                    var json = _fileService.ReadFile("draw.json");
                    var drawResponse = JsonConvert.DeserializeObject<DrawResponse>(json);
                    draws = drawResponse?.Draws;
                    if (draws != null)
                    {
                        foreach (var draw in draws)
                        {
                            await _databaseService.SaveDrawAsync(draw);
                        }
                    }
                }
                catch (JsonException)
                {

                    return null;
                }
            }

            return draws;
        }
    }
}

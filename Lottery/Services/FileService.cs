using Android.Content;
using Lottery.Shared.Services;
using System.IO;

namespace Lottery.Services
{
    public class FileService : IFileService
    {
        private readonly Context _context;

        public FileService(Context context)
        {
            _context = context;
        }

        public string ReadFile(string path)
        {
            using (var stream = _context.Assets.Open(path))
            using (var reader = new StreamReader(stream))
            {
                return reader.ReadToEnd();
            }
        }
    }
}
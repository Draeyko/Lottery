using NUnit.Framework;
using System.Collections.Generic;
using Moq;
using Lottery.Shared.Services;
using Lottery.Shared.Models;
using System.Threading.Tasks;
using NUnit.Framework.Legacy;

namespace LotteryTestsNet
{
    [TestFixture]
    public class DataStoreTests
    {
        private Mock<IFileService> _fileServiceMock;
        private DataStore _dataService;
        private Mock<IDatabaseService> _databaseServiceMock;

        [SetUp]
        public void Setup()
        {
            _fileServiceMock = new Mock<IFileService>();
            _databaseServiceMock = new Mock<IDatabaseService>();
            _dataService = new DataStore(_fileServiceMock.Object, _databaseServiceMock.Object);
        }

        [Test]
        public async Task LoadDraws_ShouldReturnListOfDraws()
        {
            var json = @"{ 'draws': [{ 'id': 'draw-1', 'drawDate': '2023-05-15', 'number1': '2', 'number2': '16', 'number3': '23', 'number4': '44', 'number5': '47', 'number6': '52', 'bonus-ball': '14', 'topPrize': 4000000000 }] }";
            // Setup mock behavior
            _fileServiceMock.Setup(fs => fs.ReadFile(It.IsAny<string>())).Returns(json);
            _databaseServiceMock.Setup(ds => ds.GetDrawsAsync()).ReturnsAsync(new List<Draw>());
            
            // Act
            List<Draw> draws = await _dataService.LoadDrawsAsync();

            // Assert
            ClassicAssert.NotNull(draws);
            ClassicAssert.IsNotEmpty(draws);
            ClassicAssert.AreEqual("draw-1", draws[0].Id);
        }

        [Test]
        public async Task LoadDraws_ShouldHandleInvalidJson()
        {
            _fileServiceMock.Setup(fs => fs.ReadFile(It.IsAny<string>())).Returns("Invalid JSON Content");
            _databaseServiceMock.Setup(ds => ds.GetDrawsAsync()).ReturnsAsync(new List<Draw>());

            List<Draw> draws = await _dataService.LoadDrawsAsync();

            ClassicAssert.IsNull(draws);
        }

        [Test]
        public async Task LoadDraws_ShouldHandleEmptyFile()
        {
            _fileServiceMock.Setup(fs => fs.ReadFile(It.IsAny<string>())).Returns(string.Empty);
            _databaseServiceMock.Setup(ds => ds.GetDrawsAsync()).ReturnsAsync(new List<Draw>());

            List<Draw> draws = await _dataService.LoadDrawsAsync();

            ClassicAssert.IsNull(draws);
        }

    }
}


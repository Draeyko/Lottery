//using NUnit.Framework;
//using Lottery.Services;
//using System.Collections.Generic;
//using Lottery.Models;
//using Android.Content.Res;
//using Android.Content;
//using Android.App;
//using System.IO;
//using Android.Support.V7.App;
//using Android.Views;
//using Lottery;

//namespace Lotterytests
//{
//    [TestFixture]
//    public class DataStoreTests
//    {
//        private Context _mockContext;

//        [SetUp]
//        public void Setup()
//        {
//            // Create a ContextThemeWrapper, which is a subclass of Context
//            _mockContext = new ContextThemeWrapper(Application.Context, Resource.Style.Theme_AppCompat);

//            // Write a sample draw.json file to the assets folder in the mock context
//            var assetManager = _mockContext.Assets;
//            using (var writer = new StreamWriter(assetManager.Open("draw.json")))
//            {
//                writer.Write(@"{
//                    'draws': [
//                        {
//                            'id': 'draw-1',
//                            'drawDate': '2023-05-15',
//                            'number1': '2',
//                            'number2': '16',
//                            'number3': '23',
//                            'number4': '44',
//                            'number5': '47',
//                            'number6': '52',
//                            'bonus-ball': '14',
//                            'topPrize': 4000000000
//                        }
//                    ]
//                }");
//            }
//        }

//        [Test]
//        public void LoadDraws_ShouldReturnListOfDraws()
//        {
//            var service = new DataStore(_mockContext);
//            List<Draw> draws = service.LoadDraws();

//            Assert.IsNotNull(draws);
//        }

//        [Test]
//        public void LoadDraws_ShouldHandleInvalidJson()
//        {
//            // Write invalid JSON content to the assets folder
//            var assetManager = _mockContext.Assets;
//            using (var writer = new StreamWriter(assetManager.Open("draw.json")))
//            {
//                writer.Write("Invalid JSON Content");
//            }

//            var service = new DataStore(_mockContext);
//            List<Draw> draws = service.LoadDraws();

//            Assert.IsNull(draws);
//        }
//    }
//}

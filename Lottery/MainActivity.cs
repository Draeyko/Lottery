using System;
using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using System.Collections.Generic;
using Lottery.Services;
using Lottery.Adapters;
using Lottery.Activities;
using Android.Content;
using Lottery.Shared.Services;
using Lottery.Shared.Models;

namespace Lottery
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : Activity
    {
        private ListView _drawListView;
        private List<Draw> _draws;
        protected override async void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.DrawListView);
            _drawListView = FindViewById<ListView>(Resource.Id.drawListView);
            var ticketButton = FindViewById<Button>(Resource.Id.ticketButton);

            //var dataStore = new DataStore(this);  Decoupled Anroid Coontext from Datastore

            // Instantiate the FileService with the Android context
            var fileService = new FileService(this);
            var databaseService = new DatabaseService();
            var dataStore = new DataStore(fileService, databaseService);

            _draws = await dataStore.LoadDrawsAsync();
            if (_draws != null)
            {
                var adapter = new DrawListAdapter(this, _draws);
                _drawListView.Adapter = adapter;

                _drawListView.ItemClick += DrawListView_ItemClick;
            }
            else
            {
                Android.Util.Log.Error("MainActivity", "Failed to load draws or draws are empty.");
                Toast.MakeText(this, "Failed to load draws or draws are empty.", ToastLength.Long).Show();

            }
            ticketButton.Click += (sender, e) =>
            {
                var intent = new Intent(this, typeof(TicketActivity));
                StartActivity(intent);
            };
        }

        private void DrawListView_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            if (_draws != null && e.Position >= 0 && e.Position < _draws.Count)
            {
                var draw = _draws[e.Position];
                var intent = new Intent(this, typeof(DrawDetailActivity));
                intent.PutExtra("drawId", draw.Id);
                StartActivity(intent);
            }
            else
            {
                Android.Util.Log.Error("MainActivity", "Invalid draw position selected.");
                Toast.MakeText(this, "Invalid draw position selected.", ToastLength.Long).Show();
            }
        }

     

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
	}
}

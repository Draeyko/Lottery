using Android.App;
using Android.Content;
using Android.OS;
using Android.Views;
using Android.Widget;
using AndroidX.ViewPager.Widget;
using Google.Android.Material.Tabs;
using Lottery.Adapters;
using Lottery.Services;
using Lottery.Fragments;
using Lottery.Shared.Models;
using Lottery.Shared.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AndroidX.AppCompat.App;

namespace Lottery.Activities
{
    [Activity(Label = "DrawDetailActivity", Theme = "@style/AppTheme")]
    public class DrawDetailActivity : AppCompatActivity
    {
        
        private List<Draw> _draws;
        private int _currentPosition;
        private ViewPager _viewPager;
        private TabLayout _tabLayout;

        protected override async void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.DrawDetailView);
            var drawId = Intent.GetStringExtra("drawId");
            _draws = await GetDrawsAsync();

            if (_draws == null || _draws.Count == 0)
            {
                Android.Util.Log.Error("DrawDetailActivity", "Draws list is null or empty.");
                Finish(); // Close the activity if there's no data to show
                return;
            }

            _currentPosition = _draws.FindIndex(d => d.Id == drawId);
            _viewPager = FindViewById<ViewPager>(Resource.Id.viewPager);
            _tabLayout = FindViewById<TabLayout>(Resource.Id.tabLayout);

            if (_currentPosition >= 0 )
            {
                _viewPager.SetCurrentItem(_currentPosition, true);
            }
            else
            {
                Android.Util.Log.Error("DrawDetailActivity", "Invalid draw ID.");
                Toast.MakeText(this, "Invalid draw ID.", ToastLength.Long).Show();
                Finish();
            }

            var adapter = new DrawPagerAdapter(SupportFragmentManager, _draws);
            _viewPager.Adapter = adapter;
            _tabLayout.SetupWithViewPager(_viewPager);

            _viewPager.SetCurrentItem(_currentPosition, true);
        }

       

       
        private async Task<List<Draw>> GetDrawsAsync()
        {
            var fileService = new FileService(this);
            var databaseService = new DatabaseService();
            var dataStore = new DataStore(fileService, databaseService);

            var draws = await dataStore.LoadDrawsAsync();

            return draws ?? new List<Draw>(); // Return an empty list if draws is null
        }
    }
}
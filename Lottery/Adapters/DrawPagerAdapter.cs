using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AndroidX.Fragment.App;
using Java.Lang;
using Lottery.Fragments;
using Lottery.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lottery.Adapters
{
    public class DrawPagerAdapter : FragmentPagerAdapter
    {
        private List<Draw> _draws;

        public DrawPagerAdapter(AndroidX.Fragment.App.FragmentManager fm, List<Draw> draws)
            : base(fm, BehaviorResumeOnlyCurrentFragment)
        {
            _draws = draws;
        }

        public override int Count => _draws.Count;

        [Obsolete]
        public override AndroidX.Fragment.App.Fragment GetItem(int position)
        {
            return DrawDetailFragment.NewInstance(_draws[position]);
        }

        public override ICharSequence GetPageTitleFormatted(int position)
        {
            return new Java.Lang.String($"Draw {position + 1}");
        }
    }
}
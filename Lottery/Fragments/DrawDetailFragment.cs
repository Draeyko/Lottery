
using Android.OS;
using Android.Views;
using Android.Widget;
using Lottery.Shared.Models;
using AndroidX.Fragment.App;
using System;

namespace Lottery.Fragments
{
    [Obsolete]
    public class DrawDetailFragment : Fragment
    {
        private Draw _draw;

        public static DrawDetailFragment NewInstance(Draw draw)
        {
            var fragment = new DrawDetailFragment();
            fragment._draw = draw;
            return fragment;
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var view = inflater.Inflate(Resource.Layout.Fragment_DrawDetail, container, false);

            var drawDateTextView = view.FindViewById<TextView>(Resource.Id.drawDateTextView);
            var numbersTextView = view.FindViewById<TextView>(Resource.Id.numbersTextView);
            var bonusBallTextView = view.FindViewById<TextView>(Resource.Id.bonusBallTextView);

            drawDateTextView.Text = $"Draw Date: {_draw.DrawDate}";
            numbersTextView.Text = $"Numbers: {_draw.Number1}, {_draw.Number2}, {_draw.Number3}, {_draw.Number4}, {_draw.Number5}, {_draw.Number6}";
            bonusBallTextView.Text = $"Bonus Ball: {_draw.BonusBall}";

            return view;
        }
    }
}
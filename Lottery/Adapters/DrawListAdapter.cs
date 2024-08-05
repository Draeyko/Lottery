using Android.Content;
using Android.Views;
using Android.Widget;
using Lottery.Shared.Models;
using System.Collections.Generic;

namespace Lottery.Adapters
{
    internal class DrawListAdapter : BaseAdapter<Draw>
    {

        private List<Draw> _items;
        private Context _context;

        public DrawListAdapter(Context context, List<Draw> items)
        {
            _context = context;
            _items = items;
        }


        public override Java.Lang.Object GetItem(int position)
        {
            return position;
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var view = convertView ?? LayoutInflater.From(_context).Inflate(Android.Resource.Layout.SimpleListItem1, parent, false);
            var draw = _items[position];
            view.FindViewById<TextView>(Android.Resource.Id.Text1).Text = draw.DrawDate;
            return view;
        }

        public override Draw this[int position] => _items[position];

        public override int Count => _items.Count;
    }

    internal class DrawListAdapterViewHolder : Java.Lang.Object
    {
        //Your adapter views to re-use
        //public TextView Title { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace SchoolApps
{
	public class GeneralMsgAdapter : BaseAdapter<GeneralMsgItem>
	{
		List<GeneralMsgItem> genMsgItem;
		Activity context;
		public GeneralMsgAdapter(Activity context, List<GeneralMsgItem> genMsgItem)
		{
			this.genMsgItem = genMsgItem;
			this.context = context;
		}
		public override long GetItemId(int position)
		{
			return position;
		}
		public override GeneralMsgItem this[int position]
		{
			get { return genMsgItem[position]; }
		}
		public override int Count
		{
			get { return genMsgItem.Count; }
		}
		public override View GetView(int position, View convertView, ViewGroup parent)
		{
			var item = genMsgItem[position];

			View view = convertView;
			if (view == null)  // no view to re-use, create new
				view = context.LayoutInflater.Inflate(Resource.Layout.GeneralMsgListView, null);
			view.FindViewById<TextView>(Resource.Id.tvSenderName).Text = item.SenderName;
			view.FindViewById<TextView>(Resource.Id.tvBriefDesc).Text = item.BriefDesc;
			view.FindViewById<ImageView>(Resource.Id.ivIconImage).SetImageResource(item.IconImageID);

			return view;
		}
	}
}


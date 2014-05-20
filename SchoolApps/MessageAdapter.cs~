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
	public class MessageAdapter : BaseAdapter<MessageItem>
	{
		List<MessageItem> privateMsgItem;
		Activity context;
		public MessageAdapter(Activity context, List<MessageItem> privateMsgItem)
		{
			this.privateMsgItem = privateMsgItem;
			this.context = context;
		}
		public override long GetItemId(int position)
		{
			return position;
		}
		public override MessageItem this[int position]
		{
			get { return privateMsgItem[position]; }
		}
		public override int Count
		{
			get { return privateMsgItem.Count; }
		}
		public override View GetView(int position, View convertView, ViewGroup parent)
		{
			var item = privateMsgItem[position];

			View view = convertView;
			if (view == null)  // no view to re-use, create new
				view = context.LayoutInflater.Inflate(Resource.Layout.MessageListView, null);

			view.FindViewById<TextView>(Resource.Id.tvMsgSender).Text = item.SenderName;
			view.FindViewById<TextView>(Resource.Id.tvMsgTitle).Text = item.BriefMsg;
			view.FindViewById<TextView>(Resource.Id.tvMsgSentDateTime).Text = item.SendDateTime;
			view.FindViewById<ImageView>(Resource.Id.ivMsgIcon).SetImageResource(item.IconImageID);

			return view;
		}
	}
}


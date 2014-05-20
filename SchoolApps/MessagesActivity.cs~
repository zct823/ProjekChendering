using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SchoolApps.GTKCoreLib;
using Newtonsoft.Json;

namespace SchoolApps
{
	//Adapters and items are referred from MessageFragment Subfiles.

	[Activity (Label = "Messages", Theme = "@style/Theme.Schoolapp")]
	public class MessagesActivity : Activity
	{

		List<MessageItem> privateMsgTableItemizeds = new List<MessageItem> ();
		ListView itemsListView;
		View footerViewPM;
		MessageAdapter msgAdapter;
		int limitStartPM = 1;
		int limitEndPM = 10;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Create your application here

			SetContentView (Resource.Layout.MessageLayout);

			itemsListView = (ListView) FindViewById (Resource.Id.lvMessagesStandalone);
			footerViewPM = ((LayoutInflater)GetSystemService (Context.LayoutInflaterService)).Inflate (Resource.Layout.ReadMorePMLayout, null, false);

			populateList(limitStartPM.ToString(),limitEndPM.ToString(),false);

			Button btnReadMorePM = (Button)itemsListView.FindViewById (Resource.Id.btnReadMorePM);

			btnReadMorePM.Click += delegate {

				limitStartPM = limitStartPM + 10;
				limitEndPM = limitEndPM + 10;
				populateList(limitStartPM.ToString(),limitEndPM.ToString(),true);

			};
		}

		private void populateList(string start, string end, bool notifyAdapter)
		{

			DatabaseAccess dbAccess = new DatabaseAccess();
			var jsonData = dbAccess.retrieveTheMessageOnDatabase (start.ToString(),end.ToString());
			var daMessageFromDB = JsonConvert.DeserializeObject<Webservice.MessageRootObject>(jsonData);
			var daMsgCountFromDB = dbAccess.countMessageOnTableDB();

			Console.WriteLine ("JSON Not Converted: "+jsonData);
			Console.WriteLine ("JSON Converted: "+daMessageFromDB);
			Console.WriteLine ("DB Msg Contains "+daMsgCountFromDB+" records");

			foreach (var deserialized in daMessageFromDB.items) {

				Console.WriteLine("Msg Title: {0}, Msg Sender: {1}, Msg Sendtime: {2}, Msg ID: {3}, Msg Content: {4}, Msg Read: {5}",deserialized.msg_title.ToString(),deserialized.msg_sender.ToString(),deserialized.msg_sendtime.ToString(),deserialized.msg_id.ToString(),deserialized.msg_content.ToString(),deserialized.msg_read.ToString());
				privateMsgTableItemizeds.Add(new MessageItem () { BriefMsg = deserialized.msg_title.ToString() , SenderName = deserialized.msg_sender.ToString() , SendDateTime = deserialized.msg_sendtime.ToString() });

			}

			if (notifyAdapter == false) {
				itemsListView.AddFooterView (footerViewPM);
				msgAdapter = new MessageAdapter (this, privateMsgTableItemizeds);
				itemsListView.Adapter = msgAdapter;
				itemsListView.ItemClick += clickedMessage;
			} else {
				msgAdapter.NotifyDataSetChanged ();
			}

		}

		public void clickedMessage(object sender, Android.Widget.AdapterView.ItemClickEventArgs e) {

			var listView = sender as ListView;
			var t = privateMsgTableItemizeds [e.Position];
			Intent privMsgIntent = new Intent(this, typeof(PrivMsgContentDetails));
			privMsgIntent.PutExtra ("MessageID",privateMsgTableItemizeds[e.Position].ToString());
			StartActivity (privMsgIntent);

		}
	}
}


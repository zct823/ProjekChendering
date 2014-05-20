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
using SchoolApps.GTKCoreLib;
using Newtonsoft.Json;

namespace SchoolApps
{
	//NOTICE: This is Activity Main Menu for Android below ICS

	[Activity (Label = "@string/app_subname", Theme = "@style/Theme.Schoolapp.NoNativeTitleBar")]			
	public class MainMenu : Activity
	{
		//Properties for General Msg
		List<GeneralMsgItem> genMsgItemTableItemizeds = new List<GeneralMsgItem> ();
		IDictionary<string, string> genMsgItemID = new Dictionary<string, string> ();
		ListView genMsgListView;
		int pageCountGM = 1;
		GeneralMsgAdapter genMsgAdapter;
		int countListGM = 0;
		string pgCountLimit;
		View footerView;

		//Properties for Messages
		List<MessageItem> privateMsgTableItemizeds = new List<MessageItem> ();
		IDictionary<string, string> privateMsgID = new Dictionary<string, string> ();
		ListView eventsListView;
		View footerViewPM;
		MessageAdapter msgAdapter;
		int limitStartPM = 1;
		int limitEndPM = 10;
		int countListPM = 0;

		//Properties for Events
		ListView privateMsgListView;
		List<EventsItem> eventsTableItemizeds = new List<EventsItem> ();
		//IDictionary<string, string> eventsInfoData = new Dictionary<string, string> ();
		IDictionary<string, string> eventsTitleBundle = new Dictionary<string, string> ();
		IDictionary<string, string> eventsDetailsBundle = new Dictionary<string, string> ();
		IDictionary<string, string> eventsStartBundle = new Dictionary<string, string> ();
		IDictionary<string, string> eventsEndBundle = new Dictionary<string, string> ();
		//IDictionary<string, bool> eventsAllDayBundle = new Dictionary<string, bool> ();
		IDictionary<string, string> eventsStatusBundle = new Dictionary<string, string> ();
		IDictionary<string, string> eventsCreatedBundle = new Dictionary<string, string> ();
		IDictionary<string, string> eventsModifiedBundle = new Dictionary<string, string> ();

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Create your application here
			SetContentView (Resource.Layout.MainContainer);
			//StartActivity (typeof(DrawerSampleActivity));
			//this.Finish ();

			var menu = FindViewById<FlyOutContainer> (Resource.Id.MMContainer);
			var menuBtn = FindViewById (Resource.Id.MenuButton);
			var leftMenuHome = FindViewById<RelativeLayout> (Resource.Id.rlLeftMenuHome);
			var leftMenuMessages = FindViewById<RelativeLayout> (Resource.Id.rlLeftMenuMessages);
			var leftMenuProfile = FindViewById<RelativeLayout> (Resource.Id.rlLeftMenuProfile);
			var leftMenuSchoolInfo = FindViewById<RelativeLayout> (Resource.Id.rlLeftMenuSchoolInfo);
			var leftMenuFeedback = FindViewById<RelativeLayout> (Resource.Id.rlLeftMenuFeedback);
			var leftMenuSettings = FindViewById<RelativeLayout> (Resource.Id.rlLeftMenuSettings);

			menuBtn.Click += delegate {
				Console.WriteLine("Tapped");
				menu.AnimatedOpened = !menu.AnimatedOpened;
			};

			leftMenuHome.Click += delegate {
				menu.AnimatedOpened = !menu.AnimatedOpened;
			};

			leftMenuMessages.Click += delegate {
				StartActivity(typeof(MessagesActivity));
				menu.AnimatedOpened = !menu.AnimatedOpened;
			};

			leftMenuProfile.Click += delegate {
				StartActivity(typeof(ProfileActivity));
				menu.AnimatedOpened = !menu.AnimatedOpened;
			};

			leftMenuSchoolInfo.Click += delegate {
				StartActivity(typeof(SchoolInfoActivity));
				menu.AnimatedOpened = !menu.AnimatedOpened;
			};

			leftMenuFeedback.Click += delegate {
				StartActivity(typeof(FeedbackActivity));
				menu.AnimatedOpened = !menu.AnimatedOpened;
			};

			leftMenuSettings.Click += delegate {
				StartActivity(typeof(SettingsActivity));
				menu.AnimatedOpened = !menu.AnimatedOpened;
			};

			genMsgListView = (ListView)FindViewById (Resource.Id.lvMMFOCGenInfo);
			privateMsgListView = (ListView)FindViewById (Resource.Id.lvMMFOCMessages);
			eventsListView = (ListView)FindViewById (Resource.Id.lvMMFOCEvents);

			RelativeLayout rlGeneralInfoBtn = (RelativeLayout)FindViewById (Resource.Id.rlMMFOCGenInfoBtn);
			RelativeLayout rlMessageBtn = (RelativeLayout)FindViewById (Resource.Id.rlMMFOCMessagesBtn);
			RelativeLayout rlEventsBtn = (RelativeLayout)FindViewById (Resource.Id.rlMMFOCEventsBtn);

			//Properties for GenMsg
			footerView = ((LayoutInflater)GetSystemService (Context.LayoutInflaterService)).Inflate (Resource.Layout.ReadMoreLayout, null, false);
			footerViewPM = ((LayoutInflater)GetSystemService (Context.LayoutInflaterService)).Inflate (Resource.Layout.ReadMorePMLayout, null, false);

			//Action to execute the codes
			processGeneralMsgListing(pageCountGM.ToString(),false);
			processMessageListing(limitStartPM.ToString(),limitEndPM.ToString(),false);
			processEventList();

			// General Info Load More Button and Actions
			Button btnReadMore = (Button)genMsgListView.FindViewById (Resource.Id.btnReadMore);

			btnReadMore.Click += (sender, e) =>  {

				pageCountGM++;
				processGeneralMsgListing(pageCountGM.ToString(),true);

			};

			Button btnReadMorePM = (Button)privateMsgListView.FindViewById (Resource.Id.btnReadMorePM);

			btnReadMorePM.Click += delegate {

				limitStartPM = limitStartPM + 10;
				limitEndPM = limitEndPM + 10;
				processMessageListing(limitStartPM.ToString(),limitEndPM.ToString(),true);

			};


			rlGeneralInfoBtn.Click += delegate {
				//Activity.StartActivity(typeof(FeedbackForm));
				rlGeneralInfoBtn.SetBackgroundResource(Resource.Color.schoolAppsBlue);
				rlMessageBtn.SetBackgroundResource(Resource.Color.gray);
				rlEventsBtn.SetBackgroundResource(Resource.Color.gray);

				//genMsgItemTableItemizeds.Clear();
				//genMsgItemID.Clear();

				//coding here
				genMsgListView.Visibility = ViewStates.Visible;
				privateMsgListView.Visibility = ViewStates.Invisible;
				eventsListView.Visibility = ViewStates.Invisible;

			};

			rlMessageBtn.Click += delegate {
				//Activity.StartActivity(typeof(FeedbackForm));
				rlGeneralInfoBtn.SetBackgroundResource(Resource.Color.gray);
				rlMessageBtn.SetBackgroundResource(Resource.Color.schoolAppsBlue);
				rlEventsBtn.SetBackgroundResource(Resource.Color.gray);

				//privateMsgTableItemizeds.Clear();

				//coding here

				genMsgListView.Visibility = ViewStates.Invisible;
				privateMsgListView.Visibility = ViewStates.Visible;
				eventsListView.Visibility = ViewStates.Invisible;



			};

			rlEventsBtn.Click += delegate {
				//Activity.StartActivity(typeof(FeedbackForm));
				rlGeneralInfoBtn.SetBackgroundResource(Resource.Color.gray);
				rlMessageBtn.SetBackgroundResource(Resource.Color.gray);
				rlEventsBtn.SetBackgroundResource(Resource.Color.schoolAppsBlue);

				//eventsTableItemizeds.Clear();

				//coding here


				genMsgListView.Visibility = ViewStates.Invisible;
				privateMsgListView.Visibility = ViewStates.Invisible;
				eventsListView.Visibility = ViewStates.Visible;

			};

			rlGeneralInfoBtn.PerformClick ();

			genMsgListView.ScrollStateChanged += (object sender, AbsListView.ScrollStateChangedEventArgs e) => {

				Console.WriteLine("Scrolling");

			};

		}
		public void clickedGenInfo(object sender, Android.Widget.AdapterView.ItemClickEventArgs e) {

			//var listView = sender as ListView;
			//var t = genMsgItemTableItemizeds [e.Position];
			//Toast.MakeText (Activity, string.Format("Clicked on position {0} with ID {1} ",e.Position,genMsgItemID[e.Position.ToString()]) , ToastLength.Short).Show();

			Intent genInfoIntent = new Intent(this, typeof(GenMsgContantDetails));
			genInfoIntent.PutExtra ("GenInfoID",genMsgItemID[e.Position.ToString()]);
			StartActivity (genInfoIntent);

		}

		public void clickedMsgPrivate(object sender, Android.Widget.AdapterView.ItemClickEventArgs e) {

			//var listView = sender as ListView;
			//var t = genMsgItemTableItemizeds [e.Position];
			//Toast.MakeText (Activity, string.Format("Clicked on position {0} with ID {1} ",e.Position,genMsgItemID[e.Position.ToString()]) , ToastLength.Short).Show();

			Intent privMsgIntent = new Intent(this, typeof(PrivMsgContentDetails));
			privMsgIntent.PutExtra ("MessageID",privateMsgID[e.Position.ToString()]);
			StartActivity (privMsgIntent);

		}

		public void clickedEventsInfo(object sender, Android.Widget.AdapterView.ItemClickEventArgs e) {

			//var listView = sender as ListView;
			//var t = genMsgItemTableItemizeds [e.Position];
			//Toast.MakeText (Activity, string.Format("Clicked on position {0} with ID {1} ",e.Position,eventsInfoID[e.Position.ToString()]) , ToastLength.Short).Show();

			Intent eventsInfoIntent = new Intent(this, typeof(EventsContentDetails));
			//eventsInfoIntent.PutExtra ("EventsPage",eventsInfoPage[e.Position.ToString()]);
			//eventsInfoIntent.PutExtra ("EventsDetailsData",eventsInfoData[e.Position.ToString()]);
			eventsInfoIntent.PutExtra ("EventsTitleData",eventsTitleBundle[e.Position.ToString()]);
			eventsInfoIntent.PutExtra ("EventsDetailsData",eventsDetailsBundle[e.Position.ToString()]);
			eventsInfoIntent.PutExtra ("EventsStartData",eventsStartBundle[e.Position.ToString()]);
			eventsInfoIntent.PutExtra ("EventsEndData",eventsEndBundle[e.Position.ToString()]);
			eventsInfoIntent.PutExtra ("EventsStatusData",eventsStatusBundle[e.Position.ToString()]);
			eventsInfoIntent.PutExtra ("EventsCreatedData",eventsCreatedBundle[e.Position.ToString()]);
			eventsInfoIntent.PutExtra ("EventsModifiedData",eventsModifiedBundle[e.Position.ToString()]);
			StartActivity (eventsInfoIntent);

		}

		public void processGeneralMsgListing(string page, bool notifyAdapter)
		{
			//TextView readMoreTxt = (TextView) generalMsgListView.FindViewById(Resource.Id.tvReadMore);

			Webservice wbsGenInfoData = new Webservice();

			var wbsGenInfoDataJSON = JsonConvert.DeserializeObject<Webservice.GMLRootObject> (wbsGenInfoData.getGeneralMsgListingData(page));

			foreach (var additionalInfo in wbsGenInfoDataJSON.paging) {

				pgCountLimit = additionalInfo.pageCount.ToString ();

			}

			foreach (var deserialized in wbsGenInfoDataJSON.data) {

				genMsgItemTableItemizeds.Add (new GeneralMsgItem () { SenderName = deserialized.creator.ToString(), BriefDesc = deserialized.text.ToString(), IconImageID = Resource.Drawable.facebookDP });


				if(deserialized.readmore == false)
				{
					//readMoreTxt.Visibility = ViewStates.Gone;
				}
				else
				{
					//readMoreTxt.Visibility = ViewStates.Visible;
				}

				genMsgItemID.Add(countListGM.ToString(),deserialized.id.ToString());
				countListGM++;
			}


			//Console.WriteLine("Readmore text visibility: "+readMoreTxt.Visibility);

			if (notifyAdapter == false) {
				genMsgListView.AddFooterView (footerView);
				genMsgAdapter = new GeneralMsgAdapter (this, genMsgItemTableItemizeds);
				genMsgListView.Adapter = genMsgAdapter;
				genMsgListView.ItemClick += clickedGenInfo;
			} else {
				if (page.ToString () == pgCountLimit.ToString ()) {
					genMsgListView.RemoveFooterView (footerView);
				}
				genMsgAdapter.NotifyDataSetChanged ();
			}

		}

		public void processMessageListing(string start, string end, bool notifyAdapter)
		{
			DatabaseAccess dbAccess = new DatabaseAccess();
			var jsonData = dbAccess.retrieveTheMessageOnDatabase (start,end);
			var daMessageFromDB = JsonConvert.DeserializeObject<Webservice.MessageRootObject>(jsonData);
			var daMsgCountFromDB = dbAccess.countMessageOnTableDB();

			Console.WriteLine ("JSON Not Converted: "+jsonData);
			Console.WriteLine ("JSON Converted: "+daMessageFromDB);
			Console.WriteLine ("DB Msg Contains "+daMsgCountFromDB+" records");

			foreach (var deserialized in daMessageFromDB.items) {

				Console.WriteLine("Msg Title: {0}, Msg Sender: {1}, Msg Sendtime: {2}, Msg ID: {3}, Msg Content: {4}, Msg Read: {5}",deserialized.msg_title.ToString(),deserialized.msg_sender.ToString(),deserialized.msg_sendtime.ToString(),deserialized.msg_id.ToString(),deserialized.msg_content.ToString(),deserialized.msg_read.ToString());
				privateMsgTableItemizeds.Add(new MessageItem () { BriefMsg = deserialized.msg_title.ToString() , SenderName = deserialized.msg_sender.ToString() , SendDateTime = deserialized.msg_sendtime.ToString() });

				privateMsgID.Add (countListPM.ToString(),deserialized.msg_id.ToString());
				countListPM++;
			}

			if (notifyAdapter == false) {
				privateMsgListView.AddFooterView (footerViewPM);
				msgAdapter = new MessageAdapter (this, privateMsgTableItemizeds);
				privateMsgListView.Adapter = msgAdapter;
				privateMsgListView.ItemClick += clickedMsgPrivate;
			} else {
				msgAdapter.NotifyDataSetChanged ();
			}

		}

		public void processEventList()
		{
			Webservice wbsInfoData = new Webservice();

			try
			{
				int count = 0;

				for (int i = 1; i < 10; i++)
				{
					var wbsEventDataJSON = wbsInfoData.getEventsInfo(i.ToString());
					Console.WriteLine("Serialized Events Data: Title = {0}",wbsEventDataJSON);
					var wbsEventsDataDeserializedJSON = JsonConvert.DeserializeObject<Webservice.GEIRootObject>(wbsEventDataJSON);

					foreach (var deserialized in wbsEventsDataDeserializedJSON.Event) {

						Console.WriteLine("Deserialized Events Data: Title = {0}",deserialized.title.ToString());

						eventsTableItemizeds.Add(new EventsItem () { EventsTitle = deserialized.title.ToString(), EventsDateTime = deserialized.start.ToString()/*, IconImageID = */ });
						//string eventsPassValue = " {\"title\":\""+deserialized.title.ToString()+"\",\"details\":\""+deserialized.details.ToString()+"\",\"start\":\""+deserialized.start.ToString()+"\",\"end\":\""+deserialized.end.ToString()+"\",\"all_day\":\""+deserialized.all_day.ToString()+"\",\"status\":\""+deserialized.status.ToString()+"\",\"active\":\""+deserialized.active.ToString()+"\",\"created\":\""+deserialized.created.ToString()+"\",\"modified\":\""+deserialized.modified.ToString()+"\"} ";
						//string eventsPassValue = wbsInfoData.getEventsInfo(i.ToString());
						//eventsInfoData.Add (count.ToString(), eventsPassValue);
						eventsTitleBundle.Add(count.ToString(),deserialized.title.ToString());
						eventsDetailsBundle.Add(count.ToString(),deserialized.details.ToString());
						eventsStartBundle.Add(count.ToString(),deserialized.start.ToString());
						eventsEndBundle.Add(count.ToString(),deserialized.end.ToString());
						eventsStatusBundle.Add(count.ToString(),deserialized.status.ToString());
						eventsCreatedBundle.Add(count.ToString(),deserialized.created.ToString());
						eventsModifiedBundle.Add(count.ToString(),deserialized.modified.ToString());
					}
					count++;
				}

			}
			catch (Exception e)
			{
				Console.WriteLine("Failed Exception MainFragment Line 134: {0}",e);
			}

			eventsListView.Adapter = new EventsAdapter (this, eventsTableItemizeds);
			eventsListView.ItemClick += clickedEventsInfo;
		}
	}
}


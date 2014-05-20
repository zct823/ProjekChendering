using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
	[Activity (Label = "EntranceToMain", Theme = "@style/Theme.HoloLight.RemovedTitle")]			
	public class EntranceToMain : Activity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Create your application here
			SetContentView (Resource.Layout.EntranceLoadingIndicator);

			Java.Lang.Thread t = new Java.Lang.Thread (delegate {
				setMessagesToDatabase ();
			});

			t.Start ();

		}

		private void setMessagesToDatabase()
		{
			ISharedPreferences preferences = GetSharedPreferences ("SchoolApps",FileCreationMode.Private);
			DatabaseAccess dbAccess = new DatabaseAccess();
			Webservice wbsGenInfoData = new Webservice();
			preferences = Application.Context.GetSharedPreferences ("SchoolApps", FileCreationMode.Private);

			dbAccess.SettingUpDataAccessForMsg();

			try
			{
				for (int i = 0; i <= 999999; i++)
				{
					var wbsGenInfoDataJSON = JsonConvert.DeserializeObject<Webservice.GMVNRootObject> (wbsGenInfoData.getMessagesViaNetwork(i.ToString(),preferences.GetString("username",null)));

					foreach (var deserialized in wbsGenInfoDataJSON.data) {

						string readed;

						if (deserialized.mread == false)
						{
							readed = "0";
						}
						else
						{
							readed = "1";
						}

						dbAccess.storeTheMessageOnDatabase (deserialized.id.ToString(), deserialized.title.ToString(), deserialized.content.ToString(), deserialized.sendtime.ToString(), deserialized.Sender.name.ToString(), readed);

						Console.WriteLine("Outputted raw from webservice: ID: "+deserialized.id+" TITLE: "+deserialized.title+" Content: "+deserialized.content+" Sendtime: "+deserialized.sendtime+" Sender: "+deserialized.Sender.name.ToString()+" Readed: "+readed);

					}
				}
			}
			catch (Exception e)
			{
				Console.WriteLine("Message ended with expected exception: "+e);
			}


			if (Android.OS.Build.VERSION.SdkInt >= Android.OS.BuildVersionCodes.IceCreamSandwich) {
				StartActivity (typeof(MainMenuDrawer));
			} else {
				StartActivity (typeof(MainMenu));
			}
			this.Finish ();
		}
	}
}


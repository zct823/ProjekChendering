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
	[Activity (Label = "Settings", Theme = "@style/Theme.Schoolapp")]			
	public class SettingsActivity : Activity
	{
		List<SettingsItem> settingsItemizeds = new List<SettingsItem> ();
		ListView settingsItemsListView; 

		ISharedPreferences preferences;
		ISharedPreferencesEditor prefedit;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Create your application here
			SetContentView (Resource.Layout.SettingsLayout);

			preferences = GetSharedPreferences ("SchoolApps",FileCreationMode.Private);
			prefedit = preferences.Edit ();

			settingsItemsListView = (ListView)FindViewById (Resource.Id.lvSettingsLayoutStandalone);

			settingsItemizeds.Add (new SettingsItem () { SettingsName = "Logout", SettingsIconID = Resource.Drawable.u39_normal });
			settingsItemizeds.Add (new SettingsItem () { SettingsName = "Reset Password", SettingsIconID = Resource.Drawable.u39_normal });

			settingsItemsListView.Adapter = new SettingsAdapter (this, settingsItemizeds);

			settingsItemsListView.ItemClick += clickedMessage;

		}

		public void clickedMessage(object sender, Android.Widget.AdapterView.ItemClickEventArgs e) {

			//var listView = sender as ListView;
			var t = settingsItemizeds [e.Position];
			//Toast.MakeText (Activity, "Clicked on position " + e.Position + " with t is " + t.SettingsName.ToString(), ToastLength.Short).Show();
			switch (t.SettingsName.ToString ()) {
			case "Logout":
				AlertDialog.Builder adb = new AlertDialog.Builder (this);
				Dialog ad = null;

				adb.SetTitle ("Logout");
				adb.SetMessage ("Are you sure want to logout?");
				adb.SetNegativeButton ("No", delegate {
					ad.Cancel ();
				});
				adb.SetPositiveButton ("Yes", delegate {
					prefedit.Clear();
					prefedit.Commit();
					StartActivity(typeof(MainActivity));
					this.Finish();
				});

				ad = adb.Create ();
				ad.Show ();

				break;

			case "Reset Password":
				processResetPassword ();
				break;

			default:
				break;
			}

		}
			
		private void processResetPassword ()
		{
			StartActivity (typeof(SettingsResetPassActivity));
		}

	}
}


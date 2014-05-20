using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using System.Threading;

namespace SchoolApps
{
	public class SettingsFragment : Fragment
	{
		List<SettingsItem> settingsItemizeds = new List<SettingsItem> ();
		ListView settingsItemsListView; 

		View rootView;

		ISharedPreferences preferences;
		ISharedPreferencesEditor prefedit;

		public override View OnCreateView(LayoutInflater layoutInflater, ViewGroup viewGroup, Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);

			// Create your fragment here

			preferences = Activity.GetSharedPreferences ("SchoolApps",FileCreationMode.Private);
			prefedit = preferences.Edit ();

			rootView = layoutInflater.Inflate (Resource.Layout.SettingsLayout, viewGroup, false);

			settingsItemsListView = (ListView) rootView.FindViewById (Resource.Id.lvSettingsLayoutStandalone);

			settingsItemizeds.Add (new SettingsItem () { SettingsName = "Logout", SettingsIconID = Resource.Drawable.u39_normal });
			settingsItemizeds.Add (new SettingsItem () { SettingsName = "Reset Password", SettingsIconID = Resource.Drawable.u39_normal });

			settingsItemsListView.Adapter = new SettingsAdapter (Activity, settingsItemizeds);

			settingsItemsListView.ItemClick += clickedMessage;

			return rootView;
		}

		public void clickedMessage(object sender, Android.Widget.AdapterView.ItemClickEventArgs e) {

			//var listView = sender as ListView;
			var t = settingsItemizeds [e.Position];
			Toast.MakeText (Activity, "Clicked on position " + e.Position + " with t is " + t.SettingsName.ToString(), ToastLength.Short).Show();
			switch (t.SettingsName.ToString ()) {
			case "Logout":
				AlertDialog.Builder adb = new AlertDialog.Builder (Activity);
				Dialog ad = null;

				adb.SetTitle ("Logout");
				adb.SetMessage ("Are you sure want to logout?");
				adb.SetNegativeButton ("No", delegate {
					ad.Cancel ();
				});
				adb.SetPositiveButton ("Yes", delegate {
					prefedit.Clear();
					prefedit.Commit();
					Activity.StartActivity(typeof(MainActivity));
					Activity.Finish();
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
			Activity.StartActivity (typeof(SettingsResetPassActivity));
		}
	}
}


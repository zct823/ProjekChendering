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
	[Activity (Label = "Compose Message", Theme = "@style/Theme.Schoolapp")]			
	public class ComposeMsgActivity : Activity
	{
		EditText etToAddressee;
		EditText etSubject;
		EditText etContent;
		//string addresseeNames = "";

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Create your application here
			SetContentView (Resource.Layout.ComposeMsgLayout);

			Button btnAddAddress = FindViewById<Button> (Resource.Id.btnAddAddressCML);
			etToAddressee = FindViewById<EditText> (Resource.Id.etComposeMsgLayoutTo);
			etSubject = FindViewById<EditText> (Resource.Id.etComposeMsgLayoutSubject);
			etContent = FindViewById<EditText> (Resource.Id.etComposeMsgLayoutContent);

			Intent cmaIntent = new Intent (this, typeof(ComposeMsgAddressee));

			btnAddAddress.Click += delegate {

				StartActivityForResult(cmaIntent,0);

			};

		}
			
		protected override void OnActivityResult(int requestCode, Result resultCode, Intent intentData)
		{
			base.OnActivityResult (requestCode, resultCode, intentData);
			if (resultCode == Result.Ok) {
				etToAddressee.Text = intentData.GetStringExtra("addresseeStrExt");
			}
		}

		public override bool OnCreateOptionsMenu(IMenu menu)
		{
			//MenuInflater.Inflate(Resource.Menu.main, menu);
			IMenuItem createItem = menu.Add ("Send");
			createItem.SetShowAsAction (ShowAsAction.IfRoom);
			createItem.SetOnMenuItemClickListener (new MMDDelegatedMenuItemListener (OnAppearingMessage));
			return base.OnCreateOptionsMenu(menu);
		}

		private bool OnAppearingMessage(IMenuItem menuItem)
		{
			this.Finish ();

			return true;
		}

	}
}


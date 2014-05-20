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
using Newtonsoft.Json;

namespace SchoolApps
{
	[Activity (Label = "Select the Receiver")]			
	public class ComposeMsgAddressee : Activity
	{
		List<ComposeMsgAddresseeItems> composeMsgAddItems = new List<ComposeMsgAddresseeItems> ();
		ListView composeMsgAddListView;
		string Pbt_Name_selected = "";
		string Pbt_ID_selected = "";

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Create your application here
			SetContentView (Resource.Layout.ComposeMsgAddresseeListView);

			composeMsgAddListView = FindViewById<ListView> (Resource.Id.lvComposeMsgAddresseeLV);


			string jsonView = "{\"data\":[{\"id\":\"2\",\"classname\":\"1 Mercury\"},{\"id\":\"4\",\"classname\":\"2 Venus\"},{\"id\":\"6\",\"classname\":\"3 Jupiter\"}]}";

			Console.WriteLine (jsonView);

			var addresseeData = JsonConvert.DeserializeObject<GARootObject> (jsonView);
			var schoolNameList = new List<string> ();

			foreach (var deserialized in addresseeData.data) {

				composeMsgAddItems.Add (new ComposeMsgAddresseeItems () { addresseeID = deserialized.id, addresseeName = deserialized.classname });
				schoolNameList.Add (deserialized.classname);
			}

			composeMsgAddListView.Adapter = new ArrayAdapter (this, Android.Resource.Layout.SimpleListItemMultipleChoice, schoolNameList);
			composeMsgAddListView.ChoiceMode = ChoiceMode.Multiple;

			Button btnDone = FindViewById<Button> (Resource.Id.btnComposeMsgAddresseeLVOK);

			btnDone.Click += delegate {

				var PBT_selected = new List<string>();
				var ID_PBT_selected = new List<string>();
			
				var sparseArray = FindViewById<ListView> (Resource.Id.lvComposeMsgAddresseeLV).CheckedItemPositions;
				var addresserListView = FindViewById<ListView> (Resource.Id.lvComposeMsgAddresseeLV);

				for (int i = 0; i < sparseArray.Size(); i++)
				{
					string selectedValue = string.Empty;
					string ID_selected = string.Empty;

					int position = sparseArray.KeyAt(i);
					if (sparseArray.ValueAt (i) == true) 
					{
						selectedValue = addresserListView.GetItemAtPosition (position).ToString ();
						ID_selected = composeMsgAddItems[position].addresseeID;
						//groups.Remove (groups [position]);
						//Android.Widget.Toast.MakeText(this,"Subscribed for "+selectedValue, Android.Widget.ToastLength.Short).Show();
						//searchGroupAdapter.NotifyDataSetChanged ();

						PBT_selected.Add(selectedValue);
						ID_PBT_selected.Add(ID_selected);


					}

				}

				Pbt_Name_selected = String.Join(" , ", PBT_selected);
				Pbt_ID_selected = String.Join(" , ", ID_PBT_selected);

				Intent intentToSend = new Intent();
				intentToSend.PutExtra("addresseeStrExt",Pbt_Name_selected.ToString());
				SetResult(Result.Ok,intentToSend);
				this.Finish();
			};

		}


	}

	public class Datum
	{
		public string id { get; set; }
		public string classname { get; set; }
	}

	public class GARootObject
	{
		public List<Datum> data { get; set; }
	}
}


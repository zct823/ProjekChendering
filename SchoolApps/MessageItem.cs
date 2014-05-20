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
	public class MessageItem
	{
		public string BriefMsg { get; set; }
		public string SenderName { get; set; }
		public string SendDateTime { get; set; }
		public int IconImageID { get; set; }
	}
}


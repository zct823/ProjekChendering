using System;
using System.Net;
using System.Collections.Generic;
using System.Collections.Specialized;
using SchoolApps.GTKCoreLib;
using Newtonsoft.Json;

namespace SchoolApps.GTKCoreLib
{
	public class Webservice
	{
		public Webservice ()
		{
		}

		// GET LOGIN DATA, RETURN AS DESERIALIZED DATA
		public string getLoginData(string username, string password, string deviceTokenID)
		{

			//Constant constants = new Constant ();
			string mainURL = "http://1mtris.ingeniworks.com.my/schoolapps/"; 
			string OS = "and";
			string schoolAppsID = "1";

			string URL = mainURL+"/users/register/";
			string param = username+"/"+password+"/"+schoolAppsID+"/"+deviceTokenID+"/"+OS;
			WebClient wbc;
			var jsonWbc = "";

			using (wbc = new WebClient ()) 
			{
				wbc.Headers.Add ("Content-Type", "application/json");
				jsonWbc = wbc.UploadString (URL+param,"");
			}

			var getStatus = JsonConvert.DeserializeObject<LoginDataRootObject> (jsonWbc);
			string status = "";

			foreach (var deserializer in getStatus.msg) {

				status = deserializer.success.ToString ();

			}

			return status;
		}

		public class Msg
		{
			public int success { get; set; }
			public string message { get; set; }
		}

		public class LoginDataRootObject
		{
			public List<Msg> msg { get; set; }
		}

		// GET GENERAL MESSAGE LISTING DATA, RETURN AS JSON
		public string getGeneralMsgListingData(string requestPage)
		{
			string mainURL = "http://1mtris.ingeniworks.com.my/schoolapps/"; 

			string URL = mainURL+"/walls/json_wall/";
			string param = "page:"+requestPage;

			WebClient wbc;
			string jsonWbc = "";

			using (wbc = new WebClient ()) 
			{
				wbc.Headers.Add ("Content-Type", "application/json");
				jsonWbc = wbc.UploadString (URL+param,"");
			}

			return jsonWbc;
		}

		public class Datum
		{
			public string id { get; set; }
			public string text { get; set; }
			public bool readmore { get; set; }
			public string created { get; set; }
			public string creator { get; set; }
		}

		public class Paging
		{
			public int page { get; set; }
			public int current { get; set; }
			public int count { get; set; }
			public bool prevPage { get; set; }
			public bool nextPage { get; set; }
			public int pageCount { get; set; }
		}

		public class GMLRootObject
		{
			public List<Datum> data { get; set; }
			public List<Paging> paging { get; set; }
		}


		// SET WEBSERVICE FOR MESSAGES, RETURN AS JSON
		public string getMessagesViaNetwork (string requestPage, string forUser)
		{
			string mainURL = "http://1mtris.ingeniworks.com.my/schoolapps";
			string URL = mainURL+"/messages/json_messagelist/1/"+forUser+"/";
			string param = "page:"+requestPage;

			WebClient wbc;
			string jsonWbc = "";

			using (wbc = new WebClient ()) 
			{
				wbc.Headers.Add ("Content-Type", "application/json");
				jsonWbc = wbc.UploadString (URL+param,"");

				Console.WriteLine ("jsonwbc: {0}",jsonWbc);
			}

			//DatabaseAccess dbaMsg = new DatabaseAccess ();

			//dbaMsg.SettingUpDataAccessForMsg ();
			return jsonWbc;
		}
		/*
		public class Sender
		{
			public string name { get; set; }
		}

		public class MessagesMsg
		{
			public string id { get; set; }
			public string title { get; set; }
			public string content { get; set; }
			public string sendtime { get; set; }
			public Sender Sender { get; set; }
			public bool mread { get; set; }
		}

		public class GMVNRootObject
		{
			public List<MessagesMsg> msg { get; set; }
		}
		*/
		public class Sender
		{
			public string name { get; set; }
		}

		public class GMVNDatum
		{
			public string id { get; set; }
			public string title { get; set; }
			public string content { get; set; }
			public string sendtime { get; set; }
			public Sender Sender { get; set; }
			public bool mread { get; set; }
		}
			
		public class GMVNPaging
		{
			public int page { get; set; }
			public int current { get; set; }
			public int count { get; set; }
			public bool prevPage { get; set; }
			public bool nextPage { get; set; }
			public int pageCount { get; set; }
			public int limit { get; set; }
			public List<object> options { get; set; }
			public string paramType { get; set; }
		}

		public class GMVNRootObject
		{
			public List<GMVNDatum> data { get; set; }
			public List<GMVNPaging> paging { get; set; }
		}

		//part
		public class MessageItem
		{
			public string msg_id { get; set; }
			public string msg_title { get; set; }
			public string msg_content { get; set; }
			public string msg_sendtime { get; set; }
			public string msg_sender { get; set; }
			public string msg_read { get; set; }
		}

		public class MessageRootObject
		{
			public List<MessageItem> items { get; set; }
		}


		//SET EVENTS, RETURN AS JSON
		public string getEventsInfo(string Paging)
		{
			string mainURL = "http://1mtris.ingeniworks.com.my/schoolapps/"; 

			string URL = mainURL+"/full_calendar/events/";
			string param = "viewjson/"+Paging;

			WebClient wbc;
			string jsonWbc = "";

			using (wbc = new WebClient ()) 
			{
				wbc.Headers.Add ("Content-Type", "application/json");
				jsonWbc = wbc.UploadString (URL+param,"");
			}

			return jsonWbc;
		}

		public class Event
		{
			public string id { get; set; }
			public string event_type_id { get; set; }
			public string title { get; set; }
			public string details { get; set; }
			public string start { get; set; }
			public string end { get; set; }
			public bool all_day { get; set; }
			public string status { get; set; }
			public bool active { get; set; }
			public string created { get; set; }
			public string modified { get; set; }
		}

		public class GEIRootObject
		{
			public List<Event> Event { get; set; }
		}

		//GET General Info Content Details, return in JSON

		public string getGeneralInfoContentDetails(string ID)
		{
			string mainURL = "http://1mtris.ingeniworks.com.my/schoolapps/"; 

			string URL = mainURL+"/walls/json_readmore/";
			string param = ""+ID;

			WebClient wbc;
			string jsonWbc = "";

			using (wbc = new WebClient ()) 
			{
				wbc.Headers.Add ("Content-Type", "application/json");
				jsonWbc = wbc.UploadString (URL+param,"");
			}

			return jsonWbc;
		}

		public class GGICDRootObject
		{
			public string text { get; set; }
			public string created { get; set; }
		}

		//GET PRIVATE MSG
		/*
		public string getPrivateMsgContentDetails(string ID)
		{
			//Retrieval via Database. DatabaseAccess.cs.
		}
		*/

		//GET LOGIN REGISTRATION
		public string getRegistrationMsg(string nric, string email, string password, string schoolID)
		{
			string URL = "http://1mtris.ingeniworks.com.my/schoolapps/";

			string URI = string.Format("{0}/users/verify/",URL);
			string param = string.Format("{0}/{1}/{2}/{3}",nric,email,password,schoolID);

			WebClient wbc;
			string jsonWbc = "";

			using (wbc = new WebClient ()) 
			{
				wbc.Headers.Add ("Content-Type", "application/json");
				jsonWbc = wbc.UploadString (string.Format("{0}{1}",URI,param),"");
			}

			return jsonWbc;
		}

		//GET RESET PASSWORD
		public string getResetPassReg(string email, string password, string schoolID)
		{
			string URL = "http://1mtris.ingeniworks.com.my/schoolapps/";

			string URI = string.Format("{0}/users/resetpassword/",URL);
			string param = string.Format("{0}/{1}/{2}",email,password,schoolID);

			WebClient wbc;
			string jsonWbc = "";

			using (wbc = new WebClient ()) 
			{
				wbc.Headers.Add ("Content-Type", "application/json");
				jsonWbc = wbc.UploadString (string.Format("{0}{1}",URI,param),"");
			}

			return jsonWbc;
		}

		public class RegMsg
		{
			public int success { get; set; }
			public string message { get; set; }
		}

		public class GRMRootObject
		{
			public List<RegMsg> msg { get; set; }
		}

	}
}


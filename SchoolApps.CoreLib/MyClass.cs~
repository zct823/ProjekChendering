using System;
using System.Net.Http;
using System.Diagnostics;
using System.Collections.Generic;
using System.Collections.Specialized;
using Newtonsoft.Json;

namespace SchoolApps.CoreLib
{
	public class MyClass
	{
		public MyClass ()
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
			HttpClient wbc = new HttpClient ();
			wbc.BaseAddress  = new Uri (URL + param.ToString());
			wbc.DefaultRequestHeaders.Accept.Add (new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue ("application/json"));
			HttpRequestMessage hrm = new HttpRequestMessage (HttpMethod.Get,"relativeAddress") ;
			var jsonWbc = "";

			wbc.SendAsync(hrm).ContinueWith(delegate(System.Threading.Tasks.Task<HttpResponseMessage> arg) {

				jsonWbc = arg.Result.ToString();
				Debug.WriteLine("Null:"+jsonWbc);
			}); 

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

	}
}


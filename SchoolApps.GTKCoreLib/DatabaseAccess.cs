using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using Mono.Data.Sqlite;
using System.Data;
using Newtonsoft.Json;

namespace SchoolApps.GTKCoreLib
{
	public class DatabaseAccess
	{
		public DatabaseAccess ()
		{
		}
			


		public string SettingUpDataAccessForMsg()
		{
			//string dbPath = Path.Combine (Environment.GetFolderPath (Environment.SpecialFolder.Personal), "schoolAppsDB.db3");
			SqliteConnection dbCon;
			string dbPath = Path.Combine (Environment.GetFolderPath (Environment.SpecialFolder.Personal), "schoolAppsDB_test.db3");

			bool exists = File.Exists (dbPath);

			Console.WriteLine ("SQLiteDB [Checking Database Status]: Checking database, exist or not...");
			if (exists == false) {

				Console.WriteLine ("SQLiteDB [Checking Database Status]: Checking database completed. No database exists. Creating a new database...");
				SqliteConnection.CreateFile (dbPath);
				Console.WriteLine ("SQLiteDB [Checking Database Status]: Creating a new database completed.");

			} else {

				Console.WriteLine ("SQLiteDB [Checking Database Status]: Checking database completed. Database exists.");
			}

			Console.WriteLine ("SQLiteDB [Checking Table Status]: Connecting Database...");
			dbCon = new SqliteConnection ("Data Source = " + dbPath);

			Console.WriteLine ("SQLiteDB [Checking Table Status]: Opening Database...");
			dbCon.Open ();
			//dbCon.BeginTransaction ();

			Console.WriteLine ("SQLiteDB [Checking Table Status]: Preparing SQLite Command...");
			var dbConCommand = dbCon.CreateCommand ();

			//dbConCommand.CommandText = "DROP TABLE IF EXISTS [SCA_Message];";
			//var presldr = dbConCommand.ExecuteNonQuery ();
			//Console.WriteLine ("SQLiteDB [Checking Table Status(DEBUG ONLY)]: Deleting table (skipped if exists) is ended with result "+presldr);

			Console.WriteLine ("SQLiteDB [Checking Table Status]: Creating table (skipped if exists)...");
			dbConCommand.CommandText = "CREATE TABLE IF NOT EXISTS [SCA_Messages](id INTEGER PRIMARY KEY AUTOINCREMENT, message_id INTEGER, sender VARCHAR(100), title VARCHAR(100), type INTEGER, body TEXT, sendtime DATETIME, timestamp DATETIME, read INTEGER);";

			var sldr = dbConCommand.ExecuteNonQuery ();

			if (sldr == 0) {
				Console.WriteLine ("SQLiteDB [Checking Table Status]: Table is existed. Result is " + sldr);
			} else {
				Console.WriteLine ("SQLiteDB [Checking Table Status]: Table is not existed and has been created. Result is " + sldr);
			}

			/*
			Console.WriteLine ("SQLiteDB [Checking Table Status]: Testing insert new data...");
			dbConCommand = dbCon.CreateCommand ();
			dbConCommand.CommandText = "INSERT INTO [SCA_Messages] (message_id, sender, title, type, body, sendtime, timestamp, read) VALUES ('123','mysender','mytitle','1','mybody','2010-03-03 14:00:14','2010-03-03 14:00:14','1');";

			var sldr2 = dbConCommand.ExecuteNonQuery ();

			Console.WriteLine ("SQLiteDB [Checking Table Status]: Data inserted with result "+sldr2+". Testing to call the data");
			dbConCommand = dbCon.CreateCommand ();
			dbConCommand.CommandText = "SELECT [message_id], [body] FROM [SCA_Messages];";

			var sldr3 = dbConCommand.ExecuteReader ();

			while (sldr3.Read ()) {
				Console.WriteLine ("SQLiteDB [Checking Table Status]: SLDR.READ passed with result "+sldr3.Read());
				Console.WriteLine (string.Format("\n\tSQLiteDB [Checking Table Status]: Test Data output: message id is {0}, body is {1} ",sldr3["message_id"].ToString(),sldr3["body"].ToString()));
			}
			*/

			dbCon.Close ();
			//Console.WriteLine ("SQLiteDB: "+sldr.Read());

			return "DB creation completed";
		}

		public void storeTheMessageOnDatabase(string message_ID, string message_title, string message_content, string message_sendtime, string message_sender, string message_read)
		{
			SqliteConnection dbCon;
			string dbPath = Path.Combine (Environment.GetFolderPath (Environment.SpecialFolder.Personal), "schoolAppsDB_test.db3");

			Console.WriteLine ("SQLiteDB [Inserting Data to Message Table Status]: Connecting Database...");
			dbCon = new SqliteConnection ("Data Source = " + dbPath);

			Console.WriteLine ("SQLiteDB [Inserting Data to Message Table Status]: Opening Database...");
			dbCon.Open ();

			var dbConCommand = dbCon.CreateCommand ();

			string titleFormat = message_title.Replace ("'", "''");
			string bodyFormat = message_content.Replace ("'", "''");

			dbConCommand.CommandText = "INSERT INTO [SCA_Messages] ([message_id],[sender],[title],[type],[body],[sendtime],[timestamp],[read]) " +
				"VALUES ("+"'"+message_ID+"'"+","+"'"+message_sender+"'"+","+"'"+titleFormat+"'"+",'',"+"'"+bodyFormat+"'"+","+"'"+message_sendtime+"'"+",'',"+"'"+message_read+"'"+"); ";

			//dbConCommand.CommandText = 'INSERT INTO [SCA_Messages] ([message_id],[sender],[title],[type],[body],[sendtime],[timestamp],[read]) VALUES ("'+message_ID+'","'+message_sender+'","'+message_title+'","","'+message_content+'","'+message_sendtime+'",'',"'+message_read+'"); ';

			Console.WriteLine ("SQLiteDB [Inserting Data to Message Table Status]: Command check "+dbConCommand.CommandText);
			var sldr = dbConCommand.ExecuteNonQuery ();


			if (sldr == 0) {

				Console.WriteLine ("SQLiteDB [Inserting Data to Message Table Status]: Inserting data for message ID "+message_ID+" and sender "+message_sender+" is failed.");

			} else {

				Console.WriteLine ("SQLiteDB [Inserting Data to Message Table Status]: Inserting data for message ID "+message_ID+" and sender "+message_sender+" is success.");

			}

			Console.WriteLine ("SQLiteDB [Inserting Data to Message Table Status]: Closing Database...");
			dbCon.Close ();

		}

		// RETRIEVE MESSAGE BRIEF DATA TO DISPLAY ON LIST
		public string retrieveTheMessageOnDatabase(string start, string end)
		{
			SqliteConnection dbCon;
			string dbPath = Path.Combine (Environment.GetFolderPath (Environment.SpecialFolder.Personal), "schoolAppsDB_test.db3");

			messagesListing arrayStr = new messagesListing();
			arrayStr.items = new List<Items> ();

			Console.WriteLine ("SQLiteDB [Reading Data in Message Table Status]: Connecting Database...");
			dbCon = new SqliteConnection ("Data Source = " + dbPath);

			Console.WriteLine ("SQLiteDB [Reading Data in Message Table Status]: Opening Database...");
			dbCon.Open ();

			var dbConCommand = dbCon.CreateCommand ();

			Console.WriteLine ("SQLiteDB [Reading Data in Message Table Status]: Executing select query from message table...");
			//string dbQuery  = string.Format("SELECT * FROM [SCA_Messages] WHERE id BETWEEN {0} AND {1}; ",start.ToString(),end.ToString());
			string dbQuery  = string.Format("SELECT * FROM [SCA_Messages] WHERE id >= {0} AND id <= {1} ; ",start.ToString(),end.ToString());
			dbConCommand.CommandText = dbQuery;
			Console.WriteLine ("SQLiteDB [Reading Data in Message Table Status]: Query commanded is {0}",dbQuery);
			//dbConCommand.CommandText = string.Format("SELECT * FROM [SCA_Messages] LIMIT 11, 20; ");
			var sldr = dbConCommand.ExecuteReader ();

			Console.WriteLine ("SQLiteDB [Reading Data in Message Table Status]: Retrieving data...");

			while (sldr.Read ()) {

				Console.WriteLine ("ID: {0}, Message: {1}",sldr["message_id"].ToString(),sldr["body"].ToString());
				try {
					arrayStr.items.Add (new Items { msg_id = sldr["message_id"].ToString(), msg_title = sldr["title"].ToString(), msg_content = sldr["body"].ToString(), msg_sendtime = sldr["sendtime"].ToString(), msg_sender = sldr["sender"].ToString(), msg_read = "" });
				}
				catch (Exception e) {
					Console.WriteLine ("Error exception DatabaseAccess at line 157: {0}",e);
				}
			}

			sldr.Close ();
			dbCon.Close ();

			string jsonSerialObj = JsonConvert.SerializeObject (arrayStr).ToString ();
			arrayStr.items.Clear ();

			return jsonSerialObj;
		}

		public string jsonConvertTry()
		{
			var arrayStr = new messagesListing();
			arrayStr.items = new List<Items> ();

			for (int i = 0; i < 2; i++) {

				//arrayStr.items.Add (new Items { msg_id = i.ToString (), msg_name = "22", msg_address = "33" });

			}

			return JsonConvert.SerializeObject (arrayStr).ToString ();
		}

		public class messagesListing
		{
			public List<Items> items { get; set; }
		}

		public class Items
		{
			public string msg_id { get; set; }
			public string msg_title { get; set; }
			public string msg_content { get; set; }
			public string msg_sendtime { get; set; }
			public string msg_sender { get; set; }
			public string msg_read { get; set; }
			//public string msg_name { get; set; }
			//public string msg_address { get; set; }
		}

		public string countMessageOnTableDB()
		{
			SqliteConnection dbCon;
			string dbPath = Path.Combine (Environment.GetFolderPath (Environment.SpecialFolder.Personal), "schoolAppsDB_test.db3");
			dbCon = new SqliteConnection ("Data Source = " + dbPath);
			dbCon.Open ();
			var dbConCommand = dbCon.CreateCommand ();
			dbConCommand.CommandText = "SELECT COUNT(*) FROM [SCA_Messages]; ";
			var sldr = dbConCommand.ExecuteScalar ();

			return sldr.ToString();
		}

		// RETRIEVING CONTENT DATA FOR EACH MESSAGE
		public string retrieveDBMessageContent(string Message_ID)
		{
			SqliteConnection dbCon;
			string dbPath = Path.Combine (Environment.GetFolderPath (Environment.SpecialFolder.Personal), "schoolAppsDB_test.db3");

			var arrayStr = new messagesListing();
			arrayStr.items = new List<Items> ();

			Console.WriteLine ("SQLiteDB [Reading Data in Message Table Status]: Connecting Database...");
			dbCon = new SqliteConnection ("Data Source = " + dbPath);

			Console.WriteLine ("SQLiteDB [Reading Data in Message Table Status]: Opening Database...");
			dbCon.Open ();

			var dbConCommand = dbCon.CreateCommand ();

			Console.WriteLine ("SQLiteDB [Reading Data in Message Table Status]: Executing select query from message table...");
			dbConCommand.CommandText = string.Format("SELECT * FROM [SCA_Messages] WHERE [message_id] = '{0}';",Message_ID.ToString());
			var sldr = dbConCommand.ExecuteReader ();

			Console.WriteLine ("SQLiteDB [Reading Data in Message Table Status]: Retrieving data...");
			while (sldr.Read ()) {
				Console.WriteLine ("ID: {0}, Message: {1}",sldr["message_id"].ToString(),sldr["body"].ToString());
				try {
					arrayStr.items.Add (new Items { msg_id = sldr["message_id"].ToString(), msg_title = sldr["title"].ToString(), msg_content = sldr["body"].ToString(), msg_sendtime = sldr["sendtime"].ToString(), msg_sender = sldr["sender"].ToString(), msg_read = "" });
				}
				catch (Exception e) {
					Console.WriteLine ("Error exception DatabaseAccess at line 157: {0}",e);
				}
			}
			return JsonConvert.SerializeObject (arrayStr).ToString ();
		}

		public class Item
		{
			public string msg_id { get; set; }
			public string msg_title { get; set; }
			public string msg_content { get; set; }
			public string msg_sendtime { get; set; }
			public string msg_sender { get; set; }
			public string msg_read { get; set; }
		}

		public class RDBMCRootObject
		{
			public List<Item> items { get; set; }
		}

	}
}


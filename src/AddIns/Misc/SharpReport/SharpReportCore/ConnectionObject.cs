//------------------------------------------------------------------------------
// <autogenerated>
//     This code was generated by a tool.
//     Runtime Version: 1.1.4322.2032
//
//     Changes to this file may cause incorrect behavior and will be lost if 
//     the code is regenerated.
// </autogenerated>
//------------------------------------------------------------------------------
using System;
using System.Data;	
using System.Data.OleDb;

/// <summary>
/// This class handles the connection to a DataBase 
/// </summary>
/// <remarks>
/// 	created by - Forstmeier Peter
/// 	created on - 17.10.2005 22:59:39
/// </remarks>

namespace SharpReportCore {
	public class ConnectionObject : object,IDisposable {
		IDbConnection connection;
		string password;
		string username;
		string connectionString;
		
		
		public ConnectionObject(string connectionString):this(connectionString,"","") {
		}
		
		public ConnectionObject(string connectionString, string password, string username)
		{
			if (String.IsNullOrEmpty(connectionString)) {
				throw new ArgumentNullException("connectionString");
			}
			this.connectionString = connectionString;
			this.password = password;
			this.username = username;
			this.connection = new OleDbConnection (this.connectionString);
		}
		
		public ConnectionObject(IDbConnection connection, string password, string username)
		{
			this.connection = connection;
			this.password = password;
			this.username = username;
			this.connectionString = this.connection.ConnectionString;
		}
		
		
		public IDbConnection Connection {
			get {
				return connection;
			}
			set {
				connection = value;
			}
		}
		public string Password {
			get {
				return password;
			}
			set {
				password = value;
			}
		}
		public string Username {
			get {
				return username;
			}
			set {
				username = value;
			}
		}
		
//		public string ConnectionString {
//			get {
//				return connectionString;
//			}
//		}
		public void Dispose(){
			if (this.connection != null) {
				if (this.connection.State == ConnectionState.Open) {
					this.connection.Close();
				}
				this.connection.Dispose();
			}
		}
		
	}
}

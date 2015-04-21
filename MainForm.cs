/*
 * Created by SharpDevelop.
 * User: ghelo
 * Date: 7/28/2012
 * Time: 9:47 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using System.Text;
using System.Data;

namespace Launcher
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		Launcher _launcher;
		
		string _url = "http://localhost:8080";
		string _title = "PGP :: Agency Node Portal";
		
		string _userStore;
		string _roleStore;
		
		DataSet dsUsers = new DataSet();
		DataSet dsRoles = new DataSet();
		
		public MainForm(Launcher launcher)
		{
			InitializeComponent();
			_launcher = launcher;	
			
			_launcher.ConsoleChanged+= delegate(object sender, EventArgs e) { 
				if(chkShowLogs.Checked)
					txtConsoleOut.Invoke(new UpdateConsoleDelegate(UpdateConsole),new object[]{ _launcher.ConsoleData });
			};
				
		}
		
		void MainFormLoad(object sender, EventArgs e)
		{
			this._userStore = Environment.CurrentDirectory + @"\..\geoserver\data_dir\security\usergroup\default\users.xml";
			this._roleStore = Environment.CurrentDirectory + @"\..\geoserver\data_dir\security\role\default\roles.xml";
			BindUser();
			
		}
		
		

		
		
		private void BindUser()
		{
			//this._userStore = "users.xml";
			dsUsers.ReadXml(this._userStore, XmlReadMode.InferSchema);
		 
			foreach(DataRow dr in dsUsers.Tables["user"].Rows){
				dr["password"] = dr["password"].ToString().Replace("plain:","");
			}
			
			dsUsers.Tables["user"].TableNewRow += delegate(object sender, DataTableNewRowEventArgs e) { 
				e.Row.SetParentRow(dsUsers.Tables["users"].Rows[0]);
				
			};
				
			dsUsers.Tables["user"].RowChanged += delegate(object sender, DataRowChangeEventArgs e) {
				if(e.Action == DataRowAction.Add) {
					DataRow newRow = dsUsers.Tables["member"].Rows.Add(new object []{e.Row["name"].ToString()});
					newRow.SetParentRow(dsUsers.Tables["group"].Rows[0]);
				}
			};
			
			dsUsers.Tables["user"].ColumnChanging += delegate(object sender, DataColumnChangeEventArgs e) { 
				if(e.Column.ColumnName == "name"){
					string name = e.Row["name"].ToString();
					DataRow[] rows = dsUsers.Tables["member"].Select("username = '" + name + "'");
					if(rows.Length > 0)
						rows[0]["username"] = e.ProposedValue;
				}
			};
			
			
			
			
			dsUsers.Tables["user"].RowDeleting += delegate(object sender, DataRowChangeEventArgs e) { 
				string name = e.Row["name"].ToString();
				DataRow[] rows = dsUsers.Tables["member"].Select("username = '" + name + "'");
				if(rows.Length > 0)
					rows[0].Delete();
			};
			

			
			grdGroup.DataSource = dsUsers.Tables["member"];
			grdUsers.DataSource = dsUsers.Tables["user"];

		}
		
		
		private void btnStart_Click(object sender, EventArgs e)
		{
			txtConsoleOut.Clear();
			_launcher.Start();
			
			Cursor.Current = Cursors.WaitCursor;
			TestServer();
			Cursor.Current = Cursors.Default;
		}
		
		private void btnStop_Click(object sender, EventArgs e)
		{
			_launcher.Stop();
			this.Text = this._title + " (Stopped)";
		}
		
		
		
		private delegate void UpdateConsoleDelegate(string s);
		private void UpdateConsole(string s)
		{
			txtConsoleOut.Text = s;
			txtConsoleOut.SelectionStart = txtConsoleOut.Text.Length;
			txtConsoleOut.ScrollToCaret();
		}
		
		
		
		
		private delegate void SetControlPropertyThreadSafeDelegate(Control control, string propertyName, object propertyValue);
        public static void SetControlPropertyThreadSafe(Control control, string propertyName, object propertyValue)
        {
            if (control.InvokeRequired)
            {
                control.Invoke(new SetControlPropertyThreadSafeDelegate(SetControlPropertyThreadSafe), new object[] { control, propertyName, propertyValue });
            }
            else
            {
                control.GetType().InvokeMember(propertyName, System.Reflection.BindingFlags.SetProperty, null, control, new object[] { propertyValue });
            }
        }
		
        
        

		
		private void mainFormForm_Closing(object sender, FormClosingEventArgs e)
		{

			e.Cancel = true;
			this.Hide();
		}
		

		
		private void btnStartPostgis_Click(object sender, EventArgs e)
		{
			string file = Environment.CurrentDirectory + @"\..\pgsql\bin\pgAdmin3.exe";
			Process.Start(file);
		}
		
		private void btnStartGeoserver_Click(object sender, EventArgs e)
		{
			
			Process.Start(this._url + "/geoserver");
		}
		
		
		
		private void TestServer()
		{
			string url = this._url + "/geoportal";
	
			int timeOut = 0;
			Timer timer = new Timer();
			timer.Interval = 1000;
			timer.Tick += delegate { 
				timeOut++;
				System.Net.WebRequest request = System.Net.WebRequest.Create(url);
				System.Net.HttpWebResponse response = null;
				request.Timeout = timer.Interval;
				timer.Stop();
				try {
					response = (System.Net.HttpWebResponse)request.GetResponse();
				
					if(response.StatusCode == System.Net.HttpStatusCode.OK){
						// ok
						System.Diagnostics.Process.Start(url);
						this.Text = this._title + " (Running)";
						
					} else {
						// fail
						MessageBox.Show("Site status is " + response.StatusCode.ToString(), "Server not responding",MessageBoxButtons.OK,MessageBoxIcon.Error);
					}

				} catch(Exception ex){
					string s = ex.Message;
					if(timeOut > 30){
						// fail
						timer.Stop();
						MessageBox.Show("Failed to contact site.", "Server not responding",MessageBoxButtons.OK,MessageBoxIcon.Error);
					} else {
						// retry
						timer.Start();
					}
				}
				// close only if a reply was received
				if(response != null)
					response.Close();
				
			};
			timer.Start();
			
		}
		
		void btnSaveUserClick(object sender, EventArgs e)
		{
			dsUsers.AcceptChanges();

			foreach(DataRow dr in dsUsers.Tables["user"].Rows){
				dr["password"] = "plain:" + dr["password"].ToString();
				dr["enabled"] = "true";
			}
			
			System.Diagnostics.Debug.Write(dsUsers.GetXml());
			dsUsers.WriteXml(this._userStore, XmlWriteMode.IgnoreSchema);
			
			string xmlString = System.IO.File.ReadAllText(this._userStore);
			xmlString = xmlString.Replace(@"standalone=""yes""",@"standalone=""no""");
			System.IO.File.WriteAllText(this._userStore, xmlString);
			
			foreach(DataRow dr in dsUsers.Tables["user"].Rows){
				dr["password"] = dr["password"].ToString().Replace("plain:","");
			}
		}
		
		void lnkOpenNodePortalLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			System.Diagnostics.Process.Start(this._url + "/geoportal");
		}

	
		
		void btnUserAddClick(object sender, EventArgs e)
		{
			
			UserForm frm = new UserForm(dsUsers.Tables["user"]);
			frm.ShowDialog();
		}
		
		void btnUserEditClick(object sender, EventArgs e)
		{
			if(grdUsers.SelectedRows.Count == 0)
				return;
			
			DataRow dr = (grdUsers.SelectedRows[0].DataBoundItem as DataRowView).Row;
		
			UserForm frm = new UserForm(dr);
			frm.ShowDialog();
		}
		
		void btnUserDeleteClick(object sender, EventArgs e)
		{
			(grdUsers.SelectedRows[0].DataBoundItem as DataRowView).Row.Delete();
		}
	}
}

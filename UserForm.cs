/*
 * Created by SharpDevelop.
 * User: ghelo
 * Date: 5/21/2014
 * Time: 1:44 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Data;
namespace Launcher
{
	/// <summary>
	/// Description of UserForm.
	/// </summary>
	public partial class UserForm : Form
	{

		// Edit
		public UserForm(DataRow dr)
		{
			InitializeComponent();
		
			txtUsername.Text = dr["name"].ToString();
			txtPassword.Text = dr["password"].ToString();	

			btnSaveUser.Click += delegate {
				dr["name"] = txtUsername.Text;
				dr["password"] = txtPassword.Text;
				
				this.Close();
			};
		}
		
		// New
		public UserForm(DataTable dt)
		{
			InitializeComponent();
			
			btnSaveUser.Click += delegate { 
				DataRow newRow = dt.NewRow();
				
				newRow["name"] = txtUsername.Text;
				newRow["password"] = txtPassword.Text;
				
				dt.Rows.Add(newRow);
			
				this.Close();
			};
		}
		

	}
}

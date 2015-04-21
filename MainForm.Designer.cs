/*
 * Created by SharpDevelop.
 * User: ghelo
 * Date: 7/28/2012
 * Time: 9:47 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace Launcher
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.btnStart = new System.Windows.Forms.Button();
			this.btnStop = new System.Windows.Forms.Button();
			this.txtConsoleOut = new System.Windows.Forms.RichTextBox();
			this.btnStartGeoserver = new System.Windows.Forms.Button();
			this.btnStartPostgis = new System.Windows.Forms.Button();
			this.grdUsers = new System.Windows.Forms.DataGridView();
			this.user = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.password = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.enabled = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.btnSaveUser = new System.Windows.Forms.Button();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.lnkOpenNodePortal = new System.Windows.Forms.LinkLabel();
			this.tabControl = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.chkShowLogs = new System.Windows.Forms.CheckBox();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.btnUserDelete = new System.Windows.Forms.Button();
			this.btnUserEdit = new System.Windows.Forms.Button();
			this.btnUserAdd = new System.Windows.Forms.Button();
			this.grdGroup = new System.Windows.Forms.DataGridView();
			this.tabTools = new System.Windows.Forms.TabPage();
			((System.ComponentModel.ISupportInitialize)(this.grdUsers)).BeginInit();
			this.groupBox2.SuspendLayout();
			this.tabControl.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.tabPage2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.grdGroup)).BeginInit();
			this.tabTools.SuspendLayout();
			this.SuspendLayout();
			// 
			// btnStart
			// 
			this.btnStart.Location = new System.Drawing.Point(30, 32);
			this.btnStart.Name = "btnStart";
			this.btnStart.Size = new System.Drawing.Size(61, 37);
			this.btnStart.TabIndex = 0;
			this.btnStart.Text = "Start";
			this.btnStart.UseVisualStyleBackColor = true;
			this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
			// 
			// btnStop
			// 
			this.btnStop.Location = new System.Drawing.Point(110, 32);
			this.btnStop.Name = "btnStop";
			this.btnStop.Size = new System.Drawing.Size(64, 37);
			this.btnStop.TabIndex = 1;
			this.btnStop.Text = "Stop";
			this.btnStop.UseVisualStyleBackColor = true;
			this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
			// 
			// txtConsoleOut
			// 
			this.txtConsoleOut.Dock = System.Windows.Forms.DockStyle.Top;
			this.txtConsoleOut.Location = new System.Drawing.Point(3, 3);
			this.txtConsoleOut.Name = "txtConsoleOut";
			this.txtConsoleOut.Size = new System.Drawing.Size(354, 168);
			this.txtConsoleOut.TabIndex = 2;
			this.txtConsoleOut.Text = "";
			this.txtConsoleOut.WordWrap = false;
			// 
			// btnStartGeoserver
			// 
			this.btnStartGeoserver.Image = ((System.Drawing.Image)(resources.GetObject("btnStartGeoserver.Image")));
			this.btnStartGeoserver.Location = new System.Drawing.Point(106, 18);
			this.btnStartGeoserver.Name = "btnStartGeoserver";
			this.btnStartGeoserver.Size = new System.Drawing.Size(224, 64);
			this.btnStartGeoserver.TabIndex = 6;
			this.btnStartGeoserver.UseVisualStyleBackColor = true;
			this.btnStartGeoserver.Click += new System.EventHandler(this.btnStartGeoserver_Click);
			// 
			// btnStartPostgis
			// 
			this.btnStartPostgis.Image = ((System.Drawing.Image)(resources.GetObject("btnStartPostgis.Image")));
			this.btnStartPostgis.Location = new System.Drawing.Point(36, 18);
			this.btnStartPostgis.Name = "btnStartPostgis";
			this.btnStartPostgis.Size = new System.Drawing.Size(64, 64);
			this.btnStartPostgis.TabIndex = 5;
			this.btnStartPostgis.UseVisualStyleBackColor = true;
			this.btnStartPostgis.Click += new System.EventHandler(this.btnStartPostgis_Click);
			// 
			// grdUsers
			// 
			this.grdUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.grdUsers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
									this.user,
									this.password,
									this.enabled});
			this.grdUsers.Location = new System.Drawing.Point(6, 6);
			this.grdUsers.Name = "grdUsers";
			this.grdUsers.RowHeadersWidth = 20;
			this.grdUsers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.grdUsers.Size = new System.Drawing.Size(348, 166);
			this.grdUsers.TabIndex = 9;
			// 
			// user
			// 
			this.user.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.user.DataPropertyName = "name";
			this.user.HeaderText = "User";
			this.user.Name = "user";
			// 
			// password
			// 
			this.password.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.password.DataPropertyName = "password";
			this.password.HeaderText = "Password";
			this.password.Name = "password";
			this.password.Visible = false;
			// 
			// enabled
			// 
			this.enabled.DataPropertyName = "enabled";
			this.enabled.HeaderText = "Enabled";
			this.enabled.Name = "enabled";
			this.enabled.Visible = false;
			// 
			// btnSaveUser
			// 
			this.btnSaveUser.Location = new System.Drawing.Point(300, 178);
			this.btnSaveUser.Name = "btnSaveUser";
			this.btnSaveUser.Size = new System.Drawing.Size(54, 23);
			this.btnSaveUser.TabIndex = 10;
			this.btnSaveUser.Text = "Save";
			this.btnSaveUser.UseVisualStyleBackColor = true;
			this.btnSaveUser.Click += new System.EventHandler(this.btnSaveUserClick);
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.lnkOpenNodePortal);
			this.groupBox2.Controls.Add(this.btnStart);
			this.groupBox2.Controls.Add(this.btnStop);
			this.groupBox2.Location = new System.Drawing.Point(12, 12);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(368, 100);
			this.groupBox2.TabIndex = 13;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Manage service";
			// 
			// lnkOpenNodePortal
			// 
			this.lnkOpenNodePortal.Location = new System.Drawing.Point(231, 44);
			this.lnkOpenNodePortal.Name = "lnkOpenNodePortal";
			this.lnkOpenNodePortal.Size = new System.Drawing.Size(100, 23);
			this.lnkOpenNodePortal.TabIndex = 9;
			this.lnkOpenNodePortal.TabStop = true;
			this.lnkOpenNodePortal.Text = "Open node portal";
			this.lnkOpenNodePortal.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkOpenNodePortalLinkClicked);
			// 
			// tabControl
			// 
			this.tabControl.Controls.Add(this.tabPage1);
			this.tabControl.Controls.Add(this.tabPage2);
			this.tabControl.Controls.Add(this.tabTools);
			this.tabControl.Location = new System.Drawing.Point(12, 118);
			this.tabControl.Name = "tabControl";
			this.tabControl.SelectedIndex = 0;
			this.tabControl.Size = new System.Drawing.Size(368, 233);
			this.tabControl.TabIndex = 14;
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.chkShowLogs);
			this.tabPage1.Controls.Add(this.txtConsoleOut);
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(360, 207);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "Logs";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// chkShowLogs
			// 
			this.chkShowLogs.Location = new System.Drawing.Point(272, 177);
			this.chkShowLogs.Name = "chkShowLogs";
			this.chkShowLogs.Size = new System.Drawing.Size(82, 24);
			this.chkShowLogs.TabIndex = 3;
			this.chkShowLogs.Text = "Show logs";
			this.chkShowLogs.UseVisualStyleBackColor = true;
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.Add(this.btnUserDelete);
			this.tabPage2.Controls.Add(this.btnUserEdit);
			this.tabPage2.Controls.Add(this.btnUserAdd);
			this.tabPage2.Controls.Add(this.grdUsers);
			this.tabPage2.Controls.Add(this.grdGroup);
			this.tabPage2.Controls.Add(this.btnSaveUser);
			this.tabPage2.Location = new System.Drawing.Point(4, 22);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage2.Size = new System.Drawing.Size(360, 207);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "User management";
			this.tabPage2.UseVisualStyleBackColor = true;
			// 
			// btnUserDelete
			// 
			this.btnUserDelete.Location = new System.Drawing.Point(126, 178);
			this.btnUserDelete.Name = "btnUserDelete";
			this.btnUserDelete.Size = new System.Drawing.Size(54, 23);
			this.btnUserDelete.TabIndex = 14;
			this.btnUserDelete.Text = "Delete";
			this.btnUserDelete.UseVisualStyleBackColor = true;
			this.btnUserDelete.Click += new System.EventHandler(this.btnUserDeleteClick);
			// 
			// btnUserEdit
			// 
			this.btnUserEdit.Location = new System.Drawing.Point(66, 178);
			this.btnUserEdit.Name = "btnUserEdit";
			this.btnUserEdit.Size = new System.Drawing.Size(54, 23);
			this.btnUserEdit.TabIndex = 13;
			this.btnUserEdit.Text = "Edit";
			this.btnUserEdit.UseVisualStyleBackColor = true;
			this.btnUserEdit.Click += new System.EventHandler(this.btnUserEditClick);
			// 
			// btnUserAdd
			// 
			this.btnUserAdd.Location = new System.Drawing.Point(6, 178);
			this.btnUserAdd.Name = "btnUserAdd";
			this.btnUserAdd.Size = new System.Drawing.Size(54, 23);
			this.btnUserAdd.TabIndex = 12;
			this.btnUserAdd.Text = "Add";
			this.btnUserAdd.UseVisualStyleBackColor = true;
			this.btnUserAdd.Click += new System.EventHandler(this.btnUserAddClick);
			// 
			// grdGroup
			// 
			this.grdGroup.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.grdGroup.Location = new System.Drawing.Point(207, 6);
			this.grdGroup.Name = "grdGroup";
			this.grdGroup.ReadOnly = true;
			this.grdGroup.RowHeadersVisible = false;
			this.grdGroup.Size = new System.Drawing.Size(147, 166);
			this.grdGroup.TabIndex = 11;
			this.grdGroup.Visible = false;
			// 
			// tabTools
			// 
			this.tabTools.Controls.Add(this.btnStartGeoserver);
			this.tabTools.Controls.Add(this.btnStartPostgis);
			this.tabTools.Location = new System.Drawing.Point(4, 22);
			this.tabTools.Name = "tabTools";
			this.tabTools.Padding = new System.Windows.Forms.Padding(3);
			this.tabTools.Size = new System.Drawing.Size(360, 207);
			this.tabTools.TabIndex = 2;
			this.tabTools.Text = "Tools";
			this.tabTools.UseVisualStyleBackColor = true;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(392, 358);
			this.Controls.Add(this.tabControl);
			this.Controls.Add(this.groupBox2);
			this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.Name = "MainForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "PGP :: Agency Node Portal";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.mainFormForm_Closing);
			this.Load += new System.EventHandler(this.MainFormLoad);
			((System.ComponentModel.ISupportInitialize)(this.grdUsers)).EndInit();
			this.groupBox2.ResumeLayout(false);
			this.tabControl.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.tabPage2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.grdGroup)).EndInit();
			this.tabTools.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.Button btnUserAdd;
		private System.Windows.Forms.Button btnUserEdit;
		private System.Windows.Forms.Button btnUserDelete;
		private System.Windows.Forms.CheckBox chkShowLogs;
		private System.Windows.Forms.TabPage tabTools;
		private System.Windows.Forms.DataGridView grdGroup;
		private System.Windows.Forms.DataGridViewTextBoxColumn enabled;
		private System.Windows.Forms.LinkLabel lnkOpenNodePortal;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabControl tabControl;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.DataGridViewTextBoxColumn user;
		private System.Windows.Forms.DataGridViewTextBoxColumn password;
		private System.Windows.Forms.Button btnSaveUser;
		private System.Windows.Forms.DataGridView grdUsers;
		private System.Windows.Forms.Button btnStartGeoserver;
		private System.Windows.Forms.Button btnStartPostgis;
		private System.Windows.Forms.Button btnStop;
		private System.Windows.Forms.Button btnStart;
		private System.Windows.Forms.RichTextBox txtConsoleOut;
	}
}

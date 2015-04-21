/*
 * Created by SharpDevelop.
 * User: ghelo
 * Date: 7/28/2012
 * Time: 4:11 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Diagnostics;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace Launcher
{
	public sealed class NotificationIcon
	{
		private NotifyIcon notifyIcon;
		private ContextMenu notificationMenu;
		private static MainForm frm;
		private static Launcher launcher = new Launcher();
		
		#region Initialize icon and menu
		public NotificationIcon()
		{
			notifyIcon = new NotifyIcon();
			notificationMenu = new ContextMenu(InitializeMenu());
			
			notifyIcon.DoubleClick += icon_DoubleClick;
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NotificationIcon));
			notifyIcon.Icon = (Icon)resources.GetObject("$this.Icon");
			notifyIcon.ContextMenu = notificationMenu;
		}
		
		private MenuItem[] InitializeMenu()
		{
			MenuItem[] menu = new MenuItem[] {
				new MenuItem("Show", menuShow_Click),
				new MenuItem("About", menuAbout_Click),
				new MenuItem("Exit", menuExit_Click)
			};
			return menu;
		}
		#endregion
		
		#region Main - Program entry point
		/// <summary>Program entry point.</summary>
		/// <param name="args">Command Line Arguments</param>
		[STAThread]
		public static void Main(string[] args)
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			
			bool isFirstInstance;
			// Please use a unique name for the mutex to prevent conflicts with other programs
			using (Mutex mtx = new Mutex(true, "launcher", out isFirstInstance)) {
				if (isFirstInstance) {
					NotificationIcon notificationIcon = new NotificationIcon();
					notificationIcon.notifyIcon.Visible = true;
					
					
					//launcher.Start();
					
					frm = new MainForm(launcher);
					frm.Show();
					
					Application.Run();
					
					
					
					notificationIcon.notifyIcon.Dispose();
				} else {
					// The application is already running
					// TODO: Display message box or change focus to existing application instance
				}
			} // releases the Mutex
		}
		#endregion
		
		#region Event Handlers
		private void menuShow_Click(object sender, EventArgs e)
		{
			frm.BringToFront();
			frm.Show();
		}
		
		private void menuAbout_Click(object sender, EventArgs e)
		{
			MessageBox.Show("Aloha! For questions, email ghelobytes@yahoo.com");
		}
		
		private void menuExit_Click(object sender, EventArgs e)
		{
			if(launcher.HasStarted)
			{
				MessageBox.Show("Server is running! Please stop them before exiting.", "Wait!");
				return;	
			}
			frm.Dispose();
			Application.Exit();
		}
		
		private void icon_DoubleClick(object sender, EventArgs e)
		{
			//MessageBox.Show("The icon was double clicked");
			frm.BringToFront();
			frm.Show();
		}
		#endregion
	}
}

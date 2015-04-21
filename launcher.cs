/*
 * Created by SharpDevelop.
 * User: ghelo
 * Date: 7/28/2012
 * Time: 4:13 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace Launcher
{
	/// <summary>
	/// Description of launcher.
	/// </summary>
	public class Launcher
	{
	
		private StringBuilder sbConsole = new StringBuilder();
		
		private string _ConsoleData;
		public string ConsoleData 
		{
			get { return _ConsoleData; }
			set { _ConsoleData = value; }
		}
		private bool _HasStarted = false;
		public bool HasStarted 
		{
			get { return _HasStarted; }
			set { _HasStarted = value; }
		}
		
		public event EventHandler ConsoleChanged;
		protected virtual void OnConsoleChanged()
		{
			if(ConsoleChanged != null)
				ConsoleChanged(this, EventArgs.Empty);
		}
		
		public Launcher()
		{
			
		}
		
		public void Start()
		{
			sbConsole.Clear();
			RunBatchFile(@"start.bat");
			_HasStarted = true;
		}
		public void Stop()
		{
			RunBatchFile(@"stop.bat");
			_HasStarted = false;
		}
		

		
		private void RunBatchFile(string batchFile)
		{
			FileInfo f = new FileInfo(batchFile);
			
			Process p = new Process();
            p.StartInfo.FileName = batchFile;
            p.StartInfo.WorkingDirectory = f.Directory.FullName;
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardOutput = true;
            p.OutputDataReceived += delegate(object sender, DataReceivedEventArgs e) { 
            	sbConsole.Append(e.Data + "\n");
            	if(sbConsole.ToString().Length > 1024)
            		sbConsole.Remove(0,1024);
            	_ConsoleData = sbConsole.ToString();
            	OnConsoleChanged();
            };
            p.Start();
            p.BeginOutputReadLine();
		}
		
		
		

		
	}
}

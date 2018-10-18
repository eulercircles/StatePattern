using System;
using System.Diagnostics;
using System.Windows.Forms;

using static System.Environment;

namespace TrayApp
{
	static class Program
	{
		private static TrayApplicationContext _context;

		[STAThread]
		static void Main()
		{
			var eventLog = CreateEventLog();

			try
			{
				Application.EnableVisualStyles();
				Application.SetCompatibleTextRenderingDefault(false);

				Application.ApplicationExit += HandleUnexpectedExit;
				Application.ThreadExit += HandleUnexpectedExit;
				
				_context = new TrayApplicationContext(eventLog);
				Application.Run(_context);
			}
			catch (Exception exception)
			{
				_context.Dispose();
				eventLog.WriteEntry(exception.ToString(), EventLogEntryType.Error, (int)LogEvents.Error);
			}
		}

		private static void HandleUnexpectedExit(object sender, EventArgs e)
		{
			if (!_context.HasExited) { _context.Exit(); }
		}

		private static EventLog CreateEventLog()
		{
			if (!EventLog.SourceExists(""))
			{
				EventLog.CreateEventSource(new EventSourceCreationData("", ""));
			}

			var result = new EventLog()
			{
				Source = "",
				Log = "",
				MachineName = MachineName,
				MaximumKilobytes = 2048
			};

			return result;
		}
	}
}

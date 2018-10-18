using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace TrayApp
{
	internal class TrayApplicationContext : ApplicationContext
	{
		private readonly EventLog _eventLog;

		internal bool HasExited { get; private set; }

		internal TrayApplicationContext(EventLog eventLog)
		{
			_eventLog = eventLog;
		}

		

		internal void Exit()
		{
			throw new NotImplementedException();
		}
	}
}

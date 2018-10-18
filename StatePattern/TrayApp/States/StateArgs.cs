using System;
using System.Diagnostics;

namespace TrayApp.States
{
	internal abstract class StateArgs
	{
		internal EventLog EventLog { get; }

		internal StateArgs(EventLog eventLog)
		{
			EventLog = eventLog;
		}

		internal StateArgs(StateArgs stateArgs) : this(stateArgs.EventLog) { }
	}
}

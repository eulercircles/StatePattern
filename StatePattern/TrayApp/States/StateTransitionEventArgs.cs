using System;

namespace TrayApp.States
{
	internal class StateTransitionEventArgs : EventArgs
	{
		internal bool Cancelled { get; }
		internal Exception Error { get; }
		internal State NextState { get; }

		internal StateTransitionEventArgs(bool cancelled, Exception error, State nextState)
		{
			Cancelled = cancelled;
			Error = error;
			// nextState is allowed to be null.
			NextState = nextState;
		}
	}
}

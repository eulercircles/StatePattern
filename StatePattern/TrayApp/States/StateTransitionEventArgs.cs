using System;

namespace TrayApp.States
{
	internal class StateTransitionEventArgs : EventArgs
	{
		internal bool Cancelled { get; }
		internal Exception Error { get; }
		internal BState NextState { get; }

		internal StateTransitionEventArgs(bool cancelled, Exception error, BState nextState)
		{
			Cancelled = cancelled;
			Error = error;
			// nextState is allowed to be null.
			NextState = nextState;
		}
	}
}

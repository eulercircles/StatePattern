using System;
using System.Linq;
using System.Threading;

namespace TrayApp.States
{
	internal abstract class TState
	{
		private readonly Thread _thread;
		private readonly StateArgs _stateArgs;

		private EventHandler<StateTransitionEventArgs> _transitioning;
		internal event EventHandler<StateTransitionEventArgs> Transitioning
		{
			add
			{
				if (_transitioning == null || !_transitioning.GetInvocationList().Contains(value))
				{
					_transitioning += value;
				}
			}
			remove { _transitioning -= value; }
		}

		internal TState(StateArgs stateArgs)
		{
			_stateArgs = stateArgs ?? throw new ArgumentNullException(nameof(stateArgs));
			_thread = new Thread(new ParameterizedThreadStart(DoWork))
			{
				IsBackground = true
			};
		}

		private void DoWork(object obj)
		{
			throw new NotImplementedException();
		}

		internal void Start() => _thread.Start();
	}
}

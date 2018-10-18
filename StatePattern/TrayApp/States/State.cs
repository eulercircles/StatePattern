using System;
using System.ComponentModel;
using System.Linq;

namespace TrayApp.States
{
	internal abstract class State
	{
		private readonly BackgroundWorker _backgroundWorker;
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

		protected bool CancellationPending => _backgroundWorker.CancellationPending;
		protected StateCancellationResons CancellationReason { get; private set; }

		internal State(StateArgs stateArgs)
		{
			_stateArgs = stateArgs ?? throw new ArgumentNullException(nameof(stateArgs));

			_backgroundWorker = new BackgroundWorker()
			{
				WorkerReportsProgress = false,
				WorkerSupportsCancellation = true
			};

			_backgroundWorker.DoWork += _backgroundWorker_DoWork;
			_backgroundWorker.RunWorkerCompleted += _backgroundWorker_RunWorkerCompleted;
		}

		internal void Run() => _backgroundWorker.RunWorkerAsync();

		internal void Cancel(StateCancellationResons reason)
		{
			CancellationReason = reason;
			_backgroundWorker.CancelAsync();
		}

		protected abstract State DoWork(StateArgs stateArgs);

		protected void TransitionState(bool cancelled, Exception error, State nextState)
			=> _transitioning?.Invoke(this, new StateTransitionEventArgs(cancelled, error, nextState));

		private void _backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
		{
			throw new NotImplementedException();
		}

		private void _backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			throw new NotImplementedException();
		}
		
		private void Completed(bool cancelled, Exception error, State result) => TransitionState(cancelled, error, result);
	}
}

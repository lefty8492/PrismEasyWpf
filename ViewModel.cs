using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Input;
using System.Windows;

namespace PrismEasyWpf {
	class ViewModel : INotifyPropertyChanged, IDataErrorInfo {
		public event PropertyChangedEventHandler PropertyChanged;

		public string Error {
			get {
				double d;
				return (!double.TryParse(X, out d)) ? "Value is not double." : null;
			}
		}

		public string this[string columnName] {
			get {
				double d;
				switch (columnName) {
				case "X": return (!double.TryParse(X, out d)) ? "Value is not double." : null;
				}
				return null;
			}
		}

		string _x = "0";

		public string X {
			get {
				return _x;
			}

			set {
				_x = value;

				if (PropertyChanged != null) {
					PropertyChanged(this, new PropertyChangedEventArgs("X"));
				}
			}
		}

		private class Command : ICommand {
			private Action<object> _Command;
			private Func<object, bool> _CanExecute;

			public Command(Action<object> command, Func<object, bool> canExecute = null) {
				if (command == null) {
					throw new ArgumentException();
				}

				_Command = command;
				_CanExecute = canExecute;
			}

			public event EventHandler CanExecuteChanged {
				add { CommandManager.RequerySuggested += value; }
				remove { CommandManager.RequerySuggested -= value; }
			}

			public bool CanExecute(object parameter) {
				if (_CanExecute != null) {
					return _CanExecute(parameter);
				} else {
					return true;
				}
			}

			public void Execute(object parameter) {
				_Command(parameter);
			}
		}

		public ICommand SumCommand {get; private set; }

		public ViewModel() {
			X = "0";
			SumCommand = new Command(v => { MessageBox.Show((double.Parse(X) * 2).ToString()); });
		}

	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

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
	}
}

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
				return (X < 0) ? "Value is not positive." : null;
			}
		}

		public string this[string columnName] {
			get {
				switch (columnName) {
				case "X": return (X < 0) ? "Value is not positive." : null;
				}
				return null;
			}
		}

		double _x = 0;

		public double X {
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

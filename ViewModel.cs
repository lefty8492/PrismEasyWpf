using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace PrismEasyWpf {
	class ViewModel : INotifyPropertyChanged {
		public event PropertyChangedEventHandler PropertyChanged;

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

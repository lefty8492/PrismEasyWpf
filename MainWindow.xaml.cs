using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PrismEasyWpf {
	/// <summary>
	/// MainWindow.xaml の相互作用ロジック
	/// </summary>
	public partial class MainWindow : Window {
		public MainWindow() {
			InitializeComponent();
		}

		private void TextChangedEvent(object sender, TextChangedEventArgs e) {
			if (TextBoxContentValidation(ref TxtNum1) && TextBoxContentValidation(ref TxtNum2)) {
				BtnSum.IsEnabled = true;
			} else {
				BtnSum.IsEnabled = false;
			}
		}

		private Boolean TextBoxContentValidation(ref TextBox textBox) {
			double _dummy;
			if (double.TryParse(textBox.Text, out _dummy)) {
				textBox.Background = new SolidColorBrush(Colors.White);
				return true;
			} else {
				textBox.Background = new SolidColorBrush(Colors.LightPink);
				return false;
			}
		}

		private void BtnSum_Click(object sender, RoutedEventArgs e) {
			double num1, num2;

			double.TryParse(TxtNum1.Text, out num1);
			double.TryParse(TxtNum2.Text, out num2);

			MessageBox.Show((num1 + num2).ToString());
		}
	}
}

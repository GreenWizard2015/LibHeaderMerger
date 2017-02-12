using System;
using System.Windows;
using System.Windows.Controls;
using CORE;

namespace GUITest {
	public partial class MainWindow: Window {
		public MainWindow() {
			InitializeComponent();
			///////////////////
			/// for testing
//			 onRefresh(null, null);
//			 lbTemplates.SelectedIndex = 0;
		}

		private CSourceLocator locator;
		private void onRefresh(object sender, RoutedEventArgs e) {
			var root = new CPath(Environment.CurrentDirectory);
			root = root.resolve(tbSrcFolder.Text).asFolder();

			locator = new CSourceLocator(root.Normalized);
			lbTemplates.ItemsSource = locator.Templates();
		}

		private void onSelectTemplate(object sender, SelectionChangedEventArgs e){
			var lb = (ListBox)sender;
			var selected = (CFileEntry)lb.SelectedItem;
			tbSource.Text = (null == selected) ? "" : selected.content();
		}

		private void onSourceChanged(object sender, TextChangedEventArgs e) {
			if (null == locator) return;

			var merger = new CHeaderMerger();
			var selected = (CFileEntry)lbTemplates.SelectedItem;
			tbResult.Text = merger.process(tbSource.Text, selected.Dir);
		}
	}
}

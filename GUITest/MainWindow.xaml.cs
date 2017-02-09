using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using CORE;

namespace GUITest {
  public partial class MainWindow: Window {
    public MainWindow() {
      InitializeComponent();
    }

    private CSourceLocator locator = null;
    private void onRefresh(object sender, RoutedEventArgs e) {
      locator = new CSourceLocator(tbSrcFolder.Text);
      lbTemplates.ItemsSource = locator.Templates();
    }

    private void onSelectTemplate(object sender, SelectionChangedEventArgs e) {
      var lb = (ListBox) sender;
      var selected = (CFileEntry)lb.SelectedItem;
      tbSource.Text = (null == selected) ? "" : selected.content();
    }

    private void onSourceChanged(object sender, TextChangedEventArgs e) {
      if (null == locator) return;
      
      var merger = new CHeaderMerger(locator.Headers());
      tbResult.Text = merger.process(tbSource.Text);
    }
  }
}

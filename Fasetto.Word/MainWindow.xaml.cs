using Fasetto.Word.Core;
using System;
using System.Windows;

namespace Fasetto.Word
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
		{
				public MainWindow()
				{
						InitializeComponent();

						DataContext = new WindowViewModel(this);
				}

		private void AppWindow_Deactivated(object sender, System.EventArgs e)
		{
			// Show overlay if we lose focus
			(DataContext as WindowViewModel).DimmableOverlayVisible = true;

			Console.Out.WriteLine($"Deactivated, Dimm {(DataContext as WindowViewModel).DimmableOverlayVisible}");
		}

		private void AppWindow_Activated(object sender, System.EventArgs e)
		{
			// Hide overlay if we are focused
			(DataContext as WindowViewModel).DimmableOverlayVisible = false;


			Console.Out.WriteLine($"Activated, Dimm {(DataContext as WindowViewModel).DimmableOverlayVisible}");
		}
	}
}

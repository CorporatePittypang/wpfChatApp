using Fasetto.Word.Core;
using System.Windows.Controls;

namespace Fasetto.Word
{
	public partial class SettingsControl : UserControl
	{
		public SettingsControl()
		{
			InitializeComponent();

			// Set daat context to settings view model
			DataContext = IoC.Settings;
		}
	}
}

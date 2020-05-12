using System.Windows.Input;

namespace Fasetto.Word.Core {
    /// <summary> 	/// The settings state as a view model 	/// </summary>     public class SettingsViewModel : BaseViewModel
	{
		/// <summary>
		/// The current users name
		/// </summary>
		public TextEntryViewModel Name { get; set; }

		/// <summary>
		/// The current users username
		/// </summary>
		public TextEntryViewModel Username { get; set; }

		/// <summary>
		/// The current users password
		/// </summary>
		public TextEntryViewModel Password { get; set; }

		/// <summary>
		/// The current users email
		/// </summary>
		public TextEntryViewModel Email { get; set; }

		/// <summary>
		/// The command to close the settings menu
		/// </summary>
		public ICommand CloseCommand { get; set; }

		/// <summary>
		/// The command to open the settings menu
		/// </summary>
		public ICommand OpenCommand { get; set; }


		/// <summary>
		/// Default constructor
		/// </summary>
		public SettingsViewModel()
		{
			// Create commands
			OpenCommand  = new RelayCommand(Open);
			CloseCommand = new RelayCommand(Close);

			// TODO: Remove this with real information pulled from our database in the future
			Name     = new TextEntryViewModel { Label = "Name", OriginalText = "Good Boi" };
			Username = new TextEntryViewModel { Label = "Username", OriginalText = "goodboi" };
			Password = new TextEntryViewModel { Label = "Password", OriginalText = "********" };
			Email    = new TextEntryViewModel { Label = "Email", OriginalText = "contact@trolol.com" };
		}

		/// <summary>
		/// Opens the settings menu
		/// </summary>
		public void Open()
		{
			IoC.Application.SettingsMenuVisible = true;
		}

		/// <summary>
		/// Closes the settings menu
		/// </summary>
		public void Close()
		{
			IoC.Application.SettingsMenuVisible = false;
		}
	} } 
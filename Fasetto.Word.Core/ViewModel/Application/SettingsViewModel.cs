using System.Windows.Input;

namespace Fasetto.Word.Core {     public class SettingsViewModel : BaseViewModel
	{
		public TextEntryViewModel Name { get; set; }

		public TextEntryViewModel Username { get; set; }

		public PasswordEntryViewModel Password { get; set; }

		public TextEntryViewModel Email { get; set; }

        public string LogoutButtonText { get; set; }

        public ICommand CloseCommand { get; set; }

		public ICommand OpenCommand { get; set; }

        public ICommand LogoutCommand { get; set; }

        public ICommand ClearDataCommand { get; set; }


		public SettingsViewModel()
		{
			OpenCommand      = new RelayCommand(Open);
			CloseCommand     = new RelayCommand(Close);
            LogoutCommand    = new RelayCommand(Logout);
            ClearDataCommand = new RelayCommand(ClearUserData);



            // TODO: Remove this later
            IoC.Settings.Name     = new TextEntryViewModel { Label     = "Name", OriginalText     = "Good Boi" };
            IoC.Settings.Username = new TextEntryViewModel { Label     = "Username", OriginalText = "goodboi" };
            IoC.Settings.Password = new PasswordEntryViewModel { Label = "Password", FakePassword = "********" };
            IoC.Settings.Email    = new TextEntryViewModel { Label     = "Email", OriginalText    = "contact@trolol.com" };

            LogoutButtonText = "Logout";
        }

		public void Open()
		{
			IoC.Application.SettingsMenuVisible = true;
		}

        public void Close()
        {
            IoC.Application.SettingsMenuVisible = false;
        }

        public void Logout()
        {
            //TODO: Confirmation dialog, cleanup of cache, view model data removal
            ClearUserData();

            IoC.Application.GoToPage(ApplicationPage.Login);
        }

        private void ClearUserData()
        {
            Name     = null;
            Username = null;
            Password = null;
            Email    = null;
        }
    } } 
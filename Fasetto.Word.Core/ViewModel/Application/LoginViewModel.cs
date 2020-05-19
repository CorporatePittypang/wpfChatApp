using System.Threading.Tasks;
using System.Windows.Input;

namespace Fasetto.Word.Core
{
	public class LoginViewModel : BaseViewModel
	{
		public string Email { get; set; }

		public bool LoginIsRunning { get; set; }

		public ICommand LoginCommand { get; set; }

		public ICommand RegisterCommand { get; set; }

		public LoginViewModel()
		{
			LoginCommand    = new RelayParameterizedCommand(async (parameter) => await LoginAsync(parameter));
			RegisterCommand = new RelayCommand(async () => await RegisterAsync());
		}

		public async Task LoginAsync(object parameter)
		{
			await RunCommandAsync(() => LoginIsRunning, async () =>
			{
				await Task.Delay(1000);


                // TODO: Remove this with real information pulled from our database in the future
                IoC.Settings.Name     = new TextEntryViewModel { Label     = "Name", OriginalText     = "Good Boi" };
                IoC.Settings.Username = new TextEntryViewModel { Label     = "Username", OriginalText = "goodboi" };
                IoC.Settings.Password = new PasswordEntryViewModel { Label = "Password", FakePassword = "********" };
                IoC.Settings.Email    = new TextEntryViewModel { Label     = "Email", OriginalText    = "contact@trolol.com" };

				IoC.Application.GoToPage(ApplicationPage.Chat);
			});
		}

		public async Task RegisterAsync()
		{
			IoC.Application.GoToPage(ApplicationPage.Register);

			await Task.Delay(1);
		}
	}
}

using System.Security;
using System.Windows.Input;

namespace Fasetto.Word.Core
{
    public class PasswordEntryViewModel : BaseViewModel
	{
		public string Label { get; set; }

		public string FakePassword { get; set; }
        
        public string CurrentPasswordHintText { get; set; }

        public string NewPasswordHintText { get; set; }

        public string ConfirmPasswordHintText { get; set; }

        public SecureString CurrentPassword { get; set; }

		public SecureString NewPassword { get; set; }

		public SecureString ConfirmPassword { get; set; }

        public bool Editing { get; set; }

		public ICommand EditCommand { get; set; }

		public ICommand CancelCommand { get; set; }

		public ICommand SaveCommand { get; set; }


        public PasswordEntryViewModel()
		{
			EditCommand   = new RelayCommand(Edit);
			CancelCommand = new RelayCommand(Cancel);
            SaveCommand   = new RelayCommand(Save);

            // TODO: Replace with localization text
            CurrentPasswordHintText = "Current password";
            NewPasswordHintText     = "New password";
            ConfirmPasswordHintText = "Confirm password";
        }

		public void Edit()
		{
            NewPassword     = new SecureString();
            ConfirmPassword = new SecureString();

			Editing = true;
		}

		public void Save()
        { 
            // TODO:  Current password check from real back-end
            var storedPassword = "Test";

            // For test, placeholder of call to back-end
            if (storedPassword != CurrentPassword.Unsecure())
            {
                IoC.UI.ShowMessage(new MessageBoxDialogViewModel
                {
                    Title   = "Wrong password",
                    Message = "The current password is invalid"
                });

                return;
            }

            if (NewPassword.Unsecure() != ConfirmPassword.Unsecure())
            {
                IoC.UI.ShowMessage(new MessageBoxDialogViewModel
                {
                    Title   = "Password mismatch",
                    Message = "The new and the old password do not match."
                });

                return;
            }

            if (NewPassword.Unsecure().Length == 0)
            {
                IoC.UI.ShowMessage(new MessageBoxDialogViewModel
                {
                    Title   = "Password too short",
                    Message = "You must enter a password!"
                });

                return;
            }

            CurrentPassword = new SecureString();

            foreach (var c in NewPassword.Unsecure().ToCharArray())
                CurrentPassword.AppendChar(c);

            Editing = false;
		}

		public void Cancel()
		{
			Editing = false;
        }
    }
}

using System.Security;
using System.Windows.Input;

namespace Fasetto.Word.Core
{
	/// <summary>
	/// The view model for a text entry to edit a string value
	/// </summary>EditedText
	public class PasswordEntryViewModel : BaseViewModel
	{
		public string Label { get; set; }

		public string FakePassword { get; set; }
        
        public string CurrentPasswordHintText { get; set; }

        public string NewPasswordHintText { get; set; }

        public string ConfirmPasswordHintText { get; set; }

        public SecureString OriginalPassword { get; set; }

		public SecureString NewPassword { get; set; }

		public SecureString ConfirmPassword { get; set; }

        /// <summary>
        /// Indicates if the current text is in edit mode
        /// </summary>
        public bool Editing { get; set; }

		/// <summary>
		/// Puts the control into edit mode
		/// </summary>
		public ICommand EditCommand { get; set; }

		/// <summary>
		/// Cancels out of edit mode
		/// </summary>
		public ICommand CancelCommand { get; set; }

		/// <summary>
		/// Commits the edits and save the value
		/// as well as goes back to non-edit mode
		/// </summary>
		public ICommand SaveCommand { get; set; }
        

		public PasswordEntryViewModel()
		{
			// Create commands
			EditCommand   = new RelayCommand(Edit);
			CancelCommand = new RelayCommand(Cancel);
			SaveCommand   = new RelayCommand(Save);

            // TODO: Replace with localization text
            CurrentPasswordHintText = "Current password";
            NewPasswordHintText     = "New password";
            ConfirmPasswordHintText = "Confirm password";
        }

		/// <summary>
		/// Puts the control into edit mode
		/// </summary>
		public void Edit()
		{
            NewPassword  = new SecureString();
            ConfirmPassword = new SecureString();

			Editing = true;
		}

		/// <summary>
		/// Commits the content and exits out of edit mode
		/// /summary>
		public void Save()
        { 
            // TODO:  Current password check from real back-end
            var storedPassword = "Test";

            // For test, placeholder of call to back-end
            if (storedPassword != OriginalPassword.Unsecure())
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
                // Let user know
                IoC.UI.ShowMessage(new MessageBoxDialogViewModel
                {
                    Title = "Password too short",
                    Message = "You must enter a password!"
                });

                return;
            }

            OriginalPassword = new SecureString();

            foreach (var c in NewPassword.Unsecure().ToCharArray())
                OriginalPassword.AppendChar(c);

            Editing = false;
		}

		/// <summary>
		/// Cancels out of edit mode
		/// </summary>
		public void Cancel()
		{
			Editing = false;
		}
        
	}
}

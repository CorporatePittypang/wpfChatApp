using System.Windows.Input;

namespace Fasetto.Word.Core
{
	/// <summary>
	/// The view model for a text entry to edit a string value
	/// </summary>
	public class TextEntryViewModel : BaseViewModel
	{
		/// <summary>
		/// The label to identify what this value is for
		/// </summary>
		public string Label { get; set; }

		/// <summary>
		/// The current saved value 
		/// </summary>
		public string OriginalText { get; set; }

		/// <summary>
		/// The current non-commited edited text
		/// </summary>
		public string EditedText { get; set; }

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
        

		public TextEntryViewModel()
		{
			// Create commands
			EditCommand = new RelayCommand(Edit);
			CancelCommand = new RelayCommand(Cancel);
			SaveCommand = new RelayCommand(Save);
		}

		/// <summary>
		/// Puts the control into edit mode
		/// </summary>
		public void Edit()
		{
			// Set the edited text to the current value
			EditedText = OriginalText;

			Editing = true;
		}

		/// <summary>
		/// Commits the content and exits out of edit mode
		/// /summary>
		public void Save()
		{
			// TODO: Save content
			OriginalText = EditedText;

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

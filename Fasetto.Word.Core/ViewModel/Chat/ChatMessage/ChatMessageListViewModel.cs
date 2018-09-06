using System.Collections.Generic;
using System.Windows.Input;

namespace Fasetto.Word.Core
{
  /// <summary>
  /// A view model for the overview chat list
  /// </summary>
  public class ChatMessageListViewModel : BaseViewModel
  {

    #region Public Properties
    /// <summary>
    /// The chat list items for the list
    /// </summary>
    public List<ChatMessageListItemViewModel> Items { get; set; }

    /// <summary>
    /// True to show the attached menu, false to hide it
    /// </summary>
    public bool AttachmentMenuVisible { get; set; }
    #endregion

    #region Public Command
    /// <summary>
    /// The command for when the attachment button is clicked
    /// </summary>
    public ICommand AttachmentButtonCommand { get; set; }
    #endregion

    #region Constructor
    /// <summary>
    /// Default constructor
    /// </summary>
    public ChatMessageListViewModel()
    {
      // Create commands
      AttachmentButtonCommand = new RelayCommand(AttachmentButton);
    }
    #endregion

    #region Command Methods
    /// <summary>
    /// When the attachment button is clicked show/hide the attachment popup
    /// </summary>
    public void AttachmentButton()
    {
      // Tooggle menu visibility
      AttachmentMenuVisible ^= true;
    }
    #endregion
  }
}

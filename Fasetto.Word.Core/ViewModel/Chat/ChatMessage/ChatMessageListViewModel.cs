using System.Collections.Generic;

namespace Fasetto.Word.Core
{
  /// <summary>
  /// A view model for the overview chat list
  /// </summary>
  public class ChatMessageListViewModel : BaseViewModel
    {
        /// <summary>
        /// The chat list items for the list
        /// </summary>
        public List<ChatMessageListItemViewModel> Items { get; set; }
    }
}

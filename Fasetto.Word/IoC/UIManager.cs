﻿using System.Threading.Tasks;
using System.Windows;
using Fasetto.Word.Core;

namespace Fasetto.Word
{
	/// <summary>
	/// The applications implementation of the <see cref="IUIManager"/>
	/// </summary>
	public class UIManager : IUIManager
	{
		/// <summary>
		/// Display a single message box to the user
		/// </summary>
		/// <param name="viewModel">The view model</param>
		/// <returns></returns>
		public Task ShowMessage(MessageBoxDialogViewModel viewModel)
		{
			return new DialogMessageBox().ShowDialog(viewModel);
		}
	}
}


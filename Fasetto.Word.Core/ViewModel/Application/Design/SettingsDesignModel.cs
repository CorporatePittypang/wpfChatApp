namespace Fasetto.Word.Core
{
    /// <summary>
    /// The design-time data for a <see cref="SettingsViewModel"/>
    /// </summary>
    public class SettingsDesignModel : SettingsViewModel
	{
		/// <summary>
		/// A single instance of the design model
		/// </summary>
		public static SettingsDesignModel Instance => new SettingsDesignModel();


		/// <summary>
		/// Default constructor
		/// </summary>
		public SettingsDesignModel()
		{
			Name     = new TextEntryViewModel { Label = "Name", OriginalText = "Good Boi" };
			Username = new TextEntryViewModel { Label = "Username", OriginalText = "goodboi" };
			Password = new PasswordEntryViewModel { Label = "Password", FakePassword = "********" };
			Email    = new TextEntryViewModel { Label = "Email", OriginalText = "contact@trolol.com" };
		}
	}
}
namespace Fasetto.Word.Core
{
    /// <summary>
    /// Design time data for a <see cref="PasswordEntryViewModel"/>
    /// </summary>
    public class PasswordEntryDesignModel : PasswordEntryViewModel
    {
		/// <summary>
		/// A single instance of the design model
		/// </summary>
		public static PasswordEntryDesignModel Instance => new PasswordEntryDesignModel();

		public PasswordEntryDesignModel()
		{
			Label        = "Name";
            FakePassword = "********";
		}
	}
}

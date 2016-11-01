using Xamarin.Forms;

namespace adal_sample
{
	public partial class adal_samplePage : ContentPage
	{
		public adal_samplePage()
		{
			InitializeComponent();
			logMeInBtn.Clicked += LogMeInBtn_Clicked;
		}

		private async void LogMeInBtn_Clicked(object sender, System.EventArgs e)
		{
			var authenticationService = DependencyService.Get<IAuthenticationService>();

			try
			{
				var authenticationResult = await authenticationService.Authenticate(
					AuthenticationParameters.Authority,
					AuthenticationParameters.GraphResourceUri,
					AuthenticationParameters.ApplicationId,
					AuthenticationParameters.ReturnUri);

				var userInfo = authenticationResult.UserInfo;

				var userName = $"{userInfo.GivenName} {userInfo.FamilyName}";
				await DisplayAlert("Success", userName, "Ok");
			}
			catch
			{
				await DisplayAlert("Failure", "Authentication failed.", "Ok");
			}
		}
	}
}

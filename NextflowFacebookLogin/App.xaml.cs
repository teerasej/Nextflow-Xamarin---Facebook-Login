using Xamarin.Forms;

namespace NextflowFacebookLogin
{
	public partial class App : Application
	{
		public static string accessToken;

		public App()
		{
			InitializeComponent();

			MainPage = new NavigationPage(new NextflowFacebookLoginPage());
		}

		protected override void OnStart()
		{
			// Handle when your app starts
		}

		protected override void OnSleep()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume()
		{
			// Handle when your app resumes
		}
	}
}

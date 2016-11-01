using System.Net.Http;
using System.Threading.Tasks;
using Model;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace NextflowFacebookLogin
{
	public partial class NextflowFacebookLoginPage : ContentPage
	{
		public NextflowFacebookLoginPage()
		{
			InitializeComponent();
		}

		async void Handle_Clicked(object sender, System.EventArgs e)
		{
			MessagingCenter.Subscribe<FacebookLoginPage, string>(this, FacebookLoginPage.LOGIN_COMPLETE, HandleAction);

			await Navigation.PushModalAsync(new FacebookLoginPage());
		}

		async void HandleAction(NextflowFacebookLogin.FacebookLoginPage arg1, string accessToken)
		{
			App.accessToken = accessToken;

			var facebookProfile = await GetFacebookProfileAsync(accessToken);

			name.Text = facebookProfile.Name;
			profileImage.Source = facebookProfile.Picture.Data.Url;
		}

		public async Task<FacebookProfile> GetFacebookProfileAsync(string accessToken)
		{
			var requestUrl =
				"https://graph.facebook.com/v2.8/me/?fields=id,name,gender,picture&access_token="
				+ accessToken;

			var httpClient = new HttpClient();

			var userJson = await httpClient.GetStringAsync(requestUrl);

			var facebookProfile = JsonConvert.DeserializeObject<FacebookProfile>(userJson);

			return facebookProfile;
		}


	}
}

using Facebook;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FacebookFriends
{
    /// <summary>
    /// Interaction logic for LoginDialog.xaml
    /// </summary>
    public partial class LoginDialog : Window
    {
        string accessToken = null;
        public LoginDialog()
        {
            InitializeComponent();
        }
        public Uri GenerateLoginUrl(string appId, string extendedPermissions)
        {
            // parameters["client_id"] = appId;
            dynamic parameters = new ExpandoObject();
            parameters.client_id = appId;
            parameters.redirect_uri = "https://www.facebook.com/connect/login_success.html";

            // The requested response: an access token (token), an authorization code (code), or both (code token).
            parameters.response_type = "token";

            // list of additional display modes can be found at http://developers.facebook.com/docs/reference/dialogs/#display
            parameters.display = "popup";

            // add the 'scope' parameter only if we have extendedPermissions.
            if (!string.IsNullOrWhiteSpace(extendedPermissions))
                parameters.scope = extendedPermissions;

            // generate the login url
            var fb = new FacebookClient();
            return fb.GetLoginUrl(parameters);
        }

        private void FBLogin_Navigated(object sender, NavigationEventArgs e)
        {
            // whenever the browser navigates to a new url, try parsing the url.
            // the url may be the result of OAuth 2.0 authentication.

            var fb = new FacebookClient();
            FacebookOAuthResult oauthResult;
            if (fb.TryParseOAuthCallbackUrl(e.Uri, out oauthResult))
            {
                // The url is the result of OAuth 2.0 authentication
                if (oauthResult.IsSuccess)
                {
                    var accesstoken = oauthResult.AccessToken;
                    FBLogin.IsEnabled = false;
                    accessToken = accesstoken;
                }
                else
                {
                    var errorDescription = oauthResult.ErrorDescription;
                    var errorReason = oauthResult.ErrorReason;
                }
            }
            else
            {
                // The url is NOT the result of OAuth 2.0 authentication.

            }

        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Uri loginUrl = GenerateLoginUrl("628725010617531", "public_profile,user_friends");
            FBLogin.Navigate(loginUrl);
        }

        public string AccessToken
        {
            get { return accessToken; }
        }

        private void btnDialogDone_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }
    }
}

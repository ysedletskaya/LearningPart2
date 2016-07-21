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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<FBUserInformation> fbUsersList = new List<FBUserInformation>();
        public MainWindow()
        {
            InitializeComponent();
        }
        
        public void GetFBFriends(string accesstoken)
        {
            FacebookClient fb = new FacebookClient(accesstoken);
            //dynamic friendListData = fb.Get("/me/friends");
            //JsonArray friends = friendListData.summary as JsonArray;
            //JsonArray fbUsers = new JsonArray();
            //fbUsers = friends;
            //Dictionary<string, string> FBFriends = new Dictionary<string, string>();
            //foreach (JsonObject friend in fbUsers)
            //{
            //    FBFriends.Add(((string)((friend)["name"])), (string)((friend)["id"]));
            //}

            dynamic me = fb.Get("me?fields=friends,name,email");

            string id = me.id; // Store in database
            string email = me.email; // Store in database
            string FBName = me.name; // Store in database            
            var friends = me.friends;
            JsonArray fbFriends = friends["summary"] as JsonArray;

            Dictionary<string, string> FBFriends = new Dictionary<string, string>();

            foreach (JsonObject friend in fbFriends)
            {
                FBFriends.Add(((string)((friend)["name"])), (string)((friend)["id"]));

            }

        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            LoginDialog dialogFBLogin = new LoginDialog();
            if (dialogFBLogin.ShowDialog() == true)
            {
                GetFBFriends(dialogFBLogin.AccessToken);
            }
        }
    }
}

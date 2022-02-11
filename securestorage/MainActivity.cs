using Android.App;
using Android.OS;
using Android.Runtime;
using AndroidX.AppCompat.App;
using Android.Widget;
using Xamarin.Essentials;
using System;
using System.Threading.Tasks;

namespace securestorage
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        EditText username, password;
        Button Login, getdetails, removekey, removeallkey;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            username = FindViewById<EditText>(Resource.Id.username);
            password = FindViewById<EditText>(Resource.Id.password);    
            Login = FindViewById<Button>(Resource.Id.login); 
            getdetails = FindViewById<Button>(Resource.Id.getdetails);  
            removekey = FindViewById<Button>(Resource.Id.removekey);
            removeallkey = FindViewById<Button>(Resource.Id.removeallkey);
            Login.Click += Login_Click;
            getdetails.Click += Getdetails_Click;
            removeallkey.Click += Removeallkey_Click;
            removekey.Click += Removekey_Click;
        }

        private void Removekey_Click(object sender, System.EventArgs e)
        {
            SecureStorage.Remove("Username");
            SecureStorage.Remove("Password");
        }

        private void Removeallkey_Click(object sender, System.EventArgs e)
        {
            SecureStorage.RemoveAll();
        }

        private void Getdetails_Click(object sender, System.EventArgs e)
        {
            _ = GetDetails();
        }

        private async Task GetDetails()
        {
            username.Text = await SecureStorage.GetAsync("Username");
            password.Text = await SecureStorage.GetAsync("Password");   
        }

        private void Login_Click(object sender, System.EventArgs e)
        {
            SecureStorage.SetAsync("Username",username.Text);
            SecureStorage.SetAsync("Password",password.Text);
            username.Text = "";
            password.Text = "";
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}
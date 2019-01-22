using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V4.Widget;
using System;
using Android.Support.V7.Widget;
using Android.Views;
using InternalFunctionsNativeUI.Droid.Views;

namespace InternalFunctionsNativeUI.Droid
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.Light", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        private DrawerLayout _drawerLayout;
        private NavigationView _navigationView;
        private Toolbar _toolbar;
        private ActionBarDrawerToggle _actionBarDrawerToggle;


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.main_layout);

            var fragmentTransaction = this.FragmentManager.BeginTransaction();
            var mainMenuView = new MainMenuView();

            fragmentTransaction.Add(Resource.Id.main_container, mainMenuView);
            fragmentTransaction.Commit();
        }

        public override bool OnOptionsItemSelected(IMenuItem item) => false;
    }
}
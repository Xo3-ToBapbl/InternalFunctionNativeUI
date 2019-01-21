using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V4.Widget;
using System;
using Android.Support.V7.Widget;
using Android.Views;

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

            _toolbar = FindViewById<Toolbar>(Resource.Id.toolBar);
            _drawerLayout = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
            _navigationView = FindViewById<NavigationView>(Resource.Id.navigation_view);
            _actionBarDrawerToggle = new ActionBarDrawerToggle(this, _drawerLayout, _toolbar, Resource.String.opend_drawer_message, Resource.String.closed_drawer_message);
            _drawerLayout.AddDrawerListener(_actionBarDrawerToggle);
            _actionBarDrawerToggle.SyncState();

            SetSupportActionBar(_toolbar);
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            SupportActionBar.SetHomeButtonEnabled(true);
            SupportActionBar.SetHomeAsUpIndicator(Resource.Drawable.ic_menu);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            if (item.ItemId == Android.Resource.Id.Home)
            {
                _drawerLayout.OpenDrawer(Android.Support.V4.View.GravityCompat.Start);
                return true;
            }

            return base.OnOptionsItemSelected(item);
        }
    }
}
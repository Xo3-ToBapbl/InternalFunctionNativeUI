using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V4.Widget;
using Android.Support.V7.App;
using Android.Util;
using Android.Views;
using Android.Widget;
using Toolbar = Android.Support.V7.Widget.Toolbar;

namespace InternalFunctionsNativeUI.Droid.Views
{
    public class MainMenuView : Fragment
    {
        private AppCompatActivity _activity;
        private DrawerLayout _drawerLayout;
        private NavigationView _navigationView;
        private Toolbar _toolbar;
        private ActionBarDrawerToggle _actionBarDrawerToggle;
        private Button _signOutButton;
        private Button _addActivityButton;


        public MainMenuView() { }


        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetHasOptionsMenu(true);
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            return inflater.Inflate(Resource.Layout.main_menu_layout, container, false);
        }

        public override void OnActivityCreated(Bundle savedInstanceState)
        {
            base.OnActivityCreated(savedInstanceState);

            _activity = Activity as AppCompatActivity;

            _signOutButton = Activity.FindViewById<Button>(Resource.Id.signout_button);
            _addActivityButton = Activity.FindViewById<Button>(Resource.Id.add_activity_button);
            _toolbar = Activity.FindViewById<Toolbar>(Resource.Id.toolBar);
            _drawerLayout = Activity.FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
            _navigationView = Activity.FindViewById<NavigationView>(Resource.Id.navigation_view);
            _actionBarDrawerToggle = new ActionBarDrawerToggle(Activity, _drawerLayout, _toolbar, Resource.String.opend_drawer_message, Resource.String.closed_drawer_message);
            _drawerLayout.AddDrawerListener(_actionBarDrawerToggle);
            _actionBarDrawerToggle.SyncState();

            _activity.SetSupportActionBar(_toolbar);
            _activity.SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            _activity.SupportActionBar.SetHomeButtonEnabled(true);

            _signOutButton.Click += NavigateToSignInView;
            _addActivityButton.Click += NavigateToFunctionsView;
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

        private void NavigateToFunctionsView(object sender, EventArgs e)
        {
            var fragmentTransaction = this.FragmentManager.BeginTransaction();
            var functionsView = new FunctionsView();

            fragmentTransaction.Replace(Resource.Id.main_container, functionsView);
            fragmentTransaction.AddToBackStack(null);
            fragmentTransaction.Commit();
        }

        private void NavigateToSignInView(object sender, EventArgs e)
        {
            var fragmentTransaction = this.FragmentManager.BeginTransaction();
            var signInView = new SignInView();

            fragmentTransaction.Replace(Resource.Id.main_container, signInView);
            fragmentTransaction.Commit();
        }
    }
}
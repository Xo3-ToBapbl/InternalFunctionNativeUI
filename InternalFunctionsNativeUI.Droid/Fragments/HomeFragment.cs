using System;
using System.Threading.Tasks;
using Android.App;
using Android.OS;
using Android.Support.Design.Widget;
using Android.Support.V4.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using Toolbar = Android.Support.V7.Widget.Toolbar;

namespace InternalFunctionsNativeUI.Droid.Fragments
{
    public class HomeFragment : Fragment
    {
        private AppCompatActivity _activity;
        private DrawerLayout _drawerLayout;
        private NavigationView _navigationView;
        private Toolbar _toolbar;
        private ActionBarDrawerToggle _actionBarDrawerToggle;
        private Button _signOutButton;
        private Button _addActivityButton;


        public HomeFragment() { }


        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetHasOptionsMenu(true);
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            return inflater.Inflate(Resource.Layout.home_layout, container, false);
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

            _activity?.SetSupportActionBar(_toolbar);
            _activity?.SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            _activity?.SupportActionBar.SetHomeButtonEnabled(true);

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
            var functionsView = new PreviousActivitiesFragment();

            fragmentTransaction.SetCustomAnimations(
                Resource.Animator.slide_in_left,
                Resource.Animator.slide_out_left, 
                Resource.Animator.slide_in_right,
                Resource.Animator.slide_out_right);
            fragmentTransaction.Replace(Resource.Id.main_container, functionsView);
            fragmentTransaction.AddToBackStack(null);
            fragmentTransaction.Commit();
        }

        private async void NavigateToSignInView(object sender, EventArgs e)
        {
            await CloseDrawer();

            var fragmentTransaction = this.FragmentManager.BeginTransaction();
            var signInView = new SignInFragment();

            fragmentTransaction.SetCustomAnimations(
                Resource.Animator.slide_in_right,
                Resource.Animator.slide_out_right); 
            fragmentTransaction.Replace(Resource.Id.main_container, signInView);
            fragmentTransaction.Commit();
        }

        private async Task CloseDrawer()
        {
            _drawerLayout.CloseDrawer(Android.Support.V4.View.GravityCompat.Start);
            await Task.Delay(200);
        }
    }
}
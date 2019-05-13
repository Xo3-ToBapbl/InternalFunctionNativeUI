using System;
using Android.App;
using Android.OS;
using Android.Views;
using Android.Widget;

namespace InternalFunctionsNativeUI.Droid.Fragments
{
    public class SignInFragment : Fragment
    {
        private Button _signInButton;


        public SignInFragment() { }


        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            return inflater.Inflate(Resource.Layout.signin_layout, container, false);
        }

        public override void OnActivityCreated(Bundle savedInstanceState)
        {
            base.OnActivityCreated(savedInstanceState);

            _signInButton = Activity.FindViewById<Button>(Resource.Id.signin_button);
            _signInButton.Click += NavigateToMainMenuView;
        }

        private void NavigateToMainMenuView(object sender, EventArgs e)
        {
            var fragmentTransaction = this.FragmentManager.BeginTransaction();
            var mainMenuView = new HomeFragment();

            fragmentTransaction.SetCustomAnimations(Resource.Animator.slide_in_left, Resource.Animator.slide_out_left, Resource.Animator.slide_out_right, Resource.Animator.slide_in_right);
            fragmentTransaction.Replace(Resource.Id.main_container, mainMenuView);
            fragmentTransaction.Commit();
        }
    }
}
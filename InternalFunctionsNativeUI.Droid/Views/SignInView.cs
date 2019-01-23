using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace InternalFunctionsNativeUI.Droid.Views
{
    public class SignInView : Fragment
    {
        private Button _signInButton;


        public SignInView() { }


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
            var mainMenuView = new MainMenuView();

            fragmentTransaction.Replace(Resource.Id.main_container, mainMenuView);
            fragmentTransaction.Commit();
        }
    }
}
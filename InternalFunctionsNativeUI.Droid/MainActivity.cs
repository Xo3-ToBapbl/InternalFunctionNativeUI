
using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V4.Widget;
using System;
using System.Runtime.Remoting.Contexts;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using InternalFunctionNativeUI.Core.Interfaces;
using InternalFunctionNativeUI.Core.Services;
using InternalFunctionsNativeUI.Droid.Fragments;
using InternalFunctionsNativeUI.Droid.Services;

namespace InternalFunctionsNativeUI.Droid
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.Light", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        public static MainActivity Instance { get; private set; }
        public EditText LogView { get; private set; }


        public MainActivity()
        {
            Instance = this;
        }


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.main_layout);
            LogView = FindViewById<EditText>(Resource.Id.logView);

            FragmentTransaction fragmentTransaction = FragmentManager.BeginTransaction();
            fragmentTransaction.Add(Resource.Id.main_container, new SignInFragment());
            fragmentTransaction.Commit();
            
            SetDependency();
        }

        private void SetDependency()
        {
            DependencyService.Register<ILogger, LogService>();
        }

        public override bool OnOptionsItemSelected(IMenuItem item) => false;
    }
}
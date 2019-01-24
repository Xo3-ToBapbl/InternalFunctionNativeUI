using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Support.V7.Widget;
using Android.Util;
using Android.Views;

namespace InternalFunctionsNativeUI.Droid.Views
{
    public class FunctionsView : Fragment
    {
        private AppCompatActivity _activity;
        private Toolbar _toolbar;


        public FunctionsView() { }


        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            return inflater.Inflate(Resource.Layout.functions_layout, container, false);
        }

        public override void OnActivityCreated(Bundle savedInstanceState)
        {
            base.OnActivityCreated(savedInstanceState);

            _activity = Activity as AppCompatActivity;
            _toolbar = Activity.FindViewById<Toolbar>(Resource.Id.navigationBar);

            _activity.SetSupportActionBar(_toolbar);
            _activity.SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            _activity.SupportActionBar.SetHomeButtonEnabled(true);

            _toolbar.NavigationClick += OnNavigationClick;
        }

        private void OnNavigationClick(object sender, Toolbar.NavigationClickEventArgs e)
        {
            _activity.OnBackPressed();
        }
    }
}
using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Support.V7.Widget;
using Android.Support.V7.Widget.Helper;
using Android.Views;
using InternalFunctionNativeUI.Core.Interfaces;
using InternalFunctionNativeUI.Core.Services;
using InternalFunctionsNativeUI.Droid.RecycleUtilities;

namespace InternalFunctionsNativeUI.Droid.Fragments
{
    public class PreviousActivitiesFragment : Fragment
    {
        private AppCompatActivity _activity;
        private Toolbar _toolbar;
        private RecyclerView _activitiesRecycleView;


        public PreviousActivitiesFragment(){ }


        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            return inflater.Inflate(Resource.Layout.previous_activities_layout, container, false);
        }

        public override void OnActivityCreated(Bundle savedInstanceState)
        {
            base.OnActivityCreated(savedInstanceState);

            _activity = (AppCompatActivity)Activity;
            _toolbar = Activity.FindViewById<Toolbar>(Resource.Id.navigationBar);
            _activitiesRecycleView = Activity.FindViewById<RecyclerView>(Resource.Id.activitiesView);
            var activitiesTouchHelper = new ItemTouchHelper(new ActivitiesSwipeCallback(_activitiesRecycleView));
            activitiesTouchHelper.AttachToRecyclerView(_activitiesRecycleView);

            _activity.SetSupportActionBar(_toolbar);
            _activity.SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            _activity.SupportActionBar.SetHomeButtonEnabled(true);

            _toolbar.NavigationClick += OnNavigationClick;

            _activitiesRecycleView.AddItemDecoration(new DividerItemDecoration(_activitiesRecycleView.Context, DividerItemDecoration.Vertical));
            _activitiesRecycleView.SetLayoutManager(new LinearLayoutManager(_activity));
            _activitiesRecycleView.SetAdapter(new ActivitiesAdapter(DataService.GetActivities()));
        }

        private void OnNavigationClick(object sender, Toolbar.NavigationClickEventArgs e)
        {
            _activity.OnBackPressed();
        }
    }
}
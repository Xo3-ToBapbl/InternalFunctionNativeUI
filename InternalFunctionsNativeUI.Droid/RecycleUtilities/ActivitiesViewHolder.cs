using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;

namespace InternalFunctionsNativeUI.Droid.RecycleUtilities
{
    public class ActivitiesViewHolder : RecyclerView.ViewHolder
    {
        private Action<int> _listener;

        public TextView TitleTextView { get; private set; }
        public TextView DescriptionTextView { get; private set; }
        public View ForegroundView { get; private set; }
        public View BackgroundView { get; private set; }
        public Button DeleteButton { get; private set; }


        public ActivitiesViewHolder(IntPtr javaReference, JniHandleOwnership transfer) : 
            base(javaReference, transfer) { }

        public ActivitiesViewHolder(View itemView, Action<int> listener) : 
            base(itemView)
        {
            _listener = listener ?? throw new ArgumentNullException(nameof(listener));

            TitleTextView = itemView.FindViewById<TextView>(Resource.Id.titleTextView);
            DescriptionTextView = itemView.FindViewById<TextView>(Resource.Id.descriptionTextView);
            ForegroundView = itemView.FindViewById(Resource.Id.foregroundView);
            BackgroundView = itemView.FindViewById(Resource.Id.backgroundView);
            DeleteButton = itemView.FindViewById<Button>(Resource.Id.activityDeleteButton);

            itemView.Touch += ItemViewTouched;
        }


        public void SetBackgroundVisibility(ViewStates viewState)
        {
            if (DeleteButton.Visibility != viewState)
            {
                DeleteButton.Visibility = viewState;
            }
        }

        private void ItemViewTouched(object sender, EventArgs e)
        {
            _listener.Invoke(base.LayoutPosition);
        }
    }
}
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
        public TextView TitleTextView { get; private set; }
        public TextView DescriptionTextView { get; private set; }
        public View ForegroundView { get; private set; }
        public View BackgroundView { get; private set; }


        public ActivitiesViewHolder(IntPtr javaReference, JniHandleOwnership transfer) : 
            base(javaReference, transfer) { }

        public ActivitiesViewHolder(View itemView) : 
            base(itemView)
        {
            TitleTextView = itemView.FindViewById<TextView>(Resource.Id.titleTextView);
            DescriptionTextView = itemView.FindViewById<TextView>(Resource.Id.descriptionTextView);
            ForegroundView = itemView.FindViewById(Resource.Id.foregroundView);
            BackgroundView = itemView.FindViewById(Resource.Id.backgroundView);
        }
    }
}
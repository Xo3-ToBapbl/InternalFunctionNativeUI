using System;
using System.Collections.Generic;
using Android.Support.V7.Widget;
using Android.Views;
using InternalFunctionNativeUI.Core.Models;

namespace InternalFunctionsNativeUI.Droid.RecycleUtilities
{
    public class ActivitiesAdapter : RecyclerView.Adapter
    {
        public IList<ActivityModel> Activities { get; private set; }


        public ActivitiesAdapter(IList<ActivityModel> activities)
        {
            Activities = activities ?? throw new ArgumentNullException();
        }


        public override int ItemCount => Activities.Count;

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            var container = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.activities_item_layout, parent, false);

            return new ActivitiesViewHolder(container, this);
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            var activitiesViewHolder = (ActivitiesViewHolder)holder;
            activitiesViewHolder.TitleTextView.Text = Activities[position].Title;
            activitiesViewHolder.DescriptionTextView.Text = Activities[position].Description;
        }

        public override void OnViewRecycled(Java.Lang.Object holder)
        {
            var activitiesViewHolder = holder as ActivitiesViewHolder;
            activitiesViewHolder.Reset(true);

            base.OnViewRecycled(holder);
        }

        public void RemoveAt(int position)
        {
            Activities.RemoveAt(position);
            NotifyItemRemoved(position);
        }
    }
}
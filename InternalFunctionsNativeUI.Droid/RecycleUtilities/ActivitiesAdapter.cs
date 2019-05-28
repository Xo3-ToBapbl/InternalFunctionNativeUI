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
using InternalFunctionNativeUI.Core.Models;

namespace InternalFunctionsNativeUI.Droid.RecycleUtilities
{
    public class ActivitiesAdapter : RecyclerView.Adapter
    {
        public IList<ActivityModel> Activities { get; private set; }
        public event EventHandler<int> ItemTouch;


        public ActivitiesAdapter(IList<ActivityModel> activities)
        {
            Activities = activities ?? throw new ArgumentNullException();
        }


        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            var activitiesViewHolder = (ActivitiesViewHolder)holder;
            activitiesViewHolder.TitleTextView.Text = Activities[position].Title;
            activitiesViewHolder.DescriptionTextView.Text = Activities[position].Description;
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            var container = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.activities_item_layout, parent, false);
            return new ActivitiesViewHolder(container, OnItemTouch);
        }

        public override int ItemCount => Activities.Count;

        private void OnItemTouch(int position) => ItemTouch?.Invoke(this, position);
    }
}
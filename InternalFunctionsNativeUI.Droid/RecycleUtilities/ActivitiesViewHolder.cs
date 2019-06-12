using System;
using Android.Animation;
using Android.App;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;

namespace InternalFunctionsNativeUI.Droid.RecycleUtilities
{
    public class ActivitiesViewHolder : RecyclerView.ViewHolder
    {
        private float _menuWidth;
        private ActivitiesAdapter _adapter;

        public float CurrentX { get; set; }
        public float CurrentY { get; set; }
        public bool IsViewMovingInactively { get; set; }
        public bool IsMenuActive { get; set; }
        public TextView TitleTextView { get; private set; }
        public TextView DescriptionTextView { get; private set; }
        public View ForegroundView { get; private set; }
        public View BackgroundView { get; private set; }
        public Button DeleteButton { get; private set; }


        public ActivitiesViewHolder(IntPtr javaReference, JniHandleOwnership transfer) : 
            base(javaReference, transfer) { }

        public ActivitiesViewHolder(View itemView, ActivitiesAdapter adapter) : 
            base(itemView)
        {
            _adapter = adapter;
            _menuWidth = Application.Context.Resources.GetDimension(Resource.Dimension.left_swipe_menu_width);

            TitleTextView = ItemView.FindViewById<TextView>(Resource.Id.titleTextView);
            DescriptionTextView = ItemView.FindViewById<TextView>(Resource.Id.descriptionTextView);
            ForegroundView = ItemView.FindViewById(Resource.Id.foregroundView);
            BackgroundView = ItemView.FindViewById(Resource.Id.backgroundView);
            DeleteButton = ItemView.FindViewById<Button>(Resource.Id.activityDeleteButton);

            ItemView.Touch += ItemViewTouched;
        }


        public void UpdateMenuVisibility()
        {
            IsMenuActive = Math.Abs(CurrentX) > _menuWidth;
            
            if (IsMenuActive)
            {
                DeleteButton.Click += DeleteButtonClicked;
            }
            else
            {
                DeleteButton.Click -= DeleteButtonClicked;
            }
        }

        private void DeleteButtonClicked(object sender, EventArgs e)
        {
            MoveForegroundViewTo(0, 75, () => 
            {
                IsMenuActive = false;
                DeleteButton.Click -= DeleteButtonClicked;

                _adapter.RemoveAt(LayoutPosition);
            });
        }

        public void Reset(bool immediately=false)
        {
            if (immediately)
                MoveForegroundViewTo(0, 0);

            DeleteButton.Click -= DeleteButtonClicked;
            IsMenuActive = false;
            MoveForegroundViewTo(0);
        }

        public void MoveForegroundViewTo(float translationX, long duration=125, Action endAction=null)
        {
            IsViewMovingInactively = true;

            var animator = ObjectAnimator.OfFloat(ForegroundView, nameof(View.TranslationX), translationX);
            animator.AnimationEnd += (s, e) => { IsViewMovingInactively = false; endAction?.Invoke(); };
            animator.SetDuration(duration);
            animator.Start();
        }

        public void SetBackgroundVisibility(ViewStates viewState)
        {
            if (DeleteButton.Visibility != viewState)
            {
                DeleteButton.Visibility = viewState;
            }
        }

        private void ItemViewTouched(object sender, EventArgs e) { }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                ItemView.Touch -= ItemViewTouched;
            }

            base.Dispose(disposing);
        }
    }
}
using Android.Views;
using System;

namespace InternalFunctionsNativeUI.Droid.RecycleUtilities
{
    public class ActivitiesTouchListener : Java.Lang.Object, View.IOnTouchListener
    {
        private readonly ActivitiesSwipeCallback _callback;


        public ActivitiesTouchListener(ActivitiesSwipeCallback callback)
        {
            _callback = callback ?? throw new ArgumentNullException(nameof(callback));
        }


        public bool OnTouch(View view, MotionEvent e)
        {
            _callback.ShouldSwipeBack = e.Action == MotionEventActions.Cancel ||
                                        e.Action == MotionEventActions.Up;

            if (e.Action == MotionEventActions.Up)
            {
                _callback.CurrentViewHolder?.UpdateMenuVisibility();
            }

            return false;
        }
    }
}
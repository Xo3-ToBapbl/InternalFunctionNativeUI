using Android.Views;
using InternalFunctionNativeUI.Core.Interfaces;
using InternalFunctionNativeUI.Core.Services;
using System;

namespace InternalFunctionsNativeUI.Droid.RecycleUtilities
{
    public class ActivitiesTouchListener : Java.Lang.Object, View.IOnTouchListener
    {
        private readonly ActivitiesSwipeCallback _callback;
        private readonly ILogger _logger;


        public ActivitiesTouchListener(ActivitiesSwipeCallback callback)
        {
            _callback = callback ?? throw new ArgumentNullException(nameof(callback));
            _logger = DependencyService.Get<ILogger>();
        }


        public bool OnTouch(View view, MotionEvent e)
        {
            _callback.ShouldSwipeBack = e.Action == MotionEventActions.Cancel ||
                                        e.Action == MotionEventActions.Up;

            if (e.Action == MotionEventActions.Up)
                _callback.UpdateMenuActivity();

            return false;
        }
    }
}
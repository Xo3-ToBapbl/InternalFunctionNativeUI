using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using InternalFunctionNativeUI.Core.Interfaces;
using InternalFunctionNativeUI.Core.Services;

namespace InternalFunctionsNativeUI.Droid.RecycleUtilities
{
    public class ActivitiesTouchListener : Java.Lang.Object,  View.IOnTouchListener
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
            //_logger.LogToView("Listener", nameof(OnTouch), e.Action.ToString());

            _callback.ShouldSwipeBack = e.Action == MotionEventActions.Cancel || e.Action == MotionEventActions.Up;

            if (e.Action == MotionEventActions.Up)
            {
                _callback.UpdateMenuActivity();
            }

            return false;
        }
    }
}
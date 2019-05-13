using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Support.V7.Widget.Helper;
using Android.Views;
using Android.Widget;
using InternalFunctionNativeUI.Core.Interfaces;
using InternalFunctionNativeUI.Core.Services;

namespace InternalFunctionsNativeUI.Droid.RecycleUtilities
{
    public class ActivitiesSwipeCallback : ItemTouchHelper.Callback
    {
        private readonly float _menuWidth;
        private readonly ILogger _logger;
        public float X;

        public bool ShouldSwipeBack { get; set; }
        public bool IsMenuActive { get; set; }


        public ActivitiesSwipeCallback(RecyclerView recyclerView)
        {
            recyclerView.SetOnTouchListener(new ActivitiesTouchListener(this));
            _logger = DependencyService.Get<ILogger>();
            _menuWidth = Application.Context.Resources.GetDimension(Resource.Dimension.left_swipe_menu_width);
        }


        public override int GetMovementFlags(RecyclerView recyclerView, RecyclerView.ViewHolder viewHolder)
        {
            //_logger.LogToView("CallBac", nameof(GetMovementFlags));

            return IsMenuActive ? MakeMovementFlags(0, ItemTouchHelper.Left | ItemTouchHelper.Right) :
                                  MakeMovementFlags(0, ItemTouchHelper.Left);
        }

        public override bool OnMove(RecyclerView recyclerView, RecyclerView.ViewHolder viewHolder, RecyclerView.ViewHolder target)
        {
            return false;
        }

        public override void OnSwiped(RecyclerView.ViewHolder viewHolder, int direction)
        {
        }

        public override int ConvertToAbsoluteDirection(int flags, int layoutDirection)
        {
            var result = base.ConvertToAbsoluteDirection(flags, layoutDirection);
            //_logger.LogToView("CallBack", "AbsDirection", $"Flags={flags} Dir={layoutDirection} Res={result}");

            if (ShouldSwipeBack)
            {
                ShouldSwipeBack = false;
                return 0;
            }

            return result;
        }

        public override void OnChildDraw(Canvas canvas, RecyclerView recyclerView, RecyclerView.ViewHolder viewHolder, float dX, float dY, int actionState, bool isCurrentlyActive)
        {
            if (actionState == ItemTouchHelper.ActionStateSwipe)
            {
                if (isCurrentlyActive)
                {
                    HandleActiveSwipe(recyclerView, canvas, (ActivitiesViewHolder)viewHolder, dX, dY, actionState);
                }
                else
                {
                    HandleInactiveSwipe(recyclerView, canvas, (ActivitiesViewHolder)viewHolder, dX, dY, actionState);
                }
            }
        }

        private void HandleActiveSwipe(RecyclerView recyclerView, Canvas canvas, ActivitiesViewHolder viewHolder, float dX, float dY, int actionState)
        {
            if (IsMenuActive)
            {
                if (dX <= 0)
                {
                    X = dX - _menuWidth;
                    DefaultUIUtil.OnDraw(canvas, recyclerView, viewHolder.ForegroundView, X, dY, actionState, true);

                    //_logger.LogToView("CallBack", "ActiveSwipe", $"X={X:0.00} dX={dX:0.00} Menu={IsMenuActive}");
                }
                else
                {
                    X = (dX - _menuWidth) >= 0 ? 0 : dX - _menuWidth;
                    DefaultUIUtil.OnDraw(canvas, recyclerView, viewHolder.ForegroundView, X, dY, actionState, true);

                    //_logger.LogToView("CallBack", "ActiveSwipe", $"X={X:0.00} dX={dX:0.00} Menu={IsMenuActive}");
                }
            }
            else
            {
                X = dX;
                DefaultUIUtil.OnDraw(canvas, recyclerView, viewHolder.ForegroundView, X, dY, actionState, true);

                //_logger.LogToView("CallBack", "ActiveSwipe", $"X={X:0.00} dX={dX:0.00} Menu={IsMenuActive}");
            }
            

        }

        private void HandleInactiveSwipe(RecyclerView recyclerView, Canvas canvas, ActivitiesViewHolder viewHolder, float dX, float dY, int actionState)
        {
            if (IsMenuActive)
            {
                X = Math.Min(dX, -_menuWidth);
                DefaultUIUtil.OnDraw(canvas, recyclerView, viewHolder.ForegroundView, X, dY, actionState, false);

                //_logger.LogToView("CallBack", "InActiveSwipe", $"X={X:0.00} dX={dX:0.00} Menu={IsMenuActive}");
            }
            else
            {
                if (dX <= 0)
                {
                    X = dX;
                    DefaultUIUtil.OnDraw(canvas, recyclerView, viewHolder.ForegroundView, X, dY, actionState, false);
                    //_logger.LogToView("CallBack", "InActiveSwipe", $"X={X:0.00} dX={dX:0.00} Menu={IsMenuActive}");
                }
                else
                {
                    X = Math.Max(X, -dX);
                    DefaultUIUtil.OnDraw(canvas, recyclerView, viewHolder.ForegroundView, X, dY, actionState, false);
                   // _logger.LogToView("CallBack", "InActiveSwipe", $"X={X:0.00} dX={dX:0.00} Menu={IsMenuActive}");
                }
            }
        }

        public bool UpdateMenuActivity()
        {
            IsMenuActive = Math.Abs(X) >= _menuWidth;
            //_logger.LogToView("CallBack", nameof(UpdateMenuActivity), $"X={X:0.00} Menu={IsMenuActive}");
            return IsMenuActive;
        }

        public override void ClearView(RecyclerView recyclerView, RecyclerView.ViewHolder viewHolder)
        {
            base.ClearView(recyclerView, viewHolder);
            UpdateMenuActivity();
        }
    }
}
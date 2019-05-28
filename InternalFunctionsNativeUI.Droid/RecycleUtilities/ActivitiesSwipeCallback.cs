using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using Android.Animation;
using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Support.V7.Widget.Helper;
using Android.Views;
using Android.Widget;
using Android.Util;
using InternalFunctionNativeUI.Core.Interfaces;
using InternalFunctionNativeUI.Core.Services;

namespace InternalFunctionsNativeUI.Droid.RecycleUtilities
{
    public class ActivitiesSwipeCallback : ItemTouchHelper.Callback
    {
        private readonly float _menuWidth;
        private readonly ILogger _logger;
        private readonly ActivitiesAdapter _adapter;
        private View _currentView;
        private int _currentLayoutPosition;
        private bool _isViewMoving;
        public float X;

        public bool ShouldSwipeBack { get; set; }
        public bool IsMenuActive { get; set; }


        public ActivitiesSwipeCallback(RecyclerView recyclerView, ActivitiesAdapter adapter)
        {
            recyclerView.SetOnTouchListener(new ActivitiesTouchListener(this));

            _adapter = adapter;
            _adapter.ItemTouch += ItemTouched;
            _currentLayoutPosition = -1;
            _logger = DependencyService.Get<ILogger>();
            _menuWidth = Application.Context.Resources.GetDimension(Resource.Dimension.left_swipe_menu_width);
        }

        private void ItemTouched(object sender, int layoutPosition)
        {
            if (layoutPosition != _currentLayoutPosition)
            {
                _currentLayoutPosition = layoutPosition;

                if (_currentView != null)
                {
                    MoveViewTo(_currentView, 0);
                }
            }
        }

        public override int GetMovementFlags(RecyclerView recyclerView, RecyclerView.ViewHolder viewHolder)
        {
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
            X = IsMenuActive ? (dX - _menuWidth) >= 0 ? 0 : dX - _menuWidth : dX;
            DefaultUIUtil.OnDraw(canvas, recyclerView, viewHolder.ForegroundView, X, dY, actionState, true);
        }

        private void HandleInactiveSwipe(RecyclerView recyclerView, Canvas canvas, ActivitiesViewHolder viewHolder, float dX, float dY, int actionState)
        {
            X = IsMenuActive ? -_menuWidth : 0;
            if(!_isViewMoving) MoveViewTo(viewHolder.ForegroundView, X);
        }

        private void MoveViewTo(View view, float translationX)
        {
            _currentView = view;
            _isViewMoving = true;

            var animator = ObjectAnimator.OfFloat(view, nameof(View.TranslationX), translationX);
            animator.AnimationEnd += (s, e) => _isViewMoving = false;
            animator.SetDuration(125);
            animator.Start();
        }

        public bool UpdateMenuActivity()
        {
            IsMenuActive = Math.Abs(X) >= _menuWidth;
            return IsMenuActive;
        }

        public override void ClearView(RecyclerView recyclerView, RecyclerView.ViewHolder viewHolder)
        {
            base.ClearView(recyclerView, viewHolder);
            UpdateMenuActivity();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _adapter.ItemTouch -= ItemTouched;
            }

            base.Dispose(disposing);
        }
    }
}
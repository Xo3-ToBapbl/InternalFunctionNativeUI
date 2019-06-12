using Android.App;
using Android.Graphics;
using Android.Support.V7.Widget;
using Android.Support.V7.Widget.Helper;

namespace InternalFunctionsNativeUI.Droid.RecycleUtilities
{
    public class ActivitiesSwipeCallback : ItemTouchHelper.Callback
    {
        private float _menuWidth;

        public ActivitiesViewHolder CurrentViewHolder { get; private set; }
        public bool ShouldSwipeBack { get; set; }


        static ActivitiesSwipeCallback() { }

        public ActivitiesSwipeCallback(RecyclerView recyclerView)
        {
            recyclerView.SetOnTouchListener(new ActivitiesTouchListener(this));

            _menuWidth = Application.Context.Resources.GetDimension(Resource.Dimension.left_swipe_menu_width);
        }


        public override int GetMovementFlags(RecyclerView recyclerView, RecyclerView.ViewHolder viewHolder)
        {
            return CurrentViewHolder != null && CurrentViewHolder.IsMenuActive ? 
                   MakeMovementFlags(0, ItemTouchHelper.Left | ItemTouchHelper.Right) :
                   MakeMovementFlags(0, ItemTouchHelper.Left);
        }

        public override bool OnMove(RecyclerView recyclerView, RecyclerView.ViewHolder viewHolder, RecyclerView.ViewHolder target)
        {
            return false;
        }

        public override void OnSwiped(RecyclerView.ViewHolder viewHolder, int direction) { }

        public override int ConvertToAbsoluteDirection(int flags, int layoutDirection)
        {
            if (ShouldSwipeBack)
            {
                ShouldSwipeBack = false;
                return 0;
            }

            return base.ConvertToAbsoluteDirection(flags, layoutDirection);
        }

        public override void OnChildDraw(Canvas canvas, RecyclerView recyclerView, RecyclerView.ViewHolder viewHolder, float dX, float dY, int actionState, bool isCurrentlyActive)
        {
            var currentViewHolder = viewHolder as ActivitiesViewHolder;
            if (CurrentViewHolder != null &&
                CurrentViewHolder.LayoutPosition != currentViewHolder.LayoutPosition)
            {
                CurrentViewHolder.Reset();
            }
            CurrentViewHolder = currentViewHolder;
            CurrentViewHolder.CurrentX = dX;
            CurrentViewHolder.CurrentY = dY;

            if (actionState == ItemTouchHelper.ActionStateSwipe)
            {
                if (isCurrentlyActive)
                {
                    HandleActiveSwipe(recyclerView, canvas, CurrentViewHolder, actionState);
                }
                else
                {
                    HandleInactiveSwipe(CurrentViewHolder);
                }
            }
        }

        private void HandleActiveSwipe(RecyclerView recyclerView, Canvas canvas, ActivitiesViewHolder viewHolder, int actionState)
        {
            viewHolder.CurrentX = viewHolder.IsMenuActive ? 
                                 (viewHolder.CurrentX - _menuWidth >= 0 ? 0 : viewHolder.CurrentX - _menuWidth) : 
                                 (viewHolder.CurrentX >= 0 ? 0 : viewHolder.CurrentX);

            DefaultUIUtil.OnDraw(c: canvas,
                                 recyclerView: recyclerView,
                                 view: viewHolder.ForegroundView, 
                                 dX: viewHolder.CurrentX,
                                 dY: viewHolder.CurrentY, 
                                 actionState: actionState, 
                                 isCurrentlyActive: true);
        }

        private void HandleInactiveSwipe(ActivitiesViewHolder viewHolder)
        {
            viewHolder.CurrentX = viewHolder.IsMenuActive ? -_menuWidth : 0;

            if (!viewHolder.IsViewMovingInactively)
            {
                viewHolder.MoveForegroundViewTo(viewHolder.CurrentX);
            }
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}
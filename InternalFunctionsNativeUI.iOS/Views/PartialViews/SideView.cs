using System;
using System.Drawing;

using CoreGraphics;
using Foundation;
using InternalFunctionsNativeUI.iOS.Extensions;
using InternalFunctionsNativeUI.iOS.Utilities;
using UIKit;

namespace InternalFunctionsNativeUI.iOS.Views.PartialViews
{
    [Register("SideView")]
    public class SideView : UIView
    {
        private UIView _topView;
        private UIView _bottomView;
        private UIView _circleView;
        private UILabel _avatarLabel;


        public SideView()
        {
            Initialize();
        }

        public SideView(RectangleF bounds) : base(bounds)
        {
            Initialize();
        }


        void Initialize()
        {
            this.CreateControls();
            this.AdjustControls();

            this.BackgroundColor = UIColor.White;

            AddSubviews(_topView, _bottomView, _circleView, _avatarLabel);

            this.SetConstraints();
        }

        private void CreateControls()
        {
            _topView = new UIView();
            _bottomView = new UIView();
            _circleView = new CircleView();
            _avatarLabel = new UILabel();
        }

        private void AdjustControls()
        {
            _topView.BackgroundColor = UIColor.Clear.FromHex(Constants.Colors.LightAzure);

            _avatarLabel.Text = "PP";
            _avatarLabel.TextColor = UIColor.White;
            _avatarLabel.TextAlignment = UITextAlignment.Center;
            _avatarLabel.Font = _avatarLabel.Font.WithSize(50);

            _bottomView.BackgroundColor = UIColor.Clear.FromHex(Constants.Colors.LightAzure);
        }

        private void SetConstraints()
        {
            DisableAutoresizingMasks();

            var constraints = new NSLayoutConstraint[]
            {
                NSLayoutConstraint.Create(_topView, NSLayoutAttribute.Height, NSLayoutRelation.Equal, this, NSLayoutAttribute.Height, 0.46f, 0),
                _topView.TopAnchor.ConstraintEqualTo(this.TopAnchor),
                _topView.LeftAnchor.ConstraintEqualTo(this.LeftAnchor),
                _topView.RightAnchor.ConstraintEqualTo(this.RightAnchor),

                NSLayoutConstraint.Create(_bottomView, NSLayoutAttribute.Height, NSLayoutRelation.Equal, this, NSLayoutAttribute.Height, 0.08f, 0),
                _bottomView.BottomAnchor.ConstraintEqualTo(this.BottomAnchor),
                _bottomView.LeftAnchor.ConstraintEqualTo(this.LeftAnchor),
                _bottomView.RightAnchor.ConstraintEqualTo(this.RightAnchor),

                _circleView.HeightAnchor.ConstraintEqualTo(120),
                _circleView.WidthAnchor.ConstraintEqualTo(120),
                _circleView.CenterXAnchor.ConstraintEqualTo(_topView.CenterXAnchor),
                _circleView.CenterYAnchor.ConstraintEqualTo(_topView.CenterYAnchor),

                _avatarLabel.CenterXAnchor.ConstraintEqualTo(_circleView.CenterXAnchor),
                _avatarLabel.CenterYAnchor.ConstraintEqualTo(_circleView.CenterYAnchor),
            };

            NSLayoutConstraint.ActivateConstraints(constraints);
        }

        private void DisableAutoresizingMasks()
        {
            foreach (var view in this)
            {
                ((UIView)view).TranslatesAutoresizingMaskIntoConstraints = false;
            }
        }
    }
}
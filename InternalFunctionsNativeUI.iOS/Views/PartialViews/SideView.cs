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

            AddSubviews(_topView, _bottomView);

            this.SetConstraints();
        }

        private void CreateControls()
        {
            _topView = new UIView();
            _bottomView = new UIView();
        }

        private void AdjustControls()
        {
            _topView.BackgroundColor = UIColor.Clear.FromHex(Constants.Colors.LightAzure);
            _topView.TranslatesAutoresizingMaskIntoConstraints = false;

            _bottomView.BackgroundColor = UIColor.Clear.FromHex(Constants.Colors.LightAzure);
            _bottomView.TranslatesAutoresizingMaskIntoConstraints = false;
        }

        private void SetConstraints()
        {
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
            };

            NSLayoutConstraint.ActivateConstraints(constraints);
        }
    }
}
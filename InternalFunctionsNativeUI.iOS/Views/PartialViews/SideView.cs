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
        private UILabel _fullNameLabel;
        private UILabel _emailLabel;
        private UIButton _signOutButton;
        private UILabel _appVersionLabel;
        private UISwitch _nightModeSwitch;
        private UILabel _nightModeLabel;


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

            AddSubviews(
                _topView, 
                _bottomView, 
                _circleView, 
                _avatarLabel, 
                _fullNameLabel, 
                _emailLabel, 
                _signOutButton, 
                _appVersionLabel, 
                _nightModeSwitch,
                _nightModeLabel);

            this.SetConstraints();
        }

        private void CreateControls()
        {
            _topView = new UIView();
            _bottomView = new UIView();
            _circleView = new CircleView();
            _avatarLabel = new UILabel();
            _fullNameLabel = new UILabel();
            _emailLabel = new UILabel();
            _signOutButton = UIButton.FromType(UIButtonType.RoundedRect);
            _appVersionLabel = new UILabel();
            _nightModeSwitch = new UISwitch();
            _nightModeLabel = new UILabel();
        }

        private void AdjustControls()
        {
            _topView.BackgroundColor = UIColor.Clear.FromHex(Colors.LightAzure);
            _bottomView.BackgroundColor = UIColor.Clear.FromHex(Colors.LightAzure);

            _avatarLabel.Text = "PP";
            _avatarLabel.TextColor = UIColor.White;
            _avatarLabel.TextAlignment = UITextAlignment.Center;
            _avatarLabel.Font = _avatarLabel.Font.WithSize(Dimens.TextSizeAvatar);

            _fullNameLabel.Text = "Pavel Petrovich";
            _fullNameLabel.TextColor = UIColor.White;
            _fullNameLabel.TextAlignment = UITextAlignment.Center;
            _fullNameLabel.Font = _fullNameLabel.Font.WithSize(Dimens.TextSizeTitle);

            _emailLabel.Text = "p.petrovich@godeltech.com";
            _emailLabel.TextColor = UIColor.White;
            _emailLabel.TextAlignment = UITextAlignment.Center;
            _emailLabel.Font = _emailLabel.Font.WithSize(Dimens.TextSizeAdditional);

            _signOutButton.BackgroundColor = UIColor.Clear.FromHex(Colors.LightPurple);
            _signOutButton.Layer.CornerRadius = 21f;
            _signOutButton.SetTitle("Sign Out", UIControlState.Normal);
            _signOutButton.SetTitleColor(UIColor.Black, UIControlState.Normal);

            _appVersionLabel.Text = "App Version: 1.0";
            _appVersionLabel.TextColor = UIColor.Clear.FromHex(Colors.SemiWhite);
            _appVersionLabel.TextAlignment = UITextAlignment.Left;
            _appVersionLabel.Font = _appVersionLabel.Font.WithSize(Dimens.TextSizeMicro);

            _nightModeSwitch.OnTintColor = UIColor.Clear.FromHex(Colors.DarkAzure);
            _nightModeSwitch.Transform = CGAffineTransform.MakeScale(0.8f, 0.8f);

            _nightModeLabel.Text = "Night Mode";
            _nightModeLabel.TextColor = UIColor.White;
            _nightModeLabel.TextAlignment = UITextAlignment.Right;
            _nightModeLabel.Font = _nightModeLabel.Font.WithSize(Dimens.TextSizeAdditional);
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

                _fullNameLabel.CenterXAnchor.ConstraintEqualTo(_circleView.CenterXAnchor),
                _fullNameLabel.CenterYAnchor.ConstraintEqualTo(_circleView.CenterYAnchor, 80),

                _emailLabel.CenterXAnchor.ConstraintEqualTo(_fullNameLabel.CenterXAnchor),
                _emailLabel.TopAnchor.ConstraintEqualTo(_fullNameLabel.BottomAnchor),

                _signOutButton.CenterXAnchor.ConstraintEqualTo(this.CenterXAnchor),
                _signOutButton.HeightAnchor.ConstraintEqualTo(42f),
                _signOutButton.LeadingAnchor.ConstraintEqualTo(this.LeadingAnchor, 40f),
                _signOutButton.BottomAnchor.ConstraintEqualTo(_bottomView.TopAnchor, -10),

                _appVersionLabel.CenterYAnchor.ConstraintEqualTo(_bottomView.CenterYAnchor),
                _appVersionLabel.LeftAnchor.ConstraintEqualTo(_bottomView.LeftAnchor, 10),

                _nightModeSwitch.CenterYAnchor.ConstraintEqualTo(_bottomView.CenterYAnchor),
                _nightModeSwitch.RightAnchor.ConstraintEqualTo(_bottomView.RightAnchor, -10),

                _nightModeLabel.CenterYAnchor.ConstraintEqualTo(_bottomView.CenterYAnchor),
                _nightModeLabel.RightAnchor.ConstraintEqualTo(_nightModeSwitch.LeftAnchor, -10),
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
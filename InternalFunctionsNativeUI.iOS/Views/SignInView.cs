using System;
using CoreGraphics;
using Foundation;
using InternalFunctionsNativeUI.iOS.Extensions;
using InternalFunctionsNativeUI.iOS.Utilities;
using UIKit;

namespace InternalFunctionsNativeUI.iOS.Views
{
    [Register("SignInView")]
    public class SignInView : UIViewController
    {
        private UILabel _appNameLabel;
        private UIImageView _logoImageView;
        private UIImage _logoImage;
        private UIButton _signInButton;


        public SignInView()
        {
        }


        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            this.CreateControls();
            this.AdjustControls();

            NavigationController.SetNavigationBarHidden(true, false);
            View.BackgroundColor = UIColor.White;
            View.AddSubviews(_logoImageView, _appNameLabel, _signInButton);

            this.SetConstraints();
        }

        private void CreateControls()
        {
            _appNameLabel = new UILabel();
            _logoImageView = new UIImageView();
            _logoImage = UIImage.FromBundle(Constants.Paths.Images.GodelLogoLight);
            _signInButton = UIButton.FromType(UIButtonType.RoundedRect);
        }

        private void AdjustControls()
        {
            _appNameLabel.Text = Constants.AppName;
            _appNameLabel.TextColor = UIColor.Black;
            _appNameLabel.TextAlignment = UITextAlignment.Center;
            _appNameLabel.TranslatesAutoresizingMaskIntoConstraints = false;

            _logoImageView.Image = _logoImage;
            _logoImageView.TranslatesAutoresizingMaskIntoConstraints = false;

            _signInButton.BackgroundColor = UIColor.Clear.FromHex(Constants.Colors.LightAzure);
            _signInButton.Layer.CornerRadius = 26f;
            _signInButton.SetTitle("Sign In", UIControlState.Normal);
            _signInButton.SetTitleColor(UIColor.Black, UIControlState.Normal);
            _signInButton.TranslatesAutoresizingMaskIntoConstraints = false;
            _signInButton.TouchDown += SignInButtonOnTouchDown;
        }

        private void SignInButtonOnTouchDown(object sender, EventArgs e)
        {
            NavigationController.PushViewController(new MenuView(), true);
        }

        private void SetConstraints()
        {
            var constraints = new[]
            {
                NSLayoutConstraint.Create(_logoImageView, NSLayoutAttribute.CenterY, NSLayoutRelation.Equal, View,NSLayoutAttribute.CenterY, 0.5f, 0f),
                _logoImageView.HeightAnchor.ConstraintEqualTo(_logoImage.Size.Height),
                _logoImageView.CenterXAnchor.ConstraintEqualTo(View.CenterXAnchor),
                _logoImageView.WidthAnchor.ConstraintEqualTo(_logoImage.Size.Width),

                _appNameLabel.WidthAnchor.ConstraintEqualTo(View.WidthAnchor),
                _appNameLabel.HeightAnchor.ConstraintGreaterThanOrEqualTo(30),
                _appNameLabel.TopAnchor.ConstraintEqualTo(_logoImageView.BottomAnchor,10),

                NSLayoutConstraint.Create(_signInButton, NSLayoutAttribute.CenterY, NSLayoutRelation.Equal, View, NSLayoutAttribute.CenterY, 1.5f, 0f),
                _signInButton.HeightAnchor.ConstraintEqualTo(52f),
                _signInButton.LeadingAnchor.ConstraintEqualTo(View.LeadingAnchor, 40f),
                _signInButton.CenterXAnchor.ConstraintEqualTo(View.CenterXAnchor),
            };

            NSLayoutConstraint.ActivateConstraints(constraints);
        }
    }
}
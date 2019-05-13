using System;
using Foundation;
using InternalFunctionsNativeUI.iOS.Extensions;
using InternalFunctionsNativeUI.iOS.Utilities;
using InternalFunctionsNativeUI.iOS.Views;
using UIKit;

namespace InternalFunctionsNativeUI.iOS.ViewControllers
{
    [Register("SignInViewController")]
    public class SignInViewController : UIViewController
    {
        private UILabel _appNameLabel;
        private UIImageView _logoImageView;
        private UIImage _logoImage;
        private UIButton _signInButton;


        public SignInViewController(){ }


        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            this.NavigationController.SetNavigationBarHidden(true, false);
        }

        public override void LoadView()
        {
            base.LoadView();

            this.CreateControls();
            this.AdjustControls();

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

            _logoImageView.Image = _logoImage;

            _signInButton.BackgroundColor = UIColor.Clear.FromHex(Colors.LightAzure);
            _signInButton.Layer.CornerRadius = Dimens.ButtonCornerRadiusCommon;
            _signInButton.SetTitle("Sign In", UIControlState.Normal);
            _signInButton.SetTitleColor(UIColor.Black, UIControlState.Normal);
            _signInButton.TouchDown += SignInButtonOnTouchDown;
        }

        private void SetConstraints()
        {
            DisableAutoresizingMasks();

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
                _signInButton.HeightAnchor.ConstraintEqualTo(Dimens.ButtonHeightCommon),
                _signInButton.LeadingAnchor.ConstraintEqualTo(View.LeadingAnchor, Dimens.ButtonMarginCommon),
                _signInButton.CenterXAnchor.ConstraintEqualTo(View.CenterXAnchor),
            };

            NSLayoutConstraint.ActivateConstraints(constraints);
        }

        private void DisableAutoresizingMasks()
        {
            foreach (var view in this.View)
            {
                ((UIView)view).TranslatesAutoresizingMaskIntoConstraints = false;
            }
        }

        private void SignInButtonOnTouchDown(object sender, EventArgs e)
        {
            NavigationController.PushViewController(new HomeViewController(), true);
        }
    }
}
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
        public SignInView() { }


        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            View = new UIView();
            View.BackgroundColor = UIColor.White;

            var margins = View.LayoutMarginsGuide;
            var signInButton = UIButton.FromType(UIButtonType.RoundedRect);

            signInButton.BackgroundColor = UIColor.Clear.FromHex(Constants.Colors.LightAzure);
            signInButton.Layer.CornerRadius = 26f;
            signInButton.SetTitle("Sign In", UIControlState.Normal);

            View.AddSubview(signInButton);

            signInButton.HeightAnchor.ConstraintEqualTo(52).Active = true;
            signInButton.LeftAnchor.ConstraintEqualTo(View.LeftAnchor).Active = true;
            signInButton.RightAnchor.ConstraintEqualTo(View.RightAnchor).Active = true;
            signInButton.CenterXAnchor.ConstraintEqualTo(View.CenterXAnchor).Active = true;
        }
    }
}
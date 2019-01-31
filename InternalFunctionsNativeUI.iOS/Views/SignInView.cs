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

            View.BackgroundColor = UIColor.White;

            var margins = View.LayoutMarginsGuide;
            var label = new UILabel(new CGRect(10,20,100,30));
            label.TextColor = UIColor.Black;
            label.Text = "Loaded";
            var signInButton = UIButton.FromType(UIButtonType.RoundedRect);

            signInButton.BackgroundColor = UIColor.Clear.FromHex(Constants.Colors.LightAzure);
            signInButton.Layer.CornerRadius = 26f;
            signInButton.SetTitle("Sign In", UIControlState.Normal);
            signInButton.SetTitleColor(UIColor.Black, UIControlState.Normal);
            signInButton.TranslatesAutoresizingMaskIntoConstraints = false;

            View.AddSubview(label);
            View.AddSubview(signInButton);

            signInButton.HeightAnchor.ConstraintEqualTo(52f).Active = true;
            signInButton.CenterYAnchor.ConstraintEqualTo(margins.CenterYAnchor).Active = true;
            signInButton.RightAnchor.ConstraintEqualTo(margins.RightAnchor).Active = true;
            signInButton.LeftAnchor.ConstraintEqualTo(margins.LeftAnchor).Active = true;
        }
    }
}
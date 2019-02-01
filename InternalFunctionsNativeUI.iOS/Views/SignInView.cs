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
            var signInButton = UIButton.FromType(UIButtonType.RoundedRect);

            var imageView = new UIImageView();
            var image = UIImage.FromBundle(Constants.Paths.Images.GodelLogoLight);
            imageView.Image = image;
            imageView.TranslatesAutoresizingMaskIntoConstraints = false;

            var label = new UILabel();
            label.Text = Constants.AppName;
            label.TextColor = UIColor.Black;
            label.TextAlignment = UITextAlignment.Center;
            label.TranslatesAutoresizingMaskIntoConstraints = false;
            signInButton.BackgroundColor = UIColor.Clear.FromHex(Constants.Colors.LightAzure);
            signInButton.Layer.CornerRadius = 26f; 
            signInButton.SetTitle("Sign In", UIControlState.Normal);
            signInButton.SetTitleColor(UIColor.Black, UIControlState.Normal);
            signInButton.TranslatesAutoresizingMaskIntoConstraints = false;

            View.AddSubview(imageView);
            View.AddSubview(label);
            View.AddSubview(signInButton);

            imageView.WidthAnchor.ConstraintEqualTo(image.Size.Width).Active = true;
            imageView.HeightAnchor.ConstraintEqualTo(image.Size.Height).Active = true;
            imageView.CenterXAnchor.ConstraintEqualTo(View.CenterXAnchor).Active = true;
            NSLayoutConstraint.Create(
                view1: imageView, 
                attribute1: NSLayoutAttribute.CenterY, 
                relation: NSLayoutRelation.Equal, 
                view2: View,
                attribute2: NSLayoutAttribute.CenterY, 
                multiplier: 0.5f, 
                constant: 0f).Active = true;

            label.WidthAnchor.ConstraintEqualTo(View.WidthAnchor).Active =  true;
            label.HeightAnchor.ConstraintGreaterThanOrEqualTo(30).Active = true;
            label.TopAnchor.ConstraintEqualTo(imageView.BottomAnchor).Active = true;

            signInButton.HeightAnchor.ConstraintEqualTo(52f).Active = true;
            signInButton.LeadingAnchor.ConstraintEqualTo(View.LeadingAnchor, 40f).Active = true;
            signInButton.CenterXAnchor.ConstraintEqualTo(View.CenterXAnchor).Active = true;
            NSLayoutConstraint.Create(
                view1: signInButton,
                attribute1: NSLayoutAttribute.CenterY,
                relation: NSLayoutRelation.Equal,
                view2: View,
                attribute2: NSLayoutAttribute.CenterY,
                multiplier: 1.5f,
                constant: 0f).Active = true;
        }
    }
}
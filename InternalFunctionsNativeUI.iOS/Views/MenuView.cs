using System;
using System.Drawing;

using CoreFoundation;
using UIKit;
using Foundation;
using InternalFunctionsNativeUI.iOS.Views.PartialViews;

namespace InternalFunctionsNativeUI.iOS.Views
{
    [Register("MenuView")]
    public class MenuView : UIViewController
    {
        public MenuView(){ }


        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            View.Add(new CircleView(new RectangleF(0, 0, 100, 100)));
        }
    }
}
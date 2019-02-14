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
        }

        public override void LoadView()
        {
            View = new CircleView();
        }
    }
}
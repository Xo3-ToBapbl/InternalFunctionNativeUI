using System;
using System.Drawing;

using CoreFoundation;
using UIKit;
using Foundation;

namespace InternalFunctionsNativeUI.iOS.ViewControllers
{
    [Register("PreviousActivitiesViewController")]
    public class PreviousActivitiesViewController : UIViewController
    {
        public PreviousActivitiesViewController()
        {
        }


        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            this.NavigationItem.Title = "Previous Activities";
        }

        public override void LoadView()
        {
            base.LoadView();

            View.BackgroundColor = UIColor.White;;
        }
    }
}
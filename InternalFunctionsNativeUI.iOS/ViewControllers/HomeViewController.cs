using System;
using Foundation;
using InternalFunctionsNativeUI.iOS.Controls;
using InternalFunctionsNativeUI.iOS.Extensions;
using InternalFunctionsNativeUI.iOS.Utilities;
using UIKit;

namespace InternalFunctionsNativeUI.iOS.ViewControllers
{
    [Register("HomeViewController")]
    public class HomeViewController : UIViewController
    {
        private UIBarButtonItem _menuBarButton;
        private UIButton _previousActivitiesButton;
        private SideMenuManager _sideMenuManager;


        public HomeViewController(){ }

        
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            this.NavigationController.SetNavigationBarHidden(false, true);
            this.NavigationItem.SetLeftBarButtonItem(_menuBarButton, false);
            this.NavigationItem.Title = "Internal Functions";
        }

        public override void LoadView()
        {
            base.LoadView();

            this.CreateControls();
            this.AdjustControls();

            View.BackgroundColor = UIColor.White;
            View.AddSubviews(_previousActivitiesButton);

            this.SetConstraints();
        }

        private void CreateControls()
        {
            _menuBarButton = new UIBarButtonItem(new UIImage("menu-button.png"), UIBarButtonItemStyle.Plain, MenuButtonHandler);
            _previousActivitiesButton = UIButton.FromType(UIButtonType.RoundedRect);

            _sideMenuManager = new SideMenuManager();
        }

        private void AdjustControls()
        {
            _previousActivitiesButton.BackgroundColor = UIColor.Clear.FromHex(Colors.LightAzure);
            _previousActivitiesButton.Layer.CornerRadius = Dimens.ButtonCornerRadiusCommon;
            _previousActivitiesButton.SetTitle("Previous Activities", UIControlState.Normal);
            _previousActivitiesButton.SetTitleColor(UIColor.Black, UIControlState.Normal);
            _previousActivitiesButton.TouchDown += PreviousActivitiesButtonOnTouchDown;

            _sideMenuManager.FadeStatusBar = false;
            _sideMenuManager.LeftNavigationController = new SideMenuNavigationController(_sideMenuManager, new SideMenuViewController(this));
        }

        private void SetConstraints()
        {
            DisableAutoresizingMasks();

            var constraints = new[]
            {
                _previousActivitiesButton.HeightAnchor.ConstraintEqualTo(Dimens.ButtonHeightCommon),
                _previousActivitiesButton.LeadingAnchor.ConstraintEqualTo(View.LeadingAnchor, Dimens.ButtonMarginCommon),
                _previousActivitiesButton.CenterXAnchor.ConstraintEqualTo(View.CenterXAnchor),
                _previousActivitiesButton.CenterYAnchor.ConstraintEqualTo(View.CenterYAnchor),
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

        private void MenuButtonHandler(object sender, EventArgs e)
        {
            this.PresentViewController(_sideMenuManager.LeftNavigationController, true, null);
        }

        private void PreviousActivitiesButtonOnTouchDown(object sender, EventArgs e)
        {
            NavigationController.PushViewController(new PreviousActivitiesViewController(), true);
        }

        public void PopToRootViewController()
        {
            _sideMenuManager.SideMenuTransition.HideMenuComplete();
            DismissViewController(true, () =>
            {
                this.NavigationController.SetNavigationBarHidden(true, true);
                this.NavigationController.PopToRootViewController(true);
            });
        }
    }
}
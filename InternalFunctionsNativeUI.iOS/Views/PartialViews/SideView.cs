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
        private UIStackView _topStackView;
        private UIStackView _midleStackView;
        private UIStackView _bottomStackView;


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

            AddSubviews(_topStackView, _midleStackView, _bottomStackView);

            this.SetConstraints();
        }

        private void CreateControls()
        {
            _topStackView = new UIStackView();
            _midleStackView = new UIStackView();
            _bottomStackView = new UIStackView();
        }

        private void AdjustControls()
        {
            _topStackView.BackgroundColor = UIColor.Clear.FromHex(Constants.Colors.LightAzure);
            _midleStackView.BackgroundColor = UIColor.Gray;
            _bottomStackView.BackgroundColor = UIColor.Clear.FromHex(Constants.Colors.LightAzure);
        }

        private void SetConstraints()
        {
            //var constraints = new[]
            //{

            //};
        }
    }
}
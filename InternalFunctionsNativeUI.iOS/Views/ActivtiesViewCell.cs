using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using InternalFunctionsNativeUI.iOS.Utilities;
using UIKit;

namespace InternalFunctionsNativeUI.iOS.Views
{
    public class ActivtiesViewCell : UITableViewCell
    {
        private UIImageView _paidStatusImage;
        private UILabel _titleLabel;
        private UILabel _descriptionLabel;


        public ActivtiesViewCell(IntPtr intPtr) 
            : base (intPtr)
        {
            CreateControls();
            AdjustControls();

            ContentView.AddSubviews(new UIView[] { _titleLabel, _descriptionLabel, _paidStatusImage });
        }

        private void CreateControls()
        {
            _titleLabel = new UILabel();
            _descriptionLabel = new UILabel();
            _paidStatusImage = new UIImageView();
        }

        private void AdjustControls()
        {
            _titleLabel.TextColor = UIColor.Black;
            _titleLabel.TextAlignment = UITextAlignment.Left;
            _titleLabel.Font = _titleLabel.Font.WithSize(Dimens.TextSizeHint);

            _descriptionLabel.TextColor = UIColor.Black;
            _descriptionLabel.TextAlignment = UITextAlignment.Left;
            _descriptionLabel.Font = _descriptionLabel.Font.WithSize(Dimens.TextSizeCommon);

            _paidStatusImage.Image = UIImage.FromBundle(Constants.Paths.Images.PaidLight);
        }

        public void UpdateCell (string title, string description)
        {
            _titleLabel.Text = title;
            _descriptionLabel.Text = description;
        }

        public override void LayoutSubviews()
        {
            base.LayoutSubviews();

            DisableAutoresizingMasks();

            var constraints = new []
            {
                _titleLabel.HeightAnchor.ConstraintEqualTo(30f),
                _titleLabel.LeftAnchor.ConstraintEqualTo(ContentView.LeftAnchor, 5),
                _titleLabel.TopAnchor.ConstraintEqualTo(ContentView.TopAnchor),

                _descriptionLabel.HeightAnchor.ConstraintEqualTo(20f),
                _descriptionLabel.LeftAnchor.ConstraintEqualTo(ContentView.LeftAnchor, 5),
                _descriptionLabel.BottomAnchor.ConstraintEqualTo(ContentView.BottomAnchor),

                _paidStatusImage.CenterYAnchor.ConstraintEqualTo(ContentView.CenterYAnchor),
                _paidStatusImage.RightAnchor.ConstraintEqualTo(ContentView.RightAnchor, -10),
            };

            NSLayoutConstraint.ActivateConstraints(constraints);
        }

        private void DisableAutoresizingMasks()
        {
            foreach (var view in ContentView)
            {
                ((UIView)view).TranslatesAutoresizingMaskIntoConstraints = false;
            }
        }
    }
}
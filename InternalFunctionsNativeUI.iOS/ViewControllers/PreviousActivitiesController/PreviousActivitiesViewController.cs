using System;
using System.Drawing;

using CoreFoundation;
using UIKit;
using Foundation;
using InternalFunctionNativeUI.Core.Services;
using InternalFunctionsNativeUI.iOS.Views;
using InternalFunctionsNativeUI.iOS.Utilities;

namespace InternalFunctionsNativeUI.iOS.ViewControllers
{
    [Register("PreviousActivitiesViewController")]
    public class PreviousActivitiesViewController : UITableViewController
    {
        public PreviousActivitiesViewController() { }


        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            this.NavigationItem.Title = "Previous Activities";
        }

        public override void LoadView()
        {
            base.LoadView();

            TableView.RegisterClassForCellReuse(typeof(ActivtiesViewCell), Constants.ActivitiesCellIdentifier);
            TableView.RowHeight = 60;
            TableView.AllowsSelection = false;
            TableView.Source = new ActivitiesTableSource(DataService.GetActivities());
            TableView.BackgroundColor = UIColor.White;
            TableView.SeparatorInset = UIEdgeInsets.Zero;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using InternalFunctionNativeUI.Core.Models;
using InternalFunctionsNativeUI.iOS.Extensions;
using InternalFunctionsNativeUI.iOS.Utilities;
using InternalFunctionsNativeUI.iOS.Views;
using UIKit;

namespace InternalFunctionsNativeUI.iOS.ViewControllers
{
    public class ActivitiesTableSource : UITableViewSource
    {
        public IList<ActivityModel> Activities { get; private set; }


        public ActivitiesTableSource(IList<ActivityModel> activities)
        {
            Activities = activities ?? throw new ArgumentNullException();
        }


        public override nint RowsInSection(UITableView tableview, nint section)
        {
            return Activities.Count;
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            var cell = (ActivtiesViewCell)tableView.DequeueReusableCell(Constants.ActivitiesCellIdentifier);
            var activity = Activities[indexPath.Row];

            cell.UpdateCell(activity.Title, activity.Description);

            return cell;
        }

        public override UISwipeActionsConfiguration GetTrailingSwipeActionsConfiguration(UITableView tableView, NSIndexPath indexPath)
        {
            var deleteAction = ContextualDeleteAction(indexPath.Row);

            var leadingSwipe = UISwipeActionsConfiguration.FromActions(new[] { deleteAction });
            leadingSwipe.PerformsFirstActionWithFullSwipe = false;

            return leadingSwipe;
        }

        private UIContextualAction ContextualDeleteAction(int rowIndex)
        {
            var action = UIContextualAction.FromContextualActionStyle(
                style: UIContextualActionStyle.Normal,
                title: "Delete",
                handler: DeleteItemHandler);

            action.BackgroundColor = UIColor.Clear.FromHex(Colors.DarkRed);

            return action;
        }

        private void DeleteItemHandler(UIContextualAction action, UIView sourceView, UIContextualActionCompletionHandler completionHandler)
        {

        }
    }
}
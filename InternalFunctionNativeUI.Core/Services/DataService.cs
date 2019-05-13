using System.Collections.Generic;
using InternalFunctionNativeUI.Core.Models;

namespace InternalFunctionNativeUI.Core.Services
{
    public static class DataService
    {
        public static IList<ActivityModel> GetActivities()
        {
            var activities = new List<ActivityModel>();
            for (int i = 0; i < 50; i++)
            {
                activities.Add(new ActivityModel
                {
                    Title = "New ActivityModel",
                    Description = $"Some activity description {i}"
                });
            }

            return activities;
        }
    }
}

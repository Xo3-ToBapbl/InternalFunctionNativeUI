using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using InternalFunctionNativeUI.Core.Interfaces;

namespace InternalFunctionsNativeUI.Droid.Services
{
    public class LogService : ILogger
    {
        public void LogToView(string type, string methodName, string message = "")
        {
            string text = $"\n{DateTime.Now.Millisecond} {type} {methodName} {message}";
            MainActivity.Instance.LogView.Append(text);
        }
    }
}
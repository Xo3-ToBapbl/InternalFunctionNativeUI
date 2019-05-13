using System;
using System.Collections.Generic;
using System.Text;

namespace InternalFunctionNativeUI.Core.Interfaces
{
    public interface ILogger
    {
        void LogToView(string type, string methodName, string message = "");
    }
}

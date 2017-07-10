using Logic.Ui.AOP;
using MethodDecorator.Fody.Interfaces;
using NLog;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
// Atribute should be "registered" by adding as module or assembly custom attribute
[module: LoggedAttribute]

namespace Logic.Ui.AOP
{
// Any attribute which provides OnEntry/OnExit/OnException with proper args
[AttributeUsage(AttributeTargets.Method | AttributeTargets.Constructor | AttributeTargets.Assembly | AttributeTargets.Module)]
    public class LoggedAttribute : Attribute, IMethodDecorator
    {
        private static Logger _logger = LogManager.GetCurrentClassLogger();
        private MethodBase Method { get; set; }
        private object[] Args { get; set; }
        // instance, method and args can be captured here and stored in attribute instance fields
        // for future usage in OnEntry/OnExit/OnException
        public void Init(object instance, MethodBase method, object[] args)
        {
            Method = method;
            Args = args;
            _logger.Warn(string.Format("Init: {0} [{1}]", GetMethodFullName(), args.Length));
        }
        public void OnEntry()
        {
            _logger.Warn($"OnEntry: {GetMethodFullName()}");
        }

        public void OnExit()
        {
            _logger.Warn($"OnExit: {GetMethodFullName()}");
        }

        public void OnException(Exception exception)
        {
            _logger.Error(string.Format("OnException: {0}: {1}", exception.GetType(), exception.Message));
        }

        private string GetMethodFullName()
        {
            if (Method == null)
                return String.Empty;
            return Method.DeclaringType.FullName + "." + Method.Name;
        }
    }
    
}

using Logic.Ui.AOP;
using MethodDecorator.Fody.Interfaces;
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
        private MethodBase Method { get; set; }
        private object[] Args { get; set; }
        // instance, method and args can be captured here and stored in attribute instance fields
        // for future usage in OnEntry/OnExit/OnException
        public void Init(object instance, MethodBase method, object[] args)
        {
            Method = method;
            Args = args;
            Debug.WriteLine(string.Format("Init: {0} [{1}]", GetMethodFullName(), args.Length));
        }
        public void OnEntry()
        {
            Debug.WriteLine($"OnEntry: {GetMethodFullName()}");
        }

        public void OnExit()
        {
            Debug.WriteLine($"OnExit: {GetMethodFullName()}");
        }

        public void OnException(Exception exception)
        {
            Debug.WriteLine(string.Format("OnException: {0}: {1}", exception.GetType(), exception.Message));
        }

        private string GetMethodFullName()
        {
            if (Method == null)
                return String.Empty;
            return Method.DeclaringType.FullName + "." + Method.Name;
        }
    }
    
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicDemo.Events
{
    public delegate void OnActionExecuting();

    public class ActionEvent
    {
        public event OnActionExecuting OnActionExecuting;

        public void ActionExecuting()
        {
            this.OnActionExecuting?.Invoke();
        }
    }
}

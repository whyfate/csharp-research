using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicDemo.Events
{
    internal static class EventTest
    {
        public static void TestEvent()
        {
            ActionEvent actionEvent = new ActionEvent();
            actionEvent.OnActionExecuting += () =>
            {
                Console.WriteLine("action executing 1");
            };

            actionEvent.OnActionExecuting += () =>
            {
                Console.WriteLine("action executing 2");
            };

            actionEvent.OnActionExecuting += () =>
            {
                Console.WriteLine("action executing 3");
            };

            actionEvent.ActionExecuting();
        }
    }
}

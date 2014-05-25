using System;
using System.Threading;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.ServiceRuntime;

namespace WorkerRole
{
    public class WorkerRole : RoleEntryPoint
    {
        public override void Run()
        {
            while (true)
            {
                Thread.Sleep(Timeout.Infinite);
            }
        }

        public override bool OnStart()
        {
            return true;
        }
    }
}

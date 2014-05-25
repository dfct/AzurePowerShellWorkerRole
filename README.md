AzurePowerShellWorkerRole
=========================

Minimal Azure Cloud Service &amp; Worker Role configuration for executing a PowerShell script on Worker Role startup.


I needed a Windows Server VM for some basic, built-in functionality. You can spin up your own VM and take responsibility for managing it, but in my case it would be ideal if Azure picked up that responsibility. Azure Cloud Service Worker Roles run on top of Windows Server 2012 [R2] and can be configured & controlled just like a regular Azure VM. The only difference is Woker Roles will be cycled periodically onto new VMs. You need to be ok with re-establishing the VM each time this happens.

I built a minimal Azure Worker Role package that will simply run a Startup.ps1 file elevated each time the Worker Role starts. The WorkerRole.dll file just sleeps indefinitely. Startup.ps1 can install Windows Features, configure components, do whatever is needed to establish the Windows VM. Any external endpoints can be defined in the ServiceDefinition file.


To use this, edit the Startup.ps1 file in .\WorkerRole\bin\Release with your script. Edit the .\CloudService\ServiceDefinition.csdef as you need for instance count, instance size, endpoints, etc. Then create a Deployment package with cspack.exe from the Azure SDK.
````
cspack.exe CloudService\ServiceDefinition.csdef /role:WorkerRole;WorkerRole\bin\Release;WorkerRole.dll /out:Deployment.cspkg
````


Head over to Azure and create a new Cloud Service. Point it at your Deployment.cspkg & ServiceDefinition.csdef and you're done.



For more information on ServiceDefinition options, see this MSDN article: http://msdn.microsoft.com/en-us/library/hh124108.aspx
For more information on cspack options, see this MSDN article: http://msdn.microsoft.com/library/azure/gg432988.aspx


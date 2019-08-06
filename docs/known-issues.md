# Known Issues

## Multiple models define the facet 'SportName' for Contact

*August 6th, 2019*

### Problem

In the Sitecore logs, you see:

```text
ManagedPoolThread #2 15:55:02 INFO  Job started: Sitecore.ListManagement.Operations.UpdateListOperationsAgent
ManagedPoolThread #2 15:55:02 INFO  Job ended: Sitecore.ListManagement.Operations.UpdateListOperationsAgent (units processed: )
36592 15:55:11 ERROR Exception when executing agent aggregation/aggregator
Exception: Sitecore.XConnect.XdbCollectionUnavailableException
Message: The HTTP response was not successful: InternalServerError
Source: Sitecore.Xdb.Common.Web
   at Sitecore.Xdb.Common.Web.Synchronous.SynchronousExtensions.SuspendContextLock[TResult](Func`1 taskFactory)
   at Sitecore.XConnect.Client.XConnectSynchronousExtensions.SuspendContextLock(Func`1 taskFactory)
   at Sitecore.XConnect.Client.Configuration.SitecoreXConnectClientConfiguration.Initialize(XmlNode configNode)
   at Sitecore.Configuration.DefaultFactory.CreateObject(XmlNode configNode, String[] parameters, Boolean assert, IFactoryHelper helper)
   at Sitecore.Configuration.DefaultFactory.CreateObject(XmlNode configNode, String[] parameters, Boolean assert)
   at Sitecore.Configuration.DefaultFactory.CreateObject(String configPath, String[] parameters, Boolean assert)
   at Sitecore.XConnect.Client.Configuration.SitecoreXConnectClientConfiguration.GetClient(String clientConfigPath)
   at Sitecore.Analytics.Aggregation.XConnect.DefaultXdbContextFactory.CreateReadOnly()
   at Sitecore.Analytics.Processing.AsyncPoolScheduler`2..ctor(IAsyncProcessingPool`1 pool, IXdbContextFactory xdbContextFactory, ExpandOptions options, Int16 maxBatchSize, BaseLog log)
   at Sitecore.Analytics.Aggregation.InteractionAggregationAgent.<ExecuteCoreAsync>d__15.MoveNext()
--- End of stack trace from previous location where exception was thrown ---
   at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()
   at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)
   at Sitecore.Analytics.Core.Agent.<ExecuteAsync>d__1.MoveNext()
--- End of stack trace from previous location where exception was thrown ---
   at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()
   at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)
   at Sitecore.Analytics.Core.AsyncBackgroundService.<ExecuteAgentAsync>d__22.MoveNext()
--- End of stack trace from previous location where exception was thrown ---
   at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()
   at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)
   at Sitecore.Analytics.Core.AsyncBackgroundService.<RunAsync>d__26.MoveNext()
```

In the xConnect logs, you see:

```text
2019-08-02 15:56:08.827 -04:00 [Error] XConnect Web Application Error: "System.ApplicationException: Exception trying to initialize Service Collection and Provider for WebAPI Dependency Resolver, Inner Exception: Multiple models define the facet 'SportName' for Contact ---> Sitecore.XConnect.Schema.DuplicateXdbFacetNameException: Multiple models define the facet 'SportName' for Contact
   at Sitecore.XConnect.Schema.XdbModel.AddAndValidateModelAndTypes(XdbModel model, HashSet`1 visited)
   at Sitecore.XConnect.Schema.XdbModel.AddAndValidateModelAndTypes(XdbModel model, HashSet`1 visited)
   at Sitecore.XConnect.Schema.XdbModel..ctor(String name, XdbModelVersion version, XdbNamedType[] types, XdbFacetDefinition[] facets, XdbModel[] referencedModels)
   at Sitecore.XConnect.Schema.XdbRuntimeModel..ctor(XdbModel[] models)
   at Sitecore.XConnect.Web.Extensions.UseXConnectModel(IServiceCollection services)
   at Sitecore.XConnect.DependencyInjection.ServiceCollectionExtensions.GetXConnectServiceConfiguration(IServiceCollection services)
   at Sitecore.XConnect.Web.WebApiConfig.ConfigureServices(HttpConfiguration config)
   --- End of inner exception stack trace ---
   at Sitecore.XConnect.Web.WebApiConfig.ConfigureServices(HttpConfiguration config)
   at System.Web.Http.GlobalConfiguration.Configure(Action`1 configurationCallback)
   at Sitecore.XConnect.Web.Global.Application_Start(Object sender, EventArgs e)"
```

### Cause

`Sitecore.HabitatHome.Foundation.Accounts.Models.AccountCollectionModel.config` was renamed to `Sitecore.Demo.Foundation.Accounts.Models.AccountCollectionModel.config`. This fixes an issue with Marketing Automation. After this change, the old file may still be present in:

* `[xConnect web root path]\App_Data\Models`
* `[xConnect web root path]\App_Data\jobs\continuous\IndexWorker\App_Data\Models`

### Solution

Delete the old `Sitecore.HabitatHome.Foundation.Accounts.Models.AccountCollectionModel.config` files in:

* `[xConnect web root path]\App_Data\Models`
* `[xConnect web root path]\App_Data\jobs\continuous\IndexWorker\App_Data\Models`

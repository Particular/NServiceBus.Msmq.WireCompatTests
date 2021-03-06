using System.Threading;
using NServiceBus;
using NServiceBus.Installation.Environments;
using NServiceBus.Unicast;

class Program
{
    static void Main()
    {
        //HACK: for trial dialog issue https://github.com/Particular/NServiceBus/issues/2001
        var synchronizationContext = SynchronizationContext.Current;
        var bus = CreateBus();
        SynchronizationContext.SetSynchronizationContext(synchronizationContext);
        TestRunner.RunTests(bus);
    }

    static UnicastBus CreateBus()
    {
        Configure.GetEndpointNameAction = () => EndpointNames.EndpointName;

        Logging.ConfigureLogging();
        var configure = Configure.With();
        configure.ApplyMessageConventions();
        configure.DefaultBuilder();
        configure.MsmqTransport();
        configure.JsonSerializer();
        configure.InMemorySagaPersister();
        configure.UseInMemoryTimeoutPersister();
        configure.RunTimeoutManager();
        configure.Sagas();
        configure.InMemorySubscriptionStorage();

        return (UnicastBus) configure.UnicastBus()
            .CreateBus().Start(() => Configure.Instance.ForInstallationOn<Windows>().Install());
    }
}
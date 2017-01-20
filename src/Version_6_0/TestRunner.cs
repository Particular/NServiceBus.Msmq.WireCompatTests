using System;
using System.Threading.Tasks;
using NServiceBus;

public static class TestRunner
{
    public static string EndpointName { get; set; }

    public static async Task RunTests(IEndpointInstance bus)
    {
        await Task.Delay(TimeSpan.FromSeconds(25)).ConfigureAwait(false);
        await bus.InitiateDataBus().ConfigureAwait(false);
        await bus.InitiatePubSub().ConfigureAwait(false);
        await bus.InitiateSaga().ConfigureAwait(false);
        await bus.InitiateSendReply().ConfigureAwait(false);
        bus.InitiateSendReturn();

        await Task.Delay(TimeSpan.FromMinutes(1)).ConfigureAwait(false);
        await bus.Stop().ConfigureAwait(false);
        DataBusVerifier.AssertExpectations();
        PubSubVerifier.AssertExpectations();
        SagaVerifier.AssertExpectations();
        SendReplyVerifier.AssertExpectations();
        SendReturnVerifier.AssertExpectations();
    }
}
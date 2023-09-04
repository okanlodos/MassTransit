namespace MassTransit
{
    using System;
    using System.Threading.Tasks;
    using Confluent.Kafka;


    public interface IKafkaTopicEndpointConnector
    {
        HostReceiveEndpointHandle ConnectTopicEndpoint<TKey, TValue>(string topicName, string groupId,
            Action<IRiderRegistrationContext, IKafkaTopicReceiveEndpointConfigurator<TKey, TValue>> configure)
            where TValue : class;

        HostReceiveEndpointHandle ConnectTopicEndpoint<TKey, TValue>(string topicName, ConsumerConfig consumerConfig,
            Action<IRiderRegistrationContext, IKafkaTopicReceiveEndpointConfigurator<TKey, TValue>> configure)
            where TValue : class;

        Task<bool> DisconnectTopicEndpoint(string topicName, string groupId);
    }
}

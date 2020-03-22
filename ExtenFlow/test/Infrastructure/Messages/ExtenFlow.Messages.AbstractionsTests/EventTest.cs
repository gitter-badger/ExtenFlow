using System;
using System.Collections.Generic;

using Newtonsoft.Json;

#pragma warning disable CS0612 // Type or member is obsolete

namespace ExtenFlow.Messages.AbstractionsTests
{
    public class TestEvent : Event
    {
        [Obsolete]
        public TestEvent()
        {
        }

        [JsonConstructor]
        public TestEvent(string aggregateType, string aggregateId, string userId, Guid correlationId, Guid messageId, DateTimeOffset dateTime) : base(aggregateType, aggregateId, userId, correlationId, messageId, dateTime)
        {
        }
    }

    public abstract class EventBaseTest<T> : MessageBaseTest<T> where T : IEvent
    {
    }

    public class EventTest : EventBaseTest<TestEvent>
    {
        protected override IEnumerable<TestEvent> Create(IDictionary<string, object> values)
        {
            var message = new TestEvent();
            message.AggregateType = (string)values[nameof(IMessage.AggregateType)];
            message.AggregateId = (string)values[nameof(IMessage.AggregateId)];
            message.UserId = (string)values[nameof(IMessage.UserId)];
            message.CorrelationId = (Guid)values[nameof(IMessage.CorrelationId)];
            message.MessageId = (Guid)values[nameof(IMessage.MessageId)];
            message.DateTime = (DateTimeOffset)values[nameof(IMessage.DateTime)];

            return new TestEvent[]{
                new TestEvent(
                    (string)values[nameof(IMessage.AggregateType)],
                    (string)values[nameof(IMessage.AggregateId)],
                    (string)values[nameof(IMessage.UserId)],
                    (Guid)values[nameof(IMessage.CorrelationId)],
                    (Guid)values[nameof(IMessage.MessageId)],
                    (DateTimeOffset)values[nameof(IMessage.DateTime)]
                ) };
        }
    }
}
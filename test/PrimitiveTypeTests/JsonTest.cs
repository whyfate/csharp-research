using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Xunit;

namespace PrimitiveTypeTests
{
    public class JsonTest
    {
        [Fact]
        public void InitialTest()
        {
            var orderCreatedEvent = new OrderCreatedEvent(1);
            var orderCreatedEventJsonString = JsonSerializer.Serialize(orderCreatedEvent);
            var orderCreatedEvent2 = JsonSerializer.Deserialize<OrderCreatedEvent>(orderCreatedEventJsonString);
            Assert.Equal(orderCreatedEvent.Id, orderCreatedEvent2.Id);
            Assert.Equal(orderCreatedEvent.CreateDate, orderCreatedEvent2.CreateDate);
        }

        public class DomainEvent
        {
            public DomainEvent()
            {
                Id = Guid.NewGuid();
                CreateDate = DateTime.Now;
            }

            /// <summary>
            /// id.
            /// </summary>
            [JsonInclude]
            public Guid Id { get; private init; }

            /// <summary>
            /// create date.
            /// </summary>
            [JsonInclude]
            public DateTime CreateDate { get; private init; }
        }

        public class OrderCreatedEvent : DomainEvent
        {
            public OrderCreatedEvent(int orderId) => OrderId = orderId;

            public int OrderId { get; set; }
        }
    }
}

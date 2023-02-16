using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventBusRabbitMQ.Events.Interfaces
{
    public abstract class IEvent // sınıfın abstract olma nedeni constructer metotda işlem yapılması (ınterfacede yapılamaz)
    {
        public Guid RequestId { get; private init; }// sadece bu metodun içinde set edileceği için init ediliyor set yerine
        public DateTime CreationDate { get; private init; }
        public IEvent()
        {
            RequestId = Guid.NewGuid();
            CreationDate = DateTime.UtcNow;
        }
    }
}

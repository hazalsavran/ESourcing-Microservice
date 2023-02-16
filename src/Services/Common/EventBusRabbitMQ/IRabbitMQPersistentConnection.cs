using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventBusRabbitMQ
{
    public interface IRabbitMQPersistentConnection:IDisposable // bu sınıf bağlantı sınıfı olduğu için disposible sınıfından türemesi lazım
        // uygulama üzerinde yük oluşturan bu tarz dispose edilmesi gerekn nesneleri tutan  her sınıf için gerekli bir interface IDisposible
    {
        bool IsConnected { get; }
        bool TryConnect();
        IModel CreateModel();
    }
}

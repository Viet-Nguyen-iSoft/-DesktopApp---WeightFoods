using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Threading.Channels;

namespace iSoft.RabbitMq
{
  public class RabbitMQImpService
  {
    public event Action<string, string>? TopicMessageReceived;

    //Instance duy nhất (Singleton)
    public static RabbitMQImpService? _instance;
    private static readonly object _lock = new object();

    //Các cấu hình cần thiết
    private readonly string _hostName;
    private readonly string _queueName;
    private readonly string _exchangesName;
    private readonly string _queueName_DatalogChange;
    private readonly string _exchangesName_DatalogChange;
    private readonly string _userName;
    private readonly string _password;
    private readonly int _port;

    //Connection giữ lâu dài (chỉ tạo 1 lần)
    private IConnection _connection;
    private IModel _channel;

    //Hàm khởi tạo private — không cho new bên ngoài
    private RabbitMQImpService(string hostName, int port, string userName, string password, string queueName, string exchangesName, string queueNameDatalogChange, string exchangesNameDatalogChange)
    {
      _hostName = hostName;
      _port = port;
      _userName = userName;
      _password = password;

      _queueName = queueName;
      _exchangesName = exchangesName;

      _queueName_DatalogChange = queueNameDatalogChange;
      _exchangesName_DatalogChange = exchangesNameDatalogChange;
      InitConnection();
    }

    private void InitConnection()
    {
      var factory = new ConnectionFactory()
      {
        HostName = _hostName,
        UserName = _userName,
        Password = _password,
        Port = _port
      };

      _connection = factory.CreateConnection();
      _channel = _connection.CreateModel();

      //_channel.QueueDeclare(
      //    queue: _queueName,
      //    durable: true,
      //    exclusive: false,
      //    autoDelete: false,
      //    arguments: null);

      //_channel.ExchangeDeclare(
      //    exchange: _exchangesName,
      //    type: ExchangeType.Direct,
      //    durable: true,
      //    autoDelete: false,
      //    arguments: null);

      Console.WriteLine($"RabbitMQ connected to {_hostName}:{_port}, queue = {_queueName}");
    }

    // 🔸 Hàm khởi tạo Instance
    //public static RabbitMQImpService Instance(string hostName = "127.0.0.1", int port = 5672,string userName = "guest", string password = "guest", string queueName = "hello")
    public static RabbitMQImpService Instance()
    {
      if (_instance == null)
      {
        string host = Environment.GetEnvironmentVariable("RABBITMQ_CONFIG__ADDRESS");
        int port = int.Parse(Environment.GetEnvironmentVariable("RABBITMQ_CONFIG__PORT"));
        string userName = Environment.GetEnvironmentVariable("RABBITMQ_CONFIG__USERNAME");
        string password = Environment.GetEnvironmentVariable("RABBITMQ_CONFIG__PASSWORD");
        string queue = Environment.GetEnvironmentVariable("RABBITMQ_CONFIG__QUEUENAME");
        string exchanges = Environment.GetEnvironmentVariable("RABBITMQ_CONFIG__EXCHANGES");
        string queueDatalogChange = Environment.GetEnvironmentVariable("RABBITMQ_CONFIG__QUEUENAME_DATALOGCHANGE");
        string exchangesDatalogChange = Environment.GetEnvironmentVariable("RABBITMQ_CONFIG__EXCHANGES_DATALOGCHANGE");

        lock (_lock)
        {
          if (_instance == null)
          {
            _instance = new RabbitMQImpService(host, port, userName, password, queue, exchanges, queueDatalogChange, exchangesDatalogChange);
          }
        }
      }
      return _instance;
    }

    //  Hàm gửi message
    public void Send(string message, EnumTypeMessage enumTypeMessage)
    {
      if (_channel == null || !_connection.IsOpen)
      {
        Console.WriteLine("Kết nối RabbitMQ bị đóng — đang khởi động lại...");
      }

      var body = Encoding.UTF8.GetBytes(message);
      switch (enumTypeMessage)
      {
        case EnumTypeMessage.Realtime:
          _channel.BasicPublish(
           exchange: _exchangesName,
           routingKey: _queueName,
           basicProperties: null,
           body: body);
          break;
        case EnumTypeMessage.DatalogChange:
          _channel.BasicPublish(
           exchange: _exchangesName_DatalogChange,
           routingKey: _queueName_DatalogChange,
           basicProperties: null,
           body: body);
          break;
      }
    }

    // Dọn dẹp khi ứng dụng tắt
    public void Dispose()
    {
      try
      {
        _channel?.Close();
        _connection?.Close();
      }
      catch { }
    }


    private EventingBasicConsumer? _consumer;
    public void StartConsumer(string queueName)
    {
      if (_channel == null || !_connection.IsOpen)
        throw new Exception("RabbitMQ chưa kết nối.");

      _consumer = new EventingBasicConsumer(_channel);

      _consumer.Received += (sender, ea) =>
      {
        try
        {
          string routingKey = ea.RoutingKey;
          string message = Encoding.UTF8.GetString(ea.Body.ToArray());

          TopicMessageReceived?.Invoke(routingKey, message);

          Console.WriteLine(
              $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] " +
              $"RoutingKey={routingKey} | Message={message}");
        }
        catch (Exception ex)
        {
          Console.WriteLine(ex.Message);
        }
      };

      _channel.BasicConsume(
          queue: queueName,
          autoAck: true,
          consumer: _consumer);

      Console.WriteLine($"Started consumer queue: {queueName}");
    }

  }


  public enum EnumTypeMessage
  {
    None,
    Realtime,
    DatalogChange
  }




}


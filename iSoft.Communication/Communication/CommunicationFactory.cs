using iSoft.Communication.Interface;
using iSoft.Communication.JsonPayload;
using iSoft.Communication.Serial;
using static iSoft.Communication.EnumCommunication;

namespace iSoft.Communication.Communication;

/// <summary>
/// Creates the concrete connection hidden behind the common connection contract.
/// </summary>
public static class CommunicationFactory
{
  public static IScaleConnection Create(
    IConfigJson config,
    Guid? machineId = null,
    eDevice device = eDevice.None)
  {
    ArgumentNullException.ThrowIfNull(config);

    string id = string.IsNullOrWhiteSpace(config.Code)
      ? config.Id.ToString()
      : config.Code;
    string name = string.IsNullOrWhiteSpace(config.NameDevice)
      ? id
      : config.NameDevice;
    int timeout = config.TimeoutMs.GetValueOrDefault(5000);

    return config switch
    {
      ConfigTcpClient tcp => CreateTcp(tcp, id, name, machineId, device, timeout),
      ConfigSerialPort serial => CreateSerial(serial, id, name, machineId, device, timeout),
      ConfigUSBHID usb => new USBHIDConnection(
        id,
        machineId,
        usb.eModeCommunication,
        device,
        name,
        timeout,
        usb.AutoConnect),
      _ => throw new NotSupportedException(
        $"Communication configuration '{config.GetType().Name}' is not supported.")
    };
  }

  private static IScaleConnection CreateTcp(
    ConfigTcpClient config,
    string id,
    string name,
    Guid? machineId,
    eDevice device,
    int timeout)
  {
    if (string.IsNullOrWhiteSpace(config.Host))
      throw new ArgumentException("TCP host is required.", nameof(config));
    if (config.Port is < 1 or > 65535)
      throw new ArgumentOutOfRangeException(nameof(config), "TCP port must be between 1 and 65535.");

    return new TcpClientConnection(
      id,
      machineId,
      config.eModeCommunication,
      device,
      name,
      config.Host,
      config.Port,
      config.Request,
      config.TimeRequest,
      config.Ssl,
      timeout,
      config.AutoConnect);
  }

  private static IScaleConnection CreateSerial(
    ConfigSerialPort config,
    string id,
    string name,
    Guid? machineId,
    eDevice device,
    int timeout)
  {
    if (string.IsNullOrWhiteSpace(config.PortName))
      throw new ArgumentException("Serial port name is required.", nameof(config));

    return new SerialConnection(
      id,
      machineId,
      config.eModeCommunication,
      device,
      name,
      config.PortName,
      config.BaudRate,
      config.Parity,
      config.DataBits,
      config.StopBits,
      timeout,
      config.AutoConnect,
      config.Request,
      config.TimeRequest);
  }
}

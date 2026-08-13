using HSF.Database.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iSoft.DatabaseServer.Models
{
  [Table("I_Connections")]
  public class ConnectionEntity : BaseConnectivityCRUDEntity
  {
    #region Properties
    public string? Name { get; set; }
    public string? TypeConnect { get; set; }
    public string? JsonConfig { get; set; }
    public long? IdSrc { get; set; }
    public bool? SyncFlag { get; set; } = false;
    #endregion


    #region Relations
    public Guid? DataMachineId { get; set; }
    public MachineEntity? DataMachine { get; set; }

    //public List<ConnectionEntityTrans>? ConnectionEntityTrans { get; set; } = new List<ConnectionEntityTrans>();
    #endregion
  }

  public enum eCommunicationType
  {
    None,

    [Description("USB")]
    USBHID,

    [Description("Serial")]
    SerialPort,

    [Description("Tcp Listener")]
    TcpListener,

    [Description("Tcp Client")]
    TcpClient,
  }
}

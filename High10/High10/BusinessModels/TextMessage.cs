using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace High10.BusinessModels {
  public class TextMessage : IMessage {
    public bool IsImage { get; set; }
    public string Message { get; set; }
    public long Timestamp { get; set; }
    public long SenderID { get; set; }
    public long OwnerID { get; set; }
    public bool Read { get; set; }
  }
}

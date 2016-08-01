using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace High10.BusinessModels {
  public interface IMessage {
    long OwnerID { get; set; }
    bool Read { get; set; }
    long Timestamp { get; set; }
  }
}

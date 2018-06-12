using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace High10.BusinessModels {
  public class Picture : IMessage {
    public string Base64Image { get; set; }
    public long PictureID { get; set; }
    public long Timestamp { get; set; }
    public byte Duration { get; set; }
    public long OwnerID { get; set; }
    public bool Read { get; set; }
  }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace High10.BusinessModels {
    public class Picture {
        public string Base64Image { get; set; }
        public long OwnerID { get; set; }
        public long PictureID { get; set; }
        public long TimeStamp { get; set; }
        public byte Duration { get; set; }
    }
}

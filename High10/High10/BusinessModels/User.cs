using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace High10.BusinessModels {
  public class User {
    public long ID { get; set; }
    public string Username { get; set; }
    public string Base64ProfilePicture { get; set; }
    public int Points { get; set; }
    public long LastUpdate { get; set; }
  }
}

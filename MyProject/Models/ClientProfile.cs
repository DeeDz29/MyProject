using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyProject.Models
{
  public class ClientProfile
  {
    public int ClientProfileId { get; set; }
    public string Name { get; set; }
    public bool? HiddenInBackOffice { get; set; }
  }
}

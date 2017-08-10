using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace IdealSysApp.ViewModels
{

  public class GoodViewModel
  {
    public string Id { get; set; }
    public string Name { get; set; }
    public string GroupID { get; set; }
    public decimal Price { get; set; }

  }
  public class GroupViewModel
  {
    public string Id { get; set; }
    public string Name { get; set; }
  }
  [XmlRoot("Groups")]
  public class GroupList
  {
    [XmlElement("Group")]
    public List<GroupViewModel> Groups { get; set; }
  }
  [XmlRoot("Goods")]
  public class GoodList
  {
    [XmlElement("Good")]
    public List<GoodViewModel> Goods { get; set; }
  }

}

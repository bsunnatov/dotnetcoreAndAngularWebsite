using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdealSysApp.Models.Entities
{
  /// <summary>
  /// Хранилища
  /// </summary>
  public class Storage : BaseEntity
  {
    public string Name { get; set; }
    /// <summary>
    /// Описание, адрес, местоположение…
    /// </summary>
    public string Description { get; set; }
    public IList<AppUser> Users { get; set; }
  }
}

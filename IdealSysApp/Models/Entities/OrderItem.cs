using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdealSysApp.Models.Entities
{
  /// <summary>
  /// Элементы заказа
  /// </summary>
  public class OrderItem : BaseEntity
  {
    public long ProductId { get; set; }
    public long OrderId { get; set; }
    public virtual Product Product { get; set; }
    public virtual Order Order { get; set; }
    /// <summary>
    /// кол-во товаров
    /// </summary>
    public decimal Amount { get; set; }
  }
}

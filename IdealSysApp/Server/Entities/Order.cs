using IdealSysApp.Data.Enums;
using IdealSysApp.Server.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdealSysApp.Models.Entities
{
  /// <summary>
  /// заказы
  /// </summary>
  public class Order : BaseEntity
  {
    public Order()
    {
      this.OrderItems = new HashSet<OrderItem>();
    }
    /// <summary>
    /// НомерНакладной
    /// </summary>
    public string OverheadNumber { get; set; }
    /// <summary>
    /// Дата отправка ДатаСделки
    /// </summary>
    public DateTime? SendDate { get; set; }
    /// <summary>
    /// Дата принято ДатаОтгрузки
    /// </summary>
    public DateTime? AcceptedDate { get; set; }
    /// <summary>
    /// Статус заказ
    /// </summary>
    public OrderStatusEnum OrderStatus { get; set; }
    public long CustomerId { get; set; }
    public virtual Customer Customer { get; set; }
    public virtual ICollection<OrderItem> OrderItems { get; set; }

  }
}

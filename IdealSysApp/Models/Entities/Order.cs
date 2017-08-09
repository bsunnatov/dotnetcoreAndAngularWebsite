using IdealSysApp.Data.Enums;
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
    /// <summary>
    /// Дата отправка
    /// </summary>
    public DateTime? SendDate { get; set; }
    /// <summary>
    /// Дата принято
    /// </summary>
    public DateTime? AcceptedDate { get; set; }
    /// <summary>
    /// Статус заказ
    /// </summary>
    public OrderStatusEnum OrderStatus { get; set; }
  }
}

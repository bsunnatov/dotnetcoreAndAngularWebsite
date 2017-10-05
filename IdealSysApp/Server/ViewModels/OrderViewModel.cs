using IdealSysApp.Data.Enums;
using IdealSysApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdealSysApp.Server.ViewModels
{
  public class OrderViewModel : ViewModel
  {
    public OrderViewModel()
    {
      OrderItems = new List<OrderItemViewModel>();
    }
    public long CustomerId { get; set; }
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
    public virtual IList<OrderItemViewModel> OrderItems { get; set; }
  }
}

using IdealSysApp.Server.Enums;
using IdealSysApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdealSysApp.Server.ViewModels
{
  public class OrderItemViewModel : ViewModel
  {
    public long ProductId { get; set; }
    public long OrderId { get; set; }
    /// <summary>
    /// Quantity*Price-DiscountAmount=Сумма
    /// </summary>
    public decimal Amount { get; set; }
    /// <summary>
    /// Скидка
    /// </summary>
    public decimal DiscountAmout { get; set; }
    /// <summary>
    /// СкидкаТип
    /// </summary>
    public DiscountTypeEnum DiscountType { get; set; }
    /// <summary>
    /// кол-во товаров
    /// </summary>
    public decimal Quantity { get; set; }
    /// <summary>
    /// Цена
    /// </summary>
    public decimal CurrentPrice { get; set; }
  }
}

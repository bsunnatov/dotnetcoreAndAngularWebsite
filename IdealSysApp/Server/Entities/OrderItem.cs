using IdealSysApp.Server.Enums;
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
    public int Quantity { get; set; }
    /// <summary>
    /// ПроданоКоличество кол-во товаров
    /// </summary>
    public int IssuedQuantity { get; set; }
    /// <summary>
    /// Цена
    /// </summary>
    public decimal CurrentPrice { get; set; }
    public virtual Product Product { get; set; }
    public virtual Order Order { get; set; }
    
  }
}

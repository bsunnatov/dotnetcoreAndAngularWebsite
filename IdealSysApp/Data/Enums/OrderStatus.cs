using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace IdealSysApp.Data.Enums
{
  public enum OrderStatusEnum
  {
    [Description("Создан")]
    Created,
    [Description("Отправлен")]
    Send,
    [Description("Принято")]
    Accepted
  }
}

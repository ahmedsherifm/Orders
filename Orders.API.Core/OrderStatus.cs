using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Orders.API.Core
{
    public enum OrderStatus
    {
        [Description("In Progress")]
        InProgress,
        [Description("Records Obtained")]
        RecordsObtained,
        [Description("Cancelled by Client")]
        CancelledByClient,
        [Description("Cancelled")]
        Cancelled
    }
}

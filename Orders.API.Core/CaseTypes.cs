using System.ComponentModel;

namespace Orders.API.Core
{
    public enum CaseTypes
    {
        [Description("Arbitration")]
        Arbitration = 0,
        [Description("Civil")]
        Civil = 1,
        [Description("Federal")]
        Federal = 2,
        [Description("Pre-Litigated Matter")]
        PreLitigatedMatter = 3,
        [Description("Probate")]
        Probate = 4,
        [Description("Workers' Comp")]
        WorkersComp = 5
    }
}

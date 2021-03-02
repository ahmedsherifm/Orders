using System.ComponentModel;

namespace Orders.API.Core
{
    public enum CaseTypes
    {
        [Description("Arbitration")]
        Arbitration,
        [Description("Civil")]
        Civil,
        [Description("Federal")]
        Federal,
        [Description("Pre-Litigated Matter")]
        PreLitigatedMatter,
        [Description("Probate")]
        Probate,
        [Description("Workers' Comp")]
        WorkersComp
    }
}

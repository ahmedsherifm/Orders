using System.ComponentModel;

namespace Orders.API.Core
{
    public enum RecordTypes
    {
        [Description("Academic Records")]
        AcademicRecords,
        [Description("Ambulance Records")]
        AmbulanceRecords,
        [Description("Bank Records")]
        BankRecords,
        [Description("Business Records")]
        BusinessRecords,
        [Description("Claims Records")]
        ClaimsRecords,
        [Description("Dental Records")]
        DentalRecords,
        [Description("Insurance Records")]
        InsuranceRecords,
        [Description("Medical Records")]
        MedicalRecords
    }
}

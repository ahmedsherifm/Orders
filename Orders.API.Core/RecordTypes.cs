using System.ComponentModel;

namespace Orders.API.Core
{
    public enum RecordTypes
    {
        [Description("Academic Records")]
        AcademicRecords = 0,
        [Description("Ambulance Records")]
        AmbulanceRecords = 1,
        [Description("Bank Records")]
        BankRecords = 2,
        [Description("Business Records")]
        BusinessRecords = 3,
        [Description("Claims Records")]
        ClaimsRecords = 4,
        [Description("Dental Records")]
        DentalRecords = 5,
        [Description("Insurance Records")]
        InsuranceRecords = 6,
        [Description("Medical Records")]
        MedicalRecords = 7
    }
}

using System.ComponentModel.DataAnnotations;

namespace HospitalManagement.Models
{
    public class Admission
    {
        [Key]
        public int AdmissionID { get; set; }

        [Required(ErrorMessage = "Requested Date is required")]
        [DataType(DataType.Date)]
        public DateTime RequestedDate { get; set; }

        [Required(ErrorMessage = "Admission Type is required")]
        public string AdmissionType { get; set; }

        [Required(ErrorMessage = "Reason for Admission is required")]
        [StringLength(500)]
        public string ReasonForAdmission { get; set; }

        public bool IsApproved { get; set; }

        [DataType(DataType.Date)]
        public DateTime? ApprovalDate { get; set; }

        [StringLength(500)]
        public string RejectionReason { get; set; }

    }
}

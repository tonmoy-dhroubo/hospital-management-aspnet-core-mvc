using System.ComponentModel.DataAnnotations;

namespace HospitalManagement.Models
{
    public class Billing
    {
        [Key]
        public int BillingID { get; set; }

        [Required(ErrorMessage = "Patient ID is required")]
        public int PatientID { get; set; }

        [Required(ErrorMessage = "Bill Date is required")]
        [DataType(DataType.Date)]
        public DateTime BillDate { get; set; }

        [Required(ErrorMessage = "Total Amount is required")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Total Amount must be greater than 0")]
        public decimal TotalAmount { get; set; }

        [Required(ErrorMessage = "Payment Status is required")]
        public string? PaymentStatus { get; set; }

        [StringLength(50)]
        public string? PaymentMethod { get; set; }


        [Display(Name = "Room Charges")]
        public decimal RoomCharges { get; set; }


        [Display(Name = "Medication Charges")]
        public decimal MedicationCharges { get; set; }


        [Display(Name = "Lab Test Charges")]
        public decimal LabTestCharges { get; set; }


        [Display(Name = "Surgery Charges")]
        public decimal SurgeryCharges { get; set; }


        [Display(Name = "Other Charges")]
        public decimal OtherCharges { get; set; }

    }
}

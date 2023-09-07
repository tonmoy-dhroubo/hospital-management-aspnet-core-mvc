using System.ComponentModel.DataAnnotations;

namespace HospitalManagement.Models
{
    public class Capacity
    {
        [Key]
        public int CapacityID { get; set; }

        [Required]
        public int CapacityCount { get; set; }

        [Required]
        public int Vacancy { get; set; }

        [Required]
        public RoomType Type { get; set; }
    }
}

public enum RoomType
{
    PrivateRoom,
    SemiPrivateRoom,
    WardRoom,
    ICU,
    CCU,
    OperatingRoom,
    EmergencyRoom,
    LaborAndDeliveryRoom,
    IsolationRoom,
    PediatricRoom,
    NICU,
    RadiologyRoom,
    RecoveryRoom,
    ProcedureRoom,
    PsychiatricRoom,
    PalliativeCareRoom,
    QuarintineRoom
}
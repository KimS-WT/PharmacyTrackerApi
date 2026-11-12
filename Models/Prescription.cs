namespace PharmacyTrackerApi.Models;

public class Prescription
{
    public int Id { get; set; }
    public string MedicationName { get; set; } = string.Empty;
    public string Dosage { get; set; } = string.Empty;
    public int RefillsRemaining { get; set; }


    public int PatientId { get; set; }
}
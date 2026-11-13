namespace PharmacyTrackerApi.DTOs;

public record CreatePrescriptionDto(
    string MedicationName,
    string Dosage,
    int RefillsRemaining,
    int PatientId
);
namespace PharmacyTrackerApi.DTOs;

public record CreatePatientDto
(
    string FirstName,
    string LastName,
    DateOnly DateOfBirth
);
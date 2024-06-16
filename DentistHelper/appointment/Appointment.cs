using DentistHelper.identity;

namespace DentistHelper.appointment;

/**
 * Represents a single appointment in the dentist's office.
 */
public class Appointment(long _id) {
    internal long Id { get; } = _id;
    internal Patient Patient { get; set; }
    internal DateTime Date { get; set; }
    internal double Expense { get; set; }
    internal string Description { get; set; }
    internal AppointmentStatus Status { get; set; }

    // The unique identifier of the appointment.
    // In the future, perhaps we could share our appointments with other entities.
    // This way we can identify the appointment in a unique way.
    private Guid _guid = Guid.NewGuid();

    // The next ID to be assigned to a new appointment.
    // It's a client-side ID, not a database ID.
    private static long _nextId = 1;

    public Appointment(Patient patient, DateTime date, double expense, string description, AppointmentStatus status) :
        this(_nextId++) {
        Patient = patient;
        Date = date;
        Expense = expense;
        Description = description;
        Status = status;
    }

    public override string ToString() {
        return
            $"Appointment ID: {_id}, Patient: {Patient}, Date: {Date}, Expense: {Expense:C}, Description: {Description}, Status: {Status}";
    }

    /**
     * Gets the unique identifier of the appointment.
     * Note: This is not the same as the appointment ID.
     */
    public string GetGuid() {
        return _guid.ToString();
    }
}

/**
 * Represents the status of an appointment.
 */
public enum AppointmentStatus {
    Pending,
    Completed,
    Cancelled
}
using DentistHelper.identity;

namespace DentistHelper.appointment;

/**
 * A base interface for managing appointments.
 */
public interface IAppointmentManager {
    /**
     * Adds an appointment to the database.
     */
    public Callback AddAppointment(Appointment appointment);

    /**
     * Removes an appointment from the database.
     */
    public Callback RemoveAppointment(Appointment appointment);

    /**
     * Updates an appointment in the database.
     */
    public Callback UpdateAppointment(Appointment appointment);

    /**
     * Gets all appointments from the database.
     */
    public List<Appointment> GetAppointments();

    /**
     * Gets all appointments for a specific patient.
     */
    public List<Appointment> GetAppointments(Patient patient);

    /**
     * Gets all appointments for a specific date.
     */
    public List<Appointment> GetAppointments(DateTime date);

    /**
     * Gets all appointments for a specific date range.
     */
    public List<Appointment> GetAppointments(DateTime startDate, DateTime endDate);

    /**
     * Gets all appointments for a specific status.
     */
    public List<Appointment> GetAppointments(AppointmentStatus status);

    /**
     * Search for appointments by a specific keyword.
     */
    public List<Appointment> SearchAppointments(string keyword);
    
    /**
     * Gets the sum of all expenses.
     */
    public double SumExpenses();
}

/**
 * A callback for the appointment manager.
 */
public class Callback(string message, bool success) {
    public string Message { get; } = message;
    public bool Success { get; } = success;

    /**
     * Processes the callback.
     */
    public void Process() {
        // Set the console color based on the success property
        Console.ForegroundColor = Success ? ConsoleColor.Green : ConsoleColor.Red;

        // Print the message
        Console.WriteLine(Message);

        // Reset the console color
        Console.ResetColor();
    }
}
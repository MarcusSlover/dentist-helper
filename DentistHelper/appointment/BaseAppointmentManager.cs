using DentistHelper.identity;

namespace DentistHelper.appointment;

/**
 * Barebones implementation of the appointment manager.
 */
public abstract class BaseAppointmentManager : IAppointmentManager {
    protected Dictionary<string, Appointment> _appointments = new();

    /**
     * Soft constructor.
     */
    public Callback AddAppointment(Patient patient, DateTime date, double cost, string description,
        AppointmentStatus status) {
        var appointment = new Appointment(patient, date, cost, description, status);
        return AddAppointment(appointment);
    }

    public Callback AddAppointment(Appointment appointment) {
        // Check if the appointment already exists
        if (_appointments.ContainsKey(appointment.GetGuid())) {
            return new Callback("The appointment already exists.", false);
        }

        _appointments.Add(appointment.GetGuid(), appointment);
        return new Callback("The appointment was added successfully.", true);
    }

    public Callback RemoveAppointment(Appointment appointment) {
        // Check if the appointment exists
        if (!_appointments.ContainsKey(appointment.GetGuid())) {
            return new Callback("The appointment does not exist.", false);
        }

        _appointments.Remove(appointment.GetGuid());
        return new Callback("The appointment was removed successfully.", true);
    }

    public Callback UpdateAppointment(Appointment appointment) {
        // Check if the appointment exists
        if (!_appointments.ContainsKey(appointment.GetGuid())) {
            return new Callback("The appointment does not exist.", false);
        }

        _appointments[appointment.GetGuid()] = appointment;
        return new Callback("The appointment was updated successfully.", true);
    }

    public List<Appointment> GetAppointments() {
        return _appointments.Values.ToList();
    }

    /**
     * Gets all appointments for a specific patient.
     */
    public virtual List<Appointment> GetAppointments(Patient patient) {
        var appointments = GetAppointments();
        // Filter appointments by patient
        var filteredAppointments = appointments.Where(appointment => appointment.Patient == patient);
        return filteredAppointments.ToList();
    }

    /**
     * Gets all appointments for a specific date.
     */
    public virtual List<Appointment> GetAppointments(DateTime date) {
        var appointments = GetAppointments();
        // Filter appointments by date
        var filteredAppointments = appointments.Where(appointment => appointment.Date == date);
        return filteredAppointments.ToList();
    }

    /**
     * Gets all appointments for a specific date range.
     */
    public virtual List<Appointment> GetAppointments(DateTime startDate, DateTime endDate) {
        var appointments = GetAppointments();
        // Filter appointments by date range
        var filteredAppointments =
            appointments.Where(appointment => appointment.Date >= startDate && appointment.Date <= endDate);
        return filteredAppointments.ToList();
    }

    /**
     * Gets all appointments for a specific status.
     */
    public virtual List<Appointment> GetAppointments(AppointmentStatus status) {
        var appointments = GetAppointments();
        // Filter appointments by status
        var filteredAppointments = appointments.Where(appointment => appointment.Status == status);
        return filteredAppointments.ToList();
    }

    /**
     * Search for appointments by a specific keyword.
     */
    public virtual List<Appointment> SearchAppointments(string keyword) {
        var appointments = GetAppointments();
        // Filter appointments by keyword
        var filteredAppointments = appointments.Where(appointment =>
            appointment.Patient.Name.Contains(keyword, StringComparison.CurrentCultureIgnoreCase) ||
            appointment.Description.Contains(keyword, StringComparison.CurrentCultureIgnoreCase));
        return filteredAppointments.ToList();
    }

    /**
     * Gets the sum of all expenses.
     */
    public double SumExpenses() {
        return GetAppointments().Sum(appointment => appointment.Expense);
    }

    /**
     * Gets the sum of all expenses for a specific patient.
     */
    public double SumExpenses(Patient patient) {
        return GetAppointments(patient).Sum(appointment => appointment.Expense);
    }
}
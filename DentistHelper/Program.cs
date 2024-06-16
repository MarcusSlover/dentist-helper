using DentistHelper.appointment;
using DentistHelper.identity;
using DentistHelper.impl;

namespace DentistHelper {
    internal static class Program {
        
        private static void Main() {
            AppointmentManagerImpl manager = new();
            
            var mm = new Patient("mmatyszczak", "Mariusz Matyszczak");
            manager.AddAppointment(mm, DateTime.Today, 250.0, "Teeth cleaning", AppointmentStatus.Completed).Process();
            manager.AddAppointment(mm, DateTime.Today.AddDays(1), 300.0, "Teeth whitening", AppointmentStatus.Pending).Process();
            
            var mb = new Patient("mbobrowski", "Marek Bobrowski");
            manager.AddAppointment(mb, DateTime.Today.AddDays(2), 200.0, "Teeth cleaning", AppointmentStatus.Pending).Process();
            manager.AddAppointment(mb, DateTime.Today.AddDays(3), 350.0, "Teeth whitening", AppointmentStatus.Pending).Process();
            
            // List all appointments
            var appointments = manager.GetAppointments();
            foreach (var appointment in appointments) {
                Console.WriteLine(appointment);
            }
            
            // List all appointments for a specific patient
            var appointmentsForMm = manager.GetAppointments(mm);
            foreach (var appointment in appointmentsForMm) {
                Console.WriteLine(appointment);
            }
            
            // List all appointments for a specific date
            var appointmentsForToday = manager.GetAppointments(DateTime.Today);
            foreach (var appointment in appointmentsForToday) {
                Console.WriteLine(appointment);
            }
            
            // List all appointments for a specific date range
            var appointmentsForThisWeek = manager.GetAppointments(DateTime.Today, DateTime.Today.AddDays(7));
            foreach (var appointment in appointmentsForThisWeek) {
                Console.WriteLine(appointment);
            }
            
            // List all appointments for a specific status
            var appointmentsPending = manager.GetAppointments(AppointmentStatus.Pending);
            foreach (var appointment in appointmentsPending) {
                Console.WriteLine(appointment);
            }
            
            // Search for appointments by a specific keyword
            var appointmentsTeeth = manager.SearchAppointments("Teeth");
            foreach (var appointment in appointmentsTeeth) {
                Console.WriteLine(appointment);
            }
            
            // Update an appointment
            var appointmentToUpdate = appointments.First();
            appointmentToUpdate.Description = "Teeth cleaning and whitening";
            manager.UpdateAppointment(appointmentToUpdate).Process();
            
            // Remove an appointment
            var appointmentToRemove = appointments.Last();
            manager.RemoveAppointment(appointmentToRemove).Process();
            
            // Get the sum of all expenses
            var sum = manager.SumExpenses();
            Console.WriteLine($"Sum of all expenses: {sum:C}");
            
            var sumForMm = manager.SumExpenses(mm);
            Console.WriteLine($"Sum of all expenses for {mm}: {sumForMm:C}");
        }
    }
}
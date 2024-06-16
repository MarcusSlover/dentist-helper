namespace DentistHelper.identity;

/**
 * Represents a patient that can be identified.
 * For instance, as a parent, you can switch your profile to view your child's profile.
 */
public interface IIdentifiablePatient {
    /**
     * The identifier of the patient.
     */
    protected string Identifier { get; }

    /**
     * Returns the identifier of the patient.
     */
    string Identify();
}
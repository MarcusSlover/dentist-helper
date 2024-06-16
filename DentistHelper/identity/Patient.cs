namespace DentistHelper.identity;

/**
 * Represents a patient that can be identified.
 */
public class Patient(string identifier, string name) : IIdentifiablePatient {
    /**
     * Implements the identifier of the patient.
     */
    public string Identifier { get; } = identifier;

    public string Name { get; } = name;

    /**
     * Gets the identifier of the patient.
     */
    public string Identify() {
        return Identifier;
    }
    
    public override string ToString() {
        return "[" + identifier + " - " + name + "]";
    }
}
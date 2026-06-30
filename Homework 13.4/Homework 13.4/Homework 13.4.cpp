// Homework 13.4.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include <iostream>
#include <string>
#include <ctime>
using namespace std;

// function for current date
string getCurrentDate() {
	// get current timestamp
    time_t now = time(0);
	// convert to tm struct
    tm ltm;
	// use localtime_s for safety on Windows
    localtime_s(&ltm, &now);
	// format date as MM/DD/YYYY
    string date = to_string(ltm.tm_mon + 1) + "/" + to_string(ltm.tm_mday) + "/" + to_string(ltm.tm_year + 1900);
    return date;
}

//Write a class named Patient that has member variables for the following data: First name, middle name, last name
//Address, city, state, and ZIP code, Phone number, Name and phone number of emergency contact
class Patient {
    private:
    string firstName;
    string middleName;
    string lastName;
    string address;
    string city;
    string state;
    string zipCode;
    string phoneNumber;
    string emergencyContactName;
	string emergencyContactPhoneNumber;
    public:
    //Constructor
    Patient(string fName, string mName, string lName, string addr, string cty, string st, string zip, string phone, string eContactName, string eContactPhone) {
        firstName = fName;
        middleName = mName;
        lastName = lName;
        address = addr;
        city = cty;
        state = st;
        zipCode = zip;
        phoneNumber = phone;
        emergencyContactName = eContactName;
        emergencyContactPhoneNumber = eContactPhone;
    }
    //Setters
    void setFirstName(string fName) {
        firstName = fName;
    }
    void setMiddleName(string mName) {
        middleName = mName;
    }
    void setLastName(string lName) {
        lastName = lName;
    }
    void setAddress(string addr) {
        address = addr;
    }
    void setCity(string cty) {
        city = cty;
    }
    void setState(string st) {
        state = st;
    }
    void setZipCode(string zip) {
        zipCode = zip;
    }
    void setPhoneNumber(string phone) {
        phoneNumber = phone;
    }
    void setEmergencyContactName(string eContactName) {
        emergencyContactName = eContactName;
    }
    void setEmergencyContactPhoneNumber(string eContactPhone) {
        emergencyContactPhoneNumber = eContactPhone;
    }
    //Getters
    string getFirstName() {
        return firstName;
    }
    string getMiddleName() {
        return middleName;
    }
    string getLastName() {
        return lastName;
    }
    string getAddress() {
        return address;
    }
    string getCity() {
        return city;
    }
    string getState() {
        return state;
    }
    string getZipCode() {
        return zipCode;
    }
    string getPhoneNumber() {
        return phoneNumber;
    }
    string getEmergencyContactName() {
        return emergencyContactName;
    }
    string getEmergencyContactPhoneNumber() {
        return emergencyContactPhoneNumber;
    }
};

// Create a class for procedures with the following member variables: Name of procedure, date of procedure
// Practitioner's name, and charge for procedure
class Procedure {
    private:
    string procedureName;
    string procedureDate;
    string practitionerName;
    double procedureCharge;
    public:
    //Constructor
    Procedure(string pName, string pDate, string prName, double pCharge) {
        procedureName = pName;
        procedureDate = pDate;
        practitionerName = prName;
        procedureCharge = pCharge;
    }
    //Setters
    void setProcedureName(string pName) {
        procedureName = pName;
    }
    void setProcedureDate(string pDate) {
        procedureDate = pDate;
    }
    void setPractitionerName(string prName) {
        practitionerName = prName;
    }
    void setProcedureCharge(double pCharge) {
        procedureCharge = pCharge;
    }
    //Getters
    string getProcedureName() {
        return procedureName;
    }
    string getProcedureDate() {
        return procedureDate;
    }
    string getPractitionerName() {
        return practitionerName;
    }
    double getProcedureCharge() {
        return procedureCharge;
    }
};


int main()
{
	// create an instance of the Patient class and initialize it with sample data.
    Patient patient("John", "A.", "Doe", "123 Main St", "Anytown", "CA", "12345", "555-1234", "Jane Doe", "555-5678");
    // create three instances of the Procedure class and initialize them with sample data.
    Procedure procedure1("Physical Exam", getCurrentDate(), "Dr. Irvine", 250.00);
    Procedure procedure2("X-Ray", getCurrentDate(), "Dr. Jamison", 500.00);
    Procedure procedure3("Blood Test", getCurrentDate(), "Dr. Smith", 200.00);

    // display the patient's information and the details of each procedure, including the total charge for all procedures.
    cout << "Patient Information:" << endl;
    cout << "Name: " << patient.getFirstName() << " " << patient.getMiddleName() << " " << patient.getLastName() << endl;
    cout << "Address: " << patient.getAddress() << ", " << patient.getCity() << ", " << patient.getState() << " " << patient.getZipCode() << endl;
    cout << "Phone Number: " << patient.getPhoneNumber() << endl;
    cout << "Emergency Contact: " << patient.getEmergencyContactName() << ", Phone: " << patient.getEmergencyContactPhoneNumber() << endl;
    cout << endl;
    cout << "Procedures:" << endl;
    cout << procedure1.getProcedureName() << ", Date: " << procedure1.getProcedureDate() << ", Practitioner: " << procedure1.getPractitionerName() << ", Charge: $" << procedure1.getProcedureCharge() << endl;
    cout << procedure2.getProcedureName() << ", Date: " << procedure2.getProcedureDate() << ", Practitioner: " << procedure2.getPractitionerName() << ", Charge: $" << procedure2.getProcedureCharge() << endl;
    cout << procedure3.getProcedureName() << ", Date: " << procedure3.getProcedureDate() << ", Practitioner: " << procedure3.getPractitionerName() << ", Charge: $" << procedure3.getProcedureCharge() << endl;
    double totalCharge = procedure1.getProcedureCharge() + procedure2.getProcedureCharge() + procedure3.getProcedureCharge();
    cout << endl;
	cout << "Total Charge for all Procedures: $" << totalCharge << endl;
};






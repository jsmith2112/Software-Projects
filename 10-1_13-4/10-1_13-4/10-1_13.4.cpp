// 10-1_13-4.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include <iostream>
#include <string>
using namespace std;



// PersonalInfo class declaration
class PersonalInfo {
private:
	string name;
	string address;
	int age;
	string phoneNumber;

public:

	// default constructor
	PersonalInfo()
	{
		name = "";
		address = "";
		age = 0;
		phoneNumber = "";
	}

	// parameterized constructor
	PersonalInfo(string n, string addr, int a, string p)
	{
		setName(n);
		setAddress(addr);
		setAge(a);
		setPhoneNumber(p);
	}

	// mutator/setter functions
	void setName(string n) { name = n; }
	void setAddress(string addr) { address = addr; }
	void setAge(int a) { age = a; }
	void setPhoneNumber(string p) { phoneNumber = p; }

	// Accessor functions
	string getName() const { return name; }
	string getAddress() const { return address; }
	int getAge() const { return age; }
	string getPhoneNumber() const { return phoneNumber; }


};

// Function prototypes
void displayPersonalInfo(PersonalInfo);


int main()
{
	// Create an instances of PersonalInfo, family member and friend
	PersonalInfo me("Herb Dorfman", "27 Technology Drive", 25, "555-1212");
	PersonalInfo auntSally("Sally Dorfman", "48 Friendly Street", 50, "555-8484");
	PersonalInfo joe("Joe Looney", "191 Apple MOuntain Road", 30, "555-2222");

	// display the data in each object
	displayPersonalInfo(me);
	displayPersonalInfo(auntSally);
	displayPersonalInfo(joe);
   
	return 0;
}

void displayPersonalInfo(PersonalInfo obj)
{
	cout << "Name: " << obj.getName() << endl;
	cout << "Address: " << obj.getAddress() << endl;
	cout << "Age: " << obj.getAge() << endl;
	cout << "Phone Number: " << obj.getPhoneNumber() << endl;
	cout << "\n";
}


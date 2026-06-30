// This file contains the 'main' function. Program execution begins and ends there.
//

#include <iostream>
#include <string>
using namespace std;


// feetInches class
class FeetInches
{
private:
	int feet;
	int inches;
	double meters;
	double centimeters;
	double millimeters;
public:
	// Constructor
	FeetInches() : feet(0), inches(0) {}

	// Overloaded Constructor
	FeetInches(int f, int i) : feet(f), inches(i) {}
	FeetInches(double m, double cm, double mm) : meters(m), centimeters(cm), millimeters(mm) {}

	// One line default setters
	void setFeet(int f) { feet = f; }
	void setInches(int i) { inches = i; }
	void setMeters(double m) { meters = m; }
	void setCentimeters(double cm) { centimeters = cm; }
	void setMillimeters(double mm) { millimeters = mm; }

	// One line default Getters
	int getFeet() const { return feet; }
	int getInches() const { return inches; }
	double getMeters() const { return meters; }
	double getCentimeters() const { return centimeters; }
	double getMillimeters() const { return millimeters; }
};


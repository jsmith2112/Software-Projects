// HW_14_13.cpp : This file contains the 'main' function. Program execution begins and ends there.
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
	FeetInches(double m, double cm, double mm)
	{
		meters = m;
		centimeters = cm;
		millimeters = mm;
	}

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

// RoomDimensions class using 2 FeetInches objects
class RoomDimensions
{
private:
	FeetInches length;
	FeetInches width;

public:
	// Default Constructor
	RoomDimensions() : length(0, 0), width(0, 0) {}

	// Overloaded Constructor
	RoomDimensions(FeetInches l, FeetInches w) : length(l), width(w) {}
	RoomDimensions(double lm, double lcm, double lmm, double wm, double wcm, double wmm)
	{
		length.setMeters(lm);
		length.setCentimeters(lcm);
		length.setMillimeters(lmm);
		width.setMeters(wm);
		width.setCentimeters(wcm);
		width.setMillimeters(wmm);
	}

	// One line default setters
	void setLength(FeetInches l) { length = l; }
	void setWidth(FeetInches w) { width = w; }
	void setLength(double lm, double lcm, double lmm)
	{
		length.setMeters(lm);
		length.setCentimeters(lcm);
		length.setMillimeters(lmm);
	}
	void setWidth(double wm, double wcm, double wmm)
	{
		width.setMeters(wm);
		width.setCentimeters(wcm);
		width.setMillimeters(wmm);
	}

	// One line default Getters
	FeetInches getLength() const { return length; }
	FeetInches getWidth() const { return width; }
	FeetInches getLengthMetric() const { return length; }
	FeetInches getWidthMetric() const { return width; }


	// multiply member function
	FeetInches multiply()
	{
		int totalInchesLength = length.getFeet() * 12 + length.getInches();
		int totalInchesWidth = width.getFeet() * 12 + width.getInches();
		int areaInches = totalInchesLength * totalInchesWidth;
		int areaFeet = areaInches / 144; // 1 square foot = 144 square inches
		int areaRemainingInches = areaInches % 144;
		return FeetInches(areaFeet, areaRemainingInches);
	}
	FeetInches multiplyMetric()
	{
		double lengthMeters = length.getMeters() + (length.getCentimeters() / 100.0) + (length.getMillimeters() / 1000.0);
		double widthMeters = width.getMeters() + (width.getCentimeters() / 100.0) + (width.getMillimeters() / 1000.0);
		double areaSquareMeters = lengthMeters * widthMeters;
		return FeetInches(areaSquareMeters, 0, 0); // returning only meters for simplicity
	}
};
// RoomCarpet class using a RoomDimensions object and a double for cost per square foot
class RoomCarpet
{
private:
	RoomDimensions dimensions;
	double costPerSquareFoot;
public:
	// Overloaded Constructor
	RoomCarpet(RoomDimensions d, double cost)
	{
		dimensions = d;
		costPerSquareFoot = cost;
	}
	// One line default setters
	void setDimensions(RoomDimensions d) { dimensions = d; }
	void setCostPerSquareFoot(double cost) { costPerSquareFoot = cost; }

	// One line default Getters
	RoomDimensions getDimensions() const { return dimensions; }
	double getCostPerSquareFoot() const { return costPerSquareFoot; }

	// totalCost member function
	double totalCost()
	{
		FeetInches area = dimensions.multiply();
		int totalAreaInches = area.getFeet() * 144 + area.getInches();
		double totalAreaFeet = static_cast<double>(totalAreaInches) / 144.0;
		return totalAreaFeet * costPerSquareFoot;
	}
	double totalCostMetric()
	{
		FeetInches area = dimensions.multiplyMetric();
		double areaSquareMeters = area.getMeters();
		double areaSquareFeet = areaSquareMeters * 10.7639; // 1 square meter = 10.7639 square feet
		return areaSquareFeet * costPerSquareFoot;
	}
};

// function prototypes for room dimensions and carpet cost input validation
FeetInches validateFeetInches(int feet, int inches);
double validateCost(double cost);

int main()
{
	// prompt user for room dimensions
	char unitChoice;
	cout << "Choose metric or imperial units (m/i): ";
	cin >> unitChoice;

	if (unitChoice == "m") {

		int lengthFeet, lengthInches;
		cout << "Enter room length (feet inches): ";
		cin >> lengthFeet >> lengthInches;
		FeetInches length = validateFeetInches(lengthFeet, lengthInches);

		int widthFeet, widthInches;
		cout << "Enter room width (feet inches): ";
		cin >> widthFeet >> widthInches;
		FeetInches width = validateFeetInches(widthFeet, widthInches);

		// create RoomDimensions object
		RoomDimensions room(length, width);

		// prompt user for carpet cost per square foot
		double costPerSquareFoot;
		cout << "Enter carpet cost per square foot: $";
		cin >> costPerSquareFoot;
		costPerSquareFoot = validateCost(costPerSquareFoot);

		// create RoomCarpet object
		RoomCarpet carpet(room, costPerSquareFoot);

		// display room area
		//FeetInches area = room.multiply();	
		//cout << "Room area: " << area.getFeet() << " feet " << area.getInches() << " inches" << endl;

		// display total cost
		cout << "Total carpet cost: $" << carpet.totalCost() << endl;
	}
	else {
		double lengthMeters, lengthCentimeters, lengthMillimeters;
		cout << "Enter room length (meters centimeters millimeters): ";
		cin >> lengthMeters >> lengthCentimeters >> lengthMillimeters;
		double widthMeters, widthCentimeters, widthMillimeters;
		cout << "Enter room width (meters centimeters millimeters): ";
		cin >> widthMeters >> widthCentimeters >> widthMillimeters;
		widthMeters = validateMetricDimensions(widthMeters);
		lengthMeters = validateMetricDimensions(lengthMeters);
		widthCentimeters = validateMetricDimensions(widthCentimeters);
		lengthCentimeters = validatvalidateMetricDimensionseCostMetric(lengthCentimeters);
		widthMillimeters = validateMetricDimensions(widthMillimeters);
		lengthMillimeters = validateMetricDimensions(lengthMillimeters);

		// create RoomDimensions object
		RoomDimensions room(lengthMeters, lengthCentimeters, lengthMillimeters,
			widthMeters, widthCentimeters, widthMillimeters);
		// prompt user for carpet cost per square meter
		double costPerSquareFoot;
		cout << "Enter carpet cost per square meter: $";
		cin >> costPerSquareFoot;
		costPerSquareFoot = validateCost(costPerSquareFoot);
		// create RoomCarpet object
		RoomCarpet carpet(room, costPerSquareFoot);
		// display total cost
		cout << "Total carpet cost: $" << carpet.totalCostMetric() << endl;
	}




	return 0;
}

// function to validate feet and inches input
FeetInches validateFeetInches(int feet, int inches)
{
	while (feet < 0 || inches < 0 || inches > 11)
	{
		cout << "Invalid input. Please enter non-negative feet and inches (<12 for inches)." << endl;
		cout << "Enter room dimension (feet inches): ";
		cin >> feet >> inches;
	}
	FeetInches fi(feet, inches);

	return fi;
}
// function to validate cost input
FeetInches validateMetricDimensions(double meters, double centimeters, double millimeters)
{
	while (meters < 0 || centimeters < 0 || centimeters >= 100 || millimeters < 0 || millimeters >= 1000)
	{
		cout << "Invalid input. Please enter non-negative meters, centimeters (<100), and millimeters (<1000)." << endl;
		cout << "Enter room dimension (meters centimeters millimeters): ";
		cin >> meters >> centimeters >> millimeters;
	}
	FeetInches fi(meters, centimeters, millimeters);
	return fi;
}
double validateCost(double cost)
{
	while (cost < 0)
	{
		cout << "Invalid input. Please enter a non-negative cost." << endl;
		cout << "Enter carpet cost per square foot: $";
		cin >> cost;
	}
	return cost;
}








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
public:
	// Constructor
	FeetInches() : feet(0), inches(0) {}

	// Overloaded Constructor
	FeetInches(int f, int i) : feet(f), inches(i) {}

	// One line default setters
	void setFeet(int f) { feet = f; }
	void setInches(int i) { inches = i; }

	// One line default Getters
	int getFeet() const { return feet; }
	int getInches() const { return inches; }
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

	// One line default setters
	void setLength(FeetInches l) { length = l; }
	void setWidth(FeetInches w) { width = w; }

	// One line default Getters
	FeetInches getLength() const { return length; }
	FeetInches getWidth() const { return width; }

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
};

// function prototypes for room dimensions and carpet cost input validation
FeetInches validateFeetInches(int feet, int inches);
double validateCost(double cost);

int main()
{
	// prompt user for room dimensions
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
	costPerSquareFoot=validateCost(costPerSquareFoot);

	// create RoomCarpet object
	RoomCarpet carpet(room, costPerSquareFoot);

	// display room area
	//FeetInches area = room.multiply();	
	//cout << "Room area: " << area.getFeet() << " feet " << area.getInches() << " inches" << endl;

	// display total cost
	cout << "Total carpet cost: $" << carpet.totalCost() << endl;

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







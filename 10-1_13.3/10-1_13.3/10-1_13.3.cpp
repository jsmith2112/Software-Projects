// 10-1_13.3.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include <iostream>
#include <string>
#include <iomanip>
using namespace std;

// Create car class with the following specifications: Make, Year, Speed
class Car
{
private:
	string make;
	int yearModel;
	int speed;

public:
	// contructors
	Car(string m, int y)
	{
		make = m;
		yearModel = y;
		speed = 0;
	}
	// accessors
	string getMake() const { return make; }
	int getYear() const { return yearModel; }
	double getSpeed() const { return speed; }

	// accelerate function
	void accelerate() { speed += 5; }
	// brake function
	void brake()
	{
		if (speed >= 5)
			speed -= 5;
	};
};

int main()
{

	// loop counter
	int count;

	// create a car object, prsche(2006, "Porsche")
	Car porsche("Porsche", 2006);

	// display the car's current speed
	cout << "Current speed: " << porsche.getSpeed() << " mph" << endl;

	// accelerate the car 5 times
	for (count = 0; count < 5; count++)
	{
		porsche.accelerate();
		cout << "Acelerating...\n";
		cout << "Current speed: " << porsche.getSpeed() << endl;
	}
	// space between sections
	cout << "\n";
	// brake the car 5 times
	for (count = 0; count < 5; count++)
	{
		porsche.brake();
		cout << "Braking...\n";
		cout << "Current speed: " << porsche.getSpeed() << " mph" << endl;
	}

	return 0;
}
// Homework_16.3.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include <iostream>
#include <iomanip>
using namespace std;

template <typename T>
// function to return maximum of two values
T getMax(T a, T b)
{
    return (a > b) ? a : b;
}
template <typename T>
// function to return minimum of two values
T getMin(T a, T b)
{
    return (a < b) ? a : b;
}

int main()
{
	// set output formatting
	cout << fixed << setprecision(2);
	// prompt user for two integers
	int int1, int2;
	cout << "Enter two integers: ";
	cin >> int1 >> int2;
	// display maximum and minimum of two integers
	cout << "Maximum: " << getMax(int1, int2) << endl;
	cout << "Minimum: " << getMin(int1, int2) << endl;
	// prompt user for two doubles
	double double1, double2;
	cout << "Enter two doubles: ";
	cin >> double1 >> double2;
	// display maximum and minimum of two doubles
	cout << "Maximum: " << getMax(double1, double2) << endl;
	cout << "Minimum: " << getMin(double1, double2) << endl;

	return 0;
}



// 10-1_Lab_Work.cpp : This file contains the 'main' function. Program execution begins and ends there.
// 12.11
#include <iostream>
#include <fstream>
#include <cstring>

using namespace std;

// constnant for the size of the array months
const int SIZE = 12;

// declaration of the division structure
struct Division
{
	char divName[SIZE];
	int quarter;            // name of the division
    double sales;   // sales for each month
};

int main()
{
	// need filestream object
	ofstream file("corp.dat", ios::out | ios::binary);

	// create structures for each Division North, South, East, West
	Division north, south, east, west;

	// Loop counter for each quarter
	int qtr;

	// Assign the division names to the division structure variables
	strcpy_s(north.divName, "North");
	strcpy_s(south.divName, "South");
	strcpy_s(east.divName, "East");
	strcpy_s(west.divName, "West");

	// Ask User to Enter Quarterly sales data for East Division	
	cout << "Enter the quarterly sales data for the East Division\n";
	for (qtr = 1; qtr <= 4; qtr++)
	{
		east.quarter = qtr;
		cout << "\tQuarter " << qtr << ": ";
		cin >> east.sales;
		// write the data to the file
		file.write(reinterpret_cast<char *>(&east), sizeof(east));
	}
	
	// redo for West Division
	cout << "Enter the quarterly sales data for the West Division\n";	
	for (qtr = 1; qtr <= 4; qtr++)
	{
		west.quarter = qtr;
		cout << "\tQuarter " << qtr << ": ";
		cin >> west.sales;
		// write the data to the file	
		file.write(reinterpret_cast<char *>(&west), sizeof(west));
	}
	// redo for North Division
	cout << "Enter the quarterly sales data for the North Division\n";
	for (qtr = 1; qtr <= 4; qtr++)
	{
		north.quarter = qtr;
		cout << "\tQuarter " << qtr << ": ";
		cin >> north.sales;
		// write the data to the file
		file.write(reinterpret_cast<char *>(&north), sizeof(north));
	}
	// redo for South Division
	cout << "Enter the quarterly sales data for the South Division\n";	

} // end of main



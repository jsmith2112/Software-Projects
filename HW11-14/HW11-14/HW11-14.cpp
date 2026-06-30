// HW11-14.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include <iostream>
#include <iomanip>
#include <string>
using namespace std;

// struct to hold parts description and number of parts in bin
struct parts
{
    string description;
    int number;
};

// function prototypes for AddParts and RemoveParts, show parts in bin and number of parts
void AddParts(parts&, int);
void RemoveParts(parts&, int);
void ShowParts(const parts&);

int main()
{
    // create and intialize an array of 10 bins to hold parts
	const int SIZE = 10;
    parts bins[SIZE] = {
        {"Valve", 10},
        {"Bearing", 5},
        {"Bushing", 15},
        {"Coupling", 21},
        {"Flange", 7},
        {"Gear", 5},
        {"Gear Housing", 5},
        {"Vacuum Gripper", 25},
        {"Cable", 18},
        {"Rod", 12}
    };
    int choice;
    int binNumber;
    int amount;
	int counter = 0;

	// do loop to pick a bin to add or remove parts from
    do
    {
        cout << "      Part Description" << "   " << setw(15) << "Number of Parts" << endl;

        // Call ShowParts function to display parts in each bin and number of parts
        for (int i = 0; i < SIZE - 1; i++)
        {
            cout << i + 1 << ". ";
            ShowParts(bins[i]);
			counter += bins[i].number;
        }
        if (bins[SIZE - 1].number < 5)
            cout << "10. " << setw(14) << bins[SIZE - 1].description << setw(15) << bins[9].number << setw(15) << "Low Stock" << endl;
		else
        cout << "10. " << setw(14) << bins[SIZE - 1].description << setw(15) << bins[9].number << endl;
		cout << "Total number of parts in all bins: " << counter << endl;
		cout << endl;

        cout << "Enter the bin number (1-10) to add or remove parts, or 0 to quit: ";
        cin >> binNumber;
        if (binNumber < 0 || binNumber > 10)
        {
            cout << "Invalid bin number. Please enter a number between 1 and 10." << endl;
            continue;
        }
        else if (binNumber == 0)
        {
            break;
        }
        cout << "Enter 1 to add parts or 2 to remove parts: ";
        cin >> choice;
        if (choice != 1 && choice != 2)
        {
            cout << "Invalid choice. Please enter 1 to add parts or 2 to remove parts." << endl;
            continue;
        }

        cout << "Enter the number of parts: ";
        cin >> amount;

        cout << endl;

        if (amount < 0)
        {
            cout << "Invalid amount. Please enter a positive number." << endl;
            continue;
        }
        if (amount + bins[binNumber - 1].number > 30)
            {
            cout << "Error: Cannot add " << amount << " parts. Bin capacity of 30 exceeded." << endl;
            continue;
		}
        if (choice == 1)
        {
            AddParts(bins[binNumber - 1], amount);
        }
        else if (choice == 2)
        {
            RemoveParts(bins[binNumber - 1], amount);
        }
    } while (true);
	cout << "Exiting program." << endl;



    
	return 0;

}

// function to add parts to the bin

void AddParts(parts& bin, int amount)
{
    bin.number += amount;
    //cout << amount << " parts added. Total parts in bin: " << bin.number << endl;
}
// function to remove parts from the bin
void RemoveParts(parts& bin, int amount)
{
    if (amount > bin.number)
    {
        cout << "Error: Not enough parts in bin to remove " << amount << " parts." << endl;
    }
    else
    {
        bin.number -= amount;
        //cout << amount << " parts removed. Total parts in bin: " << bin.number << endl;
    }
}
// function to show parts in the bin and number of parts
void ShowParts(const parts& bin)
{
    if (bin.number < 5)
        cout << setw(15) << bin.description << setw(15) << bin.number << setw(15) << "Low Stock" << endl;
	else
        cout << setw(15) << bin.description << setw(15) << bin.number << endl;

}


// CandyBarMachine.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include <iostream>
#include <string>   
#include <array>
using namespace std;

// Function prototypes
void displayCandyBarOptions(const array<struct CandyBar, 5>& candyBars);

// Create a struct for candy bars with Candy Name, Candy Cost, and Number of Candy Bars in Machine
struct CandyBar {
    string name;
    double cost;
    int quantity;
};

int main()
{
	// Create an array of CandyBar structs to hold the candy bar options
    array<CandyBar, 5> candyBars = {
        CandyBar{"Snickers", 1.00, 15},
        CandyBar{"KitKat", 0.95, 15},
        CandyBar{"Twix", 0.85, 15},
        CandyBar{"Milky Way", 0.90,15},
        CandyBar{"Reese's", 1.00, 15}
    };
	// create a loop to display the candy bar options and get user input until the user chooses to exit
    int choice = 0;
    double totalSales = 0.0;
    while (choice != 6) {
        displayCandyBarOptions(candyBars);
        cout << "Enter your choice (1-6): ";
        cin >> choice;
        // Validate user input
        if (choice < 1 || choice > 7) {
            cout << "Invalid choice. Please try again." << endl;
            continue;
        }
        // If user chooses to exit, break the loop
        if (choice == 6) {
            cout << "Exiting the program. Total sales: $" << totalSales << endl;
            break;
        }
        // if user chooses 7 set all quantities to 15
        if (choice == 7) {
            for (auto& bar : candyBars) {
                bar.quantity = 15;
            }
			cout << "All candy bars have been restocked to 15." << endl;
			continue;
        }
        // else get user money and process sale
         
        if (choice > 0 && choice < 6){
            int index = choice - 1;
            if (candyBars[index].quantity > 0) {
                double userMoney;
                cout << "You selected " << candyBars[index].name << " which costs $" << candyBars[index].cost << endl;
                cout << "Please enter your money: $";
                cin >> userMoney;
                if (userMoney >= candyBars[index].cost) {
                    candyBars[index].quantity--;
                    totalSales += candyBars[index].cost;
                    double change = userMoney - candyBars[index].cost;
                    cout << "Dispensing " << candyBars[index].name << ". Your change is $" << change << endl;
                } else {
                    cout << "Insufficient funds. Transaction cancelled." << endl;
                }
            } else {
                cout << "Sorry, " << candyBars[index].name << " is out of stock." << endl;
			}
			continue;

        }
        // display total sales when user exits
        cout << "Total sales: $" << totalSales << endl;

        return 0;
    }
}
	// Function to display the candy bar options
    void displayCandyBarOptions(const array<struct CandyBar, 5>&candyBars) {
        cout << "Candy Bar Machine Options:" << endl;
        for (size_t i = 0; i < candyBars.size(); i++) {
            cout << i + 1 << ". " << candyBars[i].name << " - $" << candyBars[i].cost
                << " (" << candyBars[i].quantity << " in stock)" << endl;
        }
        cout << "6. Exit" << endl;
        cout << "7. Restock All Candy Bars" << endl;
    }





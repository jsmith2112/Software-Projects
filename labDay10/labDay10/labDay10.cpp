// labDay10.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include <iostream>
using namespace std;

// global constants
const int SIZE = 80;
const int MIN = 6;

// function prototypes
void displayRequirements();
void displayResult(char str[]);
bool isValid(char str[]);
bool verifyPassword(string password);
bool hasLength(char[]);
bool hasUpper(char[]);
bool hasLower(char[]);
bool hasDigit(char[]);


int main()
{
	char cstring[SIZE];// to hold the user's password

	// display the password requirements
    displayRequirements();

    // get the password from the user
    cout << "Enter your password: ";
    cin.getline(cstring, SIZE);

	// validate the password and display the result
	displayResult(cstring);

	return 0;
}

void displayResult(char str[])
{
	// determine if password is valid
    
	//call isValid function
    if (isValid(str))
    {
        cout << "Password is valid." << endl;
    }
    else
    {

	// display which requirements are met
	// determine if length requirement is met
    if (!hasLength(str))
    {
        cout << "Password should be at least " << MIN << " characters long. \n" << endl;
    }

	// determine if uppercase letter requirement is met
    if (!hasUpper(str))
    {
        cout << "Password should have at least one uppercase letter. \n" << endl;
    }
	// determine if lowercase letter requirement is met
    if (!hasLower(str))
    {
        cout << "Password should have at least one lowercase letter. \n" << endl;
    }
	// determine if digit requirement is met
    if (!hasDigit(str))
    {
        cout << "Password should have at least one digit. \n" << endl;
    }
  }
}

bool isValid(char str[])
{
    if (hasLength(str) && hasUpper(str) && hasLower(str) && hasDigit(str))
    {
        return true;
    }
    return false;
}

bool verifyPassword(string password)
{
    if (password.length() < MIN)
    {
        return false;
    }
    return true;
}

void displayRequirements()
{
    cout << "Password Requirements:" << endl;
    cout << "1. At least " << MIN << " characters long" << endl;
    cout << "2. Contains at least one uppercase letter" << endl;
    cout << "3. Contains at least one lowercase letter" << endl;
    cout << "4. Contains at least one digit" << endl;
}
bool hasLength(char str[])
{
	bool status = false;
	int count = 0;

    while (*str != '\0')
    {
        *str++;
		count++;
	}
    if (count >= MIN)
    {
        status = true;
	}
	// return status
	return status;

}
bool hasUpper(char str[])
{
    bool status = false;
    int count = 0;
    while (*str != '\0' && count == 0)
    {
        if (isupper(*str))
        {
            count++;
            status = true;
        }
        else
        {
            *str++;
        }
    }
    return status;
    if (count > 0)
    {
        status = true;
    }
    // return status
    return status;
}
bool hasLower(char str[])
{
	bool status = false;
    int count = 0;
    while (*str != '\0' && count == 0)
    {
        if (islower(*str))
        {
            count++;
            status = true;
		}
        else
            {
			*str++;
            }
    }
    return status;
    if (count > 0)
    {
        status = true;
    }
	// return status
	return status;
}
bool hasDigit(char str[])
{
    bool status = false;
    int count = 0;
    while (*str != '\0' && count == 0)
    {
        if (isdigit(*str))
        {
            count++;
            status = true;
        }
        else
        {
            *str++;
        }
    }
    return status;
    if (count > 0)
    {
        status = true;
    }
    // return status
    return status;
}


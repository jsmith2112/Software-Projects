// HW1_9-9.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include <iostream>
using namespace std;

// function prototype
double medianFunction(int* arrPtr, int size);
void displayArray(int *arrPtr, int size);


int main()
{
	// create an array of integers from which to find the median
    int arr[] = { 3, 5, 7, 19, 32, 54 };
	// create a second arrary of integers from which to find the median
	int arr2[] = { 3, 5, 7, 19, 32, 54, 78 };
	// create a pointer to the array
	int *arrPtr = arr;
	int *arrPtr2 = arr2;
    // create a variable to hold the size of the array
    int size = sizeof(arr) / sizeof(*(arrPtr + 0));
	// create a variable to hold the size of the second array
	int size2 = sizeof(arr2) / sizeof(*(arrPtr2 + 0));

    // call the median function for each array and display the result
    double median = medianFunction(arrPtr, size);
	displayArray(arrPtr, size);
    cout << "Median: " << median << endl;
    
	double median2 = medianFunction(arrPtr2, size2);
	displayArray(arrPtr2, size2);
	cout << "Median: " << median2 << endl;
	return 0;
}

double medianFunction(int *arrPtr, int size)
{
	// create a pointer to the array
	int *ptr = arrPtr;


    
    // Calculate median
    if (size % 2 == 0)
    {
        return (ptr[size / 2 - 1] + ptr[size / 2]) / 2.0;
    }
    else
    {
        return ptr[size / 2];
    }
}
void displayArray(int *arrPtr, int size)
{
    for (int i = 0; i < size; i++)
    {
        cout << *(arrPtr + i) << " ";
    }
    cout << endl;
}


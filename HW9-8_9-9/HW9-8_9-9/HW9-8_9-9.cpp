// HW9-8_9-9.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include <iostream>

using namespace std;

int modeFunction(int arr[], int);

int main()

//{
{
	// create an array to hold 10 integers
	int arr[10]{};
	// ask the user to enter 10 integers
	cout << "Enter 10 integers to find their mode." << endl;
	// get user input
	for (int i = 0; i < 10; i++)
		cin >> (*(arr + i));
	// create an array of 10 integers to hold our integers
	//int arr[10]{ 1, 2, 3, 4, 5, 5, 6, 8, 5, 10 };
	// Create a pointer to the array
	int (*arrPtr)[10] = &arr;
	// create a size variable to hold the number of integers in our array
	int size = sizeof(arr)/sizeof(arr[0]);
	// call modeFunction to get the mode of the array
	int mode = modeFunction(*arrPtr, size);
	// print the mode
	if (mode != -1) {
		cout << "The mode is: " << mode << endl;
	}
	else {
		cout << "There is no mode." << endl;
	}
	return 0;
}
int modeFunction(int arr[], int size) {
	// create a frequency array to hold the frequency of each integer
	int frequency[101] = { 0 };
	// create a pointer to arr arrays
	int *ptr = arr;
	// loop through the array and count the frequency of each integer
	for (int i = 0; i < size; i++) {
		frequency[*(ptr + i)]++;
		//cout << frequency[*(ptr + i)] << endl;
	}
	// find the maximum frequency
	int maxFrequency = 0;
	for (int i = 0; i < 101; i++) {
		if (*(frequency + i) > maxFrequency) {
			maxFrequency = *(frequency + i);
		}
	}
	// if the maximum frequency is 1, there is no mode
	if (maxFrequency == 1) {
		return -1;
	}
	// find the integer with the maximum frequency
	for (int i = 0; i < 101; i++) {
		if (*(frequency + i) == maxFrequency) {
			return i;
		}
	}
	return -1;
}



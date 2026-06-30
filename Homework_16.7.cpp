// Homework_16.7.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include <iostream>
#include <iomanip>
using namespace std;

// class named test scores
class TestScores
{
    private:
    double* scores; // pointer to hold array of scores
	int numScores;  // number of scores
    public:
    // constructor
    TestScores(double* arr, int size)
    {
		// set number of scores and allocate memory
        numScores = size;
        scores = new double[numScores];

		// copy and validate scores
        for (int i = 0; i < numScores; i++)
        {
            if (arr[i] < 0 || arr[i] > 100)
            {
                throw invalid_argument("Score must be between 0 and 100.");
            }
            scores[i] = arr[i];
        }
    }
    // destructor
    ~TestScores()
    {
        delete[] scores;
    }
    // function to calculate average
    double average()
    {
        double sum = 0;
        for (int i = 0; i < numScores; i++)
        {
            sum += scores[i];
        }
        return sum / numScores;
	}
};


int main()
{
    const int SIZE = 5;
    double scores[SIZE];
	// while loop to get valid scores
    while (true)
    {
		// get scores from user
        cout << "Enter " << SIZE << " test scores (0-100)" << endl;
		// input scores
        for (int i = 0; i < SIZE; i++)
        {
            cout << "Score " << (i + 1) << ": ";
            cin >> scores[i];
        }
		// try to create TestScores object and calculate average
        try
        {
            TestScores ts(scores, SIZE);
            cout << fixed << setprecision(2);
            cout << "Average score: " << ts.average() << endl;
            break; // exit loop if successful
        }
		// catch invalid_argument exception
        catch (invalid_argument& e)
        {
            cout << e.what() << " Please try again." << endl;
        }
	}
	return 0;
    
}



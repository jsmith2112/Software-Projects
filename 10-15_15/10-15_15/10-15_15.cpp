// 10-15_15.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include <iostream>
#include <string>
#include <cctype>
#include <iomanip>
#include <fstream>
using namespace std;

// Function prototypes
int countSentences(string);
int countWords(string);

int main()
{
    int sentences // number of sentences
        , words;   // number of words
	double average; // average number of words per sentence

    // get the number of senteces in the file
	sentences = countSentences("text.txt");

	// get the number of words in the file
	words = countWords("text.txt");

	// calculate the average number of words per sentence
	average = static_cast<double>(words) / sentences;

	// display the results
	cout << "The file contains " << words
		<< " words and " << sentences
		<< " sentences.\n";
	cout << "There is an average of "
		<< setprecision(1) << fixed << average
		<< " words per sentence.\n";

	return 0;

}

int countSentences(string fileName)
{

	// Open the file and count the number of sentences. Return numSentences.
	const int SIZE = 500; // size of input array
	char input[SIZE]; // array to hold file contents
	fstream inputFile; // file stream object
	int numSentences = 0; // number of sentences

	// open the file
	inputFile.open(fileName);
	// check if it opened
	if (!inputFile)
	{
		cout << "Error opening file.\n";
		exit (0);
	}
	// read the file contents into the array
	inputFile.getline(input, SIZE);

	while (!inputFile.eof())
	{ 
		// step through input counting the number of periods.
		for (int index = 0; input[index] != '\0'; index++)
		{
			if (input[index] == '.')
				numSentences++;
		}
		inputFile.getline(input, SIZE); // Use \n as a dlimiter
	}
	// close the file
	inputFile.close();
	return numSentences;
}
int countWords(string fileName)
{
	// Open the file and count the number of words. Return numWords.
	const int SIZE = 500; // size of input array
	char input[SIZE]; // array to hold file contents
	fstream inputFile; // file stream object
	int numWords = 0; // number of words
	bool inWord = false; // flag to indicate if currently in a word

	// open the file
	inputFile.open(fileName);
	// check if it opened
	if (!inputFile)
	{
		cout << "Error opening file.\n";
		exit(0);
	}

	// read the file contents into the array
	inputFile.getline(input, SIZE);
	while (!inputFile.eof())
	{
		// step through input counting the number of words.
		int index = 0;
		while (input[index] != '\0')
		{
			// skip over any whitespace characters
			while (isspace(input[index]) && input[index] != \0)
			{
				inWord = false; // not in a word
				index++;
			}
		}

		// Read the next line f
		inputFile.getline(input, SIZE); // Use \n as a dlimiter
	}

	// close the file
	inputFile.close();

	return numWords;
}



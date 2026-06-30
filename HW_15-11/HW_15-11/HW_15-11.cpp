// HW_15-11.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include <iostream>

using namespace std;


// Define the GradedActivity class above CourseGrades
class GradedActivity
{
private:
    double score;
public:
	GradedActivity() : score(0.0) {}
	
    //GradedActivity(double s) :  score(s) {}
    void setScore(double s) { score = s; }
    double getScore() const { return score; }
};
// Define a LabActivity class derived from GradedActivity
class LabActivity : public GradedActivity
{
	private:
		double score = 0;
	public:
		LabActivity(double s) 
		{
			GradedActivity::setScore(s);
		}
		void setScore(double s) { score = s; }
		double getScore() const { return score; }
};
// Define a PassFailExam class derived from GradedActivity
class PassFailExam : public GradedActivity
{
	private:
		double score = 0;
	public:
		PassFailExam(double s) 
		{
				GradedActivity::setScore(s); 
		}
		void setScore(double s) { score = s; }
		double getScore() const { return score; }
};
// Define an Essay class derived from GradedActivity
class Essay : public GradedActivity
{
	private:
		double score = 0;
	public:
		Essay(double s)
		{
			GradedActivity::setScore(s);
		}
		void setScore(double s) { score = s; }
		double getScore() const { return score; }
};
// Define a FinalExam class derived from GradedActivity
class FinalExam : public GradedActivity
{
	private:
		double score = 0;
	public:
		FinalExam(double s)
		{
			GradedActivity::setScore(s);
		}

		void setScore(double s) { score = s; }
		double getScore() const { return score; }
};

// crate a class named CourseGrades with  member named grades that is an array of GradedActivity pointers
class CourseGrades
{
private:
    static const int numGrades = 4; // number of grades
	GradedActivity* grades[numGrades]; // array of pointers to GradedActivity

public:
	// Constructor
	CourseGrades(GradedActivity* lab, GradedActivity* passFailExam,
		GradedActivity* essay, GradedActivity* finalExam)
	{
		grades[0] = lab;
		grades[1] = passFailExam;
		grades[2] = essay;
		grades[3] = finalExam;
	}
	// Destructor
	~CourseGrades()
	{
		for (int i = 0; i < numGrades; i++)
		{
			delete grades[i];
		}
	}
	// setLab function to accept a GradedActivity pointer and assign it to the first element of the grades array
	void setLab(GradedActivity* lab)
	{
		grades[0] = lab;
	}
	// setPassFailExam function to accept a GradedActivity pointer and assign it to the second element of the grades array
	void setPassFailExam(GradedActivity* passFailExam)
	{
		grades[1] = passFailExam;
	}
	// setEssay function to accept a GradedActivity pointer and assign it to the third element of the grades array	
	void setEssay(GradedActivity* essay)
	{
		grades[2] = essay;
	}
	// setFinalExam function to accept a GradedActivity pointer and assign it to the fourth element of the grades array	
	void setFinalExam(GradedActivity* finalExam)
	{
		grades[3] = finalExam;
	}
	// print function to output the scores of each GradedActivity in the grades array
	void print() const
	{
		// calculate pass/fail exam score
		string passFailResult;
		if (grades[1]->getScore() >= 70)
			passFailResult = "Pass";
		else
			passFailResult = "Fail";

		cout << "Course Grades:" << endl;
		cout << "Lab: " << grades[0]->getScore() << endl;
		cout << "Pass/Fail Exam: " << passFailResult << endl;
		cout << "Essay: " << grades[2]->getScore() << endl;
		cout << "Final Exam: " << grades[3]->getScore() << endl;
	}


};

int main()
{
	// create activities for lab, pass/fail exam, essay, and final exam
	GradedActivity* lab = new LabActivity(85.0);	
	GradedActivity* passFailExam = new PassFailExam(75.0);
	GradedActivity* essay = new Essay(90.0);
	GradedActivity* finalExam = new FinalExam(88.0);


	// create a CourseGrades object using the graded activities
	CourseGrades courseGrades(lab, passFailExam, essay, finalExam);

	// print the course grades
	courseGrades.print();

	cout << endl << "After modifying scores:" << endl;

	// modify the scores of the graded activities
	lab->setScore(95.0);
	passFailExam->setScore(60.0);
	essay->setScore(92.0);
	finalExam->setScore(89.0);

	// Call setLab, setPassFailExam, setEssay, and setFinalExam to set the grades again
	courseGrades.setLab(lab);
	courseGrades.setPassFailExam(passFailExam);
	courseGrades.setEssay(essay);
	courseGrades.setFinalExam(finalExam);
		
	// print the course grades
	courseGrades.print();
}



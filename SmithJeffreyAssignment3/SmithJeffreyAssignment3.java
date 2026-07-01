
package SmithJeffreyAssignment3;

import java.io.File;
import java.io.IOException;
import java.util.ArrayList;
import java.util.Scanner;

/**
 * Name: Jeffrey Smith
 * Class: CS1450
 * Assignment: Assignment 3
 * Due Date:  2/13/2025, 11:59 PM
 * Create polymorphic array to store animal objects and populate from file
 * Call methods associated with interfaces and classes
 * execute code to create formatted output
 */
public class SmithJeffreyAssignment3 {
	/**
	 * 
	 */
	public static void main(String[] args) throws IOException  {
		
		// read array size from file

			File fileName = new File("Animals.txt"); // file object
			Scanner readFile = new Scanner(fileName); // scanner object
			
			int theCount = readFile.nextInt();	// initiate counter to declared array size			
			Animal[] Animals = new Animal[theCount]; // create array to size declared in file

		// read data from file and populate Animal array
			
			for (int i = 0; i < theCount; i++) {
				
				// initialize variables from file
				String theName = readFile.next();	
				String theSpecies = readFile.next();
				theSpecies = theSpecies.trim();
				int swimSpeed = readFile.nextInt();
				int runSpeed = readFile.nextInt();
				int climbSpeed = readFile.nextInt();
				
				// test species to create specific objects
				if (theSpecies.equals("alligator")){
					Animals[i] = new Alligator(theName, swimSpeed, runSpeed);							
				} else if (theSpecies.equals("bear")) {
					Animals[i] = new Bear(theName, swimSpeed, runSpeed, climbSpeed);
				} else if (theSpecies.equals("giraffe")) {
					Animals[i] = new Giraffe(theName, runSpeed);
				} else if (theSpecies.equals("monkey")) {
					Animals[i] = new Monkey(theName, runSpeed, climbSpeed);	
				} else if (theSpecies.equals("sloth")) {
					Animals[i] = new Sloth(theName, swimSpeed, climbSpeed);	
				}
			} // end for loop

		readFile.close(); // close file
		
		//Print All Animals
		
			String headerAll = "ALL ANIMALS IN ARRAY"; // all animals header text
		
		//Header for all animals
			System.out.println("-------------------------------------------------------------------");
			System.out.println(headerAll);
			System.out.println("-------------------------------------------------------------------");
		
		// Call displayAnimal and loop through to print out all animals in Array
			for (int i = 0; i < Animals.length; i++) {
				displayAnimal(Animals[i]);
			} // end display loop
			
			
		// Print Climbers
			
			String headerClimbers = "ALL ANIMALS THAT CAN CLIMB"; // climbers header text
			
			//Header 1 for climbers
				System.out.println("-------------------------------------------------------------------");
				System.out.println(headerClimbers);
			
			String headerOne = "Name";
			String headerTwo = "Species";
			String headerThree = "Climbing Speed";
			
			//Header 2 for climbers
			System.out.println("-------------------------------------------------------------------");
			System.out.printf("%-12s %-12s %-35s%n", headerOne, headerTwo, headerThree);
			System.out.println("-------------------------------------------------------------------");
			
		// Call findClimbers once to print out info for Climbers
			ArrayList<Animal> Climbers = findClimbers(Animals);
				for (int i = 0; i < Climbers.size(); i++) {
					String climberName = Climbers.get(i).getName();
					String climberSpecies = Climbers.get(i).getSpecies();
					int climberSpeed = ((climber)Climbers.get(i)).climb();
				
				// print climbers
				System.out.printf("%-12s %-12s %-35s%n", climberName, climberSpecies, climberSpeed);
				} // end print loop
			
			System.out.println("\s");
			
		// Call findMostSkilled and print info
			
			//Most skilled header
			System.out.println("-------------------------------------------------------------------");
			System.out.println("MOST SKILLED ANIMAL");
			System.out.println("-------------------------------------------------------------------");
			
			int myIndex = findMostSkilled(Animals);
			
						// declare variables
						String theName = Animals[myIndex].getName();	
						String theSpecies = Animals[myIndex].getSpecies();
						theSpecies = theSpecies.trim();
						int swimSpeed = 0;
						int runSpeed = 0;
						int climbSpeed = 0;
						
						// determine what skills to assign to animal
						if (Animals[myIndex] instanceof swimmer) {
							swimSpeed = ((swimmer)Animals[myIndex]).swim();
						}
						if (Animals[myIndex] instanceof runner) {
							runSpeed = ((runner)Animals[myIndex]).run();
						}
						if (Animals[myIndex] instanceof climber) {
							climbSpeed = ((climber)Animals[myIndex]).climb();
						}
						
						// build noise string
						String myNoise = Animals[myIndex].makeNoise();
						myNoise = myNoise + " " + myNoise + " " + myNoise;
						
						// print out the info as described
						System.out.println(theName + " the " + theSpecies + " says " + myNoise + "!!!");
						if (swimSpeed > 0) {
							System.out.println("Swimming Speed: " + swimSpeed);
						}
						if (runSpeed > 0) {
							System.out.println("Running Speed: " + runSpeed);
						}
						if (climbSpeed > 0) {
							System.out.println("Climbing Speed: " + climbSpeed);
						}
						
						System.out.println("\s"); // line break
			
	} // end of main
	
	
	// Methods for handling data
	
	public static void displayAnimal(Animal animal) {
		
		
		// Print animal
			// declare variables
			String theName = animal.getName();	
			String theSpecies = animal.getSpecies();
			theSpecies = theSpecies.trim();
			int swimSpeed = 0;
			int runSpeed = 0;
			int climbSpeed = 0;
			
			// determine what skills to assign to animal
			if (animal instanceof swimmer) {
				swimSpeed = ((swimmer)animal).swim();
			}
			if (animal instanceof runner) {
				runSpeed = ((runner)animal).run();
			}
			if (animal instanceof climber) {
				climbSpeed = ((climber)animal).climb();
			}
			
			// build noise string
			String myNoise = animal.makeNoise();
			myNoise = myNoise + " " + myNoise + " " + myNoise;
			
			// print out the info as described
			System.out.println(theName + " the " + theSpecies + " says " + myNoise + "!!!");
			if (swimSpeed > 0) {
				System.out.println("Swimming Speed: " + swimSpeed);
			}
			if (runSpeed > 0) {
				System.out.println("Running Speed: " + runSpeed);
			}
			if (climbSpeed > 0) {
				System.out.println("Climbing Speed: " + climbSpeed);
			}
			
			System.out.println("\s"); // line break

	} // end displayAnimal
	
	public static ArrayList<Animal> findClimbers(Animal[] animals) {
		
		// Create Climber ArrayList
		 ArrayList<Animal> findClimbers = new ArrayList<Animal>();
		
		// Test to see if animals are climbers and if so add to Climbers ArrayList
		for (int i = 0; i < animals.length; i++) {		
			if (animals[i] instanceof climber) {
				findClimbers.add(animals[i]);
			} // end if
		} // end climber for
		
		return findClimbers;
	} // end findClimbers
	
	public static int findMostSkilled(Animal[] animals){
		 
		
		int mostSkilledIndex = 0;
		int baseScore = 0;
		
		for (int i = 0; i < animals.length; i++) {
			
			// declare variables
			String theName = animals[i].getName();	
			String theSpecies = animals[i].getSpecies();
			theSpecies = theSpecies.trim();
			int swimSpeed = 0;
			int runSpeed = 0;
			int climbSpeed = 0;
			
			// determine what skills to assign to animal
			if (animals[i] instanceof swimmer) {
				swimSpeed = ((swimmer)animals[i]).swim();
			}
			if (animals[i] instanceof runner) {
				runSpeed = ((runner)animals[i]).run();
			}
			if (animals[i] instanceof climber) {
				climbSpeed = ((climber)animals[i]).climb();
			}		
			
			int totalScore = swimSpeed + runSpeed + climbSpeed;
			
			if (totalScore > baseScore) {
				mostSkilledIndex = i;
				baseScore = totalScore;
			}
		} // end for loop
		

		return mostSkilledIndex;
	}
	
	
	
} // end of Assignment3 class

// interfaces classes and subclasses

interface swimmer {
	abstract public int swim();
}

interface runner {
	abstract public int run();
}

interface climber {
	abstract public int climb();
}

abstract class Animal {
	// declare instance variables
	
	private String species;
	private String name;
	
	// No Constructors
	// Getters
	
	public String getName() {
		
		String theName = this.name;
		return theName;
	}
	public String getSpecies() {
		String theSpecies = this.species;
		return theSpecies;
	}
	// Setters
	
	public void setName(String name) {
        this.name = name;
    }
	
	public void setSpecies(String species) {
        this.species = species;
    }
	
	// Behaviors
	
	abstract public String makeNoise();
	
}  // end Animal Class


class Alligator extends Animal implements swimmer, runner {
	
	// declare instance variables
	
	private String name;
	private int swimSpeed;
	private int runSpeed;
	
	// constructors
		
	public Alligator () {
		
	}
	
	public Alligator(String name, int swimSpeed, int runSpeed) {
			
			this.name = name;
			this.swimSpeed = swimSpeed;
			this.runSpeed = runSpeed;
			setName(name);
			setSpecies("Alligator");
	}
	
	// getters
	// setters
	// behaviors
	
		public String makeNoise() {
			String myString = "Crunch";
			return myString;
		}
		
		@Override 
		public int swim() {
			int mySwim = this.swimSpeed;
			return mySwim;
			}
		
		@Override 
		public int run() {
			int myRun = this.runSpeed;
			return myRun;
			}	

	
} // end Alligator Class

class Bear extends Animal implements swimmer, runner, climber {
	
	// declare instance variables
	private String name;
	private int swimSpeed;
	private int runSpeed;
	private int climbSpeed;
	
	// constructors
		
	public Bear () {
		
	}
	
	public Bear (String name, int swimSpeed, int runSpeed, int climbSpeed) {
			
			this.name = name;
			this.swimSpeed = swimSpeed;
			this.runSpeed = runSpeed;
			this.climbSpeed = climbSpeed;
			setName(name);
			setSpecies("Bear");
	}
	
	// getters
	// setters
	// behaviors
	
		public String makeNoise() {
			String myString = "Growl";
			return myString;
		}
		
		@Override 
		public int swim() {
			int mySwim = this.swimSpeed;
			return mySwim;
			}
		
		@Override 
		public int run() {
			int myRun = this.runSpeed;
			return myRun;
			}	
		
		@Override 
		public int climb() {
			int myClimb = this.climbSpeed;
			return myClimb;
			}	
	
} // end Bear Class

class Giraffe extends Animal implements runner {
	
	// declare instance variables
	private String name;
	private int runSpeed;
	
	// constructors
		
	public Giraffe () {
		
	}
	
	public Giraffe (String name, int runSpeed) {
			
			this.name = name;
			this.runSpeed = runSpeed;
			setName(name);
			setSpecies("Giraffe");
	}
	
	// getters
	// setters
	// behaviors
	
		public String makeNoise() {
			String myString = "Bleat";
			return myString;
		}
		
		@Override 
		public int run() {
			int myRun = this.runSpeed;
			return myRun;
			}	
		
} // end Giraffe Class

class Monkey extends Animal implements runner, climber {
	
	// declare instance variables
	private String name;
	private int runSpeed;
	private int climbSpeed;
	
	// constructors
		
	public Monkey () {
		
	}
	
	public Monkey (String name, int runSpeed, int climbSpeed) {
			
			this.name = name;
			this.runSpeed = runSpeed;
			this.climbSpeed = climbSpeed;
			setName(name);
			setSpecies("Monkey");
	}
	
	// getters
	// setters
	// behaviors
	
		public String makeNoise() {
			String myString = "Screech";
			return myString;
		}

		@Override 
		public int run() {
			int myRun = this.runSpeed;
			return myRun;
			}	
		
		@Override 
		public int climb() {
			int myClimb = this.climbSpeed;
			return myClimb;
			}	
	
} // end Monkey Class

class Sloth extends Animal implements swimmer, climber {
	
	// declare instance variables
	private String name;
	private int swimSpeed;
	private int climbSpeed;
	
	// constructors
		
	public Sloth () {
		
	}
	
	public Sloth (String name, int swimSpeed, int climbSpeed) {
			
			this.name = name;
			this.swimSpeed = swimSpeed;
			this.climbSpeed = climbSpeed;
			setName(name);
			setSpecies("Sloth");
	}
	
	// getters
	// setters
	// behaviors
	
		public String makeNoise() {
			String myString = "Squeak";
			return myString;
	}
		
		@Override 
		public int swim() {
			int mySwim = this.swimSpeed;
			return mySwim;
			}
		
		@Override 
		public int climb() {
			int myClimb = this.climbSpeed;
			return myClimb;
			}	
	
} // end Sloth Class





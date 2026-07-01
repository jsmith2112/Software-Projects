/**
 * Name: Jeffrey Smith
 * Class Name: CS1450 (M/W)
 * Due Date: 
 * Assignment #: 
 * Description: 
 */
package SmithJeffreyAssignnment2;

import java.io.File;
import java.io.IOException;
import java.util.Scanner;

/**
 * Name: Jeffrey Smith
 * Class: CS1450
 * Assignment: Assignment 2
 * Due Date:  2/5/2025, 11:59 PM
 * Create Actor Class and Subclasses along with Movie Object
 * Read from file to create polymorphic array
 * execute code to create formatted output
 */
public class SmithJeffreyAssignnment2 {
	/**
	 * 
	 */
	public static void main(String[] args) throws IOException  {
		
		// read array size from file

			File fileName = new File("Actors.txt"); // file object
			Scanner readFile = new Scanner(fileName); // scanner object
			
			int theCount = readFile.nextInt();	// initiate counter to declared array size			
			Actor[] Actors = new Actor[theCount]; // create Actor array to size declared in file

		// read data from file and populate Actor array
			
			for (int i = 0; i < theCount; i++) {

					String theLine = readFile.next();
					
					if (theLine.equals("Hero")){
						String theType = theLine;
						String theName = readFile.nextLine();
						theName = theName.trim();
						Actors[i] = new Hero(theName);
												
					} else if (theLine.equals("Villain")) {
						String theType = theLine;
						String theName = readFile.nextLine();
						theName = theName.trim();
						Actors[i] = new Villain(theName);

					}
					else if (theLine.equals("Monster")) {
						String theType = theLine;
						String theName = readFile.nextLine();
						theName = theName.trim();
						Actors[i] = new Monster(theName);
						
					} else if (theLine.equals("Droid")) {
						String theType = theLine;
						String theName = readFile.nextLine();
						theName = theName.trim();
						Actors[i] = new Droid(theName);	
					}
			}

		readFile.close(); // close file
		
		//Print First Array
		
		String headerOne = "Actor Name";
		String headerTwo = "Actor Type";
		String headerThree = "Motto";
		
		//Header
		System.out.println("-------------------------------------------------------------------");
		System.out.printf("%-20s %-15s %-35s%n", headerOne, headerTwo, headerThree);
		System.out.println("-------------------------------------------------------------------");
		
		// Display formatted list of actors including type and motto
		for (int i=0; i < Actors.length; i++) {
			System.out.printf("%-20s %-15s %-35s%n", Actors[i].getName(), Actors[i].getType(), Actors[i].moto());
		}
		
		System.out.println("\r");
		
		// create movie object and call behaviors
		
		Movie myMovie = new Movie();
		myMovie.selectCast(Actors); // call behavior to select only heroes and villains for cast
		myMovie.printMovieDetails();// call behavior to display list of cast members

	} // end of main
} // end of Assignment2 class

// classes and subclasses
class Actor {
	// declare instance variables
	
	private String type;
	private String name;
	
	// Constructors
	
	public Actor() {
	}
	
	public Actor(String type, String name) {
		
		this.type = type;
		this.name = name;
	}
	
	// Getters
	
	public String getName() {
		return name;
	}
	public String getType() {
		return type;
	}
	
	// no Setters
	// Behaviors
	
	public String moto() {
		String theMoto = "This is a moto.";
		return theMoto;
	}
}  // end Actor Class

class Hero extends Actor {
	
	// no data fields
	// Constructors
	
	public Hero () {
	}
	public Hero (String name) {

		super("Hero", name);
	}
	// Behaviors
	@ Override
	public String moto() {
		String moto = "To the rescue!  KAPOW!! BAM!! POW!!";
		return moto;
	}
} // end Hero Class

class Villain extends Actor {
	
	// no data fields
	// Constructors
	
	public Villain () {	
	}
	public Villain (String name) {

		super("Villain", name);
	}
	// Behaviors
	@ Override
	public String moto() {
		String moto = "You’ll never stop me!  Haaaaaaa!";
		return moto;
	}
	
} // end Villain Class

class Monster extends Actor {
	
	// no data fields
	// Constructors
	
	public Monster () {		
	}
	public Monster (String name) {

		super("Monster", name);
	}
	// Behaviors
	@ Override
	public String moto() {
		String moto = "RRAAAUUGGHH GRROWR!!!";
		return moto;
	}
} // end Monster Class

class Droid extends Actor {
	
	// no data fields
	// Constructor
	
	public Droid () {
	}
	public Droid (String name) {

		super("Droid", name);
	}
	// Behaviors
	@ Override
	public String moto() {
		String moto = "Beep Beep Bloop Boop Beep!";
		return moto;
	}	
} // end Droid Class

class Movie {
	
	// Declare Private Data Fields
	private int numHeros;
	private int numVillains;
	private Actor[] actorsInMovie;
	
	// No Constructors
	// no getters or setters
	// methods / Behaviors
	
	public void selectCast (Actor[] actors) {
		
		// Count heros and villains from Actor array for hero/villain only cast
		
		// declare counters
		int hCount = 0;
		int vCount = 0;
		
		// loop to count
		for (int i = 0; i < actors.length; i++) {
			
			// determine if value type is a hero or villain
			boolean isHero = actors[i] instanceof Hero; // true if hero
			boolean isVillain = actors[i] instanceof Villain; // true if villain
			
			// add to counters if true
			if (isHero) {
				hCount = hCount + 1;
			}
			else if (isVillain) {
				vCount = vCount + 1;
			}
		} // end for
		
			int tCount = hCount + vCount; // total actors
			int j = 0; // counter for new cast array
			
			//System.out.println(hCount + " + " + vCount + " = " + tCount);
			
			Actor[] actorsInMovie = new Actor[tCount]; // create new cast array with correct size
			
			// loop to populate new cast array
			for (int i = 0; i < actors.length; i++) {
				
				// determine if value type is hero or villain
				boolean isHero = actors[i] instanceof Hero;
				boolean isVillain = actors[i] instanceof Villain;
				
				// loop to populate new cast array
				if (isHero) {
					actorsInMovie[j] = actors[i];
					j=j+1;
				}
				else if (isVillain) {
					actorsInMovie[j] = actors[i];
					j=j+1;
				}
			}
		
		// Update Private Data Fields
			
			this.numHeros = hCount;
			this.numVillains = vCount;
			this.actorsInMovie = actorsInMovie;
	}
		
	public void printMovieDetails() {
		
		// Display movie details
		//Header
		System.out.println("-------------------------------------------------");
		System.out.println("CS1450 Heroes and Villain Movie");
		System.out.println("-------------------------------------------------");
		
		// Display number of heroes and villains in movie
		System.out.println("Number of Heroes:  " + numHeros);
		System.out.println("Number of Villains " + numVillains + "\r");
		
		// Loop to display list of cast members
		for (int i = 0; i < actorsInMovie.length; i++) {
		System.out.println(actorsInMovie[i].getType() + "\t---  " + actorsInMovie[i].getName() + " " );
		}
	}	
}
// end Movie Class




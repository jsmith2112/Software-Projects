/**
 * Name: Jeffrey Smith
 * Class: CS1450
 * Assignment: Assignment 4
 * Due Date:  2/26/2025, 11:59 PM
 * Create virtual Cargo Terminal simulation
 * Read from files to populate arrays in Cargo Terminal
 * use Has-A relationships with planes and trucks and print
 * well formatted report.
 */
package SmithJeffreyAssignment4;

import java.io.File;
import java.io.IOException;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.Collections;
import java.util.Scanner;



public class SmithJeffreyAssignment4 {
	/**
	 * 
	 */
	public static void main(String[] args) throws IOException  {
		
		// read array size from files

			File fileName = new File("FedExPlanes.txt"); // file object
			File fileName2 = new File("FedExTrucks.txt"); // file object
			
			Scanner readFile = new Scanner(fileName); // scanner object
			Scanner readFile2 = new Scanner(fileName2); // scanner object
			
			int planeCount = readFile.nextInt();	// initiate counter to declared tarmac size	
			int truckCount = readFile2.nextInt();	// initiate counter to declared loading dock size
			
			CargoTerminal myTerminal = new CargoTerminal(truckCount, planeCount); // create cargo terminal object
			
			
			// create plane objects
			while (readFile.hasNext()) {
				
				int standNumber = readFile.nextInt();
				int flightNumber = readFile.nextInt();
				double capacity = readFile.nextDouble();
				String cargoType = readFile.next();
				String destinationCity = readFile.next();
				
				CargoPlane myPlane = new CargoPlane(flightNumber, capacity, cargoType, destinationCity);
				
				myTerminal.addCargoPlane(standNumber, myPlane);
				
			}
			
			// create truck objects
			while (readFile2.hasNext()) {
				
				int dockNumber = readFile2.nextInt();
				int truckNumber = readFile2.nextInt();
				String destinationCity = readFile2.next();
				
				semiTruck myTruck = new semiTruck(truckNumber, destinationCity);		
				
				myTerminal.addSemiTruck(dockNumber, myTruck);
				
			}
			
			// display cargo terminal info
			myTerminal.displayCargoTerminal();
			
			// close reading files
			readFile.close();
			readFile2.close();
			
			// print terminal status report
			System.out.print("\r\r\r\r");
			printTerminalStatus(myTerminal);

		

	} // end of main
	
	// printTerminalStatus method

	public static void printTerminalStatus(CargoTerminal terminal) {
		
		//intialize Arraylists
		ArrayList<semiTruck> myDock = new ArrayList<semiTruck>();
		ArrayList<CargoPlane> myTar = new ArrayList<>();
		
		int docks = terminal.getNumberDocks(); // number of docs
		int stands = terminal.getNumberStands(); // number of stands
		
		// add trucks
		for (int i = 0; i < docks; i++) {
			if (terminal.getSemiTruck(i) != null) {			
				myDock.add(terminal.getSemiTruck(i));
			}
		}
		// add planes
		for (int i = 0; i < stands; i++) {
			if (terminal.getCargoPlane(i) != null) {
				myTar.add(terminal.getCargoPlane(i));
			}
		}
		
		// sort arraylists
		Collections.sort(myTar);
		Collections.sort(myDock);
		
		// print truck header and report
		System.out.println("\r");
		System.out.println("***************************************************************************");
		System.out.println("                             Loading Dock Status                           ");
		System.out.println("                            (By Destination City)                          ");
		System.out.println("***************************************************************************");
		
		for (int i = 0; i < myDock.size(); i++) {
				System.out.println(myDock.get(i));
		}
		
		// print plane header and report
		System.out.println("\r");
		System.out.println("***************************************************************************");
		System.out.println("                                Tarmac Status                              ");
		System.out.println("                        (Lowest to Highest Capacity)                       ");
		System.out.println("***************************************************************************");

		for (int i = 0; i < myTar.size(); i++) {
				System.out.println(myTar.get(i));
		}
				
	}
} // end of Assignment4 class


// Classes
class CargoTerminal {

	// Private Data Fields

	private int numberDocks;
	private int numberStands;
	private semiTruck[] loadingDock;
	private CargoPlane[] tarmac; 

	// Constructors
	
	public CargoTerminal() {
		
	}

	CargoTerminal(int numberDocks, int numberStands){

		this.numberDocks = numberDocks;
		this.numberStands = numberStands;

		loadingDock = new semiTruck[numberDocks];
		tarmac = new CargoPlane[numberStands];
	}

	// Getters

	public int getNumberDocks() {

		int numberDocks = this.numberDocks;

		return numberDocks;
	}
	public int getNumberStands() {

		int numberStands = this.numberStands;

		return numberStands;
	}

	// No Setters

	// Methods

	public void addSemiTruck(int dock, semiTruck truck){

		loadingDock[dock] = truck;
	}
	public void addCargoPlane(int stand, CargoPlane plane) {

		tarmac[stand] = plane;
	}
	public semiTruck getSemiTruck(int dock) {

		return loadingDock[dock];
	}
	public CargoPlane getCargoPlane (int stand) {

		return tarmac[stand];
	}
	public void displayCargoTerminal() {
		
		System.out.println("Loading semi-trucks and planes into cargo terminal...");
		System.out.println("\r");
		for (int i = 0; i < loadingDock.length; i++) {
		System.out.print("Dock " + i + "\t\t");
		}
		System.out.println("\r");
		for (int i = 0; i < loadingDock.length; i++) {
			if (this.loadingDock[i]== null) {
				System.out.print("------"+ "\t\t");
			} else {
				System.out.print(loadingDock[i].getTruckNumber()+ "\t\t");
			}
		}
		System.out.println("\r");
		for (int i = 0; i < tarmac.length; i++) {
		System.out.print("Stand " + i + "\t\t");
		}
		System.out.println("\r");
		for (int i = 0; i < tarmac.length; i++) {
			if (this.tarmac[i]== null) {
				System.out.print("------"+ "\t\t");
			} else {
				System.out.print(tarmac[i].getFlightNumber()+ "\t\t");
			}
		}

	}
}


	class CargoPlane implements Comparable<CargoPlane> { 

	// Private Data Fields

		private int flightNumber;
		private double capacity;
		private String cargoType;
		private String destinationCity;

	// Constructors

	public CargoPlane(int flightNumber, double capacity, String cargoType, String destinationCity){

		this.flightNumber = flightNumber;
		this.capacity = capacity;
		this.cargoType = cargoType;
		this.destinationCity = destinationCity;
	}

	// Getters

	public int getFlightNumber() {

		int flightNumber = this.flightNumber;

		return flightNumber;

	}
	// No Setters
	// Methods

	@Override
	public String toString(){

		return String.format("%4d\t\t%-15s\t\t%-10s\t%.2f", flightNumber, destinationCity, cargoType, capacity);
	}
	@Override
	public int compareTo(CargoPlane otherCargoPlane){

		if (this.capacity > otherCargoPlane.capacity) {
			return 1;
		} else if (this.capacity < otherCargoPlane.capacity) {
			return -1;
		} else {
			return 0;
		}
	}
	}

	class semiTruck implements Comparable<semiTruck> { 

	// Private Data Fields

		private int truckNumber;
		private String destinationCity;

	// Constructors

	public semiTruck(int truckNumber, String destinationCity){

		this.truckNumber = truckNumber;
		this.destinationCity = destinationCity;
	}

	// Getters

	public int getTruckNumber() {

		int truckNumber = this.truckNumber;

		return truckNumber;

	}
	// No Setters
	// Methods

	@Override
	public String toString(){

		return String.format("%4d\t\t%-15s\t\t", truckNumber, destinationCity);
	}
	@Override
	public int compareTo(semiTruck otherSemiTruck){

	  int myReturn = this.destinationCity.compareToIgnoreCase(otherSemiTruck.destinationCity);
		
	  return myReturn;

	}

	}


		






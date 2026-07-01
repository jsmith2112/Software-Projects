/**
 * Name: Jeffrey Smith
 * Class: CS1450
 * Assignment: Assignment 7
 * Due Date:  4/3/2025, 11:59 PM
 * Create virtual Cargo Terminal simulation
 * Read from files to populate arrays in Cargo Terminal
 * use Has-A relationships with planes and trucks and print
 * well formatted report.
 */
package SmithJeffreyDefault;

import java.io.File;
import java.io.IOException;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.Collections;
import java.util.LinkedList;
import java.util.List;
import java.util.PriorityQueue;
import java.util.Queue;
import java.util.Scanner;

public class SmithJeffreyAssignment7 {

		public static void main(String[] args) throws IOException  {
			
			// read array size from files

				File fileName = new File("FedExPlanes7.txt"); // file object
				File fileName2 = new File("FedExTrucks7.txt"); // file object
				
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
					String destinationCity = readFile.nextLine();
					
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
				System.out.println("Loading semi-trucks and planes into cargo terminal...");
				myTerminal.displayCargoTerminal();
				
				// close reading files
				readFile.close();
				readFile2.close();
				
				// print space
				System.out.print("\r\r\r\r");
				
				
				//create taxiway, controller, and runways
				Taxiways myTaxiway = new Taxiways();
				Airtrafficcontroller myController = new Airtrafficcontroller();
				Runway myRunway = new Runway();
				
				// print planes moving from tarmac to taxiway
				System.out.println("Control Tower: Moving planes from cargo terminal tarmac to taxiways");
				System.out.println("---------------------------------------------------------------------------------");
				myController.movePlanesToTaxiways(myTerminal, myTaxiway);
				
				//Show tarmac is empty
				System.out.print("\r\r\r\r");
				System.out.println("Show empty tarmac in cargo terminal...");
				myTerminal.displayCargoTerminal();
				
				//print planes moving to runways from taxiways
				System.out.print("\r\r\r\r");
				System.out.println("Control Tower: Moving cargo planes from taxiways to runway");
				System.out.println("--------------------------------------------------------------------");
				myController.movePlanesToRunway(myTaxiway, myRunway);
				
				//print cleared for takeoff
				System.out.print("\r\r\r\r");
				System.out.println("Control Tower: Ready for takeoff!");
				System.out.println("--------------------------------------------------------------------");
				myController.clearedForTakeoff(myRunway);
				
				//print verify runway is empty
				System.out.println("\rIs Runway Empty?  " + myRunway.isrunwayEmpty());

		} // end of main
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
			
			// print out dock and stand info
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
		
		public CargoPlane removeCargoPlane(int stand) {
			// if not null remove plane from stand
			if (tarmac[stand] == null) {
				return null;
			} else {
			CargoPlane myPlane = tarmac[stand];
			tarmac[stand] = null;
			return myPlane;
			}
		}
	} // end cargo terminal


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
		
		public boolean isPriority() {
			
			// if priority cargo return true
			String Pri = this.cargoType;

	        switch (Pri) {
	            case "Military":
	            	return true;
	            case "Perishables":
	            	return true;
	            case "Medical":
	            	return true;
	            default:
	            	return false;
	        }
		} // end isPriority
		public boolean isBasic() {
			
			// if basic cargo return true
			String Pri = this.cargoType;

	        switch (Pri) {
	            case "Military":
	            	return false;
	            case "Perishables":
	            	return false;
	            case "Medical":
	            	return false;
	            default:
	            	return true;
	        }
		} // end isBasic		
		
		// format toString Print
		@Override
		public String toString(){

			return String.format("%4d\t%-15s\t%-10s", flightNumber, destinationCity, cargoType);
		}
		
		// Set priorities for cargo in priority queue
		@Override
		public int compareTo(CargoPlane otherCargoPlane){
			int myReturn = 1;
			
			 
			//myReturn = this.cargoType.compareToIgnoreCase(otherCargoPlane.cargoType);
			
			 if (this.cargoType.equalsIgnoreCase(otherCargoPlane.cargoType)) {
				 myReturn = 0;
			 } else if (otherCargoPlane.cargoType.equalsIgnoreCase("Military")) {
				 myReturn = 1;
			 } else {
				 myReturn = -1;
			 }
			 
			 return myReturn;
				
			}// end CompareTo
		} // end CargoPlane

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

		// format toString print
		@Override
		public String toString(){

			return String.format("%4d\t\t%-15s\t\t", truckNumber, destinationCity);
		}
		
		// compareTo for Trucks
		@Override
		public int compareTo(semiTruck otherSemiTruck){

		  int myReturn = this.destinationCity.compareToIgnoreCase(otherSemiTruck.destinationCity);
			
		  return myReturn;

		}//end compareTo

		}// end semiTruck

		class Taxiways {

			// Private Data Fields
 
			private Queue<CargoPlane> basicTaxiway;
			private PriorityQueue<CargoPlane> priorityTaxiway;

			// Constructors
			
			public Taxiways() {
				
				basicTaxiway = new LinkedList<>();
				priorityTaxiway = new PriorityQueue<>();
				
			} // end constructor

			// Getters

			// No Setters

			// Methods
			
			public boolean isPriorityTaxiwayEmpty() {
				
				boolean myState = priorityTaxiway.isEmpty();
				
				return myState;
			}
			
			public void addPlaneToPriorityTaxiway(CargoPlane myPlane) {
				
				priorityTaxiway.offer(myPlane);
			
			}
			public CargoPlane removePlaneFromPriorityTaxiway() {
				
				CargoPlane myPlane = priorityTaxiway.remove();
				
				return myPlane;
			}
			public boolean isbasicTaxiwayEmpty() {
				
				boolean myState = basicTaxiway.isEmpty();
				
				return myState;
			}
			
			public void addPlaneTobasicTaxiway(CargoPlane myPlane) {
				
				basicTaxiway.offer(myPlane);
				
			}
			public CargoPlane removePlaneFrombasicTaxiway() {
				
				CargoPlane myPlane = basicTaxiway.remove();
				
				return myPlane;
			}

		} // end Taxiways
		
		class Runway {

			// Private Data Fields
 
			private Queue<CargoPlane> runway;

			// Constructors
			
			public Runway() {
				
				runway = new LinkedList<>();
				
			}


			// Getters

			// No Setters

			// Methods
			public boolean isrunwayEmpty() {
				
				boolean myState = runway.isEmpty();
				
				return myState;
			}
			
			public void addPlaneTorunway(CargoPlane myPlane) {
				
				runway.offer(myPlane);
				
			}
			public CargoPlane removePlaneFromrunway() {
				
				CargoPlane myPlane = runway.remove();
				
				return myPlane;
			}

		} // end Runway
		class Airtrafficcontroller {

			// Private Data Fields

			// Constructors

			// Getters

			// No Setters

			// Methods
			
			public void movePlanesToTaxiways (CargoTerminal cargoTerminal, Taxiways taxiways) {

				// send each plane to the proper Taxiway based on Priority
				for (int i=0; i < cargoTerminal.getNumberStands(); i++) {
					if (cargoTerminal.getCargoPlane(i)!=null) {
						if (cargoTerminal.getCargoPlane(i).isPriority()) {
							CargoPlane myPlane = cargoTerminal.getCargoPlane(i);
							taxiways.addPlaneToPriorityTaxiway(myPlane);
							System.out.println("Moved to taxiway Priority flight " + myPlane.toString());
							cargoTerminal.removeCargoPlane(i);
						} else if (cargoTerminal.getCargoPlane(i).isBasic()) {
							CargoPlane myPlane = cargoTerminal.getCargoPlane(i);
							taxiways.addPlaneTobasicTaxiway(myPlane);
							System.out.println("Moved to taxiway Basic    flight " + myPlane.toString());
							cargoTerminal.removeCargoPlane(i);
						}
					} // end if
				} // end for		
			} // end move planes to taxiways
			
			public void movePlanesToRunway (Taxiways taxiways, Runway runway) {
				
				// send planes to runway based on priority
				while (!taxiways.isPriorityTaxiwayEmpty()) {
					CargoPlane myPlane = taxiways.removePlaneFromPriorityTaxiway();
					runway.addPlaneTorunway(myPlane);
					System.out.println("Moved to runway Priority flight " + myPlane.toString());
				} // end while
				while (!taxiways.isbasicTaxiwayEmpty()) {
					CargoPlane myPlane = taxiways.removePlaneFrombasicTaxiway();
					runway.addPlaneTorunway(myPlane);
					System.out.println("Moved to runway Basic    flight " + myPlane.toString());
				} // end while
			} // end move planes to Runway
			
			public void clearedForTakeoff (Runway runway) {
				
				// Let 'em take off for the wild blue yonder and empty runway
				while (!runway.isrunwayEmpty()) {
					CargoPlane myPlane = runway.removePlaneFromrunway();
					System.out.println("Cleared for takeoff flight " + myPlane.toString());
				}
				
				
			} // end Cleared for Takeoff
		} // end Airtrafficcontroller


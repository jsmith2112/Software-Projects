/**
 * Name: Jeffrey Smith
 * Class: CS1450
 * Assignment: Assignment 9
 * Due Date:  4/17/2025, 11:59 PM
 * Create virtual train
 * Use singly and doubly linked lists to
 * model a virtual train.  Populate from txt files,
 * manipulate lists and display results in a
 * well formatted output.
 */
package SmithJeffreyDefault;

import java.io.File;
import java.io.IOException;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.Iterator;
import java.util.LinkedList;
import java.util.Queue;
import java.util.Scanner;

public class SmithJeffreyAssignment9 {
	
	public static void main(String[] args) throws IOException  {
		


				// file objects for reading files
				File fileName = new File("Railcars.txt");
				
				// scanner objects for reading files
				Scanner readFile = new Scanner(fileName);
				
				DoubleLinkedList myDList = new DoubleLinkedList();
				TrainLinkedList myTrain = new TrainLinkedList();
				
				// create railCar objects
				while (readFile.hasNext()) {
					
					int number = readFile.nextInt();
					String freight = readFile.next().trim();
					String destination = readFile.nextLine().trim();
					
					RailCar myCar = new RailCar(number, freight, destination);
			        myDList.addToEnd(myCar);
			        myTrain.addByDestination(myCar);
					
				}
				
				System.out.println("RailCar\t\tFreight\t\tDestination City");
			    System.out.println("--------------------------------------------------");
		        myTrain.displayTrain();
		        
		        System.out.println();
		        
		        System.out.println("RailCar\t\tFreight\t\tDestination City");
			    System.out.println("--------------------------------------------------");
		        myDList.displayBackwards();



			} // end main
			
		} // end SmithJeffreyAssignment9


		// Classes

		class RailCar implements Comparable<RailCar>  {
			
			// private data fields
			
			private int number;
			private String freight;
			private String destination;
			
			// constructors
			
			public RailCar ( int number, String freight, String destination) {
				
				this.number = number;
				this.freight = freight;
				this.destination = destination;
			}
			
			// getters
			
			public String getFreight() {
				
				return freight;
			}
			
			public String getDestination() {
				
				return destination;
			}
			
			// setters none
			
			// methods
			
			@Override
			public String toString() {

		    String myString = number + "\t\t" + freight + "     \t" + destination;
		    
		    return myString;
			} // end toString

			@Override
			public int compareTo(RailCar otherRailCar) {
			
					int myReturn = 1; 
					
					//System.out.println("This " + this.destination);
					//System.out.println("Other " + otherRailCar.destination);
					
				if (this.destination.equalsIgnoreCase(otherRailCar.destination)) {
					myReturn = 0;
				} else if (this.destination.equalsIgnoreCase("West Palm Beach")) {
					myReturn = 1;
				} else if (this.destination.equalsIgnoreCase("Washington DC")) {
					myReturn = -1;
				} else if (this.destination.equalsIgnoreCase("Charleston")) {
				    if (otherRailCar.destination.equalsIgnoreCase("West Palm Beach")){
					    myReturn = -1;
				     } else if (otherRailCar.destination.equalsIgnoreCase("Orlando")) {
				         myReturn = -1;
				     } // end inner if
				}  else if (this.destination.equalsIgnoreCase("Orlando")) {
				    if (otherRailCar.destination.equalsIgnoreCase("West Palm Beach")){
					    myReturn = -1;
				     } else {
				         myReturn = 1;
				     } // end inner if
				     }// end outer if
					 
				return myReturn;

			} // end compareTo
			
		}// end RailCar

		class TrainLinkedList {
			
			// private data fields
			
				private Node head;
			
			// constructors - default initializes head to null
			
			// getters none
			
			// setters none
			
			// methods
				
				public void addByDestination(RailCar railCarToAdd) {
					
					Node node = new Node(railCarToAdd);
					

			        if (head == null) {
			            head = node;
			            return;
			        }
			        Node current = head;
			        Node previous = null;
			        
			        while (current.next != null) {
			        	

			            previous = current;
			        	current = current.next;
			        }
			        
			        int myInt = current.railCar.compareTo(railCarToAdd);
   
			        
			        current.next = node;

			        
			        
			    } // end addByDestination
				
				public int removeByDestination(String destination) {
					
					return 1;
				}// end removeByDestination

				public int removeByFreight(String freight) {
					
					return 1;
				}// end removeByfreight

				public void displayTrain() {
					
					Node current = head;
					while (current != null) {
						System.out.println(current.railCar + " "); 
				        current = current.next; 
					}
					
				} // end addByDestination

			// private inner class

				private static class Node {

					// private data fields
					
						private RailCar railCar;
						private Node next;

					// constructor
						
					public Node (RailCar railCar){

						this.railCar = railCar;
						next = null; 

					} // end constructor
				} // end node	
			
		}// end TrainLinkedList

		class DoubleLinkedList {

			// private data fields

				private Node head;
				private Node tail;

			// constructor - Default sets head and tail to null
		 	
			// methods

			public void addToEnd (RailCar railCarToAdd) {

				Node temp = new Node(railCarToAdd); 
			    if (tail == null) { 
			        head = temp; 
			        tail = temp; 
			    } 
			    else { 
			        tail.next = temp; 
			        temp.previous = tail; 
			        tail = temp; 
			    } 

			} // end addToEnd

			public void displayBackwards() {
					
				Node current = tail;
				while (current != null) {
					System.out.println(current.railCar + " "); 
			        current = current.previous; 
				}
		            
			} // end displayBackwards

			// private inner class

			private static class Node {

				// private data fields
				
					private RailCar railCar;
					private Node previous;
					private Node next;

				// constructor
					
				public Node (RailCar railCar){

					this.railCar = railCar;
					previous = null;
					next = null; 

				} // end constructor
			} // end node	
				


		} // end DoubleLinkedList

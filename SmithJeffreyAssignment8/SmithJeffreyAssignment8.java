/**
 * Name: Jeffrey Smith
 * Class: CS1450
 * Assignment: Assignment 8
 * Due Date:  4/10/2025, 11:59 PM
 * Create virtual message decoder
 * Use arrayLists, Arrays, queues, iterators to
 * manipulate data read from text files to
 * create a rudimentary decryption tool and print
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

public class SmithJeffreyAssignment8 {
	
	public static void main(String[] args) throws IOException  {
		
		// file objects for reading files
		File fileName = new File("keyGrid.txt");
		File fileName2 = new File("Message1.txt");
		File fileName3 = new File("Message2.txt");
		
		// scanner objects for reading files
		Scanner readFile = new Scanner(fileName);
		Scanner readFile2 = new Scanner(fileName2);
		Scanner readFile3 = new Scanner(fileName3);
		
		// create array list and key numRows and numCols
		ArrayList<Character> keyList = new ArrayList<>();
		int keyRows = readFile.nextInt();
		int keyCols = readFile.nextInt();
		
		// populate keyList
		while (readFile.hasNext()) {
			Character ch = readFile.next().charAt(0);
			keyList.add(ch);
		} // end while
		
		// create keyList iterator
		Iterator<Character> keyListIt = keyList.iterator();
		
		// create decoding machine and send iterator to build keygrid and print it
		DecodingMachine myMachine = new DecodingMachine(keyRows, keyCols);	
		myMachine.fillKeyGrid(keyListIt);
		myMachine.printKeyGrid();
		
		//create queues to hold message 1 and message 2
		Queue<KeyGridElement> Q1 = new LinkedList<>();
		Queue<KeyGridElement> Q2 = new LinkedList<>();
		
		// call fillQueue to populate Q1 and Q2
		fillQueue(Q1, readFile2);
		fillQueue(Q2, readFile3);
		
		// create iterators for Q1 and Q2
		Iterator<KeyGridElement> Q1It = Q1.iterator();
		Iterator<KeyGridElement> Q2It = Q2.iterator();
		
		// decode the test message
		System.out.println("\r");
		System.out.println("1st Secret Decoded Message");
		System.out.println("--------------------------------------------------------------------");
		Iterator<Character> myChar = myMachine.decodeMessage(Q1It); // set iterator to variable
		
		// loop through to print decoded message in Q1
		for (int i = 0; i < Q1.size(); i++) {
				System.out.print(myChar.next());
		} // end for

		// decode 2nd message
		System.out.println("\r\r");
		System.out.println("2nd Secret Decoded Message");
		System.out.println("--------------------------------------------------------------------");
		Iterator<Character> myChar2 = myMachine.decodeMessage(Q2It); // set iterator to variable
		
		// loop through to print decoded 2nd message
		for (int i = 0; i < Q2.size(); i++) {
				System.out.print(myChar2.next());
		} // end for

	} // end main
	
	// methods
	public static void fillQueue(Queue<KeyGridElement> aQueue, Scanner messageFile) {
		
		// loop through to populate Queue
		while (messageFile.hasNext()) {
			KeyGridElement myElement = new KeyGridElement(messageFile.nextInt(), messageFile.nextInt());
			aQueue.add(myElement);
		}// end while
	} // end fillQueue
	
} // end SmithJeffreyAssignment8


// Classes

class KeyGridElement  {
	
	// private data fields
	
	private int row;
	private int column;
	
	// constructors
	
	public KeyGridElement( int row, int column) {
		
		this.row = row;
		this.column = column;
	}
	
	// getters
	
	public int getRow() {
		
		return row;
	}
	
	public int getColumn() {
		
		return column;
	}
	
	// setters none
	
	// methods none
	
}// end KeyGridElement

class DecodingMachine {
	
	// private data fields
	
		private Character[][] keyGrid;
		private int numRows;
		private int numCols;
	
	// constructors
		
		public DecodingMachine (int numRows, int numCols) {
			
			this.numRows = numRows;
			this.numCols = numCols;
			keyGrid = new Character[numRows][numCols];
		}
	
	// getters none
	
	// setters none
	
	// methods
		
		public void fillKeyGrid(Iterator<Character> charIterator) {
			
			// nested loop to create rows and columns
			for (int i = 0; i < numRows; i++) {
				for (int j = 0; j < numCols; j++){
					
					keyGrid[i][j]=charIterator.next();
					
				}// end columns loop
			} // end rows loop
		} // end fillKeyGrid
		
		public Iterator<Character> decodeMessage( Iterator<KeyGridElement> msgIterator) {
			
			// create Arraylist of Character objects
			ArrayList<Character> secretMessage = new ArrayList<>();
			
			// loop through to populate the secretMessage list with decoded characters from keyGrid 2D Array
			while (msgIterator.hasNext()) {
				
				KeyGridElement myElement = msgIterator.next();
				Character ch = keyGrid[myElement.getRow()][myElement.getColumn()] ;
				secretMessage.add(ch);
				
			} // end while loop
			
			// create iterator for secretMessage list
			Iterator<Character> myIt = secretMessage.iterator();
			
			return myIt;
		} // end decodeMessage
		
		public void printKeyGrid() {
			
			System.out.println("Using the files (KeyGrid.txt, Message1.txt and Message2.txt):\r");
			System.out.println("Decoding Machine's Key Grid");
			System.out.println("---------------------------");
			
			// loop through and print keyGrid 2D Array by row/column
			for (int i = 0; i < numRows; i++) {
				for (int j = 0; j < numCols; j++){
					
					System.out.print(keyGrid[i][j] + " ");
					
				}// end columns loop
				
				System.out.println();
			
			} // end rows loop
		}// end printKeyGrid
	
}// end decodingMachine
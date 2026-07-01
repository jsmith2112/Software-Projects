package SmithJeffreyAssignnment1;

import java.util.Arrays;

/*
* Name:  Jeffrey Smith
* Class Name: CS1450 (M/W)
* Due Date: Jan 29, 2025 at 11:59pm
* Assignment #: 1
* Description: 3 tasks: Create array with values, 
* write values in the array to a file in sort order, 
* read from file to new arrays with no dups or zeros.
*/

import java.io.File;  // Import the File class
import java.io.IOException;  // Import the IOException class to handle errors
import java.io.PrintWriter; // Import the class to print arrays to file
import java.util.Scanner; // Import reader

public class SmithJeffreyAssignment1 {

	public static void main(String[] args) throws IOException {
		
		// Create and populate array
		int[] array1 = {1, 18, 10, 2, 16, 8, 15, 9, 9, 17, 14, 18, 1, 19, 18, 2, 1};
		
		//print header 1		
		System.out.println("Array Values");
		System.out.println("------------------");
		
		//print contents of array1
		for (int i = 0; i < array1.length; i++) {
			System.out.println("array1[" + i + "] = " + array1[i]);
			}
		
		//sort array1
			Arrays.sort(array1);
		
		// Task 2: Write Values in the array to a file in sorted order
		// create file

		      File filename = new File("assignment1.txt");  // create new File object
	  	
		// write to file

			PrintWriter pr = new PrintWriter("assignment1.txt");    //create PrintWriter object
			
			// initialize counters for odd and even values
			int j = 0;
			int y = 0;
			
			// Loop through array and count odd and even values
				    for (int i=0; i<array1.length ; i++) // loop through arrays till end of array
				    {

				    	if (array1[i] % 2 == 0) {
				    		j=j+1;
				    	} else {
				    		y=y+1;
				    	}
				        pr.println(array1[i]);
				    }
				    System.out.println("\rValues Written to File: " + (j+y));
				    System.out.println("Even Values Written to File: " + j);
				    System.out.println("Odd Values Written to File: " + y);

				    pr.close();	

		// print file path

			System.out.println("File is in directory: " + filename.getAbsolutePath()); // display path
			
		// create new arrays, read from file, save in new arrays, and print
						
						int[] evenArray = new int[j];
						int[] oddArray = new int[y];
			
			File fileName = new File("assignment1.txt"); // file object
		    Scanner readFile = new Scanner(fileName); // scanner object
		    
		      int i = 0;// even counter
		      int z = 0;// odd counter
		      
		// start reading while file has data
		      while (readFile.hasNextLine()) {
		        String data = readFile.nextLine();
		        
		// convert string data into int and save in appropriate new array
		          int number = Integer.parseInt(data); 
		          // identify if numbers are even or duplicates and populate arrays appropriately
		          if (i==0 && number % 2 == 0) {
			        	  evenArray[i]=number; 
			        	  i++;
			           } else if (z==0) {
			        	   oddArray[z]=number;
			        	   z++;
			           } else if (i > 0 && number % 2 == 0 && evenArray[i-1] != number) {
			        	  evenArray[i]=number; 
			        	  i++;
			           } else if (z>0 && oddArray[z-1] != number){
			        	   oddArray[z]=number;
			        	   z++;
			           }
		      }
		      readFile.close(); // close file
		      
		 //print filtered contents of evenArray and oddArray with zeros
		      
				System.out.println("\rEven array with no duplicates and extra zeros");
				System.out.println("------------------");
				
				for (int x = 0; x < evenArray.length; x++) {
					System.out.println("evenArray[" + x + "] = " + evenArray[x]);
					}
				
				System.out.println("\rOdd array with no duplicates and extra zeros");
				System.out.println("------------------");
				
				for (int n = 0; n < oddArray.length; n++) {
					System.out.println("oddArray[" + n + "] = " + oddArray[n]);
					}
				
		 // create and populate final right-sized arrays
				int[] finalArray1 = new int[i]; // sized to non-duplicate evens
				int[] finalArray2 = new int[z];// sized to non-duplicate odds

				for (int e = 0; e < i; e++) {
					finalArray1[e] = evenArray[e];
				}
				for (int o = 0; o < z; o++) {
					finalArray2[o] = oddArray[o];
				}
				
		// Print out headers and final right-sized arrays with no zeros
				System.out.println("\rEven array with no duplicates and no extra zeros");
				System.out.println("------------------");
				
				for (int n = 0; n < finalArray1.length; n++) {
					System.out.println("finalArray1[" + n + "] = " + finalArray1[n]);
					}
				System.out.println("\rOdd array with no duplicates and no extra zeros");
				System.out.println("------------------");
				
				for (int n = 0; n < finalArray2.length; n++) {
					System.out.println("finalArray2[" + n + "] = " + finalArray2[n]);
					}
				

			
	//end main
	}
}
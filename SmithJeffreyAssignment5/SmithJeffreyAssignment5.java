package SmithJeffreyDefault;

import java.io.File;
import java.io.IOException;
import java.util.ArrayList;
import java.util.Scanner;
import java.util.Stack;

/**
 * Name: Jeffrey Smith
 * Class Name: CS1450 (M/W)
 * Due Date: March 5th, 2025
 * Assignment #: 5
 * Description: 
 * Create a stack from array, replace 0's with 10's, display result.
 * Create generic stacks from values in files.  Perform manually sort, merge,
 * and display results
 */
/**
 * 
 */
public class SmithJeffreyAssignment5 {

	public static void main(String[] args) throws IOException {
	// Part 1	
		// initialize array
		int[] numbers = {0, 0, 4, 3, 0, 0, 2, 1, 0, 0};
		
		// Create a new stack
        Stack<Integer> stack = new Stack<>();
        Stack<Integer> tempStack = new Stack<>();

        // Push elements onto the stack
        for (int i = 0; i < numbers.length; i++) {
        	numbers[i] = stack.push(numbers[i]);         
        }
        // initialize counter
        int myCount = stack.size();
        // populate tempStack with corrected values
        for (int i = 0; i < myCount; i++) {
        	tempStack.push(replaceZerosWithTen(stack));
        }
        // re-populate original stack with corrected values
        for (int i = 0; i < myCount; i++) {
        	stack.push(tempStack.pop());
        }
        
        // print updated stack
        printStack(stack);

        
    // Part 2
        // Read files
        File fileName = new File("integers1.txt"); // file object
		File fileName2 = new File("integers2.txt"); // file object
		File fileName3 = new File("strings1.txt"); // file object
		File fileName4 = new File("strings2.txt"); // file object
		
		Scanner readFile = new Scanner(fileName); // scanner object
		Scanner readFile2 = new Scanner(fileName2); // scanner object
		Scanner readFile3 = new Scanner(fileName3); // scanner object
		Scanner readFile4 = new Scanner(fileName4); // scanner object	
		
		// Create generic stacks
		GenericStack<Integer> intStack1 = new GenericStack<>();
		GenericStack<Integer> intStack2 = new GenericStack<>();
		GenericStack<String> stringStack1 = new GenericStack<>();
		GenericStack<String> stringStack2 = new GenericStack<>();
		
		// populate stacks
		while (readFile.hasNext()) {
			intStack1.push(readFile.nextInt());
		}
		while (readFile2.hasNext()) {
			intStack2.push(readFile2.nextInt());
		}
		while (readFile3.hasNext()) {
			stringStack1.push(readFile3.next());
		}
		while (readFile4.hasNext()) {
			stringStack2.push(readFile4.next());
		}
		
		// print formatted output from integer stacks
		System.out.println("\r\rInteger1 Stack: filled with values from file: integers1.txt");
		System.out.println("----------------------------------------------------------");
		printStack(intStack1);
		System.out.println("\rInteger2 Stack: filled with values from file: integers2.txt");
		System.out.println("----------------------------------------------------------");
		printStack(intStack2);
		
		// sort integer stacks
		sortStack(intStack1);
		sortStack(intStack2);
		
		// print sorted integer stacks
		System.out.println("\rInteger1 Stack: sorted largest to smallest");
		System.out.println("----------------------------------------------------------");
		printStack(intStack1);
		System.out.println("\rInteger2 Stack: sorted largest to smallest");
		System.out.println("----------------------------------------------------------");
		printStack(intStack2);
		System.out.println("\rMerged Stack: sorted smallest to largest: ");
		System.out.println("----------------------------------------------------------");
		printStack(mergeStacks(intStack1, intStack2)); // print merged-sorted int stacks
		
		// print formatted string stacks
		System.out.println("\r\rString1 Stack: filled with values from file: strings1.txt");
		System.out.println("----------------------------------------------------------");
		printStack(stringStack1);
		System.out.println("\rString2 Stack: filled with values from file: strings2.txt");
		System.out.println("----------------------------------------------------------");
		printStack(stringStack2);
		
		//sort string stacks
		sortStack(stringStack1);
		sortStack(stringStack2);
		
		// pring sorted string stacks
		System.out.println("\rString1 Stack: sorted in reverse alphabetical");
		System.out.println("----------------------------------------------------------");
		printStack(stringStack1);
		System.out.println("\rString2 Stack: sorted in reverse alphabetical");
		System.out.println("----------------------------------------------------------");
		printStack(stringStack2);
		System.out.println("\rMerged Stack: reverse alphabetical ");
		System.out.println("----------------------------------------------------------");
		printStack(mergeStacks(stringStack1, stringStack2)); // print merged-sorted string stacks

	} // end main
	
	// methods
	// replace with 0's - as was originally in assignment with int return
	public static int replaceZerosWithTen (Stack<Integer> stack) {	
		// initialize return variable
		int myPop = 0;
		
		// determine which values to switch
		if (stack.peek()<1){
			myPop = 10;
		} else {
			myPop = stack.peek();
		}
		
		// pop to get to next value in stack
    	stack.pop();
    	// return correct value
		return myPop;
	} // end replaceZerosWithTen

	// integer print stack
	public static void printStack (Stack<Integer> stack) {
		// Create tempStack
		Stack<Integer> tempStack = new Stack<>();
		tempStack.addAll(stack);
		
        //display/pop elements from the stack
        System.out.println("Stack Values After 0's Replaced with 10");
        System.out.println("----------------------------------------------");
        
        // print all elements in stack
        while (!stack.isEmpty()) {
        	System.out.println(stack.pop());
        }
        // regen original stack
        stack.addAll(tempStack);
	}// end printStack
	
	// generic print stack
	public static <E> void printStack (GenericStack<E> stack) {
		
		// Create tempStack
		Stack<E> tempStack = new Stack<>();
		
		// print stack contents
		while (!stack.isEmpty()) {
			tempStack.add(stack.peek());
        	System.out.println(stack.pop());
        }
		// regen original stack
		while (!tempStack.isEmpty()) {
			stack.push(tempStack.pop());
		}
	}// end generic print stack
	
	// generic sort stack
	public static <E extends Comparable<E>> void sortStack(GenericStack<E> aStack) {
		// Create tempStack
			Stack<E> tempStack = new Stack<>();
			
			// while loop to loop comparisons
		    while (!aStack.isEmpty()) {
		        // take a peek and pop out the first element
		        E tmp = aStack.peek();
		        aStack.pop();

		        // compare while temp not empty and temp.peek is < 0
		        while (!tempStack.isEmpty() && tempStack.peek().compareTo(tmp)<0)
		        {
		            // pop from temporary stack and push to aStack
		            aStack.push(tempStack.peek());
		            tempStack.pop();
		        }

		        // push tmp to tempStack
		        tempStack.push(tmp);
		        
		    } // end while
		    
		    // create a stable counter
			int count = tempStack.size();
		    // regen original stack
		    for (int i = 0; i < count; i++) {
				aStack.push(tempStack.pop());
			}// end for
		} // end sortStack
	
	// generic merge stacks - changed return to GenericStack<E> so that generic print stack could be used.
	public static <E extends Comparable<E>> GenericStack<E> mergeStacks(GenericStack<E> stack1,GenericStack<E> stack2){
		// Create tempStack and merged stack
			GenericStack<E> mergeStack = new GenericStack<>();
			GenericStack<E> tempStack = new GenericStack<>();

				// as long as both still have elements loop through and compare
		        while (!stack1.isEmpty() && !stack2.isEmpty()) {
		            if (stack1.peek().compareTo(stack2.peek()) > 0) {
		                mergeStack.push(stack1.pop());
		            } else {
		                mergeStack.push(stack2.pop());
		            }
		        }
		        // if stack1 has values but stack2 doesn't, load them up
		        while (!stack1.isEmpty()) {
		            mergeStack.push(stack1.pop());
		        }
		        // if stack 2 has values but stack 1 doesn't, load them up
		        while (!stack2.isEmpty()) {
		            mergeStack.push(stack2.pop());
		        }

		        // push to temp to reverse order
		        while (!mergeStack.isEmpty()) {
		            tempStack.push(mergeStack.pop());
		        }
		        // return stack to be printed
		        return tempStack;
		    }
					
					

	} // end SmithJeffreyAssignment5

// classes
// GenericStack class to create stack objects
class GenericStack<E> {
	
	// private data fields
	ArrayList<E> List  = new ArrayList<>();
	private int size = List.size();
	private boolean isEmpty = true;
	
	// constructors
	public GenericStack() {
	//Creates an empty stack, which means, to allocate memory for the ArrayList
	}
	
	//getters
	public boolean isEmpty() {	
		if (List.size()<1) {
			this.isEmpty = true;
		} else {
			this.isEmpty = false;
		}
		return this.isEmpty;
	}
	public int getSize() {
			this.size = List.size();
		return this.size;
	}
	// No setters
	// Methods
	public E peek() {
			E myPeek = List.getLast();
			//System.out.println(myPeek);
			//System.out.println(List);
		return myPeek;
	}
	public E pop() {
			E myPop = List.getLast();
			List.removeLast();
			//System.out.println(myPop);
			//System.out.println(List);
		return myPop;
	}
	public void push(E value) {
			List.addLast(value);
			//System.out.println(List);
	}
	
} // end generic stack

/**
 * Name: Jeffrey Smith
 * Class: CS1450
 * Assignment: Assignment 10
 * Due Date:  5/1/2025, 11:59 PM
 * Binary Tree
 * read data from file to create objects
 * add objects to tree
 * traverse and read from tree in level order
 * visit each leaf and read data from each moving left to right
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

public class SmithJeffreyAssignment10 {
	
	public static void main(String[] args) throws IOException  {
		


				// file objects for reading files
				File fileName = new File("parrots.txt");
				
				// scanner objects for reading files
				Scanner readFile = new Scanner(fileName);
				BinaryTree myTree = new BinaryTree();
				
				// read values from file, create parrot objects and add them to binary tree
				while (readFile.hasNext()) {
					int myId = readFile.nextInt();
					String myName = readFile.next();
					String mySong = readFile.next();
					
					// create parrot objects and add them to BinaryTree
					Parrot myParrot = new Parrot(myId, myName, mySong);
					myTree.insert(myParrot);
							
				}
				
				// close file for reading
				readFile.close();
				
				
				// call level order to traverse and print song
				System.out.println("Parrot's Song");
				System.out.println("-------------------------------");
				myTree.levelOrder();
				System.out.println("\r");
				
				// call visit leaves to traverse leaves from left to right and print names
				System.out.println("Parrots on Leave Nodes");
				System.out.println("-------------------------------");
				myTree.visitLeaves();

			} // end main
		} // end SmithJeffreyAssignment10

// classes
class Parrot implements Comparable<Parrot> {
	
	// private Data Fields 
	int id;
	String name = null;
	String songWord = null;

	// constructor
		public Parrot(int id, String name, String songWord) {
			
			this.id = id;
			this.name = name;
			this.songWord = songWord;	
		}

	// Getters
		public String getName() {
			return name;
		} // getName
		
		public String sing() {
			return songWord;
		} // sing
		
	//Setters none

	// public methods
		
	// compare parrots by value of id
	@Override 
	public int compareTo(Parrot otherParrot) {
		
		if (this.id > otherParrot.id) {
			return 1;
		} else if (this.id < otherParrot.id) {
			return -1;
		} else {
			return 0;
		}
	}// end compareTo
} // end parrot

class BinaryTree {
	
	// private data fields
	TreeNode root;
	
	// Constructor 
	public BinaryTree() {
		this.root = null;
	} // end construct
	
	// Public methods
	public boolean insert(Parrot parrotToAdd){
		
		// If tree is empty create root
		if (root == null) {
		root = new TreeNode(parrotToAdd);
		}
		else {	
		// Locate the parent for the new node
		// initialize pointers
		TreeNode parent = null;
		TreeNode current = root;
		
		// Traverse the tree to add parrot to correct space in tree
		while (current != null) {
		// Determine if value will be inserted to left or right of current node
		if (current.myParrot.compareTo(parrotToAdd) > 0) {
		parent = current;
		current = current.left;
		}
		else if (current.myParrot.compareTo(parrotToAdd) < 0) {
		parent = current;
		current = current.right;
		}
		else {
		// Found a duplicate node - do not insert
		return false;
		}
		} // while
		if (parrotToAdd.id < parent.myParrot.id) {
			parent.left = new TreeNode(parrotToAdd); // add to left
			}
			else {
			parent.right = new TreeNode(parrotToAdd); // add to right
			}
			} // else not root node
			return true;
	} // end insert
	
	public void levelOrder() {
		
		// if tree is not empty 
		if (root != null) {
			
			Queue<TreeNode> myQue = new LinkedList<>(); // create queue
			myQue.offer(root); // populate queue with root value
			
			// while queue isn't empty read from queue and add more values to queue to be read
			while (!myQue.isEmpty()) {
				TreeNode tempNode = myQue.remove();  // remove root from queue
				System.out.print(tempNode.myParrot.sing() + " ");  // print out getSongWord
				
				// if next node to left exists, send it to the queue
				if (tempNode.left != null) {
					myQue.offer(tempNode.left);
				} 
				// if next node to the right exists, send it to the queue
				if (tempNode.right != null) {
					myQue.offer(tempNode.right);
				}
			// queue continues to give up values after we've read through whole tree
			} // while	
		} // end if root != null	
	} // end level order
	
	public void visitLeaves() {
		// use public method to call private method
		visitLeaves(root);
	} // end visit leaves
	
	private void visitLeaves(TreeNode aNode) {
		
	    // If tree is empty, stop processing 
	    if (aNode == null) 
	        return; 
	     
	    // If node is leaf node, print its parrot name     
	    if (aNode.left == null && 
	    		aNode.right == null) 
	    { 
	        System.out.println(aNode.myParrot.getName());
	        return; 
	    } 
	     
	    // If left child is leaf call recursive method
	    if (aNode.left != null) 
	    	visitLeaves(aNode.left); 
	         
	    // If right child is leaf call recursive method
	    if (aNode.right != null) 
	    	visitLeaves(aNode.right); 
	} // end visitLeaves
	
	private class TreeNode{
		
		// Private data fields
		Parrot myParrot = null;
		TreeNode left;
		TreeNode right;
		
		// constructor
		public TreeNode(Parrot myParrot) {
			// initialize data fields
			this.myParrot = myParrot;
			left = null;
			right = null;
		} // end constructor
		
	} // end treeNode
} // end tree

// HW21.1.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include <iostream>
using namespace std;

// Write a template that will create a binary tree that can hold values of any data type
class TreeNode
{
    public:
    template <typename T>
    struct Node
    {
        T data;
        Node* left;
        Node* right;
        Node(T val) : data(val), left(nullptr), right(nullptr) {}
    };
};



int main()
{
	// Example usage of the TreeNode template
    TreeNode::Node<int>* intNode = new TreeNode::Node<int>(10);
    TreeNode::Node<std::string>* stringNode = new TreeNode::Node<std::string>("Hello");
	TreeNode::Node<double>* doubleNode = new TreeNode::Node<double>(3.14);
	TreeNode::Node<int>* leftChild = new TreeNode::Node<int>(5);
	TreeNode::Node<int>* rightChild = new TreeNode::Node<int>(15);
    cout << "Integer Node Data: " << intNode->data << std::endl;
    cout << "String Node Data: " << stringNode->data << std::endl;
	cout << "Double Node Data: " << doubleNode->data << std::endl;
	cout << "Left Child Data: " << leftChild->data << std::endl;
	cout << "Right Child Data: " << rightChild->data << std::endl;
    // Clean up
    delete intNode;
    delete stringNode;
	delete doubleNode;
	delete leftChild;
	delete rightChild;
	return 0;
}



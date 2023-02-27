using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEA_December_2022
{
    internal class NEAQStats
    {
        public void mainscript()
        {

            
        }
        public int SumIntArray(int[] ar)
        {
            int n = 0;
            foreach (int i in ar)
            {
                n += i;
            }
            return n;
        }

        public double Difficulty(double AvgQuestionScore, double thevariance, double Userscore, bool flagged) //Function to return the arbitery Difficulty value
        {
            double x = Userscore;
            double mean;
            double z;
            double variance;
            double stddev;

            //Data will be all of the scores for THE question



            mean = AvgQuestionScore;
            variance = thevariance;
            stddev = Math.Sqrt(thevariance);
            stddev += 0.001;
            z = (x - mean) / stddev;

            Console.WriteLine("Mean: {0}, Variance: {1}, Stddev: {2}", mean, variance, stddev);
            Console.WriteLine("When X = {0}, Z = {1}", x, z);
            double difficulty = z * -1;
            if (flagged)
            {
                difficulty = difficulty + 1;
            }
            difficulty = difficulty * 100;
            Console.WriteLine("Difficulty for question with User avg {0} is: {1}", x, difficulty);
            return difficulty;




        }


        public static double average(double[] array) //Function to return the mean value of an array
        {
            double rounder;
            double avg;
            int s = 0;
            foreach (int t in array)
            {
                s += t;
            }

            rounder = (double)s / array.Length;

            return rounder;
        }

        public double Variance(double[] array) //Function to calculate and return the mathematical variance of an array
        {
            double variance = 0;

            double mean = average(array);

            foreach (int t in array)
            {
                double s = t - mean;
                variance = variance + (s * s);
            }

            variance /= array.Length;

            return variance;
        }
    }
    

    



    public class BinaryTreeNode<T> //Class to store binary tree nodes
    {
        public T Value { get; set; } //The 'T' value is the Value of the node (A,B,C,D) etc used to differentiate between nodes 
        public BinaryTreeNode<T> Left { get; set; } //Has a value to store THE node to the Left of it
        public BinaryTreeNode<T> Right { get; set; } //Has a value to store THE node to the Right of it
        public int Weight { get; set; } //The weight of the node

        public BinaryTreeNode(T value, int weight) //When a Node is first made, it has a T value and a weight,
        {
            Value = value;
            Left = null;
            Right = null;
            Weight = weight;
        }
    }

    public class BinaryTree<T> //Class to store and create a FULL binary tree
    {
        public BinaryTreeNode<T> Root { get; set; } //Uses the node class to store a Root

        public void Add(T value, int weight) //Function to add new values to the tree
        {
            var newNode = new BinaryTreeNode<T>(value, weight);

            if (Root == null) //If the Root is empty, make the root the new node (First node in tree)
            {
                Root = newNode;
            }
            else
            {
                AddNode(Root, newNode); //Add a new node
            }
        }

        private void AddNode(BinaryTreeNode<T> currentNode, BinaryTreeNode<T> newNode)
        {
            if (newNode.Weight < currentNode.Weight) //Check if the current nodes weight is bigger, hence put it on the left
            {
                if (currentNode.Left == null)
                {
                    currentNode.Left = newNode; //If left is empty then place it there,
                }
                else
                {
                    AddNode(currentNode.Left, newNode); //If not then move down and check again
                }
            }
            else //We must be placing it to the right
            {
                if (currentNode.Right == null) //Check if the node on the right is empty
                {
                    currentNode.Right = newNode; //If so, put the node straight to the right
                }
                else
                {
                    AddNode(currentNode.Right, newNode); //If not, move right and check again
                }
            }
        }

        public void TraverseInOrder(Action<T> action) //Traverse the tree using In order traversal (smallest to largest)
        {
            TraverseInOrder(Root, action); //Also stores an 'action' which is done upon traversal (Console.WriteLine) would be an action
        }

        private void TraverseInOrder(BinaryTreeNode<T> node, Action<T> action)
        {
            if (node != null) //If the node isn't empty,
            {
                TraverseInOrder(node.Left, action); //Traverse the node to the left, this will initially move all the way left
                action(node.Value); //Output the node using the 'action' e.g. Console.Writeline
                TraverseInOrder(node.Right, action); //Traverse all nodes to the right
            }
        }

        public void TraversePostOrder(Action<T> action) //Traverse the tree using Pose order traversal 
        {
            TraversePostOrder(Root, action); //Also stores an 'action' which is done upon traversal (Console.WriteLine) would be an action
        }

        private void TraversePostOrder(BinaryTreeNode<T> node, Action<T> action)
        {
            if (node != null) //If the node isn't empty,
            {
                TraversePostOrder(node.Left, action); //Traverse the node to the left, this will initially move all the way left
                TraversePostOrder(node.Right, action); //Traverse all nodes to the right
                action(node.Value); //Output the node using the 'action' e.g. Console.Writeline

            }
        }
    }
}

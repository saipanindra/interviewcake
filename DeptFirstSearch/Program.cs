using System;
using System.Collections.Generic;

namespace DeptFirstSearch
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            BinaryTreeNode root = BuildTestTree();
            TraverseDepthFirst(root);
        }
        
        private static BinaryTreeNode BuildTestTree()
        {
            BinaryTreeNode root = new BinaryTreeNode(1);
            BinaryTreeNode root_left = root.AddToLeft(2);
            BinaryTreeNode root_right = root.AddToRight(3);
            BinaryTreeNode root_left_left = root_left.AddToLeft(4);
            BinaryTreeNode root_left_right = root_left.AddToRight(5);
            return root;
        }
        private static void TraverseDepthFirst(BinaryTreeNode root)
        {
            if(root == null)
            {
                return;
            }
            
            Stack<BinaryTreeNode> s = new Stack<BinaryTreeNode>();
            s.Push(root);
            while(s.Count > 0)
            {
                BinaryTreeNode currentNode = s.Pop();
                currentNode.printData();
                BinaryTreeNode left = currentNode.GetLeftChild();
                BinaryTreeNode right = currentNode.GetRightChild();
                if(left != null)
                {
                    s.Push(currentNode.GetLeftChild());
                }
                if(right != null)
                {
                    s.Push(currentNode.GetRightChild());
                }
            }
        }
    }
    
    class BinaryTreeNode
    {
        int Data {get; set;}
        
        BinaryTreeNode Left {get; set;}
        
        BinaryTreeNode Right {get; set;}
        
        public BinaryTreeNode(int data)
        {
            Data = data;
            Left = Right = null;
        }
        public BinaryTreeNode AddToRight(int data)
        {
            BinaryTreeNode newNode = new BinaryTreeNode(data);
            Right = newNode;
            return Right;
        }
        public BinaryTreeNode AddToLeft(int data)
        {
            BinaryTreeNode newNode = new BinaryTreeNode(data);
            Left = newNode;
            return Left;
        }
        
        public BinaryTreeNode GetLeftChild()
        {
            return Left;
        }
        public BinaryTreeNode GetRightChild()
        {
            return Right;
        }
        public void printData()
        {
            Console.WriteLine(Data);
        }
    }
}

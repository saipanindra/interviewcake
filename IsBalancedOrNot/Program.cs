using System;
using System.Collections.Generic;

namespace IsBalancedOrNot
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Console.WriteLine(IsBalanced(BuildTree()));
        }
        
        public static BinaryTreeNode BuildTree()
        {
            BinaryTreeNode root = new BinaryTreeNode(1);
            BinaryTreeNode root_left = root.AddToLeft(2);
            BinaryTreeNode root_right = root.AddToRight(3);
            BinaryTreeNode root_right_right = root_right.AddToRight(8);
            BinaryTreeNode root_left_left = root_left.AddToLeft(4);
            BinaryTreeNode root_left_left_left = root_left_left.AddToLeft(6);
            BinaryTreeNode root_left_left_right = root_left_left.AddToRight(7);
            
            BinaryTreeNode root_left_right = root_left.AddToRight(5);
            return root;
        }
        
        public static bool IsBalanced(BinaryTreeNode root)
        {
            if(root == null)
            {
                return true;
            }
            return _isBalanced(new NodeDepthPair(root, 0));
        }
        
        private static bool _isBalanced(NodeDepthPair nd)
        {
            List<int> depthList = new List<int>(3);
            Stack<NodeDepthPair> s = new Stack<NodeDepthPair>();
            s.Push(nd);
            while(s.Count > 0)
            {
               NodeDepthPair currentNd = s.Pop();
               if(currentNd.isLeafNode())
               {
                   if(depthList.Contains(currentNd.depth))
                   {
                       continue;
                   }
                   if(depthList.Count == 2)
                   {
                     return false;
                   }
                   depthList.Add(currentNd.depth);
                   continue;
               }
               if(currentNd.n.Left != null)
               {
                   s.Push(new NodeDepthPair(currentNd.n.Left, currentNd.depth + 1));
               }
               if(currentNd.n.Right != null)
               {
                   s.Push(new NodeDepthPair(currentNd.n.Right, currentNd.depth + 1));
               }
            }
            
            return Math.Abs(depthList[0] - depthList[1]) <= 1;
        }
    }
   
    class NodeDepthPair
    {
        public BinaryTreeNode n;
        public int depth;
        public NodeDepthPair(BinaryTreeNode _n, int _depth)
        {
          n = _n;
          depth = _depth;
        }
        public bool isLeafNode()
        {
            return n.Left == null && n.Right == null;
        }
    }
    class BinaryTreeNode
    {
        public int Data;
        public BinaryTreeNode Left, Right;
        public BinaryTreeNode(int d)
        {
            Data = d;
        }
        public BinaryTreeNode AddToLeft(int d)
        {
           BinaryTreeNode newNode = new BinaryTreeNode(d);
           Left = newNode;
           return Left;
        }
        public BinaryTreeNode AddToRight(int d)
        {
           BinaryTreeNode newNode = new BinaryTreeNode(d);
           Right = newNode;
           return Right;
        }
    }
}

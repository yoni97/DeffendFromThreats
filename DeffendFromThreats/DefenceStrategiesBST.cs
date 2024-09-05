using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeffendFromThreats
{
    public class DefenceStrategiesBST
    {
         
        public TreeNode root;

        public DefenceStrategiesBST()
        {
            root = null;
        }



        public void Insert(TreeNode node)
        {
            TreeNode newNode = new TreeNode(node.MaxSeverity, node.MinSeverity, node.DefensesStrings);
            root = InsertRecursive(root, newNode);
        }

        private TreeNode InsertRecursive(TreeNode node, TreeNode newNode)
        {
            if (node == null)
            {
                node = new TreeNode(newNode.MinSeverity, newNode.MaxSeverity, newNode.DefensesStrings);
                return node;
            }
            if (newNode.MinSeverity < node.MinSeverity)
                node = InsertRecursive(node.Right, newNode);
            else
                node = InsertRecursive(node.Left, newNode);
            return newNode;
        }

        public void PreOrder()
        {
            PrintPreOrder(root);
        }

        public void PrintPreOrder(TreeNode node)
        {
            if (node != null)
            {
                Console.Write($" Min = {node.MinSeverity},Max = {node.MaxSeverity} End ");
                Console.WriteLine("");
                PrintPreOrder(node.Left);
                PrintPreOrder(node.Right);
            }
        }



        

        public int? GetMin()
        {
            return GetMin(root);
        }

        private int? GetMin(TreeNode node)
        {
            if (node == null)
                return null;
            int min = node.MinSeverity;
            while (node.Left != null)
            {
                min = node.Left.MinSeverity;
                node = node.Left;
            }

            return min;
        }

        //public bool Find(int value)
        //{
        //    return FindRecursive(root, value);
        //}

        //public bool FindRecursive(TreeNode node, int value)
        //{
        //    if (root == null) return false;
        //    if (root.Value == value) return true;
        //    if (value < node.Value)
        //        return FindRecursive(node.Left, value);
        //    else
        //        return FindRecursive(node.Right, value);
        //    //return FindRecursive(value < node.Value? node.Left : node.Right, value);
        //}

        //public int? GetMax()
        //{
        //    return GetMax(root);
        //}

        //private int? GetMax(TreeNode node)
        //{
        //    if (node == null)
        //        return null;
        //    int min = node.Value;
        //    while (node.Right != null)
        //    {
        //        min = node.Right.Value;
        //        node = node.Right;
        //    }
        //    return min;
        //}





        //public void Delete(int value)
        //{

        //    root = DeleteNode(root, value);


        //}

        //private TreeNode DeleteNode(TreeNode root, int value)
        //{
        //    if (root == null)
        //        return null;

        //    if (value < root.Value)
        //    {
        //        root.Left = DeleteNode(root.Left, value);
        //    }
        //    else if (value > root.Value)
        //    {
        //        root.Right = DeleteNode(root.Right, value);
        //    }
        //    else
        //    {
        //        // Node with no children
        //        if (root.Left == null && root.Right == null)
        //        {
        //            return null;
        //        }

        //        // Node with one child
        //        if (root.Left == null)
        //        {
        //            return root.Right;
        //        }
        //        if (root.Right == null)
        //        {
        //            return root.Left;
        //        }

        //        // Node with two children
        //        TreeNode minNode = GetMinValueNode(root.Right);
        //        root.Value = minNode.Value;
        //        root.Right = DeleteNode(root.Right, minNode.Value);
        //    }

        //    return root;
        //}

        //private TreeNode GetMinValueNode(TreeNode node)
        //{
        //    TreeNode current = node;
        //    while (current.Left != null)
        //    {
        //        current = current.Left;
        //    }
        //    return current;
        //}

        //public TreeNode FindNodeByValue(int value)
        //{
        //    return FindNode(root, value);
        //}

        //private TreeNode FindNode(TreeNode root, int value)
        //{
        //    if (root == null)
        //        return null;

        //    if (value < root.Value)
        //    {
        //        return FindNode(root.Left, value);
        //    }
        //    else if (value > root.Value)
        //    {
        //        return FindNode(root.Right, value);
        //    }
        //    else
        //    {
        //        return root;
        //    }
        //}
        public void InOrder()
        {
            PrintInOrder(root);
        }
        public void PrintInOrder(TreeNode node)
        {
            if (node != null)
            {
                PrintInOrder(node.Left);
                Console.Write($"{node.MinSeverity}  {node.MaxSeverity} ");
                PrintInOrder(node.Right);
            }
        }






    }
}


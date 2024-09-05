using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
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

        //print the tree from the root to left
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

   
        //find the response to the treat
        public bool Find(int value)
        {
            return FindRecursive(root, value);
        }

        //execute the func
        public bool FindRecursive(TreeNode node, int value)
        {

            if (root == null)
                Console.WriteLine("suitable defence was No found. Brace for impact!");
            if (root.MinSeverity + root.MaxSeverity != value)
                Console.WriteLine("severity Attack is below the threshold.Attack is ignored");

            if (node.MinSeverity + node.MaxSeverity == value)
            {
                Console.WriteLine($"{root.DefensesStrings[0]}");
                Task.Delay(4000);
                Console.WriteLine($"{root.DefensesStrings[1]}");
            }

            if (value < node.MinSeverity)
                return FindRecursive(node.Left, value);

            else
                return FindRecursive(node.Right, value);
            //return FindRecursive(value < node.Value? node.Left : node.Right, value);
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


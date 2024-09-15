using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DeffendFromThreats
{
    public class DefenceStrategiesBST
    {

         
        private static TreeNode? root;

        public DefenceStrategiesBST()
        {
            root = null;
        }

        public void Insert(TreeNode node)
        {
            root = InsertRecursive(root, node.MaxSeverity, node.MinSeverity, node.DefensesStrings);
        }

        //O(n)
        private TreeNode InsertRecursive(TreeNode node, int MaxSeverity, int MinSeverity, List<string> Defenses)
        {
            if (node == null)
            {
                node = new TreeNode(MinSeverity, MaxSeverity, Defenses);
                return node;
            }
            if (MinSeverity > node.MinSeverity)
                node.Right = InsertRecursive(node.Right, MinSeverity, MaxSeverity, Defenses);
            else
                node.Left = InsertRecursive(node.Left, MinSeverity, MaxSeverity, Defenses);
            return node;
        }

        public void PreOrder()
        {
            PrintPreOrder(root);
        }

        //O(n)
        public async void PrintPreOrder(TreeNode root)
        {
            if (root != null)
            {
                Console.Write($" Min = {root.MinSeverity} ,Max = {root.MaxSeverity} End {root.DefensesStrings[0]}, {root.DefensesStrings[1]}");
                Console.WriteLine("");
                PrintPreOrder(root.Left);
                PrintPreOrder(root.Right);
            }
        } 
   
        //find the response to the treat
        public void Find(int value)
        {
            FindRecursive(root, value);
        }

        //O(n)
        //find the range of the threat and print the adequate protection
        public async void FindRecursive(TreeNode node, int value)
        {
            if (root == null)
            {
                Console.WriteLine("suitable defence was No found. Brace for impact!");
                return;
            }
            if (value == node.MinSeverity || value == node.MaxSeverity)
            {
                Console.WriteLine($"{root.DefensesStrings[0]}");
                Task.Delay(4000);
                Console.WriteLine($"{root.DefensesStrings[1]}");
                return;
            }
            else if (value < node.MinSeverity)
            {
                if (node.Left != null)
                {
                    FindRecursive(node.Left, value);
                }
                else if (root.MinSeverity > value)
                {
                    Console.WriteLine("severity Attack is below the threshold. Attack is ignored!!");
                    return;
                }
            }
            
            else if (value > node.MaxSeverity)
            {
                if (node.Right != null)
                {
                    FindRecursive(node.Right, value);
                }
                else if (root.MaxSeverity < value)
                {
                    Console.WriteLine("severity Attack is below the threshold. Attack is ignored!!");
                    return;
                }
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

        public void InOrder()
        {
            PrintInOrder(root);
        }

        //O(n)
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


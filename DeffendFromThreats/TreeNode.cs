using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeffendFromThreats
{
    public class TreeNode
    {
        public int MinSeverity { get; set; }

        public int MaxSeverity {  get; set; }

        public List<string>? DefensesStrings { get; set; } = new List<string>();

        public TreeNode Left { get; set; }

        public TreeNode Right { get; set; }

        public TreeNode(int minSeverity, int maxSeverity, List<string> defensesStrings)
        {
            MinSeverity = minSeverity;
            MaxSeverity = maxSeverity;
            this.DefensesStrings = defensesStrings;
            this.Left = null;
            this.Right = null;
        }
    }
}

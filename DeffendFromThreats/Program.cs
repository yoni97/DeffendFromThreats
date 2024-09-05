using DeffendFromThreats;
using System.Text.Json;
using System.Xml.Linq;

static void Main()
{
    List<TreeNode> jsonFile = ReadFromJson<List<TreeNode>>(@"..\..\..\defenceStrategiesBalanced.json");

    List<TreeNode> jsonThreatFile = ReadFromJson<List<TreeNode>>(@"..\..\..Threats.json");


    static T ReadFromJson<T>(string jsonFile)
    {
        string jsonString = File.ReadAllText(jsonFile);
        return JsonSerializer.Deserialize<T>(jsonString);
    }





    Dictionary<string, DefenceStrategiesBST> trees = new();
    DefenceStrategiesBST tree = new();
    foreach (TreeNode item in jsonFile)
    {
        tree.Insert(item);

        tree.PreOrder();
        //Console.WriteLine("");
    }
        //tree.InOrder();
}
Main();




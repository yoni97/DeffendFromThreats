using DeffendFromThreats;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json;
using System.Xml.Linq;



static void Main()
{
    //path of the json file
    List<TreeNode> jsonFile = ReadFromJson<List<TreeNode>>(@"..\..\..\defenceStrategiesBalanced.json");

    //read and convert the json file
    static TreeNode ReadFromJson<TreeNode>(string jsonFile)
    {
        string jsonString = File.ReadAllText(jsonFile);
        return JsonSerializer.Deserialize<TreeNode>(jsonString);
    }

    
    //inserting objects to the tree
    //O(n**2)
    DefenceStrategiesBST tree = new();
    foreach (TreeNode item in jsonFile)
    {
        tree.Insert(item);
    }
    tree.PreOrder();

    //path of the threats json file
    List<ThreatsOfSiber> jsonThreatFile = ReadThreatFromJson<List<ThreatsOfSiber>>(@"C:\Users\User\Desktop\codcode\c#\consoleApp\SiberThrets\DeffendFromThreats\Threats.json");

    //read and convert the json file
    static T ReadThreatFromJson<T>(string jsonFile)
    {
        string jsonthreatString = File.ReadAllText(jsonFile);
        return JsonSerializer.Deserialize<T>(jsonthreatString);
    }

    //calculate the threat number and sending it to check the type if defence
    //O(n)
    foreach (ThreatsOfSiber item in jsonThreatFile)
    {
        string result = item.Target.ToString();
        switch (item.Target)
        {
            case "Web Server":
                result = "10";
                break;
            case "Database":
                result = "15";
                break;
            case "User Credentials":
                result = "20";
                break;
            default:
                result = "5";
                break;
        }
        int severity = (item.Volume * item.Sophistication) + int.Parse(result);
        tree.Find(severity);
    }
}
Main();




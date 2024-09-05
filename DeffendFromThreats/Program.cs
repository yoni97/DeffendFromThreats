using DeffendFromThreats;
using System.Text.Json;
using System.Xml.Linq;

static void Main()
{

    List<TreeNode> jsonFile = ReadFromJson<List<TreeNode>>(@"..\..\..\defenceStrategiesBalanced.json");

    static T ReadFromJson<T>(string jsonFile)
    {
        string jsonString = File.ReadAllText(jsonFile);
        return JsonSerializer.Deserialize<T>(jsonString);
    }

    DefenceStrategiesBST tree = new();
    foreach (TreeNode item in jsonFile)
    {
        tree.Insert(item);

        tree.PreOrder();
    }

    List<ThreatsOfSiber> jsonThreatFile = ReadThreatFromJson<List<ThreatsOfSiber>>(@"..\..\..Threats.json");

    static T ReadThreatFromJson<T>(string jsonFile)
    {
        string jsonthreatString = File.ReadAllText(jsonFile);
        return JsonSerializer.Deserialize<T>(jsonthreatString);
    }

    DefenceStrategiesBST trt = new();
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
        trt.Find(severity);
    }
}
Main();




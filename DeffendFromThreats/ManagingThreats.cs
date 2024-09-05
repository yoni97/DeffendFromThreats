using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;


namespace DeffendFromThreats
{
    public class ManagingThreats
    {
        
        public void calcThrat()
        {
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

    }
}

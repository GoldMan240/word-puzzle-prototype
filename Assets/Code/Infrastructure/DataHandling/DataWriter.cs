using System.IO;
using System.Threading.Tasks;
using UnityEngine;

namespace Code.Infrastructure.DataHandling
{
    public class DataWriter
    {
        public static void WriteToJson<T>(T data, string path)
        {
            Task task = File.WriteAllTextAsync(path, JsonUtility.ToJson(data));
            Debug.Log("Starting to write to " + path + "...");
            task.Wait();
            Debug.Log("Finished writing to " + path + "!");
        }
    }
}
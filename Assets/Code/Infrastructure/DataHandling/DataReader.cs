using System.IO;
using Code.Infrastructure.Configs;
using UnityEngine;

namespace Code.Infrastructure.DataHandling
{
    public class DataReader
    {
        public static T ReadFromJson<T>(string path)
        {
            if (!File.Exists(path))
            {
                Debug.LogError("File not found at " + path);
                return default;
            }
            
            Debug.Log("Read from " + path + "!");
            
            string json = File.ReadAllText(path);
            return JsonUtility.FromJson<T>(json);
        }
    }
}
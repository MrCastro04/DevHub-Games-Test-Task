using System.IO;
using UnityEngine;

namespace Core.Saves
{
    public static class SaveSystem
    {
        private static string SavePath => Application.persistentDataPath + "/save.json";

        public static void SetData(SaveData data)
        {
            string json = JsonUtility.ToJson(data, true);

            File.WriteAllText(SavePath, json);
        }

        public static SaveData GetData()
        {
            if (File.Exists(SavePath) == false)
            {
                return new SaveData
                {
                    Money = 0,
                };
            }

            string jsonFile = File.ReadAllText(SavePath);

            return JsonUtility.FromJson<SaveData>(jsonFile);
        }
    }
}
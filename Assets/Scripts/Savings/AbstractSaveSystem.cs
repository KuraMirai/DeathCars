using System.IO;
using UnityEngine;

namespace Savings
{
    public abstract class AbstractSaveSystem<T> : MonoBehaviour
    {
        private T _cachedData;

        public void SetData(T data)
        {
            _cachedData = data;
        }

        private void OnApplicationPause(bool pause)
        {
            if (pause)
            {
                if (_cachedData != null)
                    SaveData();
            }
        }

        private void OnDisable()
        {
            if (_cachedData != null)
                SaveData();
        }

        protected abstract void SaveData();
        protected abstract T LoadAndInitData();
        
        protected void Save(string fileName)
        {
            string jsonStr = JsonUtility.ToJson(_cachedData);
            Directory.CreateDirectory(GetSaveFilePath(fileName));
            if (!File.Exists(Path.Combine(GetSaveFilePath(fileName), fileName)))
                File.Create(Path.Combine(GetSaveFilePath(fileName), fileName)).Close();
            File.WriteAllText(Path.Combine(GetSaveFilePath(fileName), fileName), jsonStr);
        }

        protected T Load(string fileName)
        {
            if (!File.Exists(Path.Combine(GetSaveFilePath(fileName), fileName)))
                return default;
            string jsonStr = File.ReadAllText(Path.Combine(GetSaveFilePath(fileName), fileName));
            return JsonUtility.FromJson<T>(jsonStr);
        }

        private string GetSaveFilePath(string fileName)
        {
            string saveFilePath;
#if UNITY_EDITOR
            saveFilePath = Path.Combine(Application.dataPath, "Data", "Saves", fileName);
#else
            saveFilePath = Path.Combine(Application.persistentDataPath, fileName);
#endif
            return saveFilePath;
        }
    }
}
using UnityEngine;

namespace SaveLoad
{
    public static class LocalStorage
    {
        public static void Save<T>(string key, T data)
        {
            var json = JsonUtility.ToJson(data);
            PlayerPrefs.SetString(key, json);
        }
        
        public static T Load<T>(string key)
        {
            var json = PlayerPrefs.GetString(key);
            return JsonUtility.FromJson<T>(json);
        }
    }
}
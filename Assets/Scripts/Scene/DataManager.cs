using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using TMPro;
public class DataManager : MonoBehaviour
{
    public static DataManager Instance;

    public string playerName;
    public int bestScore;
    public string bestPlayer;
    
    private const string Path = "D:/wupin/unity/projects/Json/saveFile.json";

    private void Awake()
    {
        if (DataManager.Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        
        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadData();
    }
    

    [System.Serializable]
    class SaveData
    {
        public string name;
        public int bestScore;
        public string bestPlayer;
    }

    //保存name,bestScore,bestPlayer
    public void SaveAllData()
    {
        SaveData saveData = new SaveData();
        
        saveData.name = playerName;
        saveData.bestScore = bestScore;
        saveData.bestPlayer = bestPlayer;
        
        string json = JsonUtility.ToJson(saveData);
        File.WriteAllText(Path,json);
    }
    
    //加载name,best score,best player
     public void LoadData()
     {
         if (File.Exists(Path))
         {
             string json = File.ReadAllText(Path);
             SaveData saveData = JsonUtility.FromJson<SaveData>(json);
             playerName = saveData.name;
             bestScore = saveData.bestScore;
             bestPlayer = saveData.bestPlayer;
         }
     }
     
}

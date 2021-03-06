using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
public class DataController : MonoBehaviour
{
    static DataController _instance; 
    public static DataController Instance 
    { 
        get 
        { 
            if (!_instance) 
            { 
                GameObject obj = new GameObject("DataController");
                _instance = obj.AddComponent(typeof(DataController)) as DataController; 
                DontDestroyOnLoad(obj);
            } 
            return _instance; 
        } 
    } 
    
    public string GameDataFileName = "JCSaveFile.json"; 
    
    public GameData _gameData; 
    public GameData gameData 
    {
        get 
        { 
            if(_gameData == null)
            { 
                LoadGameData(); 
            }
            return _gameData;
        }
    } 
    
    private void Start() 
    {
        LoadGameData(); 
    } 
    
    public void LoadGameData() 
    {
        string filePath = Application.persistentDataPath + "\\" + GameDataFileName;
        
        if (File.Exists(filePath))
        { 
            string FromJsonData = File.ReadAllText(filePath); 
            _gameData = JsonUtility.FromJson<GameData>(FromJsonData);
        }
        else 
        {            
            _gameData = new GameData();
        } 
    } 
    
    public void SaveGameData()
    {
        this.gameData.workers = new List<Worker>();
        foreach (CompanyRoom room in GameManager.Instance.Companys)
        {
            foreach (WorkerUnit workerUnit in room.workers)
            {
                this.gameData.workers.Add(workerUnit.worker);
            }
        }
        File.WriteAllText(Application.persistentDataPath + "\\" + GameDataFileName, JsonUtility.ToJson(gameData));
    }
    
    public void SaveGameData2()
    {
        this.gameData.workers = new List<Worker>();
        File.WriteAllText(Application.persistentDataPath + "\\" + GameDataFileName, JsonUtility.ToJson(gameData));
    }

    private void OnApplicationQuit()
    { 
        SaveGameData(); 
    } 
} 
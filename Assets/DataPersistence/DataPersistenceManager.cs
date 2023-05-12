using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using TMPro;

public class DataPersistenceManager : MonoBehaviour 
{
    [Header("File Storage Config")]
    [SerializeField] private string fileName;

    public GameData gameData;
    public PlayerController Coinss;
    private List<IDataPersistence> dataPersistenceObjects;
    private FileDataHandler dataHandler;
    public static DataPersistenceManager Instance { get; private set; }

    private void Awake()
    {
        if(Instance != null)
        {
            Debug.LogError("Found more than one Data Persistance Manager in the scene");
        }
        Instance = this;
    }

    private void Start()
    {
        this.dataHandler = new FileDataHandler(Application.persistentDataPath, fileName);
        this.dataPersistenceObjects = FindAllDataPersistenceObjects();
        LoadGame();
    }

    public void NewGame()
    {
        this.gameData = new GameData();
    }

    public void LoadGame()
    {
        gameData = dataHandler.Load();

        if(this.gameData == null)
        {
            Debug.Log("No Data was found");
            NewGame();
        }

        foreach (IDataPersistence dataPersistenceObj in dataPersistenceObjects)
        {
            dataPersistenceObj.LoadData(gameData);
        }

        Debug.Log("Loaded " + gameData.CoinsNumber);
    }
    public void LoadTempHighScLV1()
    {
        this.gameData = dataHandler.LoadLV1();

        foreach (IDataPersistence dataPersistenceObj in dataPersistenceObjects)
        {
            dataPersistenceObj.LoadData(gameData);
        }

        Debug.Log("Loaded " + gameData.Lv1High);
    }
    public void SaveGame()
    {
        foreach (IDataPersistence dataPersistenceObj in dataPersistenceObjects)
        {
            dataPersistenceObj.SaveData(ref gameData);
        }

        Debug.Log("Saved " + gameData.CoinsNumber);

        dataHandler.Save(gameData);
    }

    public void SaveGameLV1()
    {
        foreach (IDataPersistence dataPersistenceObj in dataPersistenceObjects)
        {
            gameData.Lv1High = Coinss.Coins;
            dataPersistenceObj.SaveData(ref gameData);
        }

        Debug.Log("SavedLv1 " + Coinss.Coins);

        dataHandler.SaveLv1(gameData);
    }

    public void OnApplicationQuit()
    {
        SaveGame();
    }

    private List<IDataPersistence> FindAllDataPersistenceObjects()
    {
        IEnumerable<IDataPersistence> dataPersistenceObjects = FindObjectsOfType<MonoBehaviour>().OfType<IDataPersistence>();

        return new List<IDataPersistence>(dataPersistenceObjects);
    }
}

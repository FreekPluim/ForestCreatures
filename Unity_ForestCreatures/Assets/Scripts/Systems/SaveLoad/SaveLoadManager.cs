using UnityEngine;
using System.Linq;
using System.Collections.Generic;

public class SaveLoadManager : MonoBehaviour
{
    public static SaveLoadManager instance { get; private set; }
    [SerializeField] private string fileName;


    private GameData gameData;
    private List<ISaveLoad> saveLoadObjects;

    private FileDataHandler dataHandler;

    private void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(this.gameObject);
    }

    private void Start()
    {
        this.dataHandler = new FileDataHandler(Application.persistentDataPath, fileName);
        this.saveLoadObjects = FindAllSaveLoadObjects();
        LoadGame();
    }

    private void OnApplicationQuit()
    {
        SaveGame();
    }

    public void NewGame()
    {
        gameData = new GameData();
    }

    public void LoadGame()
    {
        this.gameData = dataHandler.load();

        if (gameData == null) NewGame();

        foreach (ISaveLoad s in saveLoadObjects)
        {
            s.LoadData(gameData);
        }
    }

    public void SaveGame() 
    {
        foreach (ISaveLoad s in saveLoadObjects)
        {
            s.SaveData(ref gameData);
        }

        dataHandler.Save(gameData);
    }

    private List<ISaveLoad> FindAllSaveLoadObjects()
    {
        IEnumerable<ISaveLoad> saveLoadObjects = FindObjectsByType<MonoBehaviour>().OfType<ISaveLoad>();
        return new List<ISaveLoad>(saveLoadObjects);
    }

}

public class GameData
{
    public int sceneID;
    public Vector3 playerPosition;
    //Inventory
    //Unlocked NPC's
    //StartedQuests
    //CompletedQuests

    public GameData()
    {
        sceneID = 0;
        playerPosition = Vector3.zero;
    }
}

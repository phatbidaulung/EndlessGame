using System.IO;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Newtonsoft.Json;
using System.Collections;
using Newtonsoft.Json.Converters;
using System.Collections.Generic;
using Random = UnityEngine.Random;

public class DataPlayer : MonoBehaviour
{

    [SerializeField] private TMP_InputField textInput;
    [SerializeField] private Button btnSave;
    ListModel _listModel = new();

    private void Start()
    {
        this.btnSave.onClick.AddListener(Save);
    }
    public void Save()
    {
        this.LoadDataFromFile();
        _listModel.PlayerModel.Add(new Model
        {
            id = Random.Range(1, 100),
            name = textInput.text,
            score = PlayerPrefs.GetInt("highScore")
        });

        this.SaveDataToFile();
    }
    public void SaveDataToFile()
    {
        try
        {
            //Save data to directory
            var serializer = new JsonSerializer();
            using var sw = new StreamWriter(Application.persistentDataPath + "/dataUser.json");
            using JsonWriter writer = new JsonTextWriter(sw);
            serializer.Serialize(writer, _listModel);
        }
        catch 
        { 
            //Create empty data when there is no file
            this.CreateEmptyFile(); 
        }
    }

    public void LoadDataFromFile()
    {
        try
        {
            //Get data from directory and assign it to model
            var outputJson = File.ReadAllText(Application.persistentDataPath + "/dataUser.json");
            var loadedUserData = JsonConvert.DeserializeObject<ListModel>(outputJson);
            _listModel.PlayerModel = loadedUserData.PlayerModel;
        }
        catch
        {
            //Create empty data when there is no file
            this.CreateEmptyFile();
        }
    }

    public void CreateEmptyFile()
    {
        ListModel __listModel = new();
        var serializer = new JsonSerializer();
        using var sw = new StreamWriter(Application.persistentDataPath + "/dataUser.json");
        using JsonWriter writer = new JsonTextWriter(sw);
        serializer.Serialize(writer, __listModel);
    }
}

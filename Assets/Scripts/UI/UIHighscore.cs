using System.IO;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using TMPro;
using Newtonsoft.Json;
using System.Collections;
using Newtonsoft.Json.Converters;
using System.Collections.Generic;
using Random = UnityEngine.Random;
public class UIHighscore : MonoBehaviour
{

    private string path;
    [SerializeField] private Button btnReplay;
    [SerializeField] private GameObject player;
    [SerializeField] private Transform parent;
    [SerializeField] private TextMeshProUGUI listPlayerName;
    [SerializeField] private TextMeshProUGUI listPlayerScore;

    private void Awake() { path = Application.persistentDataPath + "/dataUser.json"; }

    private void Start()
    {
        CreateListPlayerToScreen();
        this.btnReplay.onClick.AddListener(DestroyOj);
    }

    public void CreateListPlayerToScreen()
    {
        //Get data from directory and assign it to model
        var outputJson = File.ReadAllText(Application.persistentDataPath + "/dataUser.json");
        var loadedUserData = JsonConvert.DeserializeObject<ListModel>(outputJson);

        //Sort list players by score 
        var orderByResut = from n in loadedUserData.PlayerModel
                           orderby n.score descending
                           select n;
        var listPlayer = orderByResut.ToArray();

        //Check length array
        int listCount = 5;
        if (listPlayer.Count() < 5) { listCount = listPlayer.Count(); }

        //Create list player
        for (int i = 0; i < listCount; i++)
        {
            listPlayerScore.text = listPlayer[i].score.ToString();
            listPlayerName.text = listPlayer[i].name;

            Instantiate(player, transform.position - new Vector3(0, 50 * i, 0), transform.rotation, parent);
        }
    }
    private void DestroyOj()
    {
        Destroy(gameObject);
    }
}
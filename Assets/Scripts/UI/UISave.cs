using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class UISave : UIManager
{
    [SerializeField] private TMP_InputField textInput;
    [SerializeField] private Button btnSave;
    [SerializeField] private TextMeshProUGUI yourScore;
    private void Start()
    {
        this.btnSave.onClick.AddListener(ClosePopup);
        yourScore.text = "Your score: " + PlayerPrefs.GetInt("highScore").ToString();
    }

    private void Update()
    {
        this.CheckNull();
    }
    private void CheckNull()
    {
        if (textInput.text == "")
        {
            btnSave.interactable = false;
        }
        else
        {
            btnSave.interactable = true;
        }
    }
    private void ClosePopup()
    {
        DestroyPopup();
    }
}

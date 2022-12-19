using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class UIAgain : UIManager
{
    
    [SerializeField] private Button btnReplay;

    private void Start()
    {
        this.btnReplay.onClick.AddListener(Reload);
    }

    private void Reload()
    {
        SceneManager.LoadScene("Scene01");
    }

}

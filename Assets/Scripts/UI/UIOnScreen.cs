using UnityEngine;
using TMPro;

public class UIOnScreen : UIManager
{
    [SerializeField] private TextMeshProUGUI scoreNow;

    private void FixedUpdate()
    {
        this.scoreNow.text = GameManager.Instance.TimeIs().ToString();
    }
}
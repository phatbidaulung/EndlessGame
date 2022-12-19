using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    protected void LoadHighScorePopup()
    {
        Instantiate(Resources.Load<GameObject>("Popups/HighscorePopup") as GameObject);
    }

    protected void QuitGame()
    {
        Application.Quit();
    }

    protected void DestroyPopup()
    {
        Destroy(gameObject);
    }
}
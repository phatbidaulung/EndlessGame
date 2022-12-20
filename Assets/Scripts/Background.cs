using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    [SerializeField] private float speed = 0.1f;
    private float startingPosition = 39.35f;

    private void FixedUpdate()
    {
        BackgroundMove();
        ResetLocationBackground();
        ChangeLevelSpeed();
    }

    /// <summary>
    /// Background parallax scrolling 
    /// </summary>
    private void BackgroundMove()
    {
        this.transform.position -= new Vector3(this.speed, 0, 0);
    }

    /// <summary>
    /// Check and reset when background get out "view" 
    /// </summary>
    private void ResetLocationBackground()
    {
        if (this.transform.position.x <= -39.4f)
        {
            NewLocation();
        }
    }
    private void NewLocation()
    {
        this.transform.position = new Vector3(this.startingPosition, this.transform.position.y, this.transform.position.z);
    }

    private void ChangeLevelSpeed()
    {
        this.speed = GameManager.Instance.ReturnLevelSpeed() * 0.1f;
    }
}
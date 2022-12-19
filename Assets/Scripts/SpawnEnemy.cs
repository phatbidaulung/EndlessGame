using System.Collections;
using System.Collections.Generic;
using UnityEngine;
    using Random = UnityEngine.Random;

public class SpawnEnemy : MonoBehaviour
{
    private float timeClone;
    private void Update()
    {
        CheckTime();
    }

    private void Spawn()
    {
        string nameEnemy = "Enemy0" + Random.Range(1, 5);
        Instantiate(Resources.Load<GameObject>(nameEnemy) as GameObject, new Vector2(25f, 2.85f), Quaternion.identity);
    }

    private void CheckTime()
    {
        timeClone += 2 * Time.deltaTime;
        if (timeClone > TimeSpawn())
        {
            this.Spawn();
            timeClone = 0;
        }

    }

    private float TimeSpawn()
    {
        float timeDown = 10f;
        timeDown -= GameManager.Instance.ReturnLevelSpeed();
        if (timeDown <= 3)
        {
            timeDown = 3;
        }
        return timeDown;
    }
}

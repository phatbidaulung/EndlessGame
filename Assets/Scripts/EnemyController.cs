using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private float speed;

    private void Start() 
    {
        this.ChangeSpeedEnemy(GameManager.Instance.ReturnLevelSpeed());
    }
    private void FixedUpdate()
    {
        this.MoveEnemy();
        this.KillEnemy();
    }

    private void KillEnemy()
    {
        float outView = -20f;
        if(transform.position.x < outView)
        {
            Destroy(gameObject);
        }
    }

    public void ChangeSpeedEnemy(float speedUpdate)
    {
        this.speed += speedUpdate;
    }

    private void MoveEnemy()
    {
        this.transform.position -= new Vector3(this.speed, 0f, 0f) * Time.deltaTime;
    }
}

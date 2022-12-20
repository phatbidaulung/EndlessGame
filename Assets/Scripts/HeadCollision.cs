using UnityEngine;

public class HeadCollision : MonoBehaviour 
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        if ((other.gameObject.tag == "Enemy"))
        {
            GameManager.Instance.GameOver();
        }
    }
}
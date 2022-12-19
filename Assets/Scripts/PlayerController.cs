using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    public float strength = 500f;
    public bool isPlane;

    private void Update()
    {

        if ((Input.GetKeyDown(KeyCode.Space)) && (isPlane))
        {
            rb.velocity = new Vector2(rb.velocity.x, strength);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if ((other.gameObject.tag == "Enemy"))
        {
            GameManager.Instance.GameOver();
        }
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if ((other.gameObject.tag == "Plane"))
        {
            this.isPlane = true;
        }
    }
    private void OnCollisionExit2D(Collision2D other)
    {
        if ((other.gameObject.tag == "Plane"))
        {
            this.isPlane = false;
        }
    }
}

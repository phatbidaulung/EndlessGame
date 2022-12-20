using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private GameObject headCollision;
    private  float strength = 23f;
    public bool isPlane;

    private void Update()
    {
        
        if (((Input.GetKeyDown(KeyCode.Space)) && (isPlane)) || ((Input.GetKeyDown(KeyCode.UpArrow)) && (isPlane)))
        {
            rb.velocity = new Vector2(rb.velocity.x, strength);
        }
        if (((Input.GetKey(KeyCode.DownArrow)) && (isPlane)) || ((Input.GetKey(KeyCode.LeftShift)) && (isPlane)))
        {
            Physics2D.gravity = new Vector2(0f, -15f);
            headCollision.SetActive(false);
        }
        else
        {
            headCollision.SetActive(true);
        }
        Physics2D.gravity = new Vector2(0f, -9.8f);
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private PlayerController _playerController;

    private void FixedUpdate()
    {
        if (((Input.GetKey(KeyCode.DownArrow) && (_playerController.isPlane)) || ((Input.GetKey(KeyCode.LeftShift)) && (_playerController.isPlane))))
        {
            player.GetComponent<Animator>().Play("Slide");
        }
        else
        {
            if (_playerController.isPlane)
            {
                player.GetComponent<Animator>().Play("Run");
            }
            if (!_playerController.isPlane)
            {
                player.GetComponent<Animator>().Play("jump");
            }
        }
    }
}

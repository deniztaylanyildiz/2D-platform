using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keycontrol : MonoBehaviour
{
    public Animator controller;
    public Animator door;
    public GameObject portal;

   
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag=="Player")
        {
            controller.Play("key open");
            door.Play("door_open");
            portal.active = true;
        }
    }
}

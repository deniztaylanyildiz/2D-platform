using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    
    private Transform CurrentCheckpoint;//store last checkpoint
    private Health playerHealth;
    void Start()
    {
        playerHealth = GetComponent<Health>();
    }

  
    public void Respawn()
    {
        transform.position = CurrentCheckpoint.position;
        playerHealth.Respawn();
        //restore PlyerHelath Reset animation
      
    }
    //activate Check point
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision. transform.tag== "Checkpoint")
        {
            CurrentCheckpoint = collision.transform;
            //voice can add
            collision.GetComponent<Collider2D>().enabled=false;
            collision.GetComponent<Animator>().SetTrigger("Checking");
        }
    }

    
   
}

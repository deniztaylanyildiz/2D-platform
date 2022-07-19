using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_Attack : MonoBehaviour
{
    [Header("Voice's")]
    public AudioSource arrow;
    
    public float attackcooldown;
    [SerializeField] private Transform arrowpoint;
    [SerializeField] private GameObject[] arrows;
    private float cooldowntimer=Mathf.Infinity;
    private Animator anim;
    private playerMovment playerMovement;
   
    private void Awake()
    {
        anim = GetComponent<Animator>();
        playerMovement = GetComponent<playerMovment>();
    }

    private void FixedUpdate()
    {
        if (Input.GetMouseButton(0) && cooldowntimer > attackcooldown && playerMovement.iscanAttack())
        { attack();
            arrow.Play();
        }
        cooldowntimer += Time.deltaTime;
        
    }
   
    private void attack()
    {
        anim.Play("bow_start");
        
        
           anim.SetTrigger("attackoff");
          
       
    cooldowntimer = 0;



        arrows[findfireball()].transform.position = arrowpoint.position;
        if(transform.localScale.x>=0)
        arrows[findfireball()].GetComponent<Projectile>().setDirection(Mathf.Sign(transform.localScale.x));
        else
        {
            arrows[findfireball()].GetComponent<Projectile>().setDirection(Mathf.Sign(-transform.localScale.x));
        }
    }
    private int findfireball()
    {
        for (int i = 0; i < arrows.Length; i++)
        {
            if (!arrows[i].activeInHierarchy)
                return i;
        }

        return 0;
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour
{
    [Header("voice")]
    public AudioSource hurtvoice;
    public AudioSource takeHealth;
    public AudioSource death;

    [Header ("Health")]
    public float startingHealth;
    public float currentHealth;
    private Animator hurt;
    private bool dead;
    [Header("iFreams")]
    public float ifreamesDuration;
    public float colortimer;
    private SpriteRenderer spriterender;

    [Header("immortal")]
    private bool invulnerable;
    private void Awake() 
    {
        currentHealth = startingHealth;
        hurt = GetComponent<Animator>();
        spriterender = GetComponent<SpriteRenderer>();
    }


    public void Respawn()
    {
        dead = false;
        addhealth(startingHealth);
        hurt.Play("caracter_ide");
        StartCoroutine(Invureability());
        GetComponent<playerMovment>().enabled = true;
    }
    public void TakeDamage(float _damage)
    {
        if (invulnerable) return;
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);
        
        
        if (currentHealth>0)
        {
            //player Hurt
            hurt.Play("player_hurt");
            StartCoroutine(Invureability());
            hurtvoice.Play();
        }
        else
        {
            //player death
            if (!dead)
            {
                hurt.Play("DÝe");
                //player
                death.Play();
                GetComponent<playerMovment>().enabled = false;
                
              
                dead = true;
            }
            

        }
    }
  

    public void addhealth(float _value)
    {
        currentHealth = Mathf.Clamp(currentHealth + _value, 0, startingHealth);
        takeHealth.Play();
    }
    private IEnumerator Invureability()
    {
        invulnerable = true;
        Physics2D.IgnoreLayerCollision(9, 10, true);
        //invune duration
        for (int i = 0; i < colortimer; i++)
        {
            spriterender.color = new Color(1, 0, 0, 0.5f);
            yield return new WaitForSeconds(ifreamesDuration/(colortimer*2));
            spriterender.color = Color.white;
            yield return new WaitForSeconds(ifreamesDuration / (colortimer * 2)); ;
        }
        Physics2D.IgnoreLayerCollision(9, 10, false);
        invulnerable = false;
    }
}

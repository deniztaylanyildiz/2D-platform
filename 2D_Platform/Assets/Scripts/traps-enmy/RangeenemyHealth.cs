using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeenemyHealth : MonoBehaviour
{
    [Header("voices")]
    public AudioSource hurtvoice;
    public AudioSource Attacktvoice;
    public AudioSource death;
    [Header("Health")]
    public float startingHealth;
    public float currentHealth;
    private Animator hurt;
    private bool dead;
    [Header("iFreams")]
    public float ifreamesDuration;
    public float colortimer;
    private SpriteRenderer spriterender;


    private void Awake()
    {
        currentHealth = startingHealth;
        hurt = GetComponent<Animator>();
        spriterender = GetComponent<SpriteRenderer>();
    }
    public void TakeDamage(float _damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);


        if (currentHealth > 0)
        {

            hurt.Play("enemyhurt");
            StartCoroutine(Invureability());
            hurtvoice.Play();
        }
        else
        {

            if (!dead)
            {
                dead = true;



                hurt.Play("Die");
             death.Play();


}


        }
    }



    public IEnumerator Invureability()
    {
        Physics2D.IgnoreLayerCollision(9, 10, true);
        //invune duration
        for (int i = 0; i < colortimer; i++)
        {
            spriterender.color = new Color(1, 0, 0, 0.5f);
            yield return new WaitForSeconds(ifreamesDuration / (colortimer * 2));
            spriterender.color = Color.white;
            yield return new WaitForSeconds(ifreamesDuration / (colortimer * 2)); ;
        }
        Physics2D.IgnoreLayerCollision(9, 10, false);
    }
    public IEnumerator DelayTime()
    {

      

        //GetComponentInParent<EnemyPatrol>().enabled = false;


        GetComponentInParent<MeleeEnemy>().enabled = false;

        yield return new WaitForSeconds(1);
        gameObject.SetActive(false);


    }
}

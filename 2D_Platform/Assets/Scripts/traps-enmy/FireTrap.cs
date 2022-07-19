using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class FireTrap : MonoBehaviour
{
    public float firetrapdamage;
    [Header("voice")]
    public AudioSource FireTrapped;
    [Header("FireTrap Timers")]
    public float activetiondelay;
    public float activetime;
    private Animator fireTrapanim;
    private SpriteRenderer spritefiretrap;
    private Health playerHealth;

    //diðer
    private bool triggered;
    private bool activated;


    private void Awake()
    {
        fireTrapanim = GetComponent<Animator>();
        spritefiretrap = GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        if(playerHealth!=null&&activated)
        {
            playerHealth.TakeDamage(firetrapdamage);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag=="Player")
        {
            playerHealth = collision.GetComponent<Health>();
            if (!triggered)
            {
                  StartCoroutine(ActiveFireTrap());
                
            }
            if (activated)
                collision.GetComponent<Health>().TakeDamage(firetrapdamage);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == ("Player"))
            playerHealth = null;

    }




    private IEnumerator ActiveFireTrap()
    {
        triggered = true;
        spritefiretrap.color = Color.red;//uyarý baðlamýnda
        yield return new WaitForSeconds(activetiondelay);
        spritefiretrap.color = Color.white;
        activated = true;
        fireTrapanim.SetBool("Active", true);
        FireTrapped.Play();

        //bütün boolarý sýfýrlamakiçin delaylý bir bekleme
        yield return new WaitForSeconds(activetime);
        activated = false;
        triggered = false;
        fireTrapanim.SetBool("Active", false);
    }
}

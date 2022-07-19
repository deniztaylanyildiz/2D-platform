using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowTrap : MonoBehaviour
{
    [Header("Voice")]
    public AudioSource arowlunch;
    public float attackcooldown;
    public Transform arrowpoint;
    public GameObject[] arrows;
    private float cooldowntimer;
    private void attack()
    {
        cooldowntimer = 0;
        arrows[findfireball()].transform.position = arrowpoint.position;
        arrows[findfireball()].GetComponent<Projectile>().setDirection(Mathf.Sign(transform.localScale.x));
        arowlunch.Play();
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
    private void Update()
    {
        cooldowntimer += Time.deltaTime;
        if (cooldowntimer >= attackcooldown)
            attack();
        
    }

}

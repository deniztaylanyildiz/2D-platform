using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spikehead : EnemyTrapDamage
{
    [Header("Voice")]
    public AudioSource damagesound;
    public float speed;
    public float range;
    private Vector3 destinatio;
    private bool attact;
    public float checkdelay;
    private float checktimer;
    private Vector3[] directions = new Vector3[4];
    public LayerMask PlayerLayer;

    // Update is called once per frame
    void Update()
    {

        if(attact)
        transform.Translate(destinatio * Time.deltaTime * speed);
    
    else 
    {
            checktimer += Time.deltaTime;
            if (checktimer > checkdelay)
                checkforplayer();
    }
    }

    private void checkforplayer()
    {
        caluculateDirections();
        for (int i = 0; i < directions.Length; i++)
        {
            Debug.DrawRay(transform.position, directions[i], Color.red);
            RaycastHit2D hit = Physics2D.Raycast(transform.position, directions[i], range, PlayerLayer);
            if (hit.collider != null && !attact)
            {

                attact = true;
                destinatio = directions[i];
                checktimer = 0;
                damagesound.Play();


            }

            }

    }
    private void caluculateDirections()
    {

        directions[0] = transform.right*range;
        directions[1] = -transform.right * range;
        directions[2] = transform.up * range;
        directions[3] = -transform.up * range;



    }
    private void OnEnable()
    {
        stop();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);
        stop();
        if (collision)
            stop();
    }
    private void stop()
    {
        destinatio = transform.position;
        attact = false;

    }
}

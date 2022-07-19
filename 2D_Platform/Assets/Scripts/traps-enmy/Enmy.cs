using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enmy : MonoBehaviour
{


    //haraket edece�i zaman
    public float movmentdistance;
    public float speed;
    private bool movingLeft;
    private float leftEdge;
    private float rightEdge;
    //haraketsiz trap i�in
    public float damage;



    private void Awake()
    {
        leftEdge = transform.position.x - movmentdistance;
        rightEdge = transform.position.x + movmentdistance;

    }

    private void Update()
    {
        if(movingLeft)
        {
            if (transform.position.x > leftEdge)
            {
                transform.position = new Vector3(transform.position.x - speed * Time.deltaTime,transform.position.y, transform.position.z);
            }
            else
                movingLeft = false;
        }
        else
             
        {
            if (transform.position.x < rightEdge)
            {
                transform.position = new Vector3(transform.position.x + speed * Time.deltaTime, transform.position.y, transform.position.z);
            }
            else
                movingLeft = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == ("Player"))
        {
            collision.GetComponent<Health>().TakeDamage(damage);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCanCollect : MonoBehaviour
{
    public float healthValue;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == ("Player"))
        {
            collision.GetComponent<Health>().addhealth(healthValue);
            Destroy(gameObject);
        }
    }
}

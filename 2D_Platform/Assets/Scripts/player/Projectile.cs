using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed;
    private float direction;
    public float damage;
    private bool hit;
    private BoxCollider2D boxCollider;
    private float lifeTime;

    private void Awake()
    {
        boxCollider = GetComponent<BoxCollider2D>();

    }
    private void Update()
    {
        if (hit) return;
        float movmentspeed = speed * Time.deltaTime*direction;
        transform.Translate(movmentspeed, 0, 0);
        lifeTime += Time.deltaTime;
        if (lifeTime > 5) gameObject.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        hit = true;
        boxCollider.enabled = false;
        gameObject.SetActive(false);
        if (collision.tag == "Player")
        {
            collision.GetComponentInParent<Health>().TakeDamage(1);

        }
        if (collision.tag == "Enemy")
        {
           
            collision.GetComponentInParent<Healthenemy>().TakeDamage(1);


        }
        if(collision.tag =="RangeEnemy")
            collision.GetComponentInParent<RangeenemyHealth>().TakeDamage(1);

    }
    public void setDirection(float _direction)
    {
        lifeTime = 0;
        direction = _direction;
        gameObject.SetActive(true);
        hit = false;
        boxCollider.enabled = true;

        float localscaleX = transform.localScale.x;
        if (Mathf.Sign(localscaleX)!=_direction)
            localscaleX = -localscaleX;
        transform.localScale = new Vector3(localscaleX, transform.localScale.y, transform.localScale.z);
    }
     
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballProjectile : MonoBehaviour
{
    public float speed;
    private float direction;
    public float damage;
    private bool hit;
    private BoxCollider2D boxCollider;
    private float lifeTime;
    private Animator fireanim;
    public Transform fireballlauncher;
    public float directionn;
    

    private void Awake()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        fireanim = GetComponent<Animator>();
      
    }
    private void Update()
    {
        
        if (hit) return;
        float movmentspeed = speed * Time.deltaTime * direction;
        transform.Translate(direction * movmentspeed, 0, 0);
        // transform.Translate(fireballlauncher.transform.localScale.x * movmentspeed, 0, 0);
        // if(fireballlauncher.transform.localScale.x>0)
        //transform.Translate(movmentspeed, 0, 0);
        //else
        //  transform.Translate(-movmentspeed, 0, 0);
        lifeTime += Time.deltaTime;
        if (lifeTime > 5) gameObject.SetActive(false);
       
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
       
              
            StartCoroutine(DelayAction(1));
            if (collision.tag == "Player")
            {
                collision.GetComponentInParent<Health>().TakeDamage(1);

            }
            if (collision.tag == "Enemy")
            {
            hit = true;
            boxCollider.enabled = false;
            StartCoroutine(DelayAction(1));

        }
        if (collision.tag == "Traps")
        {
            hit = true;
            boxCollider.enabled = false;
            StartCoroutine(DelayAction(1));

        }
       
    }
    IEnumerator DelayAction(float delayTime)
    {
        hit = true;
        boxCollider.enabled = false;
        fireanim.Play("hit");
        yield return new WaitForSeconds(delayTime);
        gameObject.SetActive(false);
        

    }
    public void setDirection(float _direction)
    {
        lifeTime = 0;
        direction = _direction;
        gameObject.SetActive(true);
        hit = false;
        boxCollider.enabled = true;

        float localscaleX = transform.localScale.x;
        if (Mathf.Sign(localscaleX) != _direction)
            localscaleX = -localscaleX;
        transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.z);
    }

}

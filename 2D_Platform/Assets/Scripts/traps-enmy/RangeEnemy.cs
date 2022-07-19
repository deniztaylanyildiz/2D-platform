using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeEnemy : MonoBehaviour
{
    [Header("voice")]
    public AudioSource Fireballvoice;
    [ Header("attack parameters")]
    public float attackCooldown;
    public float range;
    public float damage;
    [Header("Ranged attack")]
    public Transform firepoint;
    public GameObject[] fireballs;

    [Header("collider Paramaters")]
    public float ColliderDistance;
    public BoxCollider2D BoxCollider;


    [Header("Player Layer")]
    public LayerMask PlayerLayer;
    private float cooldownTimer = Mathf.Infinity;

    //Referances
    private Animator rangeanimenmy;
    private EnemyPatrol enemypatrol;

    private void Awake()
    {
        rangeanimenmy = GetComponent<Animator>();
        enemypatrol = GetComponent<EnemyPatrol>();
    }
    private void Update()
    {
        cooldownTimer += Time.deltaTime;
            if(playerInsight())
        {
            if (cooldownTimer >= attackCooldown)
            {
                cooldownTimer = 0;
                rangeanimenmy.Play("enemy_atact");
                Fireballvoice.Play();
            }
            else return;
        }
        if (enemypatrol != null)
            enemypatrol.enabled = !playerInsight();
    }
    private bool playerInsight()

    {
        RaycastHit2D hit = Physics2D.BoxCast(BoxCollider.bounds.center + transform.right * range * transform.localScale.x * ColliderDistance,
            new Vector3(BoxCollider.bounds.size.x * range, BoxCollider.bounds.size.y, BoxCollider.bounds.size.z), 0, Vector2.left, 0, PlayerLayer);
       

        return hit.collider != null;

    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawCube(BoxCollider.bounds.center + transform.right * range * transform.localScale.x * ColliderDistance,
            new Vector3(BoxCollider.bounds.size.x * range, BoxCollider.bounds.size.y, BoxCollider.bounds.size.z));
    }

    private void Rangedattck()
    {
        cooldownTimer = 0;
        fireballs[rangeAttack()].transform.position = firepoint.position;
        fireballs[rangeAttack()].GetComponent<FireballProjectile>().setDirection(Mathf.Sign(transform.localScale.x)); ;

    }
    private int  rangeAttack()
    {
        for (int i = 0; i < fireballs.Length; i++)
        {
            if (!fireballs[i].activeInHierarchy)
                return i;
        }
        return 0;
    }
}

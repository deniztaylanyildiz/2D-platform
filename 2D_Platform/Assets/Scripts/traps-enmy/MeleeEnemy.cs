using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy : MonoBehaviour
{
    [Header("voices")]
    public AudioSource attackvoice;

    public float attackcooldown;
    public float range;
    public float ColliderDistance;
    public float damage;
    public BoxCollider2D BoxCollider;
    public LayerMask PlayerLayer;
    private float cooldowntimer = Mathf.Infinity;
    
    //Reffs
    private Animator enemyanim;
   private Health PlayerHealth;
    private EnemyPatrol enemypatrol;
    private void Awake()
    {
        enemyanim = GetComponent<Animator>();
        enemypatrol = GetComponentInParent<EnemyPatrol>();
            }
    private void Update()
    {
        cooldowntimer += Time.deltaTime;
        //attack only when player sight
        if (playerInsight())

            if (cooldowntimer >= attackcooldown)
            {
                cooldowntimer = 0;
                enemyanim.Play("enemy_atact");
                attackvoice.Play();
            }
            else return;
    }
    private bool playerInsight()

    {
        RaycastHit2D hit = Physics2D.BoxCast(BoxCollider.bounds.center+transform.right*range*transform.localScale.x*ColliderDistance,
            new Vector3(BoxCollider.bounds.size.x*range,BoxCollider.bounds.size.y,BoxCollider.bounds.size.z), 0, Vector2.left, 0, PlayerLayer);
        if(hit.collider!=null)
        {
            PlayerHealth = hit.transform.GetComponent<Health>();
        }

        return hit.collider !=null;

    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawCube(BoxCollider.bounds.center + transform.right * range * transform.localScale.x * ColliderDistance, 
            new Vector3(BoxCollider.bounds.size.x * range, BoxCollider.bounds.size.y, BoxCollider.bounds.size.z));
    }
    private void DamagePlayer()
    {  
        //if Player Still in range damage him
        if(playerInsight())
        {   
            PlayerHealth.TakeDamage(damage);

        }
        if (enemypatrol != null)
            enemypatrol.enabled = !playerInsight();
    }

}

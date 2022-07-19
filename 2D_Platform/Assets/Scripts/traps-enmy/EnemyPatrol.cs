using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public Transform leftedge;
    public  Transform rightedge;
    [Header("enemy")]
    public Transform enemy;
    [Header("enemy movment")]
    public float speed;
    private Vector3 inscale;
    private bool movingleft;

    [Header("Idle Beh")]
    public float idleDuration;
    private float idletimer;

    [Header("Animations")]
    public Animator enemyanim;
    private void OnDisable()
    {
        enemyanim.SetBool("Move",false);
        
    }


    private void Awake()
    {
        inscale = enemy.localScale;
        
    }
    private void MoveIndirection(int _direction)
    {
        idletimer = 0;
        enemyanim.SetBool("Move", true);
        //make enemyface direction
        enemy.localScale = new Vector3(Mathf.Abs(inscale.x) * _direction, inscale.y, inscale.z);
        //move in that direction
        enemy.position = new Vector3(enemy.position.x + Time.deltaTime * _direction * speed,enemy.position.y,enemy.position.z);


    }
    private void Update()
    {
        if (movingleft) {

            if (enemy.position.x >= leftedge.position.x) {
                MoveIndirection(-1); }
            else
            {
                chanceDirection();
                //chance direction
            }
            
        }
        else
        {
            if (enemy.position.x <= rightedge.position.x)
            {
                MoveIndirection(1);
            }
            else
            {
                chanceDirection();
                //chance direction

            }
        }

    }
    private void chanceDirection()
    {
        enemyanim.SetBool("Move", false);
        idletimer += Time.deltaTime;
        if(idletimer>idleDuration)
        movingleft = !movingleft;

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovment : MonoBehaviour
{

    [Header("Coyote Time")]
    public float coyoteTime;
    private float coyoteCounter;
    [Header("Multiple Jumps")]
    public int extrajumps;
    private int jumpCounter;

    [Header("Wall Jumping")]
    public float wallJumpX;
    public float wallJumpY;
   

    [Header("Voices")]
    public AudioSource jumpvoice;


    public Animator caracteranims;
    private Rigidbody2D body;
    private BoxCollider2D boxCollider;
    private float walljumpcooldown;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private LayerMask wallLayer;

    public float gravityScaler;
    private float horizontalInput;
    public float speed;
    public float jumppower;
    private void Awake()
    {
        //referanslarý almak için
        body = GetComponent<Rigidbody2D>();
        
        boxCollider = GetComponent<BoxCollider2D>();
        

    }
   
    private void Update()
    {
         horizontalInput = Input.GetAxis("Horizontal");
       
        //krakter sað-sol bakýþý
        if (horizontalInput > 0.01f)
        
            transform.localScale = new Vector3(3, 3, 1);
        
        else if (horizontalInput < -0.01f)
        
            transform.localScale = new Vector3(-3, 3, 1);
        caracteranims.SetBool("run", horizontalInput != 0);//float sýfýr omadýðýnda çalýþacak
        caracteranims.SetBool("grounded", isgrounded());





        //basic jump

        if (Input.GetKeyDown(KeyCode.Space))
        {
            jump();
            caracteranims.SetTrigger("jump");
        }
        // jump height
        if (Input.GetKeyUp(KeyCode.Space) && body.velocity.y > 0)
            body.velocity = new Vector2(body.velocity.x, body.velocity.y / 2);
        if (onWall())
        {
            body.gravityScale = 0;
            body.velocity = Vector2.zero;
        }
        else
        {
            body.gravityScale = gravityScaler;
            body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);
            if (isgrounded())
            {
                coyoteCounter = coyoteTime;//reset coyeter counter
                jumpCounter = extrajumps; //reseting extra jump mekanics 
            }
            else
                coyoteCounter -= Time.deltaTime;
        }
   

}

private void jump()
    {
        if (coyoteCounter <= 0 && !onWall()&&jumpCounter<=0) return;
        jumpvoice.Play();


        if (onWall())
        {
            wallJump();
            caracteranims.Play("wallhold");
        }
        else
        {
            if (isgrounded())
                body.velocity = new Vector2(body.velocity.x, jumppower);
            else
            {
                //if not on the gorund and coyote bigger than 0 do normal jump
                if (coyoteCounter > 0)
                    body.velocity = new Vector2(body.velocity.x, jumppower);
                else
                {
                    if (jumpCounter > 0)
                    {
                        body.velocity = new Vector2(body.velocity.x, jumppower);
                        jumpCounter--;
                    }
                }
            }
            coyoteCounter = 0;
        }

    }
    private void wallJump()
    {
        body.AddForce(new Vector2(-Mathf.Sign(transform.localScale.x) * wallJumpX, wallJumpY));
        walljumpcooldown = 0;
        

    }
    //yere deðip deðmemsini
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if (collision.gameObject.tag == "Wall")
             
       
    }
    private bool isgrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down, 0.1f, groundLayer);
        return raycastHit.collider != null;

    }
    private bool onWall()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0,new Vector2(transform.localScale.x,0), 0.1f, wallLayer);
        return raycastHit.collider != null;

    }
    public bool iscanAttack()
    {
        return horizontalInput == 0 && isgrounded() && !onWall();

    }
}

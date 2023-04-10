 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    private Animator animator;
    public float Speed;
    public float JumpForce;
    private Rigidbody2D rb;
    //SpriteRenderer sr;
    private float Horizontal;
    private bool Grounded;
    //private int currentAnimation=1;
    // Start is called before the first frame update

    void Start()
    {
        animator =GetComponent<Animator>();
        rb=GetComponent<Rigidbody2D>();
        //sr=GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Horizontal = Input.GetAxisRaw("Horizontal");
        if(Horizontal<0.0f)transform.localScale=new Vector3(-0.15f, 0.15f, 1.0f);
        else if(Horizontal>0.0f)transform.localScale=new Vector3(0.15f,0.15f,1.0f);
        animator.SetBool("running",Horizontal != 0.0f);
        Debug.DrawRay(transform.position,Vector3.down * 0.1f, Color.red);
        if(Physics2D.Raycast(transform.position, Vector3.down, 0.1f)){
            Grounded=true;
        }
        else Grounded=false;
        if(Input.GetKeyDown(KeyCode.W) && Grounded){
            Jump();
        }

        
    }
    private void Jump(){
        rb.AddForce(Vector2.up*JumpForce);
    }
    private void FixedUpdate(){
        rb.velocity = new Vector2(Horizontal,rb.velocity.y); 
    }
}
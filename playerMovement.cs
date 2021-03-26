using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerMovement : MonoBehaviour
{
    public static playerMovement instance ;
    private Rigidbody2D target;
    public float runSpeed;
    public float jumpForce = 250f;
    private BoxCollider2D boxcollider2D;
    [SerializeField]
    public LayerMask platformlayerMask;

    //[Header("hpSystem")]
    public int Hp;
    public int totalHp;
    //public Sprite heartPic;
    //public Sprite emptyPic;
    //public Image image;
    //public Canvas canvas;

    void Start()
    {
        if(instance!=null && instance != this)
        {
            Destroy(gameObject);
            instance = this;
        }
        else
        {
            instance = this;
        }
        
        target = gameObject.GetComponent<Rigidbody2D>();
        boxcollider2D = target.GetComponent<BoxCollider2D>();
        //healthbar Healthbar = new healthbar(Hp, totalHp, heartPic, emptyPic, image, canvas);
        
    }

    
    public void walk()
    {
        target.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * runSpeed, target.velocity.y);
        if (Input.GetKeyDown(KeyCode.Space) && IsGround() == true)
        {
            target.AddForce(Vector2.up * jumpForce);
            //Debug.Log("jump");

        }
        if (target.velocity.y < 0f && IsGround() == false)
        {
            target.gravityScale = 1.5f;
            //Debug.Log("dropping");
        }
        else
        {
            target.gravityScale = 1f;
        }
        if (target.velocity.x < -0.1f)
        {
            target.transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else if (target.velocity.x > 0.1f)
        {
            target.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else
        {
            target.transform.rotation = target.transform.rotation;
        }
    }
    //public void FixedUpdate()
    //{
        
    //}
    public void Update()
    {
        walk();
        
        
    }
    public bool IsGround()
    {
        float extraHeight = 1f;

        RaycastHit2D raycastHit = Physics2D.BoxCast(boxcollider2D.bounds.center, boxcollider2D.bounds.size, 0f, Vector2.down, extraHeight, platformlayerMask);
        //Debug.Log(raycastHit.collider);
        return raycastHit.collider != null;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.transform.tag == "bullet")
        {
           Hp = Hp - 1;
            
        }
        //Debug.Log(collision.transform.tag);
    }

    //public void HpSystem()
    //{
    //    healthbar healthbar = new healthbar(Hp, totalHp);
    //}
    //public playerMovement(Rigidbody2D target,float runSpeed, BoxCollider2D boxcollider2D, LayerMask platformlayerMask)
    //{
    //    this.target = target;
    //    this.runSpeed = runSpeed;
    //    this.boxcollider2D = boxcollider2D;
    //    this.platformlayerMask = platformlayerMask;
    //}
}

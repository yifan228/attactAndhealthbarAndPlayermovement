using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIEnemy : MonoBehaviour
{
    private Rigidbody2D AIBody;
    //public Animation Anim;
    public SpriteRenderer spriteRenderer;

    [Header("layer")]
    public LayerMask PlayerLayer;
    [Space]
    [Header("Collider")]
    private Collider2D Collider2D;
    [SerializeField]
    private float collisionRad = 5f;
    [Header("speed")]
    public float speed;
    public float AttactForce;
    private int Face=-1;
    

    Vector2 raycastOrigin;
    Vector2 V0;
    public GameObject enemyBullet;

    private enemyShoot EnemyShoot = new enemyShoot();

    // Start is called before the first frame update
    void Start()
    {
        AIBody = GetComponent<Rigidbody2D>();
        //Anim = GetComponent<Animation>();
        Collider2D = GetComponent<Collider2D>();
    }
    private void FixedUpdate()
    {
        
        raycastOrigin = transform.position;
        Collider2D PlayerColl = isPlayerVeiw();
        AccordingDirectionFlip(PlayerColl);
        V0 = CalculateV0(PlayerColl);
        //Debug.Log(V0);
        
    }
    private void Update()
    {
        if (!double.IsNaN(V0.x) && !double.IsNaN(V0.y) && Input.GetKeyDown(KeyCode.F))
        {
            shoot(V0);
        }
    }
    // Update is called once per frame

    public Collider2D isPlayerVeiw()
    {
        
        return Physics2D.OverlapCircle(raycastOrigin, collisionRad, PlayerLayer);        
    }
    public void AccordingDirectionFlip(Collider2D playercoll)
    {
        if (playercoll != null)
        {
            int direction;
            if (playercoll.transform.position.x > transform.position.x)
            {
                direction = 1;
                
                
            }
            else
            {
                direction = -1;
                
                //Debug.Log("playerOnLeft");
            }
            //Debug.Log(direction);
            if(Face != direction)
            {
                flip();
            }
        }
    }
    public void flip()
    {
        if(Face == -1)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }      
        Face = Face * (-1);
        //Debug.Log("flip");
    }
    public Vector2 CalculateV0(Collider2D playercoll)
    {
        if (playercoll != null)
        {
            EnemyShoot.charactorPosition = playercoll.transform.position;
            EnemyShoot.enemyPosition = transform.position;
            EnemyShoot.enemyShootForce = AttactForce;
            
            return EnemyShoot.calcauLationV0(-Physics2D.gravity.y);
            
            
        }
        else
        {
            return Vector2.zero;
        }
    }
    public void shoot(Vector2 v0)
    {
        Vector2 po = transform.position;
        GameObject newBullet =  Instantiate(enemyBullet, po+new Vector2(0,1f), transform.rotation);
        newBullet.GetComponent<Rigidbody2D>().velocity = v0;
    }
    
    

    
    //void AssistLine()
    //{
    //    Gizmos.color = Color.red;
    //    Gizmos.DrawWireSphere(transform.position, collisionRad);

    //}
    
}

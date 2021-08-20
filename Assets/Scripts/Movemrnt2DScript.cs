using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Movemrnt2DScript : MonoBehaviour
{
    public Rigidbody2D RigidB;

    public Animator KingAnim;

    public LayerMask GroundL;

    public float RayCastL;

    private bool OnGround;

    public float MAcceler;

    public float TopSpeed;

    public float Drag;

    public float AirDrag;

    private float JForce = 30f;

    public float fallM = 5f;

    private float HDirection;

    private bool CDirect => (RigidB.velocity.x > 0f && HDirection < 0f) || (RigidB.velocity.x < 0f && HDirection > 0f);

    private float AnimConter;

    private float StepConter;

    public float CastCoolDown;

    public float DamgeCoolDown;

    private bool InDamgeCoolDown;

    private bool InDamgeCoolDown1;

    private bool InDamgeCoolDown2;

    private bool InDamgeCoolDown3;

    private bool InDamgeCoolDown4;

    public AudioClip jump;

    public AudioClip Cast;

    public AudioClip Step;

    public KeyCode MenuKey;

    public KeyCode ResetKey = KeyCode.R;

    AudioSource audioS;

    public float maxHealth = 100;
    public float currentHealth;

    public RectTransform healthBar;

    public Transform AttackTransform;

    public Transform PlayerTransform;

    public Animator AttackAnim;

    public float KillZone = -16;

    public float EndZone;

    public string NextScene;

    public float PVelocityX;

    public float PVelocityY;

    void Start()
    {
        audioS = GetComponent<AudioSource>();

        currentHealth = maxHealth;
    }

    void Update() 
    {

        PVelocityX = RigidB.velocity.x;

        PVelocityY = RigidB.velocity.y;

        OnGround = Physics2D.Raycast(transform.position * RayCastL,Vector3.down, RayCastL, GroundL);

        healthBar.sizeDelta = new Vector2(currentHealth,100);

        if(RigidB.velocity.y == 0)
        {
            OnGround = true;
        }

        if (Input.GetKeyDown(KeyCode.Space) && OnGround)
        {
            RigidB.velocity = new Vector2(RigidB.velocity.x , 0f);
            RigidB.AddForce(Vector2.up * JForce, ForceMode2D.Impulse);

            audioS.PlayOneShot(jump, 0.7F);
        }

        if (RigidB.velocity.y < 0)
        {
            RigidB.velocity += Vector2.up * Physics2D.gravity.y * (fallM - 1) * Time.deltaTime;
            KingAnim.SetBool("IntheAir",true);
        }
        if(OnGround)
        {
            KingAnim.SetBool("IntheAir",false);

            if (HDirection < 0f)
            {
                KingAnim.SetFloat("Movement",1);

                if (StepConter >= 20)
                {
                    audioS.PlayOneShot(Step, 0.7F);
                    StepConter = 0;
                }
                    
            }
            else if (HDirection > 0f)
            {
                KingAnim.SetFloat("Movement",1);

                if (StepConter >= 20)
                {
                    audioS.PlayOneShot(Step, 0.7F);
                    StepConter = 0;
                }
            }
            else
            {
                KingAnim.SetFloat("Movement",0);
            }
        }
        else
        {
            KingAnim.SetFloat("Movement",0);
        }
        if (HDirection < 0f)
        {
            Vector3 PScale = transform.localScale;
            PScale.x = -1;
            transform.localScale = PScale; 
        }
        else if (HDirection > 0f)
        {
            Vector3 PScale = transform.localScale;
            PScale.x = 1;
            transform.localScale = PScale;
        }
        if (Input.GetKeyDown(KeyCode.Mouse0) && OnGround && CastCoolDown >= 30)
        {
            if (RigidB.velocity.y <= 1 && RigidB.velocity.y >= -1 && RigidB.velocity.x <= 1 && RigidB.velocity.x >= -1)
            {
                RigidB.velocity = new Vector2(0,0);
                audioS.PlayOneShot(Cast, 0.7F);
                AnimConter = 0;
                KingAnim.SetBool("Casting",true);
                AttackAnim.SetBool("Casting",true);
                CastCoolDown = 0;
                AttackTransform.localScale = PlayerTransform.localScale;
                AttackTransform.position = PlayerTransform.position;
            }
               
            
        }
        if (Input.GetKey(MenuKey))
        {
            SceneManager.LoadScene("Menu");
        }
        if (Input.GetKey(ResetKey))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        if(currentHealth <= 10)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        if(RigidB.position.y <= KillZone)
        {
           currentHealth -= 100; 
        }
        if(RigidB.position.x >= EndZone)
        {
            SceneManager.LoadScene(NextScene);
        }

    }
    void FixedUpdate()
    {
        AnimConter += 1;
        StepConter += 1;
        CastCoolDown += 1;
        DamgeCoolDown += 1;

        HDirection = Input.GetAxisRaw("Horizontal");
        RigidB.AddForce(new Vector2(HDirection, 0f)* MAcceler);

        if (Mathf.Abs(RigidB.velocity.x)> TopSpeed)
        {
            RigidB.velocity = new Vector2(Mathf.Sign(RigidB.velocity.x) * TopSpeed, RigidB.velocity.y);
        }
        if (OnGround)
        {
            if (Mathf.Abs(HDirection) < 0.4f || CDirect)
            {
                RigidB.drag = Drag; 
            }
            else
            {
                RigidB.drag = 0.1f;
            }
        }
        else
        {
            RigidB.drag = AirDrag;
        }

        if (AnimConter == 12)
        {
            AttackAnim.SetBool("Casting",false);
            KingAnim.SetBool("Casting",false);
            AttackTransform.position = new Vector3(0,-16,0);
        }

        
        if (DamgeCoolDown >= 30)
        {
            if (InDamgeCoolDown == true)
            {
                currentHealth -= 10;
                DamgeCoolDown = 0;
            }
            else if (InDamgeCoolDown1 == true)
            {
                currentHealth -= 20;
                DamgeCoolDown = 0;  
            }
            else if (InDamgeCoolDown2 == true)
            {
                currentHealth -= 30;
                DamgeCoolDown = 0;
            }
            else if (InDamgeCoolDown3 == true)
            {
                currentHealth -= 35;
                DamgeCoolDown = 0;
            }
            else if (InDamgeCoolDown4 == true && DamgeCoolDown >= 60)
            {
                currentHealth -= 10;
                DamgeCoolDown = 0;
            }
        } 
         
    }
    private void OnCollisionEnter2D(Collision2D Collision) 
    {

        if (Collision.collider.tag == "Enemie")
        {
            InDamgeCoolDown = true;
        }
        if (Collision.collider.tag == "Enemie1")
        {
            InDamgeCoolDown1 = true;
        }
        if (Collision.collider.tag == "Enemie2")
        {
            InDamgeCoolDown2 = true;
        }
        if (Collision.collider.tag == "fireball")
        {
            InDamgeCoolDown3 = true;
        }
        if (Collision.collider.tag == "Boss")
        {
            InDamgeCoolDown4 = true;
        }

    }
    private void OnCollisionExit2D(Collision2D Collision) 
    {

        if (Collision.collider.tag == "Enemie")
        {
            InDamgeCoolDown = false;
        }
        if (Collision.collider.tag == "Enemie1")
        {
            InDamgeCoolDown1 = false;
        }
        if (Collision.collider.tag == "Enemie2")
        {
            InDamgeCoolDown2 = false;
        }
        if (Collision.collider.tag == "fireball")
        {
            InDamgeCoolDown3 = false;
        }
        if (Collision.collider.tag == "Boss")
        {
            InDamgeCoolDown4 = false;
        }
    }
    void OnDrawGizmos() 
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(transform.position, transform.position + Vector3.down * RayCastL);  
    }
}

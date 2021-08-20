using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemieControlScript : MonoBehaviour
{
    public bool EasyEnemie;

    public bool MediumEnemie;

    public bool HardEnemie;

    private bool EDerct;

    private Transform ETransform;

    public float EMoveRangeMax;

    public float EMoveRangeMin;

    private Vector3 NewPoss;
    
    private bool Attacked;

    public Animator EnemieAnim;

    public bool Charging;
    
    private bool Hit;

    public float RayCastLegth;

    public LayerMask PlayerLayer;

    public float RayCastNumber;

    private BoxCollider2D BoxColider;

    void Start()
    {
        ETransform = gameObject.GetComponent<Transform>();
        EnemieAnim = gameObject.GetComponent<Animator>();
        BoxColider = gameObject.GetComponent<BoxCollider2D>();

        EDerct = true;
        Charging = false;
    }

    void Update()
    {


        if (EasyEnemie == true)
        {
            if (Attacked == true)
            {
                Destroy(this.gameObject);
            }
            if (ETransform.position.x >= EMoveRangeMax)
            {
                EDerct = true;
                Vector3 EScale = ETransform.localScale;
                EScale.x = -1;
                ETransform.localScale = EScale;
            }

            if (EDerct)
            {   
                NewPoss = new Vector3(ETransform.position.x + -1f*Time.deltaTime,ETransform.position.y,20);
                ETransform.position = NewPoss;
            }

            if (ETransform.position.x <= -EMoveRangeMin)
            {
                EDerct = false;
                Vector3 EScale = ETransform.localScale;
                EScale.x = 1;
                ETransform.localScale = EScale; 
            }

            if (!EDerct)
            {
                NewPoss = new Vector3(ETransform.position.x + 1f*Time.deltaTime,ETransform.position.y,20);  
                ETransform.position = NewPoss;
            }
        }
        else if (MediumEnemie == true)
        {
        
        EnemieAnim.SetBool("Hit",Hit);

            if (Attacked == true)
            {
                Hit = true;
                StartCoroutine(KillEnemie());
            }
            
            if(Hit == false)
            {
                if (Charging == false)
                {
                    EnemieAnim.SetBool("Charging",false);
                    if (ETransform.position.x >= EMoveRangeMax)
                    {
                        EDerct = true;
                        Vector3 EScale = ETransform.localScale;
                        EScale.x = -1;
                        ETransform.localScale = EScale;
 
                        RaycastHit2D EyeRange = Physics2D.Raycast(ETransform.position , Vector2.left,RayCastNumber,PlayerLayer);

                        if(EyeRange.collider != null)
                        {
                            Charging = true;
                        }
                        else
                        {
                            Charging = false;
                        }

                    }

                    if (EDerct)
                    {   
                        NewPoss = new Vector3(ETransform.position.x + -1f*Time.deltaTime,ETransform.position.y,20);
                        ETransform.position = NewPoss;
                    }

                    if (ETransform.position.x <= -EMoveRangeMin)
                    {
                        EDerct = false;
                        Vector3 EScale = ETransform.localScale;
                        EScale.x = 1;
                        ETransform.localScale = EScale;

                        RaycastHit2D EyeRange = Physics2D.Raycast(ETransform.position , Vector2.right,RayCastNumber,PlayerLayer);

                        
                        if(EyeRange.collider != null)
                        {
                            Charging = true;
                        }
                        else
                        {
                            Charging = false;
                        }
 
                    }

                    if (!EDerct)
                    {
                        NewPoss = new Vector3(ETransform.position.x + 1f*Time.deltaTime,ETransform.position.y,20);  
                        ETransform.position = NewPoss;
                    }
                }
                else
                {
                    EnemieAnim.SetBool("Charging",true);
                    if (ETransform.position.x >= EMoveRangeMax)
                    {
                        EDerct = true;
                        Vector3 EScale = ETransform.localScale;
                        EScale.x = -1;
                        ETransform.localScale = EScale;
                        
                        RaycastHit2D EyeRange = Physics2D.Raycast(ETransform.position , Vector2.left,RayCastNumber,PlayerLayer);

                        
                        if(EyeRange.collider != null)
                        {
                            Charging = true;
                        }
                        else
                        {
                            Charging = false;
                        }

                    }

                    if (EDerct)
                    {   
                        NewPoss = new Vector3(ETransform.position.x + -3f*Time.deltaTime,ETransform.position.y,20);
                        ETransform.position = NewPoss;
                    }

                    if (ETransform.position.x <= -EMoveRangeMin)
                    {
                        EDerct = false;
                        Vector3 EScale = ETransform.localScale;
                        EScale.x = 1;
                        ETransform.localScale = EScale; 
                        
                        RaycastHit2D EyeRange = Physics2D.Raycast(ETransform.position , Vector2.right,RayCastNumber,PlayerLayer);

                        
                        if(EyeRange.collider != null)
                        {
                            Charging = true;
                        }
                        else
                        {
                            Charging = false;
                        }

                    }

                    if (!EDerct)
                    {
                        NewPoss = new Vector3(ETransform.position.x + 3f*Time.deltaTime,ETransform.position.y,20);  
                        ETransform.position = NewPoss;
                    }  
                }
            }    
        }
        else if (HardEnemie == true)
        {
            
            EnemieAnim.SetBool("Hit",Hit);

            if (Attacked == true)
            {
                Hit = true;
                StartCoroutine(KillEnemie());
            }
            
            if(Hit == false)
            {
                if (Charging == false)
                {
                    EnemieAnim.SetBool("Charging",false);
                    if (ETransform.position.x >= EMoveRangeMax)
                    {
                        EDerct = true;
                        Vector3 EScale = ETransform.localScale;
                        EScale.x = -1;
                        ETransform.localScale = EScale;

                        RaycastHit2D EyeRange = Physics2D.Raycast(ETransform.position , Vector2.left,RayCastNumber,PlayerLayer);

                        if(EyeRange.collider != null)
                        {
                            Charging = true;
                        }
                        else
                        {
                            Charging = false;
                        }

                    }

                    if (EDerct)
                    {   
                        NewPoss = new Vector3(ETransform.position.x + -2f*Time.deltaTime,ETransform.position.y,20);
                        ETransform.position = NewPoss;
                    }

                    if (ETransform.position.x <= -EMoveRangeMin)
                    {
                        EDerct = false;
                        Vector3 EScale = ETransform.localScale;
                        EScale.x = 1;
                        ETransform.localScale = EScale;

                        RaycastHit2D EyeRange = Physics2D.Raycast(ETransform.position , Vector2.right,RayCastNumber,PlayerLayer);

                        
                        if(EyeRange.collider != null)
                        {
                            Charging = true;
                        }
                        else
                        {
                            Charging = false;
                        }

                    }

                    if (!EDerct)
                    {
                        NewPoss = new Vector3(ETransform.position.x + 2f*Time.deltaTime,ETransform.position.y,20);  
                        ETransform.position = NewPoss;
                    }
                }
                else
                {
                    EnemieAnim.SetBool("Charging",true);
                    if (ETransform.position.x >= EMoveRangeMax)
                    {
                        EDerct = true;
                        Vector3 EScale = ETransform.localScale;
                        EScale.x = -1;
                        ETransform.localScale = EScale;
                        
                        RaycastHit2D EyeRange = Physics2D.Raycast(ETransform.position , Vector2.left,RayCastNumber,PlayerLayer);

                        
                        if(EyeRange.collider != null)
                        {
                            Charging = true;
                        }
                        else
                        {
                            Charging = false;
                        }

                    }

                    if (EDerct)
                    {   
                        NewPoss = new Vector3(ETransform.position.x + -5f*Time.deltaTime,ETransform.position.y,20);
                        ETransform.position = NewPoss;
                    }

                    if (ETransform.position.x <= -EMoveRangeMin)
                    {
                        EDerct = false;
                        Vector3 EScale = ETransform.localScale;
                        EScale.x = 1;
                        ETransform.localScale = EScale; 
                        
                        RaycastHit2D EyeRange = Physics2D.Raycast(ETransform.position , Vector2.right,RayCastNumber,PlayerLayer);

                        
                        if(EyeRange.collider != null)
                        {
                            Charging = true;
                        }
                        else
                        {
                            Charging = false;
                        }

                    }

                    if (!EDerct)
                    {
                        NewPoss = new Vector3(ETransform.position.x + 5f*Time.deltaTime,ETransform.position.y,20);  
                        ETransform.position = NewPoss;
                    }
                }  
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D Collision) 
    {

        if (Collision.collider.tag == "Attack")
        {
            Attacked = true;
        }

    }
    IEnumerator KillEnemie()
    {
        BoxColider.enabled = !enabled;
        EnemieAnim.SetBool("Charging",false);
        EnemieAnim.SetBool("Hit",true);
        yield return new WaitForSeconds(1);
        Destroy(this.gameObject); 
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossScript : MonoBehaviour
{
    private Transform Bosstransform;

    private Animator BossAnimator;

    public Animator BossbodyAnimator1;

    public Animator BossbodyAnimator2;

    public Animator BossbodyAnimator3;

    public Animator BossbodyAnimator4;

    public Animator BossbodyAnimator5;
    
    public bool isBossAtack = false;

    public bool isBossAtack2 = false;

    public bool isBossDead = false;

    public bool Bosstriger = false;

    private Vector3 NewBossPoss;

    private Vector3 NewBossPoss2;

    private Vector3 NewBossPoss3;

    public Transform fireball1T;

    public Transform fireball2T;

    public Transform fireball3T;

    public Transform PlayerTransform;

    private bool EDerct;

    private bool EDerct2;

    private bool EDerct3;

    public float BATimer;

    public float BA2Timer;

    public float MoveTimer;

    public float BossIvis = 200;

    public float BossHP = 3;

    private bool TimerReset = true;
    
    public bool isResting;

    public Transform AttackTransform;

    public RectTransform BossHeathBarRect;

    public RectTransform BossHeathBarRect1;

    public RectTransform BossHeathBarRect2;

    public RectTransform BossHeathBarRect3;

    void Start()
    {
        Bosstransform = GetComponent<Transform>();

        BossAnimator = GetComponent<Animator>();

        EDerct = true;
    }

    //Rylris, the Eternal One
    void Update()
    {  
        
        if(PlayerTransform.position.x >= 110)
        {
            Bosstriger = true;
        }
        if(PlayerTransform.position.x >= 113 && BATimer >= 4000 && Bosstransform.position.y <= -5.5f )
        {
            isBossAtack = true;
        }
        if(BA2Timer >= 1000 && Bosstransform.position.y >= -5.5f )
        {
            isBossAtack2 = true;
        }
        if(BossHP <= 0)
        {
            isBossDead = true;
        }
        if(BossIvis >= 200 && Bosstransform.position.y <= -5.5f && AttackTransform.position.x >= 117)
        {
            BossHP -= 1;
            BossIvis = 0;
        }
        if(Bosstriger == true)
        {
            
            BA2Timer += 1;
            BATimer += 1;
            MoveTimer += 1;
            BossIvis += 1;

            if(isBossDead == false)
            {
                BossHeathBarRect.anchoredPosition = new Vector2(-7,-10);
                switch(BossHP) 
                {
                case 0:
                    BossHeathBarRect3.anchoredPosition = new Vector2(-7,90);
                    break;
                case 1:
                    BossHeathBarRect2.anchoredPosition = new Vector2(-7,90);
                    break;
                case 2:
                    BossHeathBarRect1.anchoredPosition = new Vector2(-7,90);
                    break;
                case 3:

                    break;
                }
                if(isBossAtack == false)
                {
                    if(isBossAtack2 == false)
                    {
                        float posReset =  10 * Time.deltaTime;
                        Bosstransform.position = Vector3.MoveTowards(Bosstransform.position, new Vector3(122,Bosstransform.position.y,20) , posReset);
                        changeAnimA(false);
                        if(MoveTimer >= 500 && Bosstransform.position.y <= -5.88f)
                        {
                            isResting = true;
                            StartCoroutine(Bossrest());
                        }
                        if(isResting == false)
                        {
                            if (Bosstransform.position.y >= 1f)
                            {
                                EDerct = true;
                            }

                            if (EDerct)
                            {   
                                NewBossPoss = new Vector3(Bosstransform.position.x,Bosstransform.position.y + -1f*Time.deltaTime,20);
                                Bosstransform.position = NewBossPoss;
                            }

                            if (Bosstransform.position.y <= -6f)
                            {
                                EDerct = false;
                            }

                            if (!EDerct)
                            {
                                NewBossPoss = new Vector3(Bosstransform.position.x,Bosstransform.position.y + 1f*Time.deltaTime,20);  
                                Bosstransform.position = NewBossPoss;
                            } 
                        }
                    }
                    else
                    {
                        if(TimerReset == true)
                        {
                            BA2Timer = 0;
                            TimerReset = false;
                        }


                        if (Bosstransform.position.x <= 130f)
                        {
                            NewBossPoss3 = new Vector3(Bosstransform.position.x + 10f*Time.deltaTime,Bosstransform.position.y,20);
                            Bosstransform.position = NewBossPoss3;
                        }

                        if(BA2Timer >= 200)
                        {
                            fireball1T.position = new Vector3(102,11,20);

                            fireball2T.position = new Vector3(112,11,20);

                            fireball3T.position = new Vector3(122,11,20);
                        }

                        if (BA2Timer >= 400)
                        {
                            isBossAtack2 = false;
                            BA2Timer = 0;
                            TimerReset = true;  
                        } 
                    } 
                }
                else
                {   
                    changeAnimA(true);
                    if(TimerReset == true)
                    {
                        BATimer = 0;
                        TimerReset = false;
                    }
                    if(BATimer >= 200)
                    {
                        if (Bosstransform.position.x >= 121f)
                        {
                            EDerct2 = true;
                        }

                        if (EDerct2)
                        {   
                            NewBossPoss2 = new Vector3(Bosstransform.position.x + -10f*Time.deltaTime,Bosstransform.position.y,20);
                            Bosstransform.position = NewBossPoss2;
                        }

                        if (Bosstransform.position.x <= 117f)
                        {
                            EDerct2 = false;
                        }

                        if (!EDerct2)
                        {
                            NewBossPoss2 = new Vector3(Bosstransform.position.x + 3f*Time.deltaTime,Bosstransform.position.y,20);  
                            Bosstransform.position = NewBossPoss2;
                        }

                        if (Bosstransform.position.x >= 121f && BATimer >= 400)
                        {
                            isBossAtack = false;
                            BATimer = 0;
                            TimerReset = true;  
                        } 
                    }
                }
            }
            else
            {
                BossIvis = 0;
                StartCoroutine(Die());
            }
        }
    }

    void changeAnimA(bool Status)
    {
        BossAnimator.SetBool("Atacking",Status);

        BossbodyAnimator1.SetBool("Atacking",Status);

        BossbodyAnimator2.SetBool("Atacking",Status);

        BossbodyAnimator3.SetBool("Atacking",Status);

        BossbodyAnimator4.SetBool("Atacking",Status);

        BossbodyAnimator5.SetBool("Atacking",Status);
    }
    void changeAnimD(bool Status)
    {
        BossAnimator.SetBool("IsDead",Status);

        BossbodyAnimator1.SetBool("IsDead",Status);

        BossbodyAnimator2.SetBool("IsDead",Status);

        BossbodyAnimator3.SetBool("IsDead",Status);

        BossbodyAnimator4.SetBool("IsDead",Status);

        BossbodyAnimator5.SetBool("IsDead",Status);
    }
    IEnumerator Die()
    {
        changeAnimD(true);
        yield return new WaitForSeconds(1);
        BossHeathBarRect.anchoredPosition = new Vector2(-7,75);
        Bosstransform.position = new Vector3(122,-30,30);
    }
    IEnumerator Bossrest()
    {
        yield return new WaitForSeconds(10);
        MoveTimer = 0;
        isResting = false;
    }
}

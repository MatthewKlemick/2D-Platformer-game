using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    public bool BossEntryDoor;

    public Transform PTransform;

    public Transform DTransform;

    public Transform Bosstransform;

    public Camera BossRoomCamera;

    private bool BRCS;

    void Update()
    {
        if(BossEntryDoor == true)
        {
            if(PTransform.position.x >= 110)
            {
                DTransform.position = new Vector3(97.54f,-5.88f,20f);
                if(BRCS == false)
                {
                  BossRoomCamera.enabled = true;
                  BRCS = true;  
                } 
            }
        }
        else
        {
            if(Bosstransform.position.y == -30)
            {
                DTransform.position = new Vector3(96.48f,-23.73f,20f);
                BossRoomCamera.enabled = false;
            }
        }
    }
}

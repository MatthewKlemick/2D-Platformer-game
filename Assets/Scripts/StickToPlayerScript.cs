using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickToPlayerScript : MonoBehaviour
{
    public Transform RigPlayerSpot;

    public Transform RigPos;

    void FixedUpdate()
    {
       RigPos.position = RigPlayerSpot.position; 
    }
}

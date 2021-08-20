using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallScript : MonoBehaviour
{
    private Transform FireBalltransform;

    private float posMove;

    void Start()
    {
        FireBalltransform = GetComponent<Transform>();
    }

    void Update()
    {
        FireBalltransform.position =  Vector3.MoveTowards(FireBalltransform.position, new Vector3(FireBalltransform.position.x,-23,30) , 10 * Time.deltaTime);
    }
}

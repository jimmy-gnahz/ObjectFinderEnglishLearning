using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCasting : MonoBehaviour
{
    public static float DistFromTarget;
    public float ToTarget;
    public static string currentObjectTag;

    // Update is called once per frame
    void Update()
    {
        RaycastHit Hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out Hit))
        {
            ToTarget = Hit.distance;
            DistFromTarget = ToTarget;
            currentObjectTag = Hit.transform.tag;
        }
    }
}

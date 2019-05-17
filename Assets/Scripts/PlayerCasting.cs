using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCasting : MonoBehaviour
{
    public static float DistFromTarget;
    public float ToTarget;
    public static string currentObjectTag;
    public static Vector3 currentDirection;

    // Update is called once per frame
    void Update()
    {
        currentDirection = transform.TransformDirection(Vector3.forward);
        RaycastHit Hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out Hit))
        {
            ToTarget = Hit.distance;
            DistFromTarget = ToTarget;
            currentObjectTag = Hit.transform.tag;
        }
    }
}

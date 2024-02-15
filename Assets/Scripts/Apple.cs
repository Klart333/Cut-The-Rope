using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour
{
    public void AddRope(Rigidbody2D jointParent)
    {
        var joint = gameObject.AddComponent<HingeJoint2D>();
        joint.connectedBody = jointParent;
    }
}

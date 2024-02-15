using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rope : MonoBehaviour
{
    [SerializeField]
    private Apple apple;

    [SerializeField]
    private HingeJoint2D ropeJointPrefab;

    private void Start()
    {
        float dist = Vector3.Distance(transform.position, apple.transform.position);
        print(dist);
        int jointAmount = Mathf.RoundToInt(dist / transform.localScale.x);

        Vector2 dir = (apple.transform.position - transform.position).normalized;

        Rigidbody2D jointParent = GetComponent<Rigidbody2D>();
        for (int i = 0; i < jointAmount; i++)
        {
            Vector3 pos = (Vector2)transform.localPosition + dir * ((i + 1.0f) / jointAmount) * dist;
            print(pos);
            var joint = Instantiate(ropeJointPrefab, transform);
            joint.transform.position = pos;
            joint.connectedBody = jointParent;

            jointParent = joint.GetComponent<Rigidbody2D>();
        }

        apple.AddRope(jointParent);
    }
}

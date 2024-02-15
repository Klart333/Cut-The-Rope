using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutHandler : MonoBehaviour
{
    private Vector3 startCut;
    private Camera cam;

    private void Start()
    {
        cam = Camera.main;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            startCut = cam.ScreenToWorldPoint(Input.mousePosition);
            print("Start Cut: " + startCut);
        }

        if (Input.GetMouseButtonUp(0))
        {
            Cut(startCut, cam.ScreenToWorldPoint(Input.mousePosition));
        }
    }

    private void Cut(Vector3 startPosition, Vector3 endPosition)
    {
        print("Cutting from " + startPosition + " to " + endPosition);

        var hit = Physics2D.Raycast(startPosition, endPosition - startPosition);

        if (hit.collider.gameObject.TryGetComponent(out HingeJoint2D joint))
        {
            joint.breakForce = 0;
            joint.transform.parent.GetChild(joint.transform.parent.childCount - 1).GetComponent<HingeJoint2D>().breakForce = 0;
        }
    }
}

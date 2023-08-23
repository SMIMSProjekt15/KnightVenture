using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistonScript : MonoBehaviour
{

    public float initialDelay;
    public float expansionSpeed = 2;
    public float contractSpeed = 5;
    public float delayExpanded = 5;
    public float delayContracted = 5;
    private float delay;
    private bool expanding = true;
    private float minZ;
    private float maxZ;
    private Transform headTransform;
    private Rigidbody rb;
    
    void Start()
    {
        delay = initialDelay;
        rb = GetComponentInChildren<Rigidbody>();
        headTransform = transform.Find("Head");
        minZ = headTransform.localPosition.z;
        maxZ = headTransform.Find("Tail").lossyScale.z + minZ;
        print(minZ);
        print(maxZ);
    }

    void FixedUpdate()
    {
        if(delay > 0)
        {
            delay -= Time.deltaTime;
            return;
        }

        Vector3 position;
        if (expanding)
        {
            position = headTransform.localPosition + Vector3.forward * expansionSpeed * Time.deltaTime;
            position = headTransform.TransformDirection(position);
            rb.MovePosition(position);
            if(headTransform.localPosition.z >= maxZ)
            {
                headTransform.localPosition = new Vector3(0, 0, maxZ);
                delay = delayExpanded;
                expanding = false;
            }
            return;
        }

        position = headTransform.localPosition + Vector3.back * expansionSpeed * Time.deltaTime;
        position = headTransform.TransformDirection(position);
        rb.MovePosition(position);
        if (headTransform.localPosition.z <= minZ)
        {
            headTransform.localPosition = new Vector3(0, 0, minZ);
            delay = delayContracted;
            expanding = true;
        }
    }
}

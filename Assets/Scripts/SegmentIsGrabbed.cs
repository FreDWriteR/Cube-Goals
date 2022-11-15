using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SegmentIsGrabbed : MonoBehaviour
{
    // Start is called before the first frame update
    public bool _segmentIsgrabbed = false, isSticked = false, isTriggered = false;
    public float Cathetus, halfCathetus, SizeX, Slice, halfSlice;
    public Color ColorSegment;

    void Start()
    {
        SizeX = gameObject.GetComponent<MeshRenderer>().bounds.size.x;
        Cathetus = (float)Math.Sqrt(Math.Pow(gameObject.GetComponent<MeshRenderer>().bounds.size.x, 2) / 2f);
        halfCathetus = (float)Math.Sqrt(Math.Pow(gameObject.GetComponent<MeshRenderer>().bounds.size.x / 2f, 2) / 2f);
        Slice = Cathetus - SizeX / 2f;
        halfSlice = SizeX / 2f - halfCathetus;
        ColorSegment = gameObject.GetComponent<MeshRenderer>().material.color;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

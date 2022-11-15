using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColorGrab : MonoBehaviour
{
    // Start is called before the first frame update

    private void OnTriggerStay(Collider other)
    {
        gameObject.GetComponent<MeshRenderer>().material.SetColor("_Color", new Color(0.6f, 0.6f, 0.6f));
        if (other.name.Length >= 10 && other.name.Substring(0, 10) == "WaySegment")
        {
            other.GetComponent<MeshRenderer>().material.SetColor("_Color", new Color(0.6f, 0.6f, 0.6f));
        }
    }

    private void OnTriggerExit(Collider other)
    {
        gameObject.GetComponent<MeshRenderer>().material.SetColor("_Color", new Color(0f, 0f, 0f));
        if (other.name.Length >= 10 && other.name.Substring(0, 10) == "WaySegment")
        {
            other.GetComponent<MeshRenderer>().material.color = other.gameObject.GetComponent<SegmentIsGrabbed>().ColorSegment;
        }
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

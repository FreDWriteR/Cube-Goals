using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColorStick : MonoBehaviour
{
    // Start is called before the first frame update

    private void OnTriggerStay(Collider other)
    {
        if (gameObject.name == "front" && other != null && other.name == "back" ||
            gameObject.name == "back" && other != null && other.name == "front" ||
            gameObject.name == "back" && other != null && other.name == "Start1" ||
            gameObject.name == "back" && other != null && other.name == "Start2" ||
            gameObject.name == "back" && other != null && other.name == "Start3" ||
            gameObject.name == "back" && other != null && other.name == "Start4" ||
            gameObject.name == "back" && other != null && other.name == "Start5"
            )
        {
            if (other.gameObject.name.Length < 6 && !gameObject.transform.parent.GetComponent<SegmentIsGrabbed>()._segmentIsgrabbed)
            {
                gameObject.transform.parent.GetComponent<MeshRenderer>().material.SetColor("_Color", new Color(0.5647059f, 0.9333333f, 0.5647059f));
            }
            if (other.gameObject.name.Length < 6 && !other.gameObject.transform.parent.GetComponent<SegmentIsGrabbed>()._segmentIsgrabbed)
            {
                other.gameObject.transform.parent.GetComponent<MeshRenderer>().material.SetColor("_Color", new Color(0.5647059f, 0.9333333f, 0.5647059f));
            }
            if (other.gameObject.name.Length == 6 && other.gameObject.name.Substring(0, 5) == "Start")
            {
                other.gameObject.transform.parent.GetComponent<MeshRenderer>().material.SetColor("_Color", new Color(0.5647059f, 0.9333333f, 0.5647059f));
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (gameObject.name == "front" && other != null && other.name == "back" ||
            gameObject.name == "back" && other != null && other.name == "front" ||
            gameObject.name == "back" && other != null && other.name == "Start1" ||
            gameObject.name == "back" && other != null && other.name == "Start2" ||
            gameObject.name == "back" && other != null && other.name == "Start3" ||
            gameObject.name == "back" && other != null && other.name == "Start4" ||
            gameObject.name == "back" && other != null && other.name == "Start5")
        {
            gameObject.transform.parent.GetComponent<MeshRenderer>().material.SetColor("_Color", gameObject.transform.parent.GetComponent<SegmentIsGrabbed>().ColorSegment);
            other.gameObject.transform.parent.GetComponent<MeshRenderer>().material.SetColor("_Color", gameObject.transform.parent.GetComponent<SegmentIsGrabbed>().ColorSegment);
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

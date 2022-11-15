using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class GrabMoveSegment : MonoBehaviour
{
    // Start is called before the first frame update

    Vector3 TempPos;
    string nameGrabbedSegment;
    IEnumerator coroutine;
    private bool isGrabbed = false;
    public GameObject Obj1, Obj2;

    void SetPositionSegment(Collider other)
    {
        TempPos = gameObject.transform.position;
        TempPos.y -= gameObject.GetComponent<MeshRenderer>().bounds.size.x / 2f - other.gameObject.GetComponent<MeshRenderer>().bounds.size.y / 2f;
        other.transform.position = TempPos;
    }

    void SetTriggers(Collider other)
    {
        var WaySegments = GameObject.FindGameObjectsWithTag("WaySegment");
        foreach(var WaySegment in WaySegments)
        {
            if (WaySegment.name == other.name)
            {
                WaySegment.transform.GetChild(0).GetComponent<SphereCollider>().isTrigger = true;
                WaySegment.transform.GetChild(1).GetComponent<SphereCollider>().isTrigger = true;
            }
            else 
            {
                WaySegment.transform.GetChild(0).GetComponent<SphereCollider>().isTrigger = false;
                WaySegment.transform.GetChild(1).GetComponent<SphereCollider>().isTrigger = false;
            }
        }
    }

    private void _GrabSegment(Collider other)
    {
        if (Input.GetKey(KeyCode.G) && !isGrabbed && other.name.Length >= 10 && other.name.Substring(0, 10) == "WaySegment")
        {
            if (Vector2.Distance(new Vector2(Obj1.transform.position.x, Obj1.transform.position.z),
                                 new Vector2(other.gameObject.transform.Find("front").transform.position.x, other.gameObject.transform.Find("front").transform.position.z)) > 0.001f &&
                Vector2.Distance(new Vector2(Obj2.transform.position.x, Obj2.transform.position.z),
                                 new Vector2(other.gameObject.transform.Find("front").transform.position.x, other.gameObject.transform.Find("front").transform.position.z)) > 0.001f)
            {
                other.gameObject.transform.GetChild(0).GetComponent<ConnectionSegments>().Unstick();
                SetTriggers(other);
                SetPositionSegment(other);
                nameGrabbedSegment = other.name;
                other.gameObject.GetComponent<SegmentIsGrabbed>()._segmentIsgrabbed = true;
                isGrabbed = true;
            }
        }
    }

    private void  MovingSegment(Collider other)
    {
        if (isGrabbed && nameGrabbedSegment == other.name && !other.gameObject.GetComponent<SegmentIsGrabbed>().isSticked)
        {
            SetPositionSegment(other);
        }
    }

    public void ReleaseSegment(Collider other)
    {
        if (other.name.Length >= 10 && other.name.Substring(0, 10) == "WaySegment" && isGrabbed && other.gameObject.GetComponent<SegmentIsGrabbed>()._segmentIsgrabbed)
        {
            if (other.gameObject.GetComponent<SegmentIsGrabbed>().isSticked || !other.gameObject.GetComponent<SegmentIsGrabbed>().isTriggered)
            {
                isGrabbed = false;
                other.gameObject.GetComponent<SegmentIsGrabbed>()._segmentIsgrabbed = false;
                other.gameObject.transform.GetChild(0).GetComponent<SphereCollider>().isTrigger = false;
                other.gameObject.transform.GetChild(1).GetComponent<SphereCollider>().isTrigger = false;
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        _GrabSegment(other);
        if (Input.GetKey(KeyCode.R) && other.name.Length >= 10 && other.name.Substring(0, 10) == "WaySegment" && !other.gameObject.GetComponent<SegmentIsGrabbed>().isTriggered)
            ReleaseSegment(other);
        MovingSegment(other);
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class RotateSegment : MonoBehaviour
{
    Vector3 TempEuler;
    Quaternion TempQuat;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            if (gameObject.GetComponent<SegmentIsGrabbed>()._segmentIsgrabbed && !gameObject.GetComponent<SegmentIsGrabbed>().isSticked)
            {
                TempEuler = gameObject.transform.rotation.eulerAngles;
                TempEuler.y += 45f;
                TempEuler.y = (float)Math.Round(Convert.ToDouble(TempEuler.y));
                TempQuat.eulerAngles = TempEuler;
                gameObject.transform.rotation = TempQuat;

                TempEuler = gameObject.transform.rotation.eulerAngles;
                TempEuler.y = (float)Math.Round(Convert.ToDouble(TempEuler.y));
                TempQuat.eulerAngles = TempEuler;
                gameObject.transform.rotation = TempQuat;
            }
            
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            if (gameObject.GetComponent<SegmentIsGrabbed>()._segmentIsgrabbed && !gameObject.GetComponent<SegmentIsGrabbed>().isSticked)
            {
                TempEuler = gameObject.transform.rotation.eulerAngles;
                TempEuler.y -= 45f;
                TempEuler.y = (float)Math.Round(Convert.ToDouble(TempEuler.y));
                TempQuat.eulerAngles = TempEuler;
                gameObject.transform.rotation = TempQuat;

                TempEuler = gameObject.transform.rotation.eulerAngles;
                TempEuler.y = (float)Math.Round(Convert.ToDouble(TempEuler.y));
                TempQuat.eulerAngles = TempEuler;
                gameObject.transform.rotation = TempQuat;

            }
        }
    }
}

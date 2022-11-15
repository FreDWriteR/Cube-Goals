using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ConnectionSegments : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Grabber;
    void Start()
    {
        
    }

    public void Unstick()
    {
        if (gameObject.transform.parent.GetComponent<SegmentIsGrabbed>().isSticked)
        {
            gameObject.transform.parent.GetComponent<SegmentIsGrabbed>().isSticked = false;
        }
    }

    void SetStartPosition(Collider other, Vector3 EulersGO)
    {
        if (other != null)
        {
            if (gameObject.name == "back" && other.gameObject.name == "Start1" && EulersGO == new Vector3(0f, 0f, 0f))
            {
                var TempPos = other.gameObject.transform.position;
                TempPos.z += gameObject.transform.parent.gameObject.GetComponent<MeshRenderer>().bounds.size.z / 2f;
                gameObject.transform.parent.gameObject.transform.position = TempPos;
                gameObject.transform.parent.GetComponent<SegmentIsGrabbed>().isSticked = true;
                gameObject.transform.parent.GetChild(0).GetComponent<SphereCollider>().isTrigger = false;
                gameObject.transform.parent.GetChild(1).GetComponent<SphereCollider>().isTrigger = false;
            }
            if (gameObject.name == "back" && other.gameObject.name == "Start2" && EulersGO == new Vector3(0f, 45f, 0f))
            {
                var TempPos = other.gameObject.transform.position;
                TempPos.z += gameObject.transform.parent.gameObject.GetComponent<MeshRenderer>().bounds.size.z / 2f;
                TempPos.x += gameObject.transform.parent.gameObject.GetComponent<MeshRenderer>().bounds.size.x / 2f;
                TempPos.z -= gameObject.transform.parent.GetComponent<SegmentIsGrabbed>().Cathetus / 2f;
                TempPos.x -= gameObject.transform.parent.GetComponent<SegmentIsGrabbed>().Cathetus / 2f;
                gameObject.transform.parent.gameObject.transform.position = TempPos;
                gameObject.transform.parent.GetComponent<SegmentIsGrabbed>().isSticked = true;
                gameObject.transform.parent.GetChild(0).GetComponent<SphereCollider>().isTrigger = false;
                gameObject.transform.parent.GetChild(1).GetComponent<SphereCollider>().isTrigger = false;
            }
            if (gameObject.name == "back" && other.gameObject.name == "Start3" && EulersGO == new Vector3(0f, 315f, 0f))
            {
                var TempPos = other.gameObject.transform.position;
                TempPos.z += gameObject.transform.parent.gameObject.GetComponent<MeshRenderer>().bounds.size.z / 2f;
                TempPos.x -= gameObject.transform.parent.gameObject.GetComponent<MeshRenderer>().bounds.size.x / 2f;
                TempPos.z -= gameObject.transform.parent.GetComponent<SegmentIsGrabbed>().Cathetus / 2f;
                TempPos.x += gameObject.transform.parent.GetComponent<SegmentIsGrabbed>().Cathetus / 2f;
                gameObject.transform.parent.gameObject.transform.position = TempPos;
                gameObject.transform.parent.GetComponent<SegmentIsGrabbed>().isSticked = true;
                gameObject.transform.parent.GetChild(0).GetComponent<SphereCollider>().isTrigger = false;
                gameObject.transform.parent.GetChild(1).GetComponent<SphereCollider>().isTrigger = false;
            }
            if (gameObject.name == "back" && other.gameObject.name == "Start4" && EulersGO == new Vector3(0f, 270f, 0f))
            {
                var TempPos = other.gameObject.transform.position;
                TempPos.x -= gameObject.transform.parent.gameObject.GetComponent<MeshRenderer>().bounds.size.x / 2f;
                gameObject.transform.parent.gameObject.transform.position = TempPos;
                gameObject.transform.parent.GetComponent<SegmentIsGrabbed>().isSticked = true;
                gameObject.transform.parent.GetChild(0).GetComponent<SphereCollider>().isTrigger = false;
                gameObject.transform.parent.GetChild(1).GetComponent<SphereCollider>().isTrigger = false;
            }
            if (gameObject.name == "back" && other.gameObject.name == "Start5" && EulersGO == new Vector3(0f, 90f, 0f))
            {
                var TempPos = other.gameObject.transform.position;
                TempPos.x += gameObject.transform.parent.gameObject.GetComponent<MeshRenderer>().bounds.size.x / 2f;
                gameObject.transform.parent.gameObject.transform.position = TempPos;
                gameObject.transform.parent.GetComponent<SegmentIsGrabbed>().isSticked = true;
                gameObject.transform.parent.GetChild(0).GetComponent<SphereCollider>().isTrigger = false;
                gameObject.transform.parent.GetChild(1).GetComponent<SphereCollider>().isTrigger = false;
            }
        }
    }

    void SetPositionSegment(Vector3 EulersGO, Vector3 EulersOther, float Sign, Collider other)
    {
        if (EulersGO == new Vector3(0f, 0f, 0f) && EulersOther == new Vector3(0f, 0f, 0f) ||
            EulersGO == new Vector3(0f, 45f, 0f) && EulersOther == new Vector3(0f, 315f, 0f) ||
            EulersGO == new Vector3(0f, 315f, 0f) && EulersOther == new Vector3(0f, 45f, 0f))
        {
            var TempPos = gameObject.transform.parent.gameObject.transform.position;
            TempPos.z = other.gameObject.transform.parent.gameObject.transform.position.z +
                        (other.gameObject.transform.parent.gameObject.GetComponent<MeshRenderer>().bounds.size.z / 2f) * Sign +
                        (gameObject.transform.parent.gameObject.GetComponent<MeshRenderer>().bounds.size.z / 2f) * Sign;
            TempPos.x = other.gameObject.transform.parent.gameObject.transform.position.x;
            TempPos.y = other.gameObject.transform.parent.gameObject.transform.position.y;
            gameObject.transform.parent.gameObject.transform.position = TempPos;
            gameObject.transform.parent.GetComponent<SegmentIsGrabbed>().isSticked = true;
            gameObject.transform.parent.GetChild(0).GetComponent<SphereCollider>().isTrigger = false;
            gameObject.transform.parent.GetChild(1).GetComponent<SphereCollider>().isTrigger = false;
        }
        if (EulersGO == new Vector3(0f, 45f, 0f) && EulersOther == new Vector3(0f, 0f, 0f))
        {
            var TempPos = gameObject.transform.parent.gameObject.transform.position;
            TempPos.z = other.gameObject.transform.parent.gameObject.transform.position.z +
                        (other.gameObject.transform.parent.gameObject.GetComponent<MeshRenderer>().bounds.size.z / 2f) * Sign +
                        (gameObject.transform.parent.gameObject.GetComponent<MeshRenderer>().bounds.size.z / 2f) * Sign;
            TempPos.x = other.gameObject.transform.parent.gameObject.transform.position.x + (gameObject.transform.parent.gameObject.GetComponent<MeshRenderer>().bounds.size.x / 2f) * Sign;
            TempPos.y = other.gameObject.transform.parent.gameObject.transform.position.y;
            TempPos.x -= (gameObject.transform.parent.GetComponent<SegmentIsGrabbed>().Cathetus - gameObject.transform.parent.GetComponent<SegmentIsGrabbed>().SizeX / 2f) * Sign;
            gameObject.transform.parent.gameObject.transform.position = TempPos;
            gameObject.transform.parent.GetComponent<SegmentIsGrabbed>().isSticked = true;
            gameObject.transform.parent.GetChild(0).GetComponent<SphereCollider>().isTrigger = false;
            gameObject.transform.parent.GetChild(1).GetComponent<SphereCollider>().isTrigger = false;
        }
        if (EulersGO == new Vector3(0f, 315f, 0f) && EulersOther == new Vector3(0f, 0f, 0f))
        {
            var TempPos = gameObject.transform.parent.gameObject.transform.position;
            TempPos.z = other.gameObject.transform.parent.gameObject.transform.position.z +
                        (other.gameObject.transform.parent.gameObject.GetComponent<MeshRenderer>().bounds.size.z / 2f) * Sign +
                        (gameObject.transform.parent.gameObject.GetComponent<MeshRenderer>().bounds.size.z / 2f) * Sign;
            TempPos.x = other.gameObject.transform.parent.gameObject.transform.position.x - (gameObject.transform.parent.gameObject.GetComponent<MeshRenderer>().bounds.size.x / 2f) * Sign;
            TempPos.y = other.gameObject.transform.parent.gameObject.transform.position.y;
            TempPos.x += (gameObject.transform.parent.GetComponent<SegmentIsGrabbed>().Cathetus - gameObject.transform.parent.GetComponent<SegmentIsGrabbed>().SizeX / 2f) * Sign;
            gameObject.transform.parent.gameObject.transform.position = TempPos;
            gameObject.transform.parent.GetComponent<SegmentIsGrabbed>().isSticked = true;
            gameObject.transform.parent.GetChild(0).GetComponent<SphereCollider>().isTrigger = false;
            gameObject.transform.parent.GetChild(1).GetComponent<SphereCollider>().isTrigger = false;
        }
        if (EulersGO == new Vector3(0f, 90f, 0f) && EulersOther == new Vector3(0f, 0f, 0f))
        {
            var TempPos = gameObject.transform.parent.gameObject.transform.position;
            TempPos.z = other.gameObject.transform.parent.gameObject.transform.position.z +
                        (other.gameObject.transform.parent.gameObject.GetComponent<MeshRenderer>().bounds.size.z / 2f) * Sign +
                        (gameObject.transform.parent.gameObject.GetComponent<MeshRenderer>().bounds.size.z / 2f) * Sign;
            TempPos.x = other.gameObject.transform.parent.gameObject.transform.position.x + (gameObject.transform.parent.gameObject.GetComponent<MeshRenderer>().bounds.size.x / 2f) * Sign +
                        gameObject.transform.parent.GetComponent<SegmentIsGrabbed>().SizeX / 2f * Sign;
            TempPos.y = other.gameObject.transform.parent.gameObject.transform.position.y;
            gameObject.transform.parent.gameObject.transform.position = TempPos;
            gameObject.transform.parent.GetComponent<SegmentIsGrabbed>().isSticked = true;
            gameObject.transform.parent.GetChild(0).GetComponent<SphereCollider>().isTrigger = false;
            gameObject.transform.parent.GetChild(1).GetComponent<SphereCollider>().isTrigger = false;
        }
        if (EulersGO == new Vector3(0f, 270f, 0f) && EulersOther == new Vector3(0f, 0f, 0f))
        {
            var TempPos = gameObject.transform.parent.gameObject.transform.position;
            TempPos.z = other.gameObject.transform.parent.gameObject.transform.position.z +
                        (other.gameObject.transform.parent.gameObject.GetComponent<MeshRenderer>().bounds.size.z / 2f) * Sign +
                        (gameObject.transform.parent.gameObject.GetComponent<MeshRenderer>().bounds.size.z / 2f) * Sign;
            TempPos.x = other.gameObject.transform.parent.gameObject.transform.position.x - (gameObject.transform.parent.gameObject.GetComponent<MeshRenderer>().bounds.size.x / 2f) * Sign -
                        gameObject.transform.parent.GetComponent<SegmentIsGrabbed>().SizeX / 2f * Sign;
            TempPos.y = other.gameObject.transform.parent.gameObject.transform.position.y;
            gameObject.transform.parent.gameObject.transform.position = TempPos;
            gameObject.transform.parent.GetComponent<SegmentIsGrabbed>().isSticked = true;
            gameObject.transform.parent.GetChild(0).GetComponent<SphereCollider>().isTrigger = false;
            gameObject.transform.parent.GetChild(1).GetComponent<SphereCollider>().isTrigger = false;
        }
        if (EulersGO == new Vector3(0f, 0f, 0f) && EulersOther == new Vector3(0f, 45f, 0f))
        {
            var TempPos = other.gameObject.transform.parent.gameObject.transform.position;
            TempPos.z = other.gameObject.transform.parent.gameObject.transform.position.z +
                        (other.gameObject.transform.parent.gameObject.GetComponent<MeshRenderer>().bounds.size.z / 2f) * Sign +
                        (gameObject.transform.parent.gameObject.GetComponent<MeshRenderer>().bounds.size.z / 2f) * Sign;
            TempPos.x += (other.gameObject.transform.parent.gameObject.GetComponent<MeshRenderer>().bounds.size.x / 2f) * Sign;
            TempPos.y = other.gameObject.transform.parent.gameObject.transform.position.y;
            TempPos.x -= (gameObject.transform.parent.GetComponent<SegmentIsGrabbed>().Cathetus - gameObject.transform.parent.GetComponent<SegmentIsGrabbed>().SizeX / 2f) * Sign;
            gameObject.transform.parent.gameObject.transform.position = TempPos;
            gameObject.transform.parent.GetComponent<SegmentIsGrabbed>().isSticked = true;
            gameObject.transform.parent.GetChild(0).GetComponent<SphereCollider>().isTrigger = false;
            gameObject.transform.parent.GetChild(1).GetComponent<SphereCollider>().isTrigger = false;
        }
        if (EulersGO == new Vector3(0f, 0f, 0f) && EulersOther == new Vector3(0f, 315f, 0f))
        {
            var TempPos = other.gameObject.transform.parent.gameObject.transform.position;
            TempPos.z = other.gameObject.transform.parent.gameObject.transform.position.z +
                        (other.gameObject.transform.parent.gameObject.GetComponent<MeshRenderer>().bounds.size.z / 2f) * Sign +
                        (gameObject.transform.parent.gameObject.GetComponent<MeshRenderer>().bounds.size.z / 2f) * Sign;
            TempPos.x -= (other.gameObject.transform.parent.gameObject.GetComponent<MeshRenderer>().bounds.size.x / 2f) * Sign;
            TempPos.y = other.gameObject.transform.parent.gameObject.transform.position.y;
            TempPos.x += (gameObject.transform.parent.GetComponent<SegmentIsGrabbed>().Cathetus - gameObject.transform.parent.GetComponent<SegmentIsGrabbed>().SizeX / 2f) * Sign;
            gameObject.transform.parent.gameObject.transform.position = TempPos;
            gameObject.transform.parent.GetComponent<SegmentIsGrabbed>().isSticked = true;
            gameObject.transform.parent.GetChild(0).GetComponent<SphereCollider>().isTrigger = false;
            gameObject.transform.parent.GetChild(1).GetComponent<SphereCollider>().isTrigger = false;
        }
        if (EulersGO == new Vector3(0f, 0f, 0f) && EulersOther == new Vector3(0f, 90f, 0f))
        {
            var TempPos = other.gameObject.transform.parent.gameObject.transform.position;
            TempPos.z = other.gameObject.transform.parent.gameObject.transform.position.z +
                        (other.gameObject.transform.parent.gameObject.GetComponent<MeshRenderer>().bounds.size.z / 2f) * Sign +
                        (gameObject.transform.parent.gameObject.GetComponent<MeshRenderer>().bounds.size.z / 2f) * Sign;
            TempPos.x += (other.gameObject.transform.parent.gameObject.GetComponent<MeshRenderer>().bounds.size.x / 2f) * Sign +
                        gameObject.transform.parent.GetComponent<SegmentIsGrabbed>().SizeX / 2f * Sign;
            TempPos.y = other.gameObject.transform.parent.gameObject.transform.position.y;
            gameObject.transform.parent.gameObject.transform.position = TempPos;
            gameObject.transform.parent.GetComponent<SegmentIsGrabbed>().isSticked = true;
            gameObject.transform.parent.GetChild(0).GetComponent<SphereCollider>().isTrigger = false;
            gameObject.transform.parent.GetChild(1).GetComponent<SphereCollider>().isTrigger = false;
        }
        if (EulersGO == new Vector3(0f, 0f, 0f) && EulersOther == new Vector3(0f, 270f, 0f))
        {
            var TempPos = new Vector3(0f, 0f, 0f);
            TempPos = other.gameObject.transform.parent.gameObject.transform.position;
            TempPos.z = other.gameObject.transform.parent.gameObject.transform.position.z +
                        (other.gameObject.transform.parent.gameObject.GetComponent<MeshRenderer>().bounds.size.z / 2f) * Sign +
                        (gameObject.transform.parent.gameObject.GetComponent<MeshRenderer>().bounds.size.z / 2f) * Sign;
            TempPos.x -= (other.gameObject.transform.parent.gameObject.GetComponent<MeshRenderer>().bounds.size.x / 2f) * Sign +
                        gameObject.transform.parent.GetComponent<SegmentIsGrabbed>().SizeX / 2f * Sign;
            TempPos.y = other.gameObject.transform.parent.gameObject.transform.position.y;
            gameObject.transform.parent.gameObject.transform.position = TempPos;
            gameObject.transform.parent.GetComponent<SegmentIsGrabbed>().isSticked = true;
            gameObject.transform.parent.GetChild(0).GetComponent<SphereCollider>().isTrigger = false;
            gameObject.transform.parent.GetChild(1).GetComponent<SphereCollider>().isTrigger = false;
        }
        if (EulersGO == new Vector3(0f, 90f, 0f) && EulersOther == new Vector3(0f, 45f, 0f))
        {
            var TempPos = other.gameObject.transform.parent.gameObject.transform.position;
            TempPos.x = other.gameObject.transform.parent.gameObject.transform.position.x +
                        (other.gameObject.transform.parent.gameObject.GetComponent<MeshRenderer>().bounds.size.x / 2f) * Sign +
                        (gameObject.transform.parent.gameObject.GetComponent<MeshRenderer>().bounds.size.x / 2f) * Sign;
            TempPos.z += (other.gameObject.transform.parent.gameObject.GetComponent<MeshRenderer>().bounds.size.z / 2f) * Sign;
            TempPos.y = other.gameObject.transform.parent.gameObject.transform.position.y;
            TempPos.z -= (gameObject.transform.parent.GetComponent<SegmentIsGrabbed>().Cathetus - gameObject.transform.parent.GetComponent<SegmentIsGrabbed>().SizeX / 2f) * Sign;
            gameObject.transform.parent.gameObject.transform.position = TempPos;
            gameObject.transform.parent.GetComponent<SegmentIsGrabbed>().isSticked = true;
            gameObject.transform.parent.GetChild(0).GetComponent<SphereCollider>().isTrigger = false;
            gameObject.transform.parent.GetChild(1).GetComponent<SphereCollider>().isTrigger = false;
        }
        if (EulersGO == new Vector3(0f, 45f, 0f) && EulersOther == new Vector3(0f, 90f, 0f))
        {
            var TempPos = other.gameObject.transform.parent.gameObject.transform.position;
            TempPos.x = other.gameObject.transform.parent.gameObject.transform.position.x +
                        (other.gameObject.transform.parent.gameObject.GetComponent<MeshRenderer>().bounds.size.x / 2f) * Sign +
                        (gameObject.transform.parent.gameObject.GetComponent<MeshRenderer>().bounds.size.x / 2f) * Sign;
            TempPos.z = other.gameObject.transform.parent.gameObject.transform.position.z + (gameObject.transform.parent.gameObject.GetComponent<MeshRenderer>().bounds.size.z / 2f) * Sign;
            TempPos.y = other.gameObject.transform.parent.gameObject.transform.position.y;
            TempPos.z -= (gameObject.transform.parent.GetComponent<SegmentIsGrabbed>().Cathetus - gameObject.transform.parent.GetComponent<SegmentIsGrabbed>().SizeX / 2f) * Sign;
            gameObject.transform.parent.gameObject.transform.position = TempPos;
            gameObject.transform.parent.GetComponent<SegmentIsGrabbed>().isSticked = true;
            gameObject.transform.parent.GetChild(0).GetComponent<SphereCollider>().isTrigger = false;
            gameObject.transform.parent.GetChild(1).GetComponent<SphereCollider>().isTrigger = false;
        }
        if (EulersGO == new Vector3(0f, 270f, 0f) && EulersOther == new Vector3(0f, 315f, 0f))
        {
            var TempPos = other.gameObject.transform.parent.gameObject.transform.position;
            TempPos.x -= (other.gameObject.transform.parent.gameObject.GetComponent<MeshRenderer>().bounds.size.x / 2f) * Sign;
            TempPos.x -= (gameObject.transform.parent.gameObject.GetComponent<MeshRenderer>().bounds.size.x / 2f) * Sign;
            TempPos.z += (other.gameObject.transform.parent.gameObject.GetComponent<MeshRenderer>().bounds.size.z / 2f) * Sign;
            TempPos.z -= (gameObject.transform.parent.GetComponent<SegmentIsGrabbed>().Cathetus - gameObject.transform.parent.GetComponent<SegmentIsGrabbed>().SizeX / 2f) * Sign;
            gameObject.transform.parent.gameObject.transform.position = TempPos;
            gameObject.transform.parent.GetComponent<SegmentIsGrabbed>().isSticked = true;
            gameObject.transform.parent.GetChild(0).GetComponent<SphereCollider>().isTrigger = false;
            gameObject.transform.parent.GetChild(1).GetComponent<SphereCollider>().isTrigger = false;
        }
        if (EulersGO == new Vector3(0f, 315f, 0f) && EulersOther == new Vector3(0f, 270f, 0f))
        {
            var TempPos = other.gameObject.transform.parent.gameObject.transform.position;
            TempPos.x -= (other.gameObject.transform.parent.gameObject.GetComponent<MeshRenderer>().bounds.size.x / 2f) * Sign;
            TempPos.x -= (gameObject.transform.parent.gameObject.GetComponent<MeshRenderer>().bounds.size.x / 2f) * Sign;
            TempPos.z += (gameObject.transform.parent.gameObject.GetComponent<MeshRenderer>().bounds.size.z / 2f) * Sign;
            TempPos.z -= (gameObject.transform.parent.GetComponent<SegmentIsGrabbed>().Cathetus - gameObject.transform.parent.GetComponent<SegmentIsGrabbed>().SizeX / 2f) * Sign;
            gameObject.transform.parent.gameObject.transform.position = TempPos;
            gameObject.transform.parent.GetComponent<SegmentIsGrabbed>().isSticked = true;
            gameObject.transform.parent.GetChild(0).GetComponent<SphereCollider>().isTrigger = false;
            gameObject.transform.parent.GetChild(1).GetComponent<SphereCollider>().isTrigger = false;
        }
        if (EulersGO == new Vector3(0f, 90f, 0f) && EulersOther == new Vector3(0f, 90f, 0f))
        {
            var TempPos = other.gameObject.transform.parent.gameObject.transform.position;
            TempPos.x += (other.gameObject.transform.parent.gameObject.GetComponent<MeshRenderer>().bounds.size.x / 2f) * Sign;
            TempPos.x += (gameObject.transform.parent.gameObject.GetComponent<MeshRenderer>().bounds.size.x / 2f) * Sign;
            gameObject.transform.parent.gameObject.transform.position = TempPos;
            gameObject.transform.parent.GetComponent<SegmentIsGrabbed>().isSticked = true;
            gameObject.transform.parent.GetChild(0).GetComponent<SphereCollider>().isTrigger = false;
            gameObject.transform.parent.GetChild(1).GetComponent<SphereCollider>().isTrigger = false;
        }
        if (EulersGO == new Vector3(0f, 270f, 0f) && EulersOther == new Vector3(0f, 270f, 0f))
        {
            var TempPos = other.gameObject.transform.parent.gameObject.transform.position;
            TempPos.x -= (other.gameObject.transform.parent.gameObject.GetComponent<MeshRenderer>().bounds.size.x / 2f) * Sign;
            TempPos.x -= (gameObject.transform.parent.gameObject.GetComponent<MeshRenderer>().bounds.size.x / 2f) * Sign;
            TempPos.z -= (other.gameObject.transform.parent.gameObject.GetComponent<MeshRenderer>().bounds.size.x / 2f) * Sign;
            TempPos.z -= (gameObject.transform.parent.gameObject.GetComponent<MeshRenderer>().bounds.size.x / 2f) * Sign;
            gameObject.transform.parent.gameObject.transform.position = TempPos;
            gameObject.transform.parent.GetComponent<SegmentIsGrabbed>().isSticked = true;
            gameObject.transform.parent.GetChild(0).GetComponent<SphereCollider>().isTrigger = false;
            gameObject.transform.parent.GetChild(1).GetComponent<SphereCollider>().isTrigger = false;
        }
        if (EulersGO == new Vector3(0f, 45f, 0f) && EulersOther == new Vector3(0f, 45f, 0f))
        {
            var TempPos = other.gameObject.transform.parent.gameObject.transform.position;
            TempPos.z += (other.gameObject.transform.parent.gameObject.GetComponent<MeshRenderer>().bounds.size.x / 2f) * Sign;
            TempPos.z += (gameObject.transform.parent.gameObject.GetComponent<MeshRenderer>().bounds.size.x / 2f) * Sign;
            TempPos.x += (other.gameObject.transform.parent.gameObject.GetComponent<MeshRenderer>().bounds.size.x) * Sign;
            TempPos.x -= gameObject.transform.parent.GetComponent<SegmentIsGrabbed>().Cathetus * Sign;
            TempPos.z -= gameObject.transform.parent.GetComponent<SegmentIsGrabbed>().Cathetus * Sign;
            gameObject.transform.parent.gameObject.transform.position = TempPos;
            gameObject.transform.parent.GetComponent<SegmentIsGrabbed>().isSticked = true;
            gameObject.transform.parent.GetChild(0).GetComponent<SphereCollider>().isTrigger = false;
            gameObject.transform.parent.GetChild(1).GetComponent<SphereCollider>().isTrigger = false;
        }
        if (EulersGO == new Vector3(0f, 315f, 0f) && EulersOther == new Vector3(0f, 315f, 0f))
        {
            var TempPos = other.gameObject.transform.parent.gameObject.transform.position;
            TempPos.z += (other.gameObject.transform.parent.gameObject.GetComponent<MeshRenderer>().bounds.size.x / 2f) * Sign;
            TempPos.z += (gameObject.transform.parent.gameObject.GetComponent<MeshRenderer>().bounds.size.x / 2f) * Sign;
            TempPos.x -= (other.gameObject.transform.parent.gameObject.GetComponent<MeshRenderer>().bounds.size.x) * Sign;
            TempPos.x += gameObject.transform.parent.GetComponent<SegmentIsGrabbed>().Cathetus * Sign;
            TempPos.z -= gameObject.transform.parent.GetComponent<SegmentIsGrabbed>().Cathetus * Sign;
            gameObject.transform.parent.gameObject.transform.position = TempPos;
            gameObject.transform.parent.GetComponent<SegmentIsGrabbed>().isSticked = true;
            gameObject.transform.parent.GetChild(0).GetComponent<SphereCollider>().isTrigger = false;
            gameObject.transform.parent.GetChild(1).GetComponent<SphereCollider>().isTrigger = false;
        }
    }

    void Stick(SphereCollider other)
    {
        if (Input.GetKey(KeyCode.R)) {
            if (gameObject.name == "front" && other != null && other.name == "back" && gameObject.transform.parent.GetComponent<SegmentIsGrabbed>()._segmentIsgrabbed)
            {
                SetPositionSegment(gameObject.transform.rotation.eulerAngles, other.gameObject.transform.rotation.eulerAngles, -1f, other);
            }
            if (gameObject.name == "back" && other != null && other.name == "front" && gameObject.transform.parent.GetComponent<SegmentIsGrabbed>()._segmentIsgrabbed)
            {
                SetPositionSegment(gameObject.transform.rotation.eulerAngles, other.gameObject.transform.rotation.eulerAngles, 1f, other);
            }
            SetStartPosition(other, gameObject.transform.rotation.eulerAngles);
            Grabber.GetComponent<GrabMoveSegment>().ReleaseSegment(gameObject.transform.parent.GetComponent<BoxCollider>());
        }
    }

    private void OnTriggerStay(Collider other)
    {
        gameObject.transform.parent.GetComponent<SegmentIsGrabbed>().isTriggered = true;
        if (!gameObject.transform.parent.GetComponent<SegmentIsGrabbed>().isSticked)
        {
            Stick(other as SphereCollider);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        gameObject.transform.parent.GetComponent<SegmentIsGrabbed>().isTriggered = false;
    }

    private void OnCollisionStay(Collision collision)
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

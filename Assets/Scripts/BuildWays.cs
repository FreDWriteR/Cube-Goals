using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Data;

public class BuildWays : MonoBehaviour
{
    // Start is called before the first frame update

    private Vector3 StartWay1;
    public GameObject PointB, WaySegment;
    private GameObject StartSegment, MiddleSegment, EndSegment, Segment;
    public bool SpawnStartSegmentWay1 = false, SpawnStartSegmentWay2 = false, SetsStarts;
    public List<Vector3> PointsWay1, PointsWay2;

    void Start()
    {
        
    }

    void SetPositionsForStarts()
    {
        if (!SetsStarts)
        {
            var TempPos = gameObject.transform.position;
            TempPos.y += gameObject.GetComponent<MeshRenderer>().bounds.size.y / 2f;
            TempPos.z += gameObject.GetComponent<MeshRenderer>().bounds.size.z / 2f;
            gameObject.transform.Find("Start1").transform.position = TempPos;
            gameObject.transform.Find("NameStart1").transform.position = new Vector3(TempPos.x, TempPos.y + 0.2f, TempPos.z);
            TempPos.x += gameObject.GetComponent<MeshRenderer>().bounds.size.x / 2f;
            StartWay1 = TempPos;
            gameObject.transform.Find("Start2").transform.position = TempPos;
            gameObject.transform.Find("NameStart2").transform.position = new Vector3(TempPos.x, TempPos.y + 0.2f, TempPos.z);
            TempPos.x -= gameObject.GetComponent<MeshRenderer>().bounds.size.x;
            gameObject.transform.Find("Start3").transform.position = TempPos;
            gameObject.transform.Find("NameStart3").transform.position = new Vector3(TempPos.x, TempPos.y + 0.2f, TempPos.z);
            TempPos.z -= gameObject.GetComponent<MeshRenderer>().bounds.size.z / 2f;
            gameObject.transform.Find("Start4").transform.position = TempPos;
            gameObject.transform.Find("NameStart4").transform.position = new Vector3(TempPos.x, TempPos.y + 0.2f, TempPos.z);
            TempPos.x += gameObject.GetComponent<MeshRenderer>().bounds.size.x;
            gameObject.transform.Find("Start5").transform.position = TempPos;
            gameObject.transform.Find("NameStart5").transform.position = new Vector3(TempPos.x, TempPos.y + 0.2f, TempPos.z);

            TempPos = PointB.transform.position;
            TempPos.y += PointB.GetComponent<MeshRenderer>().bounds.size.y / 2f;
            TempPos.z -= PointB.GetComponent<MeshRenderer>().bounds.size.z / 2f;
            PointB.transform.Find("Start1").transform.position = TempPos;
            TempPos.x += PointB.GetComponent<MeshRenderer>().bounds.size.x / 2f;
            PointB.transform.Find("Start2").transform.position = TempPos;
            TempPos.x -= PointB.GetComponent<MeshRenderer>().bounds.size.x;
            PointB.transform.Find("Start3").transform.position = TempPos;
            TempPos.z += PointB.GetComponent<MeshRenderer>().bounds.size.z / 2f;
            PointB.transform.Find("Start4").transform.position = TempPos;
            TempPos.x += PointB.GetComponent<MeshRenderer>().bounds.size.x;
            PointB.transform.Find("Start5").transform.position = TempPos;
            SetsStarts = true;
        }
    }

    void BuildWay0()
    {
        float Len = PointB.transform.Find("Start1").transform.position.z - gameObject.transform.Find("Start1").transform.position.z;
        float lenSegment = Len / 7f;
        PointsWay1.Add(gameObject.transform.Find("Start1").transform.position); //Добавление точки пути
        
         //Добавление точки пути
        for (int i = 0; i < 7; i++)
        {
            Segment = Instantiate(WaySegment, new Vector3(-2f, 0.5f + i * 0.5f, -11f), Quaternion.identity);
            Segment.name = "WaySegment" + (i + 10).ToString();

            Vector3 ScaleSegment = Segment.transform.localScale;
            ScaleSegment.z = ScaleSegment.z * lenSegment / WaySegment.GetComponent<MeshRenderer>().bounds.size.z;
            Segment.transform.localScale = ScaleSegment;
            PointsWay1.Add(new (PointsWay1[i].x, PointsWay1[i].y, PointsWay1[i].z + Segment.GetComponent<MeshRenderer>().bounds.size.z));
        }
    }

    void BuildWay1()
    {
        float LenStartSegment = UnityEngine.Random.Range(gameObject.GetComponent<MeshRenderer>().bounds.size.x, gameObject.GetComponent<MeshRenderer>().bounds.size.x * 2f);
        float LenForPointStartMiddleSegments = (float)Math.Sqrt(Math.Pow(LenStartSegment, 2) / 2f);

        PointsWay2.Add(gameObject.transform.Find("Start2").transform.position); //Добавление точки пути

        PointsWay2.Add(new Vector3(StartWay1.x + LenForPointStartMiddleSegments, StartWay1.y, StartWay1.z + LenForPointStartMiddleSegments)); //Добавление точки пути

        Vector3 PointToStartMiddleSegments = new (StartWay1.x + LenForPointStartMiddleSegments + WaySegment.GetComponent<SegmentIsGrabbed>().halfSlice, 
                                                  StartWay1.y, 
                                                  StartWay1.z + LenForPointStartMiddleSegments + WaySegment.GetComponent<SegmentIsGrabbed>().halfCathetus);

        PointsWay2.Add(new Vector3(StartWay1.x + LenForPointStartMiddleSegments + WaySegment.GetComponent<SegmentIsGrabbed>().halfSlice,
                                                  StartWay1.y,
                                                  StartWay1.z + LenForPointStartMiddleSegments + WaySegment.GetComponent<SegmentIsGrabbed>().halfCathetus)); //Добавление точки пути

        float LenForMiddleSegments = PointB.transform.Find("Start5").position.z - PointToStartMiddleSegments.z - WaySegment.GetComponent<SegmentIsGrabbed>().SizeX / 2f;

        

        Vector3 PointToStartEndSegment = new (PointToStartMiddleSegments.x - WaySegment.GetComponent<SegmentIsGrabbed>().SizeX / 2f, 
                                              PointToStartMiddleSegments.y, 
                                              PointToStartMiddleSegments.z + LenForMiddleSegments);

        

         

        float LenEndSegment = PointToStartEndSegment.x - PointB.transform.Find("Start5").position.x;

        StartSegment = Instantiate(WaySegment, new Vector3(-2f, 1f, -6f), Quaternion.identity);
        StartSegment.name = "WaySegment0"; 
        Vector3 ScaleStartSegment = StartSegment.transform.localScale;
        ScaleStartSegment.z = ScaleStartSegment.z * LenStartSegment / WaySegment.GetComponent<MeshRenderer>().bounds.size.z;
        StartSegment.transform.localScale = ScaleStartSegment;
        float lenMiddleSegment = LenForMiddleSegments / 4f;
        for (int i = 0; i < 4; i++)
        {
            MiddleSegment = Instantiate(WaySegment, new Vector3(-2f, 1.5f + i * 0.5f, -6f), Quaternion.identity);
            MiddleSegment.name = "WaySegment" + (i + 1).ToString();
            Vector3 ScaleMiddleSegment = MiddleSegment.transform.localScale;
            ScaleMiddleSegment.z = ScaleMiddleSegment.z * lenMiddleSegment / WaySegment.GetComponent<MeshRenderer>().bounds.size.z;
            MiddleSegment.transform.localScale = ScaleMiddleSegment;
            PointsWay2.Add(new(PointsWay2[i + 2].x, PointsWay2[i + 2].y, PointsWay2[i + 2].z + MiddleSegment.GetComponent<MeshRenderer>().bounds.size.z));
        }
        PointsWay2.Add(new(PointToStartMiddleSegments.x - WaySegment.GetComponent<SegmentIsGrabbed>().SizeX / 2f,
                           PointToStartMiddleSegments.y,
                           PointToStartMiddleSegments.z + LenForMiddleSegments + WaySegment.GetComponent<SegmentIsGrabbed>().SizeX / 2f)); //Добавление точки пути
        PointsWay2.Add(PointB.transform.Find("Start5").position); //Добавление точки пути
        EndSegment = Instantiate(WaySegment, new Vector3(-2f, 3.5f, -6f), Quaternion.identity);
        EndSegment.name = "WaySegment5";
        Vector3 ScaleEndSegment = EndSegment.transform.localScale;
        ScaleEndSegment.z = ScaleEndSegment.z * LenEndSegment / WaySegment.GetComponent<MeshRenderer>().bounds.size.z;
        EndSegment.transform.localScale = ScaleEndSegment;

    }

    // Update is called once per frame
    void Update()
    {
        if (PointB.GetComponent<SetPosiotionPointB>().positionisSet)
        {
            SetPositionsForStarts();
            if (!SpawnStartSegmentWay2)
            {
                BuildWay1();
                SpawnStartSegmentWay2 = true;
            }
            if (!SpawnStartSegmentWay1)
            {
                BuildWay0();
                SpawnStartSegmentWay1 = true;
            }
        }
    }
}

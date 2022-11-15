using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MoveToPointB : MonoBehaviour
{

    public GameObject PointA, PointB;
    public int Score = 0;
    private int i = 0, j = 0, k = 0, q = 0;
    private Vector3 Point = new Vector3(0f, 0f, 0f);
    private bool theEndOfPartOfTheWay = true, theEndOfTheWay = false;
    // Start is called before the first frame update

    void Start()
    {

    }

    public void Scoring()
    {
        if (i < PointA.GetComponent<BuildWays>().PointsWay2.Count && gameObject.name == "Obj2")
        {
            if (Vector2.Distance(new Vector2(gameObject.transform.position.x, gameObject.transform.position.z),
                                 new Vector2(PointA.GetComponent<BuildWays>().PointsWay2[i].x,
                                             PointA.GetComponent<BuildWays>().PointsWay2[i].z)) < 0.00001f)
            {
                Score += 10;
                i++;
            }
            else if (i != k || i == 0 && k == 0)
            {
                Score += 1;
            }
            k++;    
        }
        if (j < PointA.GetComponent<BuildWays>().PointsWay1.Count && gameObject.name == "Obj1") 
        {
            if (Vector2.Distance(new Vector2(gameObject.transform.position.x, gameObject.transform.position.z),
                                 new Vector2(PointA.GetComponent<BuildWays>().PointsWay1[j].x,
                                             PointA.GetComponent<BuildWays>().PointsWay1[j].z)) < 0.00001f)
            {
                Score += 10;
                j++;
            }
            else if (j != q || j == 0 && q == 0)
            {
                Score += 1;
            }
            q++;
        }
        if (Vector2.Distance(new Vector2(gameObject.transform.position.x, gameObject.transform.position.z),
                             new Vector2(PointB.transform.position.x,
                                         PointB.transform.position.z)) < 0.49f)
        {
            Score += 50;
        }
        if (Vector2.Distance(new Vector2(gameObject.transform.position.x, gameObject.transform.position.z),
                             new Vector2(PointA.GetComponent<BuildWays>().PointsWay2[PointA.GetComponent<BuildWays>().PointsWay2.Count - 1].x,
                                         PointA.GetComponent<BuildWays>().PointsWay2[PointA.GetComponent<BuildWays>().PointsWay2.Count - 1].z)) < 0.00001f ||
            Vector2.Distance(new Vector2(gameObject.transform.position.x, gameObject.transform.position.z),
                             new Vector2(PointA.GetComponent<BuildWays>().PointsWay1[PointA.GetComponent<BuildWays>().PointsWay1.Count - 1].x,
                                         PointA.GetComponent<BuildWays>().PointsWay1[PointA.GetComponent<BuildWays>().PointsWay1.Count - 1].z)) < 0.00001f)
        {
            Score += 100;
        }
    }

    Vector3 SearchWay(Collider other)
    {
        if (other.name == "back" && Vector2.Distance(new Vector2(gameObject.transform.position.x, gameObject.transform.position.z), 
                                                     new Vector2(other.transform.position.x, other.transform.position.z)) < 0.00001f &&
            other.transform.parent.GetComponent<SegmentIsGrabbed>().isSticked)
        {
            theEndOfPartOfTheWay = false;
            return other.transform.parent.transform.Find("front").transform.position;
        }
        else if (other.name == "back" && (gameObject.transform.position.z != other.transform.position.z ||
                                          gameObject.transform.position.x != other.transform.position.x) &&
                 other.transform.parent.GetComponent<SegmentIsGrabbed>().isSticked)
        {
            theEndOfPartOfTheWay = false;
            return other.transform.position;
        }
        return new Vector3(0f, 0f, 0f);  
    }

    bool CheckGoal(Collider other)
    {
        return (other.name == "front" && Vector2.Distance(new Vector2(gameObject.transform.position.x, gameObject.transform.position.z),
                                                          new Vector2(other.transform.position.x, other.transform.position.z)) < 0.00001f);
    }

    public IEnumerator Moving()
    {
        yield return new WaitForSeconds(0.1f);
        Vector3 TempPos;
        Vector3 TempPoint;
        if (PointA.GetComponent<BuildWays>().SpawnStartSegmentWay2)
        {
            while (Vector2.Distance(new Vector2(gameObject.transform.position.x, gameObject.transform.position.z),
                                    new Vector2(PointB.transform.Find(gameObject.GetComponent<AssignWay>().NumberEnd).transform.position.x, 
                                                PointB.transform.Find(gameObject.GetComponent<AssignWay>().NumberEnd).transform.position.z)) > 0.00001f &&
                   Vector2.Distance(new Vector2(gameObject.transform.position.x, gameObject.transform.position.z),
                                    new Vector2(PointB.transform.position.x,
                                                PointB.transform.position.z)) > 0.48f)
            {
                Vector3 GOStartPos = gameObject.transform.position;
                if (Point != new Vector3(0f, 0f, 0f))
                {
                    TempPoint = Point;
                    float t = 0f;
                    TempPos.y = GOStartPos.y;
                    float Len = (float)Math.Sqrt(Math.Pow(TempPoint.x - gameObject.transform.position.x, 2) + Math.Pow(TempPoint.z - gameObject.transform.position.z, 2));
                    while (gameObject.transform.position.x != TempPoint.x ||
                           gameObject.transform.position.z != TempPoint.z)
                    {
                        TempPos.x = Mathf.Lerp(GOStartPos.x, TempPoint.x, t);
                        TempPos.z = Mathf.Lerp(GOStartPos.z, TempPoint.z, t);
                        gameObject.transform.position = TempPos;
                        t += (1f / Len) * Time.deltaTime * 3f;
                        yield return new WaitForSeconds(0.001f);
                    }
                    theEndOfPartOfTheWay = true;
                    Scoring();
                    yield return new WaitForSeconds(0.1f);
                }
                yield return new WaitForSeconds(0.01f);
            }
            theEndOfTheWay = true;
        }
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (theEndOfPartOfTheWay)
        {
            Point = SearchWay(other);
        }
        if (theEndOfTheWay && CheckGoal(other))
        {
            gameObject.GetComponent<BoxCollider>().isTrigger = false;
            theEndOfTheWay = false;
        }
        
    }

    // Update is called once per frame
    void Update()
    {

    }
}

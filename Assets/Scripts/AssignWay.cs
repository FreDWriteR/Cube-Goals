using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssignWay : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject PointA;
    public bool bWaySelected = false, Select = false;
    public string NumberStart = "", NumberEnd = "";
    private Vector3 TempPos;
    IEnumerator coroutine;
    void Start()
    {
        
    }

    public IEnumerator MoveToStart()
    {
        yield return new WaitForSeconds(0.4f);
        Vector3 GOStartPos = gameObject.transform.position;
        float t = 0f;
        TempPos.y = GOStartPos.y;
        while (gameObject.transform.position.x != PointA.transform.Find(NumberStart).transform.position.x ||
               gameObject.transform.position.z != PointA.transform.Find(NumberStart).transform.position.z)
        {
            TempPos.x = Mathf.Lerp(GOStartPos.x, PointA.transform.Find(NumberStart).transform.position.x, t);
            TempPos.z = Mathf.Lerp(GOStartPos.z, PointA.transform.Find(NumberStart).transform.position.z, t);
            gameObject.transform.position = TempPos;
            t += 2f * Time.deltaTime;
            yield return new WaitForSeconds(0.001f);
        }
        gameObject.GetComponent<MoveToPointB>().Scoring();
        coroutine = gameObject.GetComponent<MoveToPointB>().Moving();
        StartCoroutine(coroutine);
    }

    void EnableNameStarts()
    {
        if (!bWaySelected)
        {
            PointA.transform.Find("NameStart1").GetComponent<MeshRenderer>().enabled = true;
            PointA.transform.Find("NameStart2").GetComponent<MeshRenderer>().enabled = true;
            PointA.transform.Find("NameStart3").GetComponent<MeshRenderer>().enabled = true;
            PointA.transform.Find("NameStart4").GetComponent<MeshRenderer>().enabled = true;
            PointA.transform.Find("NameStart5").GetComponent<MeshRenderer>().enabled = true;

            PointA.transform.Find("NameStart1").GetComponent<SelectWay>().StartDisappearance = false;
            PointA.transform.Find("NameStart2").GetComponent<SelectWay>().StartDisappearance = false;
            PointA.transform.Find("NameStart3").GetComponent<SelectWay>().StartDisappearance = false;
            PointA.transform.Find("NameStart4").GetComponent<SelectWay>().StartDisappearance = false;
            PointA.transform.Find("NameStart5").GetComponent<SelectWay>().StartDisappearance = false;

            PointA.transform.Find("Start1").GetComponent<SphereCollider>().enabled = false;
            PointA.transform.Find("Start2").GetComponent<SphereCollider>().enabled = false;
            PointA.transform.Find("Start3").GetComponent<SphereCollider>().enabled = false;
            PointA.transform.Find("Start4").GetComponent<SphereCollider>().enabled = false;
            PointA.transform.Find("Start5").GetComponent<SphereCollider>().enabled = false;
            
            Select = true;
        }
        gameObject.GetComponent<MeshRenderer>().material.SetColor("_Color", new Color(0.2389196f, 0.8584906f, 0.2609229f));
    }

    void DisableNameStarts()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1) && !bWaySelected)
        {
            PointA.transform.Find("NameStart1").GetComponent<MeshRenderer>().enabled = false;
            PointA.transform.Find("NameStart2").GetComponent<MeshRenderer>().enabled = false;
            PointA.transform.Find("NameStart3").GetComponent<MeshRenderer>().enabled = false;
            PointA.transform.Find("NameStart4").GetComponent<MeshRenderer>().enabled = false;
            PointA.transform.Find("NameStart5").GetComponent<MeshRenderer>().enabled = false;

            PointA.transform.Find("Start1").GetComponent<SphereCollider>().enabled = true;
            PointA.transform.Find("Start2").GetComponent<SphereCollider>().enabled = true;
            PointA.transform.Find("Start3").GetComponent<SphereCollider>().enabled = true;
            PointA.transform.Find("Start4").GetComponent<SphereCollider>().enabled = true;
            PointA.transform.Find("Start5").GetComponent<SphereCollider>().enabled = true;
            gameObject.GetComponent<MeshRenderer>().material.SetColor("_Color", new Color(1.0f, 1.0f, 1.0f));
            Select = false;
        }

    }

    private void OnMouseOver()
    {
        if (!bWaySelected)
        {
            gameObject.GetComponent<MeshRenderer>().material.SetColor("_Color", new Color(0.6f, 0.6f, 0.6f));
        }
    }

    private void OnMouseExit()
    {
        if (!bWaySelected)
        {
            gameObject.GetComponent<MeshRenderer>().material.SetColor("_Color", new Color(1.0f, 1.0f, 1.0f));
        }
    }

    private void OnMouseDown()
    {
        EnableNameStarts();
    }

    // Update is called once per frame
    void Update()
    {
        DisableNameStarts();
    }
}

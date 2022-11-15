using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class SelectWay : MonoBehaviour
{
    // Start is called before the first frame update
    IEnumerator coroutine;
    public bool StartDisappearance = false;
    public GameObject Obj1, Obj2;

    void Start()
    {

    }

    void DisableOtherNameStarts()
    {
        string NameStart, Start;
        for (int i = 1; i <= 5; i++)
        {
            if (i.ToString() != gameObject.name.Substring(9, 1))
            {
                NameStart = "NameStart" + i.ToString();
                gameObject.transform.parent.transform.Find(NameStart).GetComponent<MeshRenderer>().enabled = false;
            }
            Start = "Start" + i.ToString();
            gameObject.transform.parent.transform.Find(Start).GetComponent<SphereCollider>().enabled = true;
        }
    }

    private void OnMouseOver()
    {
        if (!StartDisappearance)
        {
            gameObject.GetComponent<TextMeshPro>().color = new Color(0.003921569f, 0.2470588f, 0.1568627f);
        }
    }

    private IEnumerator Disappearance()
    {
        if (gameObject.GetComponent<TextMeshPro>().color.a != 0)
        {
            yield return new WaitForSeconds(0.3f);
            float t = 0f;
            float ColorA;
            Color ColorNameStart = gameObject.GetComponent<TextMeshPro>().color;
            while (gameObject.GetComponent<TextMeshPro>().color.a != 0)
            {
                ColorA = Mathf.Lerp(1f, 0f, t);
                ColorNameStart.a = ColorA;
                gameObject.GetComponent<TextMeshPro>().color = ColorNameStart;
                if (t > 1f)
                {
                    gameObject.GetComponent<TextMeshPro>().color = Color.clear;
                }
                t += 0.01f;
                yield return new WaitForSeconds(0.005f);
            }
            Vector3 TempPos = gameObject.transform.position;
            TempPos.y -= 10f;
            gameObject.transform.position = TempPos;
        }
    }

    

    private void OnMouseExit()
    {
        if (!StartDisappearance) 
        { 
            gameObject.GetComponent<TextMeshPro>().color = new Color(0.2389196f, 0.8584906f, 0.2609229f);
        }
    }

    void Ready()
    {
        if (Obj1.GetComponent<AssignWay>().Select && Obj1.GetComponent<AssignWay>().NumberStart == "")
        {
            Obj1.GetComponent<AssignWay>().NumberStart = "Start" + gameObject.name.Substring(9, 1);
            Obj1.GetComponent<AssignWay>().NumberEnd = "Start1";
            Obj1.GetComponent<AssignWay>().bWaySelected = true;
            Obj1.GetComponent<MeshRenderer>().material.SetColor("_Color", new Color(1f, 0.6470588f, 0f));
            coroutine = Obj1.GetComponent<AssignWay>().MoveToStart();
            StartCoroutine(coroutine);
            Obj1.GetComponent<BoxCollider>().isTrigger = true;
        }
        if (Obj2.GetComponent<AssignWay>().Select && Obj2.GetComponent<AssignWay>().NumberStart == "")
        {
            Obj2.GetComponent<AssignWay>().NumberStart = "Start" + gameObject.name.Substring(9, 1);
            Obj2.GetComponent<AssignWay>().NumberEnd = "Start5";
            Obj2.GetComponent<AssignWay>().bWaySelected = true;
            Obj2.GetComponent<MeshRenderer>().material.SetColor("_Color", new Color(1f, 0.6470588f, 0f));
            coroutine = Obj2.GetComponent<AssignWay>().MoveToStart();
            StartCoroutine(coroutine);
            Obj2.GetComponent<BoxCollider>().isTrigger = true;
        }
    }

    private void OnMouseDown()
    {
        StartDisappearance = true;
        gameObject.GetComponent<TextMeshPro>().color = new Color(1f, 0.6470588f, 0f);
        DisableOtherNameStarts();
        coroutine = Disappearance();
        StartCoroutine(coroutine);
        Ready();
    }

    // Update is called once per frame
    void Update()
    {

    }
}

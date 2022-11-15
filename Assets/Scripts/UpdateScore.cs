using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpdateScore : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Obj1, Obj2;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<TextMeshProUGUI>().text = (Obj1.GetComponent<MoveToPointB>().Score + Obj2.GetComponent<MoveToPointB>().Score).ToString();
    }
}

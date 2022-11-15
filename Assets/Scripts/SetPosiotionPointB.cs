using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetPosiotionPointB : MonoBehaviour
{
    // Start is called before the first frame update
    public bool positionisSet = false; 
    void Start()
    {
        Vector3 TempPos = gameObject.transform.position;
        TempPos.z = UnityEngine.Random.Range(TempPos.z - 5f, TempPos.z);
        gameObject.transform.position = TempPos;
        positionisSet = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

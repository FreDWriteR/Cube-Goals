using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class MoveGrabler : MonoBehaviour
{
    // Start is called before the first frame update

    Vector3 TempPos;

    void Start()
    {
        
    }

    void movingGrabler()
    {
        TempPos = gameObject.transform.position;
        if (Input.GetKey(KeyCode.W))
        {
            TempPos.x -= 3f * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            TempPos.x += 3f * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A))
        {
            TempPos.z -= 3f * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            TempPos.z += 3f * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.Q))
        {
            TempPos.y += 3f * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.E))
        {
            TempPos.y -= 3f * Time.deltaTime;
        }
        gameObject.transform.position = TempPos;
    } 

    // Update is called once per frame
    void Update()
    {
        movingGrabler();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePart : MonoBehaviour
{
    public float speed = 10f;
    public Transform[] wayPoint;

    public int index = 1;

    public float value = 0;

    public Vector3 startPoint;
    public Vector3 targetPoint;
    void Start()
    {
        startPoint = wayPoint[0].position;
        targetPoint = wayPoint[1].position;
    }

    // Update is called once per frame
    void Update()
    {

        transform.position = Vector3.Lerp(startPoint, targetPoint, value);
        value += speed * Time.deltaTime;

        if (value >= 1)
        {
            value = 0;
          

            startPoint = targetPoint;

            index = index + 1;


          

            if (index  < wayPoint.Length)
            {
                
              targetPoint = wayPoint[index].position;
              
            }
            else
            {
                index = 0; 
                targetPoint = wayPoint[0].position;
            }

        }


    }
}

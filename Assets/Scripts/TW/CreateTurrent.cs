using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateTurrent : MonoBehaviour
{
    public GameObject[] prefap;

    public LayerMask layerMask;

    public int lv = 1;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Spawn();
    }


    

    public void Spawn()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                // Debug.Log(hit.collider.name);
                //Vector3 position = hit.transform.position;
                //position.y += hit.transform.localScale.y / 2f;
                //Debug.Log(hit.transform.localScale);
                //    Instantiate(prefap, position, Quaternion.identity);

                Node node = hit.collider.gameObject.GetComponent<Node>();
                if(node)
                {
                    node.Create(prefap[lv]);
                }

            }

        }
        if(Input.GetMouseButtonDown(1))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                // Debug.Log(hit.collider.name);
                //Vector3 position = hit.transform.position;
                //position.y += hit.transform.localScale.y / 2f;
                //Debug.Log(hit.transform.localScale);
                //    Instantiate(prefap, position, Quaternion.identity);

                Node node = hit.collider.gameObject.GetComponent<Node>();
                if (node)
                {
                    node.Remove();
                }

            }
        }



    }
}

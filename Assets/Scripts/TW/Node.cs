
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    
    public bool haveTurrent = true;
    public GameObject turrent;
    public Transform root;
    void Start()
    {
        
    }

   
    void Update()
    {
        
    }
    public void Create(GameObject prefap)
    {
        if(!haveTurrent)
        {
            turrent =  Instantiate(prefap, transform.position, Quaternion.identity, root);
            haveTurrent = true;
        }
    }
    public void Remove()
    {
        if(haveTurrent)
        {
            Destroy(turrent);
            haveTurrent = false;
        }
    }
}

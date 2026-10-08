using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowLine : MonoBehaviour
{
    public float size = 100f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnDrawGizmos()
    {
        Gizmos.color = new Color(146,215,240,0.3f);
        Gizmos.DrawCube(new Vector3(transform.position.x,transform.position.y,transform.position.z + size /2f),new Vector3(2.3f,1,size));
    }
}

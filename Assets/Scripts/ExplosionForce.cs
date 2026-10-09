using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionForce : MonoBehaviour
{
  
    
    public Rigidbody rb;
    // Update is called once per frame

    public float forwardForce = 15f;
    public float maxSpreadX = 10f;  //  ซ้าย-ขวา
    public float maxSpreadY = 10f;  //  ขึ้น-ลง
    public float maxSpreadZ = 10f;  //  ขึ้น-ลง
    void Update()
    {
     

        
    }

    [ContextMenu("Explosion")]
    private void Explosion()
    {
        float randomX = Random.Range(-maxSpreadX, maxSpreadX);
        float randomY = Random.Range(-maxSpreadY, maxSpreadY);
        float randomZ = Random.Range(-maxSpreadZ, maxSpreadZ);
        Quaternion rotate = Quaternion.Euler(randomX, randomY, randomZ);
        Vector3 dir = rotate * transform.forward;

        rb.AddForce(dir * forwardForce, ForceMode.Impulse);
    }
}

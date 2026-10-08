using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionForce : MonoBehaviour
{
  
    public float forceAmount = 15f;
       public float upwardForce = 5f;   
    public Rigidbody rb;
    // Update is called once per frame
    void Update()
    {
        
    }

    [ContextMenu("Explosion")]
    private void Explosion()
    {
        
        rb.AddForce(transform.forward * forceAmount,ForceMode.Impulse);
    }
}

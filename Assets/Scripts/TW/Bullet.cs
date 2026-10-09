using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 50f;
    private Transform target;

   
    public void Seek(Transform _target)
    {
        target = _target;
    }

    void Update()
    {
       
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

     
        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

      
        if (dir != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(dir);
        }

       
        if (dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }

      
        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
    }

    void HitTarget()
    {
      
        Destroy(gameObject); 
    }
}

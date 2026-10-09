using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.GraphicsBuffer;

public class Gunturent : MonoBehaviour
{
    public float rotateSpeed = 5;

    public Transform rotatePivot;
    public Transform targetLook;
    public float radius = 10f;
    public LayerMask enemyLayerMask;
    public Collider[] ememys;

    public float timerToshoot = 0;
    public float timeToshoot = 3;

    public GameObject bullet;
    public Transform muzzle;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Rotate();




        ememys = Physics.OverlapSphere(rotatePivot.position, radius, enemyLayerMask);
        Debug.Log(ememys);
      
        if(ememys.Length > 0)
        {
            targetLook = ememys[0].transform;

            if(timerToshoot >= timeToshoot)
            {
                timerToshoot = 0;
                GameObject bulletOBJ = Instantiate(bullet, muzzle.transform.position, Quaternion.identity);
                Bullet bulletscritp = bulletOBJ.GetComponent<Bullet>();

                bulletscritp.Seek(ememys[0].transform);


             }
            else
            {
                timerToshoot += Time.deltaTime;
            }

        }
        else
        {
            targetLook = null;
        }



    }

    private void Rotate()
    {
        //Quaternion rotatetion = Quaternion.LookRotation(rotatePivot.up.normalized, targetLook.position);
        //rotatePivot.rotation = rotatetion; 
        if (targetLook == null) return;

        Vector3 direction = targetLook.position - transform.position;

        direction.y = 0;

        Quaternion targetRotate = Quaternion.LookRotation(direction);

        rotatePivot.rotation = Quaternion.Slerp(rotatePivot.rotation, targetRotate, rotateSpeed * Time.deltaTime);


    }

    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(236, 75, 75, 0.45f);
        Gizmos.DrawSphere(rotatePivot.position, radius);
    }
}

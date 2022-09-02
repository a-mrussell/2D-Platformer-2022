using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacking : MonoBehaviour
{
    public Transform fP;
    public static bool shooting;
    [SerializeField] LineRenderer lineRenderer;

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetButton("Attack"))
        {
            shooting = true;
            Shoot();
        }
        else
        {
            shooting = false;
        }

        if (shooting)
        {
            lineRenderer.enabled = true;
        }
        else
        {
            lineRenderer.enabled = false;
        }
    }


    void Shoot()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(fP.position, fP.right);

        if (hitInfo)
        {
            lineRenderer.SetPosition(0, fP.position);
            lineRenderer.SetPosition(1, hitInfo.point);

            if (hitInfo.transform.name == "enemy")
            {
                Debug.Log("enemy hit");
                EnemyHealth.enemyHealthAmount -= 1;
            }
        }
        else
        {
            lineRenderer.SetPosition(0, fP.position);
            lineRenderer.SetPosition(1, fP.position + fP.right * 100);
        }
       
    }
}

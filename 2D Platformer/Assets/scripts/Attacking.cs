using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacking : MonoBehaviour
{
    public Transform fP;
    public static bool shooting;
    public int damage; //yeah this not work bro
    //[SerializeField] GameObject impactEffect;
    [SerializeField] LineRenderer lineRenderer;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Attack"))
        {
            shooting = true;
            StartCoroutine( Shoot());
        }
        else{
            shooting = false;
        }
    }

    IEnumerator Shoot()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(fP.position, fP.right);

        if (hitInfo)
        {
            Debug.Log(hitInfo.transform.name);
            /*Enemy enemy = hitInfo.transform.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);//this doesnt work
            }
            */

            //Instantiate(impactEffect, hitInfo.point, Quaternion.identity);

            lineRenderer.SetPosition(0, fP.position);
            lineRenderer.SetPosition(1, hitInfo.point);

        }
        else
        {
            lineRenderer.SetPosition(0, fP.position);
            lineRenderer.SetPosition(1, fP.position + fP.right * 100);
        }

        lineRenderer.enabled = true;
        yield return 0;
        lineRenderer.enabled = false;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private GameObject enemy;
    [SerializeField] float XScale = 1.5f;
    [SerializeField] Vector3 enemyScale;
    
    public static int enemyHealthAmount = 50;

    // Start is called before the first frame update
    void Start()
    {
        XScale = 1.5f;   
        enemyScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {

    }
}

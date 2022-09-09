using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private GameObject enemy;
    [SerializeField] GameObject healthBar;
    [SerializeField] Vector3 XScale;
    [SerializeField] Vector3 enemyScale;
    [SerializeField] BoxCollider2D enemyBC;
    [SerializeField] public Animator animator;
    [SerializeField] Rigidbody2D enemyRB;

    [SerializeField] SpriteRenderer SR;
    
    public static int enemyHealthAmount = 50;
    [SerializeField] float enHealthHalf;

    void EnemyAttack()
    {
        animator.SetBool("attack", true);
    }

    // Start is called before the first frame update
    void Start()
    {
        enemyScale = healthBar.transform.localScale;
        enemyScale.x = enemyHealthAmount * 0.05f;
        healthBar.transform.localScale = enemyScale;
        enHealthHalf = enemyHealthAmount * 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyScale.x != enemyHealthAmount)
        {
            enemyScale.x = enemyHealthAmount* 0.05f;
            healthBar.transform.localScale = enemyScale;
        }

        if (enemyHealthAmount < enHealthHalf)
        {
            SR.color = Color.yellow;
        }
        //enemyScale.x -= 0.1f;
        //healthBar.transform.localScale = enemyScale;
        
        if (enemyHealthAmount <= 0)
        {
            Debug.Log("enemy dead");
            int LayerIgnoreRaycast = LayerMask.NameToLayer("Ignore Raycast");
            enemy.layer = LayerIgnoreRaycast;
            animator.SetBool("dead", true);
            enemyRB.constraints = RigidbodyConstraints2D.FreezeAll;
            enemyBC.enabled = false;
            healthBar.SetActive(false);
        }
    }
}

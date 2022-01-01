using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class EnemyCombat : MonoBehaviour
{

    public Transform AttackPoint;
    public float AttackRange = 0.5f;
    public LayerMask Player;

    public int attackDamage = 40;
    public float attackRate = 0.5f;
    float nextAttackTime = 0f;

    private void Update()
    {
        if (Time.time >= nextAttackTime)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                Attack();
                nextAttackTime = Time.time + 2f / attackRate;
            }
        }
    }

    void Attack()
    {
        
        //Detect enemies
        Collider[] hitEnemies = Physics.OverlapSphere(AttackPoint.position, AttackRange, Player);
      
        //deal damage
        foreach (Collider enemy in hitEnemies)
        {
            enemy.GetComponent<Enemy>().TakeDamage(attackDamage);
            Debug.Log(" We hit " + enemy.name);
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(AttackPoint.position, AttackRange);
    }

}

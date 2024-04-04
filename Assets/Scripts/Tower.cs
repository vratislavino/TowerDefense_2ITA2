using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField]
    private float damage;
    [SerializeField]
    private float attackSpeed;
    [SerializeField]
    private float range;

    [SerializeField]
    private CircleCollider2D rangeCollider;

    private List<EnemyStats> enemiesInRange = new List<EnemyStats>();

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(AttackRoutine());
        rangeCollider = GetComponent<CircleCollider2D>();
        if(rangeCollider)
        {
            rangeCollider.radius = range;
        }
    }

    private IEnumerator AttackRoutine()
    {
        while (true)
        {
            if (enemiesInRange.Count == 0)
            {
                yield return new WaitForEndOfFrame();
            } else
            {
                Attack(enemiesInRange.First());
                yield return new WaitForSeconds(attackSpeed);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var obj = collision.gameObject.GetComponentInParent<EnemyStats>();
        if(obj)
        {
            enemiesInRange.Add(obj);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        var obj = collision.gameObject.GetComponentInParent<EnemyStats>();
        if(obj)
        {
            if(enemiesInRange.Contains(obj)) enemiesInRange.Remove(obj);
        }
    }

    private void Attack(EnemyStats enemyStats)
    {
        enemyStats.TakeDamage(damage);
    }
}

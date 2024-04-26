using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public abstract class SingleFireTower : Tower
{

    [SerializeField]
    private float attackSpeed;
    [SerializeField]
    private float range;

    [SerializeField]
    private CircleCollider2D rangeCollider;

    private List<EnemyStats> enemiesInRange = new List<EnemyStats>();

    protected virtual void Start()
    {
        StartCoroutine(AttackRoutine());
        rangeCollider = GetComponent<CircleCollider2D>();
        if (rangeCollider)
        {
            rangeCollider.radius = range;
        }
    }

    protected abstract void Attack(EnemyStats enemyStats);

    private IEnumerator AttackRoutine()
    {
        while (true)
        {
            if (enemiesInRange.Count == 0)
            {
                yield return new WaitForEndOfFrame();
            }
            else
            {
                Attack(enemiesInRange.First());
                yield return new WaitForSeconds(attackSpeed);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var obj = collision.gameObject.GetComponentInParent<EnemyStats>();
        if (obj)
        {
            enemiesInRange.Add(obj);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        var obj = collision.gameObject.GetComponentInParent<EnemyStats>();
        if (obj)
        {
            EnemyOutOfRange(obj);
        }
    }

    protected virtual void EnemyOutOfRange(EnemyStats enemy)
    {
        if (enemiesInRange.Contains(enemy))
        {
            enemiesInRange.Remove(enemy);
        }
    }
}

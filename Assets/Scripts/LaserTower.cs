using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class LaserTower : SingleFireTower
{
    LineRenderer lineRenderer;
    EnemyStats currentEnemy;

    protected override void Start()
    {
        base.Start();
        lineRenderer = GetComponent<LineRenderer>();
    }

    protected override void Attack(EnemyStats enemyStats)
    {
        currentEnemy = enemyStats;
        enemyStats.TakeDamage(damage);
    }

    private void Update()
    {
        if (currentEnemy != null)
        {
            lineRenderer.SetPositions(new Vector3[] {
                transform.position,
                currentEnemy.transform.position
            });
        }
    }

    protected override void EnemyOutOfRange(EnemyStats enemy)
    {
        base.EnemyOutOfRange(enemy);
        currentEnemy = null;
        lineRenderer.SetPositions(new Vector3[] {
            transform.position,
            transform.position,
        });
    }
}

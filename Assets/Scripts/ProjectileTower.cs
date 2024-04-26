using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileTower : SingleFireTower
{
    [SerializeField]
    private ExplosiveProjectile projectilePrefab;

    [SerializeField]
    private float explosionRange;

    protected override void Attack(EnemyStats enemy)
    {
        SpawnProjectile(enemy);
    }

    private void SpawnProjectile(EnemyStats target)
    {
        var projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
        projectile.SetData(target, 10, damage, explosionRange);
    }
}


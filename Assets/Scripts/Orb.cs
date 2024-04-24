using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orb : MonoBehaviour
{
    private OrbTower orbTower;
    private void Start()
    {
        orbTower = GetComponentInParent<OrbTower>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        var enemy = other.GetComponentInParent<EnemyStats>();
        if(enemy != null)
        {
            enemy.TakeDamage(orbTower.Damage);
        }
    }
}

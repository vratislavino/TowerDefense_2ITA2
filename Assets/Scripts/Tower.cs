using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Tower : MonoBehaviour
{
    [SerializeField] protected float damage;
    protected int xp;
    protected int level;

    public virtual void Upgrade()
    {
        level++;
        damage *= 1.1f;
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyStats : MonoBehaviour
{
    static int count = 0;

    [SerializeField]
    private float damage;

    public float Damage => damage;

    private float hp;
    [SerializeField]
    private float maxHp;

    [SerializeField]
    Image hpBarImage;

    public float Hp
    {
        get { return hp; }
        set { 
            hp = value;
            UpdateHpBar();
        }
    }

    private void UpdateHpBar()
    {
        hpBarImage.fillAmount = hp / maxHp;
    }

    // Start is called before the first frame update
    void Start()
    {
        Hp = maxHp;
        count++;
    }

    public void TakeDamage(float damage)
    {
        Hp -= damage;
        if(Hp <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        count--;
        if(count == 0)
        {
            Player.Instance.KilledLast();
        }
    }
}

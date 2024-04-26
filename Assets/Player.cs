using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField]
    private Image healthbar;

    [SerializeField]
    private float maxHp;

    private float currentHp;

    public void TakeDamage(float damage)
    {
        currentHp -= damage;
        healthbar.fillAmount = currentHp/maxHp;
        if (currentHp < 0)
        {
            GameManager.Instance.PlayerDied();
        }
    } 

    // Start is called before the first frame update
    void Start()
    {
        currentHp = maxHp;
        healthbar.fillAmount = currentHp / maxHp;
    }
}

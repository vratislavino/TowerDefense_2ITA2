using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    static Player instance;
    public static Player Instance => instance;

    public event Action GameLost;
    public event Action GameWon;

    [SerializeField]
    private Image healthbar;

    [SerializeField]
    private float maxHp;

    private float currentHp;

    private void Awake()
    {
        instance = this;
    }

    public void TakeDamage(float damage)
    {
        currentHp -= damage;
        healthbar.fillAmount = currentHp/maxHp;
        if (currentHp < 0)
        {
            GameLost?.Invoke();
        }
    } 

    // Start is called before the first frame update
    void Start()
    {
        currentHp = maxHp;
        healthbar.fillAmount = currentHp / maxHp;
    }

    internal void KilledLast()
    {
        GameWon?.Invoke();
    }
}

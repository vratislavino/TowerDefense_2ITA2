using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance => instance;

    public Player Player => player;

    public event Action GameLost;
    public event Action GameWon;


    [SerializeField]
    Spawner spawner;

    [SerializeField]
    Player player;

    private void Awake()
    {
        instance = this;
    }

    public void EnemyKilled(EnemyStats enemy)
    {
        spawner.RemoveEnemy(enemy);
        if(spawner.EnemyCount == 0 && spawner.BossSpawned)
        {
            GameWon?.Invoke();
        }
    }

    internal void PlayerDied()
    {
        GameLost?.Invoke();
    }
}

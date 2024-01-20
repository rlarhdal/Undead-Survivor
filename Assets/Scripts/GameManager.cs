using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("# Game Control")]
    public float gameTime;
    public float maxTime = 2 * 10f;
    public bool isLive;

    [Header("# Player Info")]
    public int health;
    public int maxHealth = 100;
    public int level;
    public int kill;
    public int exp;
    public int[] nextExp = { 3, 5, 10, 100, 150, 210, 280, 360, 450, 600 };

    [Header("# GameObject")]
    public PoolManager pool;
    public Player player;
    public LevelUp uiLv;

    void Awake()
    {
        instance = this;    
    }

    void Start()
    {
        health = maxHealth;
        //임시 스크립트
        uiLv.Select(0);
    }

    void Update()
    {
        if (!isLive)
            return;
        gameTime += Time.deltaTime;
        
        if(gameTime > maxTime)
        {
            gameTime = maxTime;
        }
    }

    public void GetExp()
    {
        exp++;
        if(exp == nextExp[Mathf.Min(level, nextExp.Length-1)])
        {
            level++;
            exp = 0;
            uiLv.Show();
        }
    }

    public void Stop()
    {
        isLive = false;
        Time.timeScale = 0;
    }

    public void Resume()
    {
        isLive = true;
        Time.timeScale = 1;
    }
}

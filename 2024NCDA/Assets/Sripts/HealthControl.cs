using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.Rendering;

public class HealthControl : MonoBehaviour
{
    public GameObject PlayerHealthObj;
    public GameObject EnemyHealthObj;

    private Slider PlayerSlider;
    private Slider EnemySlider;

    private float playerHealth;
    private float enemyHealth;

    private UnityEvent healthChange = new UnityEvent();


    void Start()
    {
        StartBattle();
        healthChange.AddListener(DisplayHealth);
    }
    public void StartBattle()
    {
        playerHealth = 1;
        enemyHealth = 1;
        PlayerSlider = PlayerHealthObj.GetComponentInChildren<Slider>();
        EnemySlider = EnemyHealthObj.GetComponentInChildren<Slider>();

        PlayerSlider.value = playerHealth;
        EnemySlider.value = enemyHealth;
    }

    public void HealthNumChange(int _PlayerID, int _AttackNum)
    {
        float attacknum = _AttackNum / 100f;
        //Debug.Log("AttackNum = " + attacknum);
        if (_PlayerID == 1)
        {
            playerHealth = playerHealth - attacknum;
            healthChange.Invoke();

        }
        else if (_PlayerID == 0)
        {
            enemyHealth = enemyHealth - attacknum;
            healthChange.Invoke();
        }
    }

    /// <summary>
    /// 血条变动时改变血条
    /// </summary>
    public void DisplayHealth()
    {
        PlayerSlider.value = playerHealth;
        EnemySlider.value = enemyHealth;
        //Debug.Log("enemyHealth = " + EnemySlider.value);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnim : MonoBehaviour
{
   private Animator enemyAnim;
   private EnemyController enemy;

    private void Awake()
    {
        enemy = FindObjectOfType<EnemyController>();
        enemyAnim = GetComponent<Animator>();
    }

    private void Update()
    {
        RunAnim();
    }
    void RunAnim()
    {
        if (enemy.enemyMove)
        {
            enemyAnim.SetBool("Run", true);
        }
        else
        {
            enemyAnim.SetBool("Run", false);
        }

    }
    

} 

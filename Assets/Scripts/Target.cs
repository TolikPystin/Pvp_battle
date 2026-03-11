using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Target : MonoBehaviour
{
    public float healft;
    public float maxhealf = 100f;
    public Slider sliderenemyhp;
    private Animator animator;
    private Gamemanager gamemanager;
    private bool isdead = false;

    void Start()
    {
        healft = maxhealf;    
        sliderenemyhp.maxValue = maxhealf;
        sliderenemyhp.value = healft;
        animator = GetComponent<Animator>();
        gamemanager = FindObjectOfType<Gamemanager>();    
    }

    public void TakeDamage(float value) 
    {
        if (isdead) return;

        healft -= value;
        Debug.Log("Отняли 25 хп" + maxhealf);
        animator.SetTrigger("gethit");

        sliderenemyhp.value = healft;
        if (healft <= 0 )
        {
            Dead();

        }
    }

    void Dead()
    {
        if (isdead)
            return;

        isdead = true;
        animator.SetTrigger("death");
        gamemanager.OnEnemyKilled();
        
        Destroy(gameObject, 5);
    }

   
}

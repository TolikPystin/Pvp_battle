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



    

    void Start()
    {
        healft = maxhealf;
        sliderenemyhp.maxValue = maxhealf;
        sliderenemyhp.value = healft;
        animator = GetComponent<Animator>();
        gamemanager = GameObject.Find("Gamemanager").GetComponent<Gamemanager>();
    }

    public void TakeDamage(float value) 
    {
        
        healft -= value;
        Debug.Log("Отняли 25 хп" + maxhealf);
        animator.SetTrigger("gethit");

        sliderenemyhp.value = healft;
        if (healft == 0 )
        {
            animator.SetTrigger("death");
            Destroy(gameObject, 5);
            gamemanager.Recountenemy();

        }
    }

   
}

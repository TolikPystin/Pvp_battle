using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float atakerange = 8f;
    private Transform playertransform;
    public float speed = 4f;
    private Vector3 direction;
    private float distanttoplayer;
    private Animator animatorenemy;
    private Gamemanager gamemanager;
    private Rigidbody rb;
    private float jumppower = 10f;



    void Start()
    {
        animatorenemy = GetComponent<Animator>();
        gamemanager = GameObject.Find("Gamemanager").GetComponent<Gamemanager>();
        playertransform = GameObject.Find("Player").transform;
        rb = GetComponent<Rigidbody>();
    }

   
    void Update()
    {
        distanttoplayer = Vector3.Distance(transform.position, playertransform.position);
        if (distanttoplayer < atakerange ) 
        {
            animatorenemy.SetBool("running", true);
            direction = (playertransform.position - transform.position).normalized;
            direction.y = 0;
            
         //   transform.position = Vector3.MoveTowards(transform.position, direction, speed * Time.deltaTime);
         transform.Translate(direction * speed * Time.deltaTime);
            Quaternion rotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Lerp(transform.rotation, rotation, speed * Time.deltaTime);
        }
        else
        {
            animatorenemy.SetBool("running", false);

        }
    }




    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            animatorenemy.SetTrigger("attack");
            Debug.Log("Анимация атаки включена");
             gamemanager.Recounthp(-30);
            rb.AddForce(Vector3.back * jumppower, ForceMode.Impulse);
            
        }

    }
}

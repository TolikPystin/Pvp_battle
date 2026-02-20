using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEditor;
using UnityEngine;

public class Medhit : MonoBehaviour
{
    public Gamemanager gamemanager;
    public GameObject red, green, gray, yellow;
    public int counter = 0;
    private float rotationspeed = 100f;
    private float speed = 1f;
    private bool isused  = false;
    private float delta = 1f;
    private Vector3 startposition;
    private Vector3 endposition;
   
    private Vector3 targetposition;

    private Soundsmanager soundsmanager;
    

   

    void Start()
    { 
        counter = 0;
        red.SetActive(true);
        green.SetActive(false);
        gray.SetActive(false);
        yellow.SetActive(false);
        startposition = transform.position;
        endposition = transform.position + new Vector3(0,delta,0);
        targetposition = endposition;
        soundsmanager = GameObject.Find("sounds").GetComponent<Soundsmanager>();
    }

    
    void Update()
    {
        if (!isused)
        {
            transform.Rotate(Vector3.up, rotationspeed * Time.deltaTime);
            transform.position = Vector3.MoveTowards(transform.position, targetposition, Time.deltaTime * speed);
            if (Vector3.Distance(transform.position, targetposition) < 0.01f)
            {
                if (targetposition == endposition)
                {
                    targetposition = startposition;
                    
                }
                else
                {
                    targetposition = endposition;
                }
            }
        }
        

        

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("лекаюсь");
            if (counter == 0)
            {
                soundsmanager.HealingPlay();

                gamemanager.Recounthp(50);
                red.SetActive(false);
                gray.SetActive(true);
                green.SetActive(false);
                yellow.SetActive(false);
            }
            else if (counter == 1) 
            {
                soundsmanager.HealingPlay();
                red.SetActive(false);
                gray.SetActive(false);
                green.SetActive(true);
                yellow.SetActive(false);
                gamemanager.Recounthp(19);
            }
            else if (counter == 2)
            {
                soundsmanager.DamagePlay();
                red.SetActive(false);
                gray.SetActive(false);
                green.SetActive(false);
                yellow.SetActive(true);
                isused = true;
                gamemanager.Recounthp(-55);
            }
            else
            {
                soundsmanager.EmptyPlay();
            }
            counter++;
        }
        
    }
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Gunrotation : MonoBehaviour
{
    private float rotationspeed = 100f;
    private float speed = 1f;
    
    
    private Vector3 startposition;
    private Vector3 endposition;
    private float delta = 1f;
    private Vector3 targetposition;



    private void Start()
    {
        startposition = transform.position;
        endposition = transform.position + new Vector3(0, delta, 0);
        targetposition = endposition;
    }


    void Update()
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("нашли оружие");
            Playercontroller playercontroller = other.gameObject.GetComponent<Playercontroller>();
            if (playercontroller != null)
            {
                playercontroller.Giveweapon();
                Destroy(gameObject);
            }
            
        }
    }
}

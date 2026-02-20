using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    private Transform playertransform;
    //public Transform pointtransform;
    public GameObject player;
    private CharacterController characterController;



    private void Start()
    {
        playertransform = player.transform;
        characterController = player.GetComponent<CharacterController>();
    }
    
    public void Onclick()
    {
        characterController.enabled = false;
        playertransform.position = transform.position;
        characterController.enabled = true;

    }
       






}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playercontroller : MonoBehaviour
{
    private Animator animator;
    private CharacterController characterController;
    public float speed = 5f;
    private Vector3 velosity;
    private float horizontal;
    private float vertical;
    public float jumpheight = 3f;
    private float gravity = -9.81f;
    public bool isgrounded;
    public Gamemanager gamemanager;
    public GameObject weapon;



    private void Start()
    {
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        weapon.SetActive(false);
    }



    private void Update()
    {
        isgrounded = characterController.isGrounded;
        if (Input.GetKeyDown(KeyCode.Space) && isgrounded)
        {

            velosity.y += Mathf.Sqrt(jumpheight * gravity * -3f);


        }

        velosity.y += gravity * Time.deltaTime;
        characterController.Move(velosity * Time.deltaTime);

        if (isgrounded && velosity.y < 0)
        {
         velosity.y = 0;
        }
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        if (Input.GetKeyDown(KeyCode.R))
        {
            Debug.Log("нажата клавиша R ");
            animator.SetTrigger("Reload");
            
        }
        Vector3 moving = transform.right * horizontal + transform.forward * vertical;
        characterController.Move(moving * speed * Time.deltaTime);
       
        
    }

    public void Giveweapon()
    {
        
            weapon.SetActive(true);
            animator.SetTrigger("Reload");
        
    }


}

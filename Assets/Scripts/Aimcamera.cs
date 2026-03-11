
using UnityEngine;
using UnityEngine.UI;

public class Aimcamera : MonoBehaviour
{
    [SerializeField] private Camera maincamera;
    [SerializeField] private Camera aimcamera;

    [SerializeField] private Image image;
    [SerializeField] float scale;
    private Vector3 curentsize;
    private Gamemanager gamemanager;

    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
        curentsize = image.transform.localScale;
        gamemanager = FindObjectOfType<Gamemanager>();
    }




    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            maincamera.enabled = false;
            aimcamera.enabled = true;
            animator.SetBool("Aim", true);
            Changeimagesize(aimcamera.enabled);
        }

        if (Input.GetMouseButtonUp(1))
        {
            maincamera.enabled = true;
            aimcamera.enabled = false;
            animator.SetBool("Aim", false);
            Changeimagesize(aimcamera.enabled);
        }

        image.enabled = gamemanager.gameactive;

    }



    void Changeimagesize(bool value)
    {
        if (value)
        {
            image.transform.localScale = curentsize * scale;
            
        }
        else
        {
            image.transform.localScale = curentsize;
        }

    }
}

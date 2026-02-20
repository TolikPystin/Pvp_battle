using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public float range = 100f;
    public float damage = 25f;
    public Camera aimcamera;
    public AudioSource gunshootingsaund;
    
    public ParticleSystem effectatack;
    public GameObject bulleteffect;






    void Start()
    {
        
    }

    
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            effectatack.Play();
            gunshootingsaund.Play();
            
            Shoots();
        }


    }

    void Shoots()
    {
        RaycastHit hit;
        if (Physics.Raycast(aimcamera.transform.position, aimcamera.transform.forward, out hit, range)) 
        {
            Debug.Log("мы попали в" + hit.transform.name);
            Target target = hit.transform.GetComponent<Target>();   
            if (target != null)
            {
                target.TakeDamage(damage);
            }
            GameObject effect = Instantiate(bulleteffect,hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(effect,4f);
        }
    }



    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(aimcamera.transform.position, aimcamera.transform.forward * range);
    }

}

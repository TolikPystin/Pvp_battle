using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soundsmanager : MonoBehaviour
{
    public AudioSource healing;
    public AudioSource damagehealing;
    public AudioSource emptysound;

    public void HealingPlay()
    {
        healing.Play();
     
    }

    public void DamagePlay()
    {
        damagehealing.Play();
    }

    public void EmptyPlay()
    {
        emptysound.Play();
    }





}

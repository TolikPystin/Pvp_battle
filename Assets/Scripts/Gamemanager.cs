using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Gamemanager : MonoBehaviour
{
    private int hp = 100;
    public Slider hpSlider;
    public int enemy;
    public GameObject[] enemylist;
    private int maxhp = 100;
    private int minhp = 0;
    public GameObject door;
    public GameObject loseponel;
    public GameObject helponlvl;
    public GameObject winponel;
    public int killenemy;
    public TextMeshProUGUI killenemytext;



    private bool isdooropened;



   

    void Start()
    {
        hpSlider.value = hp;
        loseponel.SetActive(false);
        Time.timeScale = 1.0f;
        enemylist = GameObject.FindGameObjectsWithTag("enemy");
        enemy = enemylist.Length;
        door.SetActive(true);
        isdooropened = false;
        winponel.SetActive(false);
        helponlvl.SetActive(false);
    }

     public void Recounthp(int value)
    {
        hp += value;
        hp = Mathf.Clamp(hp, minhp, maxhp);
        hpSlider.value = hp;
        if (hp <= minhp)
        {
            GameOver();

        }

    }

   public void Recountenemy()
    {
        killenemy += 1;
        killenemytext.text = "убито врагов : " + killenemy.ToString();
        if (killenemy >= 10 && !isdooropened) 
        {
            helponlvl.SetActive(true);
            Time.timeScale = 0f;
            
            isdooropened=true;
            OpenDoor(); 
        }
        
    }

    public void Gotime()
    {
        helponlvl.SetActive(false);
        Time.timeScale = 1f;
    }



     public void OpenDoor()
    {
        door.SetActive(false);

    }



    public void RestartButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }



    public void GameOver()
    {
      loseponel.SetActive(true);
        Time.timeScale = 0;

    }



    void Update()
    {
        
    }
}

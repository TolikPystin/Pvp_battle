using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Gamemanager : MonoBehaviour
{
    [System.Serializable]
    public class WaveData
    {
        public Spawnerenemy spawnerenemy;
        public int enemyTokill;
        public GameObject door;
    }

    [Header("UI")]
    public Slider hpSlider;
    public TextMeshProUGUI killenemytext;
    public GameObject loseponel;
    public GameObject helponlvl;
    public GameObject winponel;
    public GameObject introponel;

    [Header("Waves")]
    public WaveData[] waves;
    public int currentwaveindex = 0;

    private int hp = 100;
    private int maxhp = 100;
    private int minhp = 0;
    public bool gameactive = false;
    


    private int currentKills = 0;
    private bool wavecompleted = false;


    void Start()
    {
        
        Showintro();
        loseponel.SetActive(false);
        winponel.SetActive(false);
        helponlvl.SetActive(false);
        hpSlider.maxValue = maxhp;
        hpSlider.value = hp;

        if (waves.Length > 0)
        {
            waves[0].door.SetActive(true);
        }
    }
    

    void Showintro()
    {
        introponel.SetActive(true);
        Time.timeScale = 0f;
        gameactive = false;

    }

   public void Hideintro()
    {
        introponel.SetActive(false);
        Time.timeScale = 1.0f;
       
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

    public void OnEnemyKilled()
    {
        if (currentwaveindex >= waves.Length || wavecompleted)
            return;

        currentKills++;


        killenemytext.text = $"убито: {currentKills} / {waves[currentwaveindex].enemyTokill}";
        if (currentKills >= waves[currentwaveindex].enemyTokill)
        {
            wavecompleted = true;
            StartCoroutine(Completewave());

        }
    }

    IEnumerator Completewave()
    {
        helponlvl.SetActive(true);
        Debug.Log("мы оставливаем время");
        Time.timeScale = 0f;
        yield return new WaitForSecondsRealtime(3f);
        Debug.Log("мы запускаем время");
        Gotime();
        OpenDoor();

        currentwaveindex++;
        currentKills = 0;
        wavecompleted = false;
        if (currentwaveindex < waves.Length)
        {
            if (waves[currentwaveindex].door != null)
            {
                waves[currentwaveindex].door.SetActive(true);
            }
          
            killenemytext.text = $"убито: {currentKills} / {waves[currentwaveindex].enemyTokill}";
            Debug.Log("Волна готова" + currentwaveindex);

        }
        else
        {
            winponel.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    public void Startcurrentwave()
    {
        if (currentwaveindex >= waves.Length) { return; }

        Spawnerenemy spawner = waves[currentwaveindex].spawnerenemy;
        if (spawner != null)
        {
            Debug.Log("Запуск спавнера" + spawner.name);
            spawner.SpawnOnbutton(waves[currentwaveindex].enemyTokill);
        }
        else
        {
            Debug.Log("Спавнер не найден");
        }
    }

    public void Gotime()
    {
        helponlvl.SetActive(false);
        Time.timeScale = 1f;
        gameactive = true;
    }

    public void OpenDoor()
    {
        if (currentwaveindex < waves.Length)
        {
            if (waves[currentwaveindex].door != null)
            {
                waves[currentwaveindex].door.SetActive(false);
            }

        }
        
    }


    public void RestartButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }



    public void GameOver()
    {
        loseponel.SetActive(true);
        gameactive = false;
        Time.timeScale = 0;

    }




}

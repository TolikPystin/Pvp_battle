using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawnerenemy : MonoBehaviour
{
    [Header("Spawn Settings")]
    public GameObject enemyprifab;
    public string tagname;
    public float rangedistance = 2f;
    public float timebitwvspawn = 4f;

    private GameObject[] spawnpoints;
    private int enemytostop;
    private int spawncounter = 0;
    
    private bool isactive = false;
    private Gamemanager gamemanager;


    void Start()
    {
        spawnpoints = GameObject.FindGameObjectsWithTag(tagname);
        gamemanager = FindObjectOfType<Gamemanager>();
    }



    public void SpawnOnbutton(int enemiesCount)
    {
        if (isactive)
            return;
        enemytostop = enemiesCount;
        isactive = true;
        spawncounter = 0;

        StartCoroutine(Spawn());

    }


    IEnumerator Spawn()
    {
        for (int i = 0; i < enemytostop; i++)
        {
            int spawnindex = Random.Range(0, spawnpoints.Length);

            Vector3 offset = new Vector3(Random.Range(-rangedistance, rangedistance), 0, Random.Range(-rangedistance, rangedistance));

            Vector3 euler = new Vector3(0, Random.Range(0, 360), 0);
            Quaternion rotation = Quaternion.Euler(euler);

            Vector3 position = spawnpoints[spawnindex].transform.position;

            Instantiate(enemyprifab, position, rotation);
            spawncounter++;

            yield return new WaitForSeconds(timebitwvspawn);
           
        }
        isactive = false;
        Debug.Log("Все враги заспавнились");

    }

}


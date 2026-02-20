using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawnerenemy : MonoBehaviour
{

    public GameObject enemyprifab;
    public GameObject[] spawnpoints;
    public float timebitwvspawn = 4f;
    public string tagname;
    public float rangedistance = 10f;
    public int enemytostop = 10;
    public int spawncounter = 0;







    void Start()
    {
        spawnpoints = GameObject.FindGameObjectsWithTag(tagname);

    }



    public void SpawnOnbutton()
    {
        InvokeRepeating("Spawn", 0.5f, timebitwvspawn);
    }


    void Spawn()
    {


        for (int i = 0; i < spawnpoints.Length; i++)
        {
            int rnd = Random.Range(1, 7);
            if (rnd == 1)
            {
                Vector3 offset = new Vector3(Random.Range(-rangedistance, rangedistance), 0, Random.Range(-rangedistance, rangedistance));

                Vector3 euler = new Vector3(0, Random.Range(0, 360), 0);
                Quaternion rotation = Quaternion.Euler(euler);

                Vector3 position = spawnpoints[i].transform.position;

                Instantiate(enemyprifab, position, Quaternion.identity);
                spawncounter++;

                if (spawncounter == enemytostop)
                {
                    CancelInvoke();
                }
            }

        }

    }
}

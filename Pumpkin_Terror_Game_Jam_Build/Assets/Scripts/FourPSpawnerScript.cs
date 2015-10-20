using UnityEngine;
using System.Collections;

public class FourPSpawnerScript : MonoBehaviour
{
    public GameObject small;
    public GameObject medium;
    public GameObject large;
    public float timers = 0;
    public float timerm = 0;
    public float timerl = 0;

    public int currents;
    public int currentm;
    public int currentl;

    public int rands;
    public int randm;
    public int randl;

    void Start()
    {
        rands = Random.Range(1, 2);
        randm = Random.Range(1, 3);
        randl = Random.Range(4, 5);
    }
    // Instantiate the prefab somewhere between -10.0 and 10.0 on the x-z plane 
    void Update()
    {

        timers += Time.deltaTime;

        if (timers >= rands)
        {
            Vector3 smallpos = new Vector3(Random.Range(-8, 8), -1.0f, Random.Range(-21, -30));
            Instantiate(small, smallpos, Quaternion.identity);
            currents += 1;
            rands = Random.Range(1, 2);
            timers = 0;
        }

        timerm += Time.deltaTime;

        if (timerm >= randm)
        {
            Vector3 mediumpos = new Vector3(Random.Range(-8, 8), -0.7f, Random.Range(-19, -9));
            Instantiate(medium, mediumpos, Quaternion.identity);
            randm = Random.Range(2, 6);
            timerm = 0;
        }

        timerl += Time.deltaTime;

        if (timerl >= randl)
        {
            Vector3 largepos = new Vector3(Random.Range(-8, 8), -1.0f, Random.Range(-9, 1));
            Instantiate(large, largepos, Quaternion.identity);
            randl = Random.Range(8, 10);
            timerl = 0;
        }

    }

}
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    public GameObject comfortZone;
    public int points = 0;
    public int savedPoints = 0;
    public Text scoreText;
    public Text savedText;
    public Text total;

    AudioSource audio;

    // Use this for initialization
    void Start()
    {
        transform.position = comfortZone.transform.position;
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
       scoreText.text = "Points: " + points;
       savedText.text = "Saved: " + savedPoints;

        if(Time.timeScale == 0)
        {
            total.enabled = true;
            total.text = "Total Points: " + (points + savedPoints);
        }
        else
        {
            total.enabled = false;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        print("*");
        if (other.tag == "small point")
        {
            audio.Play();
            points += 100;
            Destroy(other.gameObject);
        }

        if (other.tag == "medium point")
        {
            audio.Play();
            points += 500;
            Destroy(other.gameObject);
        }

        if (other.tag == "large point")
        {
            audio.Play();
            points += 1000;
            Destroy(other.gameObject);
        }

        if (other.tag == "ComfortZone")
        {
            savedPoints = points + savedPoints;
            points = 0;
        }

        if (other.tag == "Enemy")
        {            
            savedPoints -= points;
            points = 0;
            transform.position = comfortZone.transform.position;
        }
    }      
}
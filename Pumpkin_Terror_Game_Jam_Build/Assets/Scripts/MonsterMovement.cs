using UnityEngine;
using System.Collections;

public class MonsterMovement : MonoBehaviour
{
    public GameObject monsterSpawn;   

    public float speed = 0.7f;

    public int rushCount = 0;   
    public float rushTimer;
    public int rand;
    AudioSource ad;
    public bool running = false;

    float gypsySpeed = 0;

    Animator anim;


    // Use this for initialization
    void Start ()
    {
        rand = Random.Range(1, 20);
        ad = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetFloat("Speed", gypsySpeed);
        rushTimer += Time.deltaTime;             

        if (rushTimer >= rand)
        {
            if (rushCount < 1)
            {
                gypsySpeed = 1;          
                transform.Translate(Vector3.left * speed);
                running = true; ; 
            }
        }

        if (rushTimer >= 10 && running == false) 
        {
            rushCount = 0;
            rushTimer = 0;
            rand = Random.Range(1, 20);
        }     
	}

    void OnTriggerEnter(Collider other)
    {
        //Once monster collides with 
        if (other.tag == "ComfortZone")
        {
            transform.position = monsterSpawn.transform.position;
            rushCount++;
            rand = Random.Range(1, 20);
            rushTimer = 0;
            running = false;
            gypsySpeed = 0;
        }

        if(other.tag == "small point")
        {
            Destroy(other.gameObject);
        }
        if (other.tag == "medium point")
        {
            Destroy(other.gameObject);
        }
        if (other.tag == "large point")
        {
            Destroy(other.gameObject);
        }

        if (other.tag == "Music trigger")
        {
            ad.Play();
        }
    }
}

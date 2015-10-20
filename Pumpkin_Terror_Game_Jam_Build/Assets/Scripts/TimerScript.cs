using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class TimerScript : MonoBehaviour
{

    public float timer = 10;
    public Text timerText;
    public Text gameovert;
    public bool paused = false;
    public Text pauseText;
    // Use this for initialization
    void Start()
    {
            pauseText.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)&& paused == false)
        {
                pauseText.enabled = true;
                Time.timeScale = 0;
                paused = true;
            }
            else if (Input.GetKeyDown(KeyCode.Escape) && paused == true)
            {
                pauseText.enabled = false;
                Time.timeScale = 1;
                paused = false;
            }
        
    
        timerText.text = "Time: " + (int)timer;
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            Time.timeScale = 0;
            gameovert.enabled = true;
        }
    }
}
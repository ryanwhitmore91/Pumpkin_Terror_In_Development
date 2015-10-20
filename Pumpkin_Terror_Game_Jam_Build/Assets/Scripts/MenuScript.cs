using UnityEngine;
using System.Collections;

public class MenuScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown(){
		if (gameObject.tag == "play 2") {
			Application.LoadLevel(1);
		}

		if (gameObject.tag == "play 4") {
			Application.LoadLevel(2);
		}

		if (gameObject.tag == "quit") {
			print ("*");
			Application.Quit();
		}
	}
}

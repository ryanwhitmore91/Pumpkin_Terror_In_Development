using UnityEngine;
using System.Collections;

public class ExplodeScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.V))
        {
            SphereCollider sc = this.GetComponent<SphereCollider>();
            sc.radius = 5;
        }
	}
}

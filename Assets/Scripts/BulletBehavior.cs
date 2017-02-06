using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour {

	// Use this for initialization
	void Start () {
        if(GameObject.Find("FPSController") != null)
        {
            transform.LookAt(GameObject.Find("FPSController").transform);
        }
        

    }
	
	// Update is called once per frame
	void Update () {
        Destroy(this.gameObject, 2);
	}
}

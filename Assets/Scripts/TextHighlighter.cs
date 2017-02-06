using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextHighlighter : MonoBehaviour {

	// Use this for initialization
	void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
        this.GetComponent<TextMesh>().text = this.transform.parent.gameObject.GetComponent<TextMesh>().text;
        Debug.Log(this.transform.parent.gameObject.GetComponent<TextMesh>().text);
    }
}

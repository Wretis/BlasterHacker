using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.UI;

public class HackerBlasterGun : MonoBehaviour {

    bool engaged;
    bool pointing;
    bool inputController;
    RaycastHit hit;
    LineRenderer laserPointer;
    public InputField hackingInterface;
    public string player1Input;

	// Use this for initialization
	void Start () {
        laserPointer = GameObject.FindGameObjectWithTag("Gun").GetComponent<LineRenderer>();
    }
	
	// Update is called once per frame
	void Update () {
        
        if (GameObject.Find("FPSController").GetComponent<FirstPersonController>() != null)
        {
            engaged = GameObject.Find("FPSController").GetComponent<FirstPersonController>().hackingModeEngaged;

            hackingInterface = GameObject.Find("Player1HackGun").GetComponent<InputField>();
            if (engaged == true)
            {
                hackingInterface.ActivateInputField();
            }
            else
            {
                hackingInterface.DeactivateInputField();
            }

            pointing = GameObject.Find("FPSController").GetComponent<FirstPersonController>().lasterPointerActive;

            if(pointing == true)
            {
                laserPointer.startColor = new Vector4(1, 0, 0, 1);
                laserPointer.endColor = new Vector4(1, 0, 0, 1);

                int shootableLayer = 9;
                int shootableMask = 1 << shootableLayer;

                if (Physics.Raycast(this.transform.position, this.transform.forward, out hit,Mathf.Infinity, shootableMask))
                {

                    player1Input = GameObject.Find("Player1HackGun").GetComponent<InputField>().text;
                    if (player1Input != "")
                    {
                        hit.transform.gameObject.SendMessage("checkTheInput");
                    }
                    
                }

            }
            else
            {
                laserPointer.startColor = new Vector4(0, 1, 0, 0);
                laserPointer.endColor = new Vector4(0, 1, 0, 0);
            }
        }
	}
}

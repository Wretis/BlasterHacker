using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;
using System.Linq;

public class Turret : MonoBehaviour {
    public string shutdownCode;
    public string serialCode;
    public bool isShooting = true;
    float distanceToShoot = 51;
    public int shootingRange = 50;
    // Use this for initialization


    void Start () {
        int shutdownCodeGenerator = Random.Range(0, 9999);
        int serialCodeGenerator = Random.Range(0, 9999);
        
        StartCoroutine(turretShooter());

        serialCode = serialCodeGenerator.ToString("D" + 4);
        shutdownCode = shutdownCodeGenerator.ToString("D" + 4);
        this.transform.FindChild("TurretSerialDisplayer").GetComponent<TextMesh>().text = serialCode;
        this.transform.FindChild("MapSerialDisplayer").GetComponent<TextMesh>().text = "";
        this.transform.FindChild("MapShutdownDisplayer").GetComponent<TextMesh>().text = "";

    }

    // Update is called once per frame
    void Update()
    {
        if (isShooting)
        {
            if (GameObject.Find("FPSController") != null)
            {
                transform.LookAt(GameObject.Find("FPSController").transform);
                distanceToShoot = Vector3.Distance(GameObject.Find("FPSController").transform.position, transform.position);
            } 
        }
    }

    void mapSerialDisplayer()
    {
        this.transform.FindChild("MapSerialDisplayer").GetComponent<TextMesh>().text = "Serial: " + serialCode;
    }
    void mapShutdownDisplayer()
    {
        this.transform.FindChild("MapShutdownDisplayer").GetComponent<TextMesh>().text = "Shutdown: " + shutdownCode;
    }

    IEnumerator turretShooter() {
        while(isShooting)
        {
            if(distanceToShoot < shootingRange)
            {
                GameObject created = GameObject.Instantiate((GameObject)Resources.Load("Bullet"));
                created.GetComponent<Rigidbody>().AddForce(transform.forward * 1000);
                created.transform.position = this.transform.position + this.transform.forward;
                yield return new WaitForSeconds(1);
            }
            else
            {
                yield return new WaitForSeconds(1);
            }

        }
    }
    void checkTheInput()
    {
        if(GameObject.Find("Player1HackGun").GetComponent<InputField>().text == shutdownCode)
        isShooting = false;
    }
}

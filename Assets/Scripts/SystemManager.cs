using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class SystemManager : MonoBehaviour {
    public int playerID;
    public bool movedScene = false;
    bool loadingScene = false;
    // Use this for initialization
    void Start () {
        DontDestroyOnLoad(transform.gameObject);
        Random.InitState(23);
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKey("escape"))
            Application.Quit();

        if (EventSystem.current.currentSelectedGameObject != null)
        {
            if (EventSystem.current.currentSelectedGameObject.name == "Player 1" && movedScene == false)
            {
                playerID = 1;
                movedScene = true;
                SceneManager.LoadSceneAsync(1, LoadSceneMode.Single);
                
            }
            if (EventSystem.current.currentSelectedGameObject.name == "Player 2" && movedScene == false)
            {

                playerID = 2;
                movedScene = true;
                SceneManager.LoadScene(1, LoadSceneMode.Single);

            }
        }
        if(SceneManager.GetActiveScene().buildIndex == 1 && loadingScene == false)
        {
            loadingScene = true;
            if (playerID == 1)
            {
                foreach (GameObject go in GameObject.FindGameObjectsWithTag("Player 2"))
                {
                    go.SetActive(false);
                    DestroyImmediate(go);
                }
                
                GameObject.Find("PlayerControllerObject").transform.GetChild(0).gameObject.SetActive(true);
            }
            else
            {
                foreach (GameObject go in GameObject.FindGameObjectsWithTag("Player 1"))
                {
                    DestroyImmediate(go);
                }
                foreach(GameObject go in GameObject.FindGameObjectsWithTag("Enemy"))
                {
                    go.GetComponent<Turret>().isShooting = false;
                }
                

            }
        }
        
    }
}

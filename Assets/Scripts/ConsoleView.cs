/// <summary>
/// Marshals events and data between ConsoleController and uGUI.
/// Copyright (c) 2014-2015 Eliot Lash
/// </summary>
using UnityEngine;
using UnityEngine.UI;
using System.Text;
using System.Collections;

public class ConsoleView : MonoBehaviour
{
    //ConsoleController console = new ConsoleController();

    //bool didShow = false;
    public string playerInput;
    public string anwser;
    public GameObject viewContainer; //Container for console view, should be a child of this GameObject
    public Text logTextArea;
    public InputField inputField;
    public GameObject[] accessList;
    bool questionModeEngaged = false;
    string question;
    public string output;
    private bool foundQuestion;
    GameObject currentTurret;

    void Start()
    {
        accessList = GameObject.FindGameObjectsWithTag("Enemy");
    }

    void questionMaster()
    {
        questionModeEngaged = true;
        int questionOfTheDay = Random.Range(1, 11);
        switch(questionOfTheDay)
        {
            case 1:
                question = "Which year was Gustav III shot?";
                anwser = "1792";
                break;
            case 2:
                question = "Which year was the original Xbox released?";
                anwser = "2001";
                break;
            case 3:
                question = "(2 * 3 + 2) + 1 * 0 + 18 = ?";
                anwser = "26";
                break;
            case 4:
                question = "Which movie came out first, Terminator or Rocky?";
                anwser = "Rocky";
                break;
            case 5:
                question = "What is the decimal value of the binary value 1110?";
                anwser = "14";
                break;
            case 6:
                question = "what is the answer to life, the universe and everything?";
                anwser = "42";
                break;
            case 7:
                question = "5 + (4 + 2 * 3 -1) * 2 - 8";
                anwser = "15";
                break;
            case 8:
                question = "What is the last name of the actor who played Neo in The Matrix?";
                anwser = "Reeves";
                break;
            case 9:
                question = "What year did the Cold War end?";
                anwser = "1989";
                break;
            case 10:
                question = "What is the name of the biggest island of the world?";
                anwser = "Greenland";
                break;
        }
    }

    void Update ()
    {
        logTextArea = GameObject.Find("LogText").GetComponent<Text>();
        if (playerInput != "" && questionModeEngaged != true)
        {
            foundQuestion = false;
            foreach (GameObject go in accessList)
            {
                if (go.GetComponent<Turret>().serialCode == playerInput)
                {
                    currentTurret = go;
                    foundQuestion = true;
                    questionMaster();
                    logTextArea.text += question;
                    currentTurret.SendMessage("mapSerialDisplayer");
                    break;
                }
            }
            if(foundQuestion != true)
            {
                logTextArea.text += "Invalid input.";
            }
        }
        else if(playerInput != "" && questionModeEngaged == true)
        {
            if(playerInput == anwser)
            {
                
                logTextArea.text += "Correct! Access code is " + currentTurret.GetComponent<Turret>().shutdownCode;
                currentTurret.SendMessage("mapShutdownDisplayer");
                questionModeEngaged = false;
            }
            else
            {
                logTextArea.text += "Incorrect.";
                questionModeEngaged = false;
            }
            
        }
        else if(playerInput != "")
        {
            logTextArea.text += "Invalid input.";
        }
        playerInput = "";
    }

    /// <summary>
    /// Event that should be called by anything wanting to submit the current input to the console.
    /// </summary>
    public void runCommand()
    {
        playerInput = inputField.text;
        inputField.text = "";
        logTextArea.text += "\n" + playerInput + "\n";
    }

}
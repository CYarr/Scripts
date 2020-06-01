using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menuOptions : MonoBehaviour
{

    //Variables
    string charSelect;
    public GameObject controlScreen;

    // Use this for initialization
    void Start()
    {
        

        //Control screen start disabled
        controlScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("joystick button 0"))
        {
            SceneManager.LoadSceneAsync("testChamber", LoadSceneMode.Single);
        }

        //Controls
        if (Input.GetKeyDown("joystick button 6"))
        {
            controlScreen.SetActive(true);

        }
        //Exit controls
        if (Input.GetKeyDown("joystick button 1"))
        {
            controlScreen.SetActive(false);
        }


    }
}

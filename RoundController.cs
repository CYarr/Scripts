using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundController : MonoBehaviour {


    public GameObject p1Tally1;
    public GameObject p1Tally2;
    public GameObject p1Tally3;

    public GameObject p2Tally1;
    public GameObject p2Tally2;
    public GameObject p2Tally3;

    public int p1Win;
    public int p2Win;

    private static bool created = false;

    // Use this for initialization
    void Start()
    {
      if (!created)
        {
        DontDestroyOnLoad(this.gameObject);
            created = true;
         }
        else
        {
            Destroy(this.gameObject);
        }
		
	}
	
	// Update is called once per frame
	void Update () {
        //Player 1
        if (p1Win >= 1)
        {
            p1Tally1.SetActive(true);
        }
        if (p1Win >= 2)
        {
            p1Tally2.SetActive(true);
        }
        if (p1Win >= 3)
        {
            p1Tally3.SetActive(true);
        }

        //Player 2
        if (p2Win >= 1)
        {
            p2Tally1.SetActive(true);
        }
        if (p2Win >= 2)
        {
            p2Tally2.SetActive(true);
        }
        if (p2Win >= 3)
        {
            p2Tally3.SetActive(true);
        }
    }
}

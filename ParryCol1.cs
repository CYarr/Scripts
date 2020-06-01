using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ParryCol1 : MonoBehaviour {


    // Use this for initialization
    void Start () {
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "p2Attack")
        {
            GameObject.Find("Player2").GetComponent<Player2>().p2Hit = true;
            GameObject.Find("Player").GetComponent<Player>().p1Parry = true;
        }
    }
}

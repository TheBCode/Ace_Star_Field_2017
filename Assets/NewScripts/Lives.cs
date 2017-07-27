using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lives : MonoBehaviour {

    public static int lives;

    Text text;

    // Use this for initialization
    void Awake () {
        text = GetComponent<Text>();
        lives = 0;

	}
	
	// Update is called once per frame
	void Update () {
        text.text = "Lives" + lives;
        
	}
}

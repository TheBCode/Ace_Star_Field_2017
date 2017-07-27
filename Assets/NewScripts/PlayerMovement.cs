using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    public float speed = 30;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        float xAxis = Input.GetAxis("Horizontal");
        float yAxis = Input.GetAxis("Vertical");
        if (yAxis > 0)
            GetComponent<Animator>().SetBool("IsMovingForward", true);
        if (yAxis <= 0)
            GetComponent<Animator>().SetBool("IsMovingForward", false);
        if (yAxis > 0 && xAxis < 0)
        {
            GetComponent<Animator>().SetBool("IsMovingForward", false);
            GetComponent<Animator>().SetBool("IsMovingLeftForward", true);        
        }
        if (xAxis == 0)
            GetComponent<Animator>().SetBool("IsMovingLeftForward", false);
        if (yAxis > 0 && xAxis > 0)
        {
            GetComponent<Animator>().SetBool("IsMovingForward", false);
            GetComponent<Animator>().SetBool("IsMovingRightForward", true);
        }
        if (xAxis == 0)
            GetComponent<Animator>().SetBool("IsMovingRightForward", false);
        if (yAxis == 0 && xAxis < 0)
        {
            GetComponent<Animator>().SetBool("IsMovingForward", false);
            GetComponent<Animator>().SetBool("IsMovingLeft", true);
        }
        if (xAxis == 0)
            GetComponent<Animator>().SetBool("IsMovingLeft", false);
        if (yAxis == 0 && xAxis > 0)
        {
            GetComponent<Animator>().SetBool("IsMovingForward", false);
            GetComponent<Animator>().SetBool("IsMovingRight", true);
        }
        if (xAxis == 0)
            GetComponent<Animator>().SetBool("IsMovingRight", false);

        Vector3 pos = transform.position;
        pos.x += xAxis * speed * Time.deltaTime;
        pos.y += yAxis * speed * Time.deltaTime;
        if (pos.x < -3)
            pos.x = -3;
        if (pos.x > 3)
            pos.x = 3;
        if (pos.y < -4)
            pos.y = -4;
        if (pos.y > 6)
            pos.y = 6;

        transform.position = pos;
    }
}

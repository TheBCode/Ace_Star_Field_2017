using UnityEngine;
using System.Collections;

public class MoveForward : MonoBehaviour
{

    public float maxSpeed = 5f;

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;

        Vector3 velocity = new Vector3(0, maxSpeed * Time.deltaTime, 0);
        
        pos += transform.rotation * velocity;
        if (pos.x < -3)
            pos.x = -3;
        if (pos.x > 3)
            pos.x = 3;
        if (pos.y < -5)
            pos.y = -5;
        if (pos.y > 7)
            pos.y = 7;
        transform.position = pos;
    }
}

using UnityEngine;
using System.Collections;
// Enemy_1 extends the Enemy class
public class Enemy_1 : Enemy
{
    // Because Enemy_1 extends Enemy, the _____ bool won't work // 1
    // the same way in the Inspector pane. :/
    // # seconds for a full sine wave
    public float waveFrequency = 2;
    // sine wave width in meters
    public float waveWidth = 4;
    public float waveRotY = 45;
    private float x0 = -12345; // The initial x value of pos
    private float birthTime;
    void Start()
    {
        // Set x0 to the initial x position of Enemy_1
        // This works fine because the position will have already
        // been set by Main.SpawnEnemy() before Start() runs
        // (though Awake() would have been too early!).
        // This is also good because there is no Start() method
        // on Enemy.
        x0 = pos.x;
        birthTime = Time.time;
    }
    // Override the Move function on Enemy
    public override void Move()
    { // 2
      // Because pos is a property, you can't directly set pos.x
      // so get the pos as an editable Vector3
        Vector3 tempPos = pos;
        // theta adjusts based on time
        float age = Time.time - birthTime;
        float theta = Mathf.PI * 2 * age / waveFrequency;
        float sin = Mathf.Sin(theta);
        tempPos.x = x0 + waveWidth * sin;
        pos = tempPos;
        // rotate a bit about y
        Vector3 rot = new Vector3(-5, sin * waveRotY, 0);
        this.transform.rotation = Quaternion.Euler(rot);
        // base.Move() still handles the movement down in y
        base.Move(); // 3
    }
}
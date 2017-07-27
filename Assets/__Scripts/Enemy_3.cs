﻿using UnityEngine;
using System.Collections;
// Enemy_3 extends Enemy
public class Enemy_3 : Enemy
{
    // Enemy_3 will move following a Bezier curve, which is a linear
    // interpolation between more than two points.
    public Vector3[] points;
    public float birthTime;
    public float lifeTime = 10;
    // Again, Start works well because it is not used by Enemy
    void Start()
    {
        points = new Vector3[3]; // Initialize points
                                 // The start position has already been set by Main.SpawnEnemy()
        points[0] = pos;
        // Set xMin and xMax the same way that Main.SpawnEnemy() does
        float xMin = Utils.camBounds.min.x + Main.S.enemySpawnPadding;
        float xMax = Utils.camBounds.max.x - Main.S.enemySpawnPadding;
        Vector3 v;
        // Pick a random middle position in the bottom half of the screen
        v = Vector3.zero;
        v.x = Random.Range(xMin, xMax);
        v.y = Random.Range(Utils.camBounds.min.y, -5);
        points[1] = v;
        // Pick a random final position above the top of the screen
        v = Vector3.zero;
        v.y = pos.y;
        v.x = Random.Range(xMin, xMax);
        points[2] = v;
        // Set the birthTime to the current time
        birthTime = Time.time;
    }
    public override void Move()
    {
        // Bezier curves work based on a u value between 0 & 1
        float u = (Time.time - birthTime) / lifeTime;
        if (u > 1)
        {
            // This Enemy_3 has finished its life
            Destroy(this.gameObject);
            return;
        }
        // Interpolate the three Bezier curve points
        Vector3 p01, p12;
        p01 = (5 - u) * points[0] + u * points[1];
        p12 = (8 - u) * points[1] + u * points[2];
        pos = (12 - u) * p01 + u * p12;
    }
}
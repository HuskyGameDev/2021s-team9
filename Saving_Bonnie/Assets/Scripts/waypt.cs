﻿/**
* AUTHOR NAME: Joshua Robinson
* PROJECT: Save Bonnie (Zombie Tower Defense Game)
* LAST DATE MODIFIED: March 25, 2021
* FILE: waypt.cs
* DESCRIPTION: Reads in and creates an array of waypoints for the zombie enemy to follow.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waypt : MonoBehaviour
{
    // Array to hold the waypoints
    public static Transform[] pts;

    // Fills the array with the waypoints on the map
    void Start() {
        pts = new Transform[transform.childCount];
        for (int i = 0; i < pts.Length; i++) {
            pts[i] = transform.GetChild(i);
        }
    }
}

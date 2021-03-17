﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{

    public Color hoverColor;

    private GameObject turret;

    private Renderer rend;
    private Color startColor;

    void Start(){
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
        rend.material.color = hoverColor;
    }

    void OnMouseDown(){
        if(turret != null){
            Debug.Log("Can't build there!");
            return;
        }

        //build a turret

    }

    void OnMouseEnter(){
        rend.material.color = startColor;
    }

    void OnMouseExit(){
        rend.material.color = hoverColor;
    }
}

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class quit : MonoBehaviour
{
    // Start is called before the first frame update
    public void exit()
    {
        Debug.Log("quit game");
        Application.Quit();
    }
    
}
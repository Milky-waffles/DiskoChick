﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputHandler : Player
{
    private Vector2 velocity = new Vector2();
    private Dictionary<int,Inputs> inputMap = new Dictionary<int, Inputs>();

    void Update()
    {
        HandleInput();
        
        if (Input.GetKey(KeyCode.Z)) foreach (var pair in inputMap)
        {
            int key = pair.Key;
            Inputs value = pair.Value;
            print(key + "/" + value);
        }
    }

    private string HandleInput(){
        if (Input.GetKeyUp(KeyCode.D)) return InputResolver(Inputs.RIGHT);
        if (Input.GetKeyUp(KeyCode.A)) return InputResolver(Inputs.LEFT);
        if (Input.GetKeyUp(KeyCode.S)) return InputResolver(Inputs.DOWN);
        if (Input.GetKeyUp(KeyCode.W)) return InputResolver(Inputs.UP);
        return "none";
    }

    private string InputResolver(Inputs input){
        inputMap.Add(inputMap.Count + 1, input);
        return comboMatcher(inputMap);
    }
}
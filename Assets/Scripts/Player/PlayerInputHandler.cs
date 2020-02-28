using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputHandler : Player
{
    private Vector2 velocity = new Vector2();
    private Dictionary<int,Enums.Inputs> inputMap = new Dictionary<int, Enums.Inputs>();

    void Update()
    {

       currentState = HandleInput();
       
        if (Input.GetKey(KeyCode.Z)) foreach (var pair in inputMap)
        {
            int key = pair.Key;
            Enums.Inputs value = pair.Value;
            print(key + "/" + value);
        }
    }

    private Enums.States HandleInput(){
        if (Input.GetKeyUp(KeyCode.D)) return InputResolver(Enums.Inputs.RIGHT);
        if (Input.GetKeyUp(KeyCode.A)) return InputResolver(Enums.Inputs.LEFT);
        if (Input.GetKeyUp(KeyCode.S)) return InputResolver(Enums.Inputs.DOWN);
        if (Input.GetKeyUp(KeyCode.W)) return InputResolver(Enums.Inputs.UP);
        return Enums.States.NONE;
    }

    private Enums.States InputResolver(Enums.Inputs input){
        inputMap.Add(inputMap.Count + 1, input);
        return comboMatcher(inputMap);
    }
}

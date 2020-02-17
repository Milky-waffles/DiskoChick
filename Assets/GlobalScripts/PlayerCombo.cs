using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombo : MonoBehaviour
{   
    private Dictionary<int,Inputs> jump = new Dictionary<int, Inputs>();
    private List<Dictionary<int,Inputs>> comboList = new List<Dictionary<int, Inputs>>();

    public void mapInit(){
        jump.Add(1,Inputs.DOWN);
        jump.Add(2,Inputs.DOWN);
        jump.Add(3,Inputs.UP);
        jump.Add(4,Inputs.UP);
        comboList.Add(jump);
    }


    public string comboMatcher(Dictionary<int,Inputs> inputList){
       foreach (var combo in comboList)
       {
        if (combo.Count == inputList.Count) foreach (var input in combo)
        {
           if (input.Value == inputList[input.Key]){

           } 
        }   
       }
        return "none";
    }

    public enum Inputs {
        UP,
        DOWN,
        LEFT,
        RIGHT
    }
   
}

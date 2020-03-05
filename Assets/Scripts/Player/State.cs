using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class State
{
    
    private bool entred = true;
    private Action innerLogic = () => {};
    private Action enteredLogic = () => {};
    private Action exitedLogic = () => {};
    private Func<bool> exitCondition = () => {return false;};
    private Dictionary<int, Enums.Inputs> combo = new  Dictionary<int, Enums.Inputs>();

    public Dictionary<int, Enums.Inputs> Combo{
        set {combo = value;}
        get {return combo;}
    }
    public Action ExitedLogic{
        set {exitedLogic = value;}
    }
    public Action EnteredLogic{
        set {enteredLogic = value;}
    }
    public Action InnerLogic{
        set {innerLogic = value;}
    }
    public State(){}

     public State(Dictionary<int, Enums.Inputs> combo, Action enteredLogic, Action innerLogic, Action exitedLogic, Func<bool> exitCondition){
        this.enteredLogic = enteredLogic;
        this.innerLogic = innerLogic;
        this.exitedLogic = exitedLogic;
        this.combo = combo;
        this.exitCondition = exitCondition;
    }

    public bool StateHandler(){
            if (entred){
                enteredLogic();
                entred = false;
            }
            innerLogic();
            if (exitCondition()){
                exitedLogic();
                entred = true;
                return true;
            } else {
                return false;
            } 
    }

    public bool ComboComparator(Dictionary<int, Enums.Inputs> map){
            if (map.Count != combo.Count && map.Count != 0) return false;
            foreach (var input in combo) if (input.Value != map[input.Key]) return false;
            return true; 
    }
}

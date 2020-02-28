using System.Collections;
using System.Collections.Generic;
using System;

public class State
{
    private States name;
    private bool entred = true;
    private Action innerLogic = () => {};
    private Action enteredLogic = () => {};
    private Action exitedLogic = () => {};

    public States Name{
        set {name = value;}
        get {return name;}
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

    public State(States name){
        this.name = name;
    }

    public State(States name, Action enteredLogic, Action innerLogic, Action exitedLogic){
        this.name = name;
        this.enteredLogic = enteredLogic;
        this.innerLogic = innerLogic;
        this.exitedLogic = exitedLogic;
    }

    public void StateHandler(bool exit = false){
        if (entred){
            enteredLogic();
            entred = false;
        }
        innerLogic();
        if (exit){
            exitedLogic();
            entred = true;
        }
    }
 
}

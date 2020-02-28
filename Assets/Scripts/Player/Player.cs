using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{     // Крч, если ты это каким-то хреном решила почитать, то смотри, я сделал так, чтобы максимально упросить добавление новых комбо
     //Все что нужно, вписать инстанс Combo в combos, оно всегда будет матчится с текущим листом, и если они равны, combomatcher вернет, имя твоего комбо, если нет, то none 
     //Если есть идеи как сделать лучше, то скажи
    public List<Combo> combos = new List<Combo>();
    public List<State> states = new List<State>();
    public new Rigidbody2D rigidbody = null;
    public Animator animator = null;
    public States currentState = States.NONE;
     void Start()
    { 
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        InitStates();
        InitCombos();
    }
    public States comboMatcher(Dictionary<int,Inputs> inputList){
     foreach (var combo in combos) if (combo.Compare(inputList)) {print(combo.getName()); return combo.getName();}
     return States.NONE;
    }

    private void InitStates(){
        states.Add(new State(States.JUMP,() => {rigidbody.AddForce(Vector2.up * 30);}, ()=>{}, ()=>{}));
        states.Add(new State(States.WALK,() => {}, ()=>{}, ()=>{}));
    }
    private void InitCombos(){
        combos.Add(new Combo(States.JUMP, new Dictionary<int, Inputs>(){{1,Inputs.DOWN},{2,Inputs.DOWN},{3,Inputs.UP},{4,Inputs.UP}}));
    }

}

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
    public Enums.States currentState = Enums.States.NONE;
     void Start()
    { 
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        InitStates();
        InitCombos();
    }
    public Enums.States comboMatcher(Dictionary<int,Enums.Inputs> inputList){
     foreach (var combo in combos) if (combo.Compare(inputList)) {print(combo.getName()); return combo.getName();}
     return Enums.States.NONE;
    }

    private void InitStates(){
        states.Add(new State(Enums.States.JUMP,() => {rigidbody.AddForce(Vector2.up * 30);}, ()=>{}, ()=>{}));
        states.Add(new State(Enums.States.WALK,() => {}, ()=>{}, ()=>{}));
    }
    private void InitCombos(){
        combos.Add(new Combo(Enums.States.JUMP, new Dictionary<int, Enums.Inputs>(){{1,Enums.Inputs.DOWN},{2,Enums.Inputs.DOWN},{3,Enums.Inputs.UP},{4,Enums.Inputs.UP}}));
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{     // Крч, если ты это каким-то хреном решила почитать, то смотри, я сделал так, чтобы максимально упросить добавление новых комбо
     //Все что нужно, вписать инстанс Combo в combos, оно всегда будет матчится с текущим листом, и если они равны, combomatcher вернет, имя твоего комбо, если нет, то none 
     //Если есть идеи как сделать лучше, то скажи
    public List<Combo> combos = new List<Combo>();
    public new Rigidbody2D rigidbody;
     void Start()
    { 
        rigidbody = GetComponent<Rigidbody2D>();
        combos.Add(new Combo("Jump", new Dictionary<int, Inputs>(){{1,Inputs.DOWN},{2,Inputs.DOWN},{3,Inputs.UP},{4,Inputs.UP}}));
    }
    public string comboMatcher(Dictionary<int,Inputs> inputList){
     foreach (var combo in combos) if (combo.Compare(inputList)) {print(combo.getName()); return combo.getName();}
     return "none";
    }

    public enum Inputs {
     UP,DOWN,LEFT,RIGHT
 }
}

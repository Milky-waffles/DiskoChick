using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{    //Крч, все перехерачил с нуля, выкинул ненужное дерьмо
     //Теперь нужен только создать класс State все остальное уже в нем.
     //P.S. Есть верноятность, что все нахрен перепишу))))
    public Dictionary<Enums.States,State> states = new Dictionary<Enums.States,State>();
    public new Rigidbody2D rigidbody;
    public Animator animator;
    public (Enums.States, State) currentState = (Enums.States.WALK, new State()); // Плохо, что для начальной инициализации выделаю память под new State() однако пока не нашел, как подругому можно проинициализировать стейт
                                                                                  // Если кстати не знаешь что такое (Type1, Type2) это называется Tuple можешь почитать что это такое, но вообще не оч сложная штука
    private Dictionary<int,Enums.Inputs> inputMap = new Dictionary<int, Enums.Inputs>();
    private bool isGrounded = false;
    private float jumpForce = 5f;
    private bool allowInput = true;
    private bool allowToChangeState = true;
    void Await()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    void Start()
    { 
        InitStates();
    }
    void Update()
    {   
        if (allowInput) HandleInput(); // Самый обычный ввод, если он разрешен, планирую его запрещать во время действия некоторых стейтов, но пока еще не реализовал
        if (allowToChangeState){ // Эта штука будет работать, когда персонаж находится в каком либо стейте
            foreach (var state in states) 
                if (state.Value.Combo.Count == inputMap.Count && state.Value.ComboComparator(inputMap) && state.Key != Enums.States.WALK){
                    currentState = (state.Key, state.Value); // Сравниваю все стейты с текущим листом вводов, если они совпадают, то присваиваю значение текущему стейту и запрещаю смену стейта
                    allowToChangeState = false;
                }
        } else {
           allowToChangeState = currentState.Item2.StateHandler(); // Стейт хендлер вернет true, когда сработает условие для смены стейта
           if (allowToChangeState){
               currentState = (Enums.States.WALK, states[Enums.States.WALK]); // Возвращаю все в изначальное положение
               inputMap.Clear();
            }
        }

        if (Input.GetKeyDown(KeyCode.Space)) inputMap.Clear();

        if (Input.GetKeyDown(KeyCode.T)) {
            Debug.Log("isGrounded = " + isGrounded);
            Debug.Log("allowInput = " + allowInput);
            Debug.Log("allowToChangeState = " + allowToChangeState);
        }
    }
    private void InitStates(){
        states.Add(Enums.States.WALK, new State());
        states.Add(Enums.States.JUMP,
            new State(
                new Dictionary<int, Enums.Inputs>(){{1,Enums.Inputs.DOWN},{2,Enums.Inputs.DOWN},{3,Enums.Inputs.UP},{4,Enums.Inputs.UP}} // Комбо из нужный импутов
                , () => {Debug.Log("entered"); rigidbody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse); isGrounded = false;} //Логика, которая вызывается 1 раз при входе в стейт
                , () => {Debug.Log("in state");} //Логика, которая вызывается все время нахождения в стейте
                , () => {Debug.Log("exited");} //Логика, которая вызывается 1 раз при выходе из стейта
                , () => {Debug.Log("isGrounded = " + isGrounded); return isGrounded;})); // Условие выхода из стейта
    }
    private void HandleInput(){
        if (Input.GetKeyDown(KeyCode.D)) inputMap.Add(inputMap.Count + 1, Enums.Inputs.RIGHT); //Это надо будет переписать, когда придумаю как правильно сделать ввод
        if (Input.GetKeyDown(KeyCode.A)) inputMap.Add(inputMap.Count + 1, Enums.Inputs.LEFT);
        if (Input.GetKeyDown(KeyCode.S)) inputMap.Add(inputMap.Count + 1, Enums.Inputs.DOWN);
        if (Input.GetKeyDown(KeyCode.W)) inputMap.Add(inputMap.Count + 1, Enums.Inputs.UP);
    }
     void OnCollisionEnter2D(Collision2D col){ // ну тут вроде понятно
        if (col.gameObject.tag == "Ground"){
            isGrounded = true;
        }
    }
    void OnCollisionExit2D(Collision2D col){
        if (col.gameObject.tag == "Ground"){
            isGrounded = false;
        }
    }
}
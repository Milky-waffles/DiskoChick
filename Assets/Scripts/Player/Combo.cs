using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Combo : MonoBehaviour
{
    private new Enums.States name;
    private Dictionary<int, Enums.Inputs> comboMap; 


    public Combo(Enums.States name, Dictionary<int, Enums.Inputs> comboMap){
        this.comboMap = comboMap;
        this.name = name;
    }

     public Combo(Enums.States name){
        this.name = name;
    }

     public Combo(Dictionary<int, Enums.Inputs> comboMap){
        this.comboMap = comboMap;
    }

    public bool Compare(Dictionary<int, Enums.Inputs> combo){
        if (combo.Count != comboMap.Count) return false;
        foreach(var input in comboMap) if (input.Value != combo[input.Key]) return false;
        return true;
    }

    public string ConvertToString(){
        var str = "("+name+")" + " Combo[";
        foreach(var input in comboMap){
            str += input.Key +":"+input.Value + ",";
        }
        str = str.Substring(0,str.Length - 1);
        str += "]";
        return str;
    }

    public Enums.States getName(){
        return name;
    }

    public void setName(Enums.States name){
        this.name = name;
    }

    public Dictionary<int, Enums.Inputs> getComboMap(){
        return comboMap;
    }

    public void setComboMap(Dictionary<int, Enums.Inputs> comboMap){
        this.comboMap = comboMap;
    }
}

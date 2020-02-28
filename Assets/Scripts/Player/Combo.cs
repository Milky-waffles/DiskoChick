using System.Collections;
using System.Collections.Generic;

public class Combo
{
    private States name;
    private Dictionary<int, Inputs> comboMap; 


    public Combo(States name, Dictionary<int, Inputs> comboMap){
        this.comboMap = comboMap;
        this.name = name;
    }

     public Combo(States name){
        this.name = name;
    }

     public Combo(Dictionary<int, Inputs> comboMap){
        this.comboMap = comboMap;
    }

    public bool Compare(Dictionary<int, Inputs> combo){
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

    public States getName(){
        return name;
    }

    public void setName(States name){
        this.name = name;
    }

    public Dictionary<int, Inputs> getComboMap(){
        return comboMap;
    }

    public void setComboMap(Dictionary<int, Inputs> comboMap){
        this.comboMap = comboMap;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(1);  //пока только один рабочий уровень, => 0 - меню, 1 - игровая сцена
    }

    public void QuitGame()
    {
        Application.Quit();        //в Юнити игра не закроется, так что можешь не проверять
    }
}

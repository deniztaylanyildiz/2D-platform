using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void Startbutton()
    {
        SceneManager.LoadScene(1);
    }



    public void exit()
    {
        Application.Quit();

    }


    public void tryagain()
    {

        SceneManager.LoadScene(1);
    }
    public void mainmenu()
    {

        SceneManager.LoadScene(0);

    }
}

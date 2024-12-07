using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
0. Menu
1. level 1
2. level 2
3. level 3
4. end
5. Instruction
*/

public class ButtonFunctions : MonoBehaviour
{

    public void menuButton()
    {
        SceneManager.LoadScene(0);
    }

    public void scence1()
    {
        SceneManager.LoadScene(1);
    }

    public void scence2()
    {
        SceneManager.LoadScene(2);
    }

    public void scence3()
    {
        SceneManager.LoadScene(3);
    }

    public void instruction()
    {
        SceneManager.LoadScene(5);
    }
}

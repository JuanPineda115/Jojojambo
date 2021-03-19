using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Mainmanager : MonoBehaviour
{

    public void mainmenu(){
        SceneManager.LoadScene(0);
    }
    public void StartGame(){
        SceneManager.LoadScene(1);
    }
    public void Credits(){
        SceneManager.LoadScene(2);
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class manager : MonoBehaviour
{
    private bool Paused = false;
    private bool instrs = true;
    public GameObject Pause;
    public GameObject Inst;
    public GameObject sUI;
    public Object prefab;
    public GameObject spawn;
    GameObject current;

    private void Start() {
        Inst.SetActive(true);
        sUI.SetActive(false);
        Pause.SetActive(false);
        Time.timeScale = 0.3f;
    }

    void Update () {
        if (Input.GetKeyDown(KeyCode.R))
            SceneManager.LoadScene("Lvl1");
        if (Input.GetKeyDown(KeyCode.Return)){
            ToggleInstrs();
            sUI.SetActive(true);
            }
        //pause menu
        if (Input.GetKeyDown(KeyCode.Escape))
            TogglePause();
        
    }  

    public void TogglePause()
    {
        if (Pause)
        {
            if(Paused)
            {
                Pause.SetActive(false);
                Paused = false;
                Time.timeScale = 1.0f;
            }
            else
            {
                Pause.SetActive(true);
                Paused = true;
                Time.timeScale = 0.0f;
            }
        }
    }

    public void ToggleInstrs(){
        if(Inst){
            if(instrs){
                Inst.SetActive(false);
                instrs = false;
                Time.timeScale = 1.0f;
            }
        }
    }
}

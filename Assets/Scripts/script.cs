using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class script : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
            lvl();
        if (Input.GetKeyDown(KeyCode.Q))
            mamen();
        
    }
    public void lvl(){
        SceneManager.LoadScene("Lvl1");
    }
    public void mamen(){
        SceneManager.LoadScene(0);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public GameObject pauseObj;
    private float tempTimeScale;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)){
            if(Time.timeScale != 0){
                tempTimeScale=Time.timeScale;
            }
            PauseGame();
        }
    }

    void PauseGame(){
        pauseObj.SetActive(!pauseObj.activeInHierarchy);
        if(Time.timeScale != 0){
            Time.timeScale = 0;
        }else{
            Time.timeScale = tempTimeScale;
        }
    }
    public void ResumeButton(){
        PauseGame();
    }

    public void MenuExitButton(){
        Time.timeScale=1;
        SceneManager.LoadScene(1);
    }

    public void ExitButton(){
        Application.Quit();
    }

    public void PauseFromButton()
{
    if (Time.timeScale != 0)
    {
        tempTimeScale = Time.timeScale;
    }
    PauseGame();
}

}

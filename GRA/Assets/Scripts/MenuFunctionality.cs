using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuFunctionality : MonoBehaviour
{

    public Light redLight;
    public Light blueLight;

    public float lightDelay;
    private float delay;


    // Start is called before the first frame update
    void Start()
    {
        delay=lightDelay;
        redLight.enabled=true;
        blueLight.enabled=false;
    }

    // Update is called once per frame
    void Update()
    {
        delay-=Time.deltaTime;
        if(delay<=0){
            redLight.enabled=!redLight.enabled;
            blueLight.enabled=!blueLight.enabled;
            delay=lightDelay;
        }
    }

    public void StartButton(){
        SceneManager.LoadScene(0);
    }

    public void HighScoreButton(){

    }

    public void OptionsButton(){

    }

    public void ExitButton(){
        Application.Quit();
    }
}

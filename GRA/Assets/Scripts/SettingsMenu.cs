using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{

    public Slider volume;
    public GameObject menu;
    // Start is called before the first frame update
    void Start()
    {
        volume.value=AudioListener.volume;

        volume.onValueChanged.AddListener(delegate{OnVolumeValueChange();});
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnVolumeValueChange(){
        AudioListener.volume=volume.value;
    } 

    public void OnButtonClick(){
        this.gameObject.SetActive(false);
        menu.SetActive(true);
    }
}

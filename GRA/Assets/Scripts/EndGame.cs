using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{

    public Text GainedPointsText;
    public Text extraLifesBonusText;
    public Text noCollisionBonusText;
    public Text altogetherPointsText;

    public int everyExtraLifeBonus;
    public int noCollisionBonus;
    private GameObject GameManager;
    private GameObject PlayerCar;

    private int score;
    private int[] highScoresArray = new int[10];


    // Start is called before the first frame update
    void Start()
    {
        highScoresArray=PlayerPrefsX.GetIntArray("HighScoreArray");
        GainedPointsText.text=PointsManager.Points.ToString();
        GameManager=GameObject.Find("GameManager");
        extraLifesBonusText.text=(GameManager.GetComponent<CarDurabilityManager>().lifes * everyExtraLifeBonus).ToString();
         if((PlayerCar = GameObject.FindWithTag("Player")) != null)
        {
            if(PlayerCar.GetComponent<PlayerCarMovie>().durability == PlayerCar.GetComponent<PlayerCarMovie>().maxDurability && GameManager.GetComponent<CarDurabilityManager>().lifes == GameManager.GetComponent<CarDurabilityManager>().maxLifes){
                noCollisionBonusText.text=noCollisionBonus.ToString();
            }
        }
        altogetherPointsText.text = (int.Parse(GainedPointsText.text) + int.Parse(extraLifesBonusText.text) + int.Parse(noCollisionBonusText.text)).ToString();
    score = int.Parse(altogetherPointsText.text);
        if(score > highScoresArray[9])
        {
            for(int i = 0; i<10; i++)
            {
                if(score > highScoresArray[i])
                {
                    for(int j=9; j>i; j--)
                    {
                        highScoresArray[j] = highScoresArray[j - 1];
                    }
                    highScoresArray[i] = score;
                    break;
                }
            }
        }


        PlayerPrefsX.SetIntArray("HighScoreArray", highScoresArray);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RetryButton(){
        Time.timeScale=1;
        SceneManager.LoadScene(0);
    }

    public void MenuExitButton(){
        Time.timeScale=1;
        SceneManager.LoadScene(1);
    }
}

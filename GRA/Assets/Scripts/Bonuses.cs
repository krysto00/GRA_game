using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonuses : MonoBehaviour
{

    public bool isDurability;
    public bool isShield;
    public bool isSpeed;

    [Header("Bonuses Settings")]
    public float bonusSpeed= 10f;

    [Header("Durability Settings")]
    public float repairPoints;

    [Header("Shield Settings")]
    public GameObject shield;
    private GameObject playerCar;
    private Vector3 playerCarPos;

    [Header("Speed Setting")]
    public float speedBoost;
    public float duration;
    private bool isActivated = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.gameObject.transform.Translate(new Vector3(0, -1, 0)*bonusSpeed * Time.deltaTime); 
    }

    void OnTriggerEnter2D(Collider2D obj){
        if(obj.gameObject.tag == "Player"){
            if(isDurability == true){
                obj.gameObject.GetComponent<PlayerCarMovie>().durability += repairPoints;
                Destroy(this.gameObject);
            }else if(isShield == true){
                playerCar = GameObject.FindWithTag("Player");
                obj.gameObject.tag="Shield";
                playerCarPos=playerCar.transform.position;
                playerCarPos.z=-0.1f;
                GameObject shieldObj = (GameObject)Instantiate(shield, playerCarPos, Quaternion.identity);
                shieldObj.transform.parent = playerCar.transform;
                Destroy(this.gameObject);
            }
            else if(isSpeed==true){
                gameObject.GetComponent<SpriteRenderer>().enabled=false;
                isActivated=true;
                StartCoroutine("SpeedBoostActivated");
            }
        } else if(obj.gameObject.tag == "End" && isActivated == false){
            Destroy(this.gameObject);
        }
    }
    IEnumerator SpeedBoostActivated(){
        while(duration>0){
            duration-=Time.deltaTime/speedBoost;
            Time.timeScale=speedBoost;
            yield return null;
            }
        Time.timeScale = 1f;
        Destroy(this.gameObject);
    }
}
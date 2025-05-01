using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BanditCarBehaviour : MonoBehaviour
{

    public GameObject bomb;
    public int bombAmount;
    public int banditCarVerticalSpeed;
    public int banditCarHorizontalSpeed;
    public float bombDelay;
    [HideInInspector]
    public int pointsPerCar;
    private float Delay;
    private GameObject playerCar;
    private Vector3 banditCarPos;

    // Start is called before the first frame update
    void Start()
    {
        playerCar=GameObject.FindWithTag("Player");
        Delay = bombDelay;
    }

    // Update is called once per frame
    void Update()
    {
        if(playerCar == null){
            playerCar=GameObject.FindWithTag("Player");
        }else{
            if(gameObject.transform.position.y > 3.8f && bombAmount>0){
                this.gameObject.transform.Translate(new Vector3(0, -1, 0)*banditCarVerticalSpeed*Time.deltaTime);
            }else if (bombAmount <=0){
                this.gameObject.transform.Translate(new Vector3(0, 1, 0)* banditCarVerticalSpeed * Time.deltaTime);
                if(gameObject.transform.position.y > 6.5f){
                    PointsManager.Points += pointsPerCar;
                    Destroy(this.gameObject);
                }
            }else{
                banditCarPos=Vector3.Lerp(transform.position, playerCar.transform.position, Time.fixedDeltaTime*banditCarHorizontalSpeed);
                transform.position=new Vector3(banditCarPos.x, transform.position.y, 0);

                Delay -= Time.deltaTime;
                if(Delay<=0 && bombAmount>0){
                    Delay=bombDelay;
                    bombAmount--;
                    Instantiate(bomb, transform.position, Quaternion.identity);
                } else if(Delay <=0 && bombAmount<=5 && bombAmount>0){
                    Delay=bombDelay/2;
                    bombAmount--;
                    Instantiate(bomb, transform.position, Quaternion.identity);
                }
            }
        }
    }
}

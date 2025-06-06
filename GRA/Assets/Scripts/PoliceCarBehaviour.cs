using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoliceCarBehaviour : MonoBehaviour
{
    public Light Red;
    public Light Blue;
    public float lightDelay;
    private float lightShowDelay;
    public GameObject bullet;
    public float shootingSeriesDelay;
    public float singleShotDelay;
    public float policeCarVerticalSpeed;
    public bool isLeft;
    private float shootDelay;
    private Vector3 policeCarPos;
    private GameObject bulletObj;
    public int bulletsInSeries;
    [HideInInspector]
    public int pointsPerCar;


    public AudioClip shotSound;
    private AudioSource audio;
    public GameObject explosion;
    // Start is called before the first frame update
    void Start()
    {
        lightShowDelay=2*lightDelay;
        shootDelay=shootingSeriesDelay;
        audio = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        lightShowDelay-=Time.deltaTime;
        if(lightShowDelay>lightDelay){
            Blue.enabled=false;
            Red.enabled=true;
        }else if(lightShowDelay<=lightDelay && lightShowDelay>0){
            Red.enabled=false;
            Blue.enabled=true;
        }else if(lightShowDelay<=0){
            lightShowDelay=2*lightDelay;
        }
        if(gameObject.transform.position.y < -3.8f){
            gameObject.transform.Translate(new Vector3(0, 1, 0) * policeCarVerticalSpeed * Time.deltaTime);
        }else{
            shootDelay -= Time.deltaTime;
            if(shootDelay<=0 && GameObject.FindWithTag("Untouchable")==false){
                StartCoroutine("Shoot");
                shootDelay=shootingSeriesDelay;
            }
        }
    }
    IEnumerator Shoot(){
        for(int i=bulletsInSeries;i>0;i--){
            audio.PlayOneShot(shotSound, 0.77f);
            bulletObj=(GameObject)Instantiate(bullet, transform.position, Quaternion.identity);
            if(isLeft==true){
                bulletObj.GetComponent<Bullet>().direction=1;
            }else if(isLeft==false){
                bulletObj.GetComponent<Bullet>().direction=-1;
            }
            yield return new WaitForSeconds(singleShotDelay);
        }
    }
    void OnCollisionEnter2D(Collision2D obj){
        if(obj.gameObject.tag == "Barrier"){
            if(isLeft==true){
                WaveManager.isLeft=false;
            }else if (isLeft==false){
                WaveManager.isRight=false;
            }
            PointsManager.Points += pointsPerCar;
            Instantiate(explosion, gameObject.transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}

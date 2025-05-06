using UnityEngine;
using System.Collections;

public class WaveManager  : MonoBehaviour {

    [Header("Wave 1 (Civil Cars)")]
      public float civilcarSpawnDelay;
      public GameObject civilCar;
      public int civilCarsAmount;
    [Header("Wave 2 (Bandit Cars)")]
    public GameObject banditCar;
    public int bombAmount;
    public int banditCarVerticalSpeed;
    public int banditCarHorizontalSpeed;
    public float bombDelay;
    private GameObject spawnedBanditCar;
    private bool isSpawned;
    private bool is2ndSpawned;
   [Header("Wave 3 (Police Cars)")]
    public GameObject policeCar;
    public int policeCarAmount;
    [HideInInspector]
    static public bool isLeft;
    [HideInInspector]
    static public bool isRight;
    public float shootingSeriesDelay;
    public float singleShotDelay;
    public float policeCarVerticalSpeed;
    public int bulletsInSeries;
    private GameObject spawnedPoliceCar;

    [Header("Points")]
    public int pointsPerCivilCar;
    public int pointsPerBanditCar;
    public int pointsPerBomb;
    public int pointsPerPoliceCar;
    public GameObject EndGameScreen;

  
    private float[] lanesArray;
    private float spawnDelay;
    void Start()
    {
        lanesArray = new float[4];
        lanesArray[0] = -2.11f;
        lanesArray[1] = -0.76f;
        lanesArray[2] = 0.76f;
        lanesArray[3] = 2.11f;
        spawnDelay = civilcarSpawnDelay;
    }
     void Update()
    {
        spawnDelay -= Time.deltaTime;
        if(spawnDelay<=0 && civilCarsAmount > 0)
        {
            spawnCar();
            spawnDelay = civilcarSpawnDelay;
        } else if (civilCarsAmount <= 0 && is2ndSpawned == false) {
            if (isSpawned == false)
            {
                spawnBanditCar();
            }
            else if (isSpawned == true && spawnedBanditCar.GetComponent<BanditCarBehaviour>().bombAmount < 10 && is2ndSpawned == false)
            {
                spawnBanditCar();
            }
        } else if (civilCarsAmount <= 0 && policeCarAmount > 0 && spawnedBanditCar == null)
        {
            spawnPoliceCar();
        }else if(policeCarAmount<=0 && isLeft==false && isRight==false){
            Time.timeScale=0;
            EndGameScreen.SetActive(true);
        }
    }


    void spawnPoliceCar()
    {
        Transform playerCarPosition;
        if(GameObject.FindWithTag("Player")){
            playerCarPosition=GameObject.FindWithTag("Player").transform;
        }else if(GameObject.FindWithTag("Shield")){
            playerCarPosition=GameObject.FindWithTag("Shield").transform;
        }else if(GameObject.FindWithTag("Untouchable")){
            playerCarPosition=GameObject.FindWithTag("Untouchable").transform;
        }else{
            playerCarPosition=null;
        }
        if(playerCarPosition.position.x <= -0.51f && isRight == false)
        {
            spawnedPoliceCar = (GameObject)Instantiate(policeCar, new Vector3(2.02f, -5.5f, 0), Quaternion.identity);
            spawnedPoliceCar.GetComponent<PoliceCarBehaviour>().isLeft = false;
            isRight = true;
            policeCarAmount--;
        } else if (playerCarPosition.position.x > -0.51f && isLeft == false)
        {
            spawnedPoliceCar = (GameObject)Instantiate(policeCar, new Vector3(-2.02f, -5.5f, 0), Quaternion.identity);
            spawnedPoliceCar.GetComponent<PoliceCarBehaviour>().isLeft = true;
            isLeft = true;
            policeCarAmount--;
        }
        spawnedPoliceCar.GetComponent<PoliceCarBehaviour>().shootingSeriesDelay = shootingSeriesDelay;
        spawnedPoliceCar.GetComponent<PoliceCarBehaviour>().singleShotDelay = singleShotDelay;
        spawnedPoliceCar.GetComponent<PoliceCarBehaviour>().bulletsInSeries = bulletsInSeries;
        spawnedPoliceCar.GetComponent<PoliceCarBehaviour>().policeCarVerticalSpeed = policeCarVerticalSpeed;
        spawnedPoliceCar.GetComponent<PoliceCarBehaviour>().pointsPerCar=pointsPerPoliceCar;
       
    }






    void spawnBanditCar(){
        if(isSpawned==false){
            spawnedBanditCar=(GameObject)Instantiate(banditCar, new Vector3(Random.Range(-2.25f, 2.25f), 7f, 0), Quaternion.identity);
            spawnedBanditCar.GetComponent<BanditCarBehaviour>().bombDelay=bombDelay;
            isSpawned=true;
        }else if(isSpawned==true && is2ndSpawned == false){
            if(spawnedBanditCar.transform.position.x < 0.45f){
                spawnedBanditCar=(GameObject)Instantiate(banditCar, new Vector3(2.2f, 7f, 0), Quaternion.identity);
                is2ndSpawned=true;
            }else if(spawnedBanditCar.transform.position.x >= 0.45f){
                spawnedBanditCar=(GameObject)Instantiate(banditCar, new Vector3(-2.2f, 7f, 0), Quaternion.identity);
                is2ndSpawned=true;
        }
        spawnedBanditCar.GetComponent<BanditCarBehaviour>().bombDelay=bombDelay/1.5f;
    }
            spawnedBanditCar.GetComponent<BanditCarBehaviour>().bombAmount=bombAmount;
            spawnedBanditCar.GetComponent<BanditCarBehaviour>().banditCarVerticalSpeed=banditCarVerticalSpeed;
            spawnedBanditCar.GetComponent<BanditCarBehaviour>().banditCarHorizontalSpeed=banditCarHorizontalSpeed;
            spawnedBanditCar.GetComponent<BanditCarBehaviour>().pointsPerCar=pointsPerBanditCar;
            spawnedBanditCar.GetComponent<BanditCarBehaviour>().bomb.gameObject.GetComponent<Bomb>().pointsPerBomb=pointsPerBomb;
    }
    void spawnCar()
    {
        int lane = Random.Range(0, 4);
        if (lane == 0 || lane == 1)
        {
            GameObject car = (GameObject)Instantiate(civilCar, new Vector3(lanesArray[lane], 6f, 0), Quaternion.Euler(new Vector3(0, 0, 180)));
            car.GetComponent<CivilCar>().direction = 1;
            car.GetComponent<CivilCar>().civilCarSpeed = 12f;
            car.GetComponent<CivilCar>().pointsPerCar=pointsPerCivilCar;

        }
        if (lane == 2 || lane == 3)
        {
            GameObject car = Instantiate(civilCar, new Vector3(lanesArray[lane], 6f, 0), Quaternion.identity);
            car.GetComponent<CivilCar>().direction = -1;
            car.GetComponent<CivilCar>().civilCarSpeed = 5f;
            car.GetComponent<CivilCar>().pointsPerCar=pointsPerCivilCar;
    }
    civilCarsAmount--;
    }
}


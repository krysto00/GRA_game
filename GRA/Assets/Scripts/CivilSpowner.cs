using UnityEngine;
using System.Collections;


public class CivilCarSpawner : MonoBehaviour {


    public float carSpawnDelay = 2f;
    public GameObject civilCar;

    private float[] lanesArray;
    private float spawnDelay;
    void Start()
    {
        lanesArray = new float[4];
        lanesArray[0] = -2.11f;
        lanesArray[1] = -0.76f;
        lanesArray[2] = 0.76f;
        lanesArray[3] = 2.11f;
        spawnDelay = carSpawnDelay;
    }


    void Update()
    {
        spawnDelay -= Time.deltaTime;
        if(spawnDelay<=0)
        {
            spawnCar();
            spawnDelay = carSpawnDelay;
        }
    }


    void spawnCar()
    {
        int lane = Random.Range(0, 4);
        if (lane == 0 || lane == 1)
        {
            GameObject car = (GameObject)Instantiate(civilCar, new Vector3(lanesArray[lane], 6f, 0), Quaternion.Euler(new Vector3(0, 0, 180)));
            car.GetComponent<CivilCar>().direction = 1;
            car.GetComponent<CivilCar>().civilCarSpeed = 12f;
        }
        if (lane == 2 || lane == 3)
        {
            GameObject car = Instantiate(civilCar, new Vector3(lanesArray[lane], 6f, 0), Quaternion.identity);
            car.GetComponent<CivilCar>().direction = -1;
            car.GetComponent<CivilCar>().civilCarSpeed = 5f;
    }
    }


}

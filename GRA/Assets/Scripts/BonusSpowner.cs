using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusSpowner : MonoBehaviour
{

    private float delay;
    public GameObject[] bonuses;
    public int minDelay;
    public int maxDelay;
    // Start is called before the first frame update
    void Start()
    {
        delay=Random.Range(minDelay, maxDelay);
    }

    // Update is called once per frame
    void Update()
    {
        delay -= Time.deltaTime;
        if(delay<=0){
            delay=Random.Range(minDelay, maxDelay);
            spawnBonus();
        }
    }

    void spawnBonus(){
        Instantiate(bonuses[(int)Random.Range(0, 3)], new Vector3(Random.Range(-2.4f, 2.4f), 6f, 0), Quaternion.identity);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusSpowner : MonoBehaviour
{
    public GameObject[] bonuses;
    public int minDelay;
    public int maxDelay;
    private float delay;
    
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
        Instantiate(bonuses[(int)Random.Range(0, 3)], new Vector3(Random.Range(-1.9f, 1.9f), 6f, 0), Quaternion.identity);
    }
}

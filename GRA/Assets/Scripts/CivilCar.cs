using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CivilCar : MonoBehaviour
{
    public float civilCarSpeed = 5f;
    private Vector3 civilCarPosition;

    public int direction = -1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.gameObject.transform.Translate(new Vector3(0, direction, 0) * civilCarSpeed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D obj){
        if(obj.gameObject.tag=="Player"){
            Debug.Log("Il giocatore ci ha colpiti");
            Destroy(this.gameObject);
        }else if (obj.gameObject.tag == "RoadEnd")
        {
            Destroy(this.gameObject);
        }

    }
}

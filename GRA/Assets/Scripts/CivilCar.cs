using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CivilCar : MonoBehaviour
{
    public float civilCarSpeed = 5f;
    public float crashDamage = 20f;
    private Vector3 civilCarPosition;
    public int direction = -1;
    void Update()
    {
        this.gameObject.transform.Translate(new Vector3(0, direction, 0) * civilCarSpeed * Time.deltaTime);
    }

    void OnCollisionEnter2D(Collision2D obj){
        if(obj.gameObject.tag=="Player"){
            obj.gameObject.GetComponent<PlayerCarMovie>().durability -= crashDamage / 5 ;
        }
    }

    void OnTriggerEnter2D(Collider2D obj){
        if(obj.gameObject.tag=="Player"){
            obj.gameObject.GetComponent<PlayerCarMovie>().durability -= crashDamage;
            Debug.Log("Il giocatore ci ha colpiti");
            Destroy(this.gameObject);
        }else if (obj.gameObject.tag == "RoadEnd")
        {
            Destroy(this.gameObject);
        }

    }
}

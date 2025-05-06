using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CivilCar : MonoBehaviour
{

    public GameObject explosion;
    public float civilCarSpeed = 5f;
    public float crashDamage = 20f;
    private Vector3 civilCarPosition;
    public int direction = -1;

    [HideInInspector]
    public int pointsPerCar;
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
            PointsManager.Points -= pointsPerCar;
            obj.gameObject.GetComponent<PlayerCarMovie>().durability -= crashDamage;
            Debug.Log("Il giocatore ci ha colpiti");
            Instantiate(explosion, gameObject.transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }else if(obj.gameObject.tag=="Shield"){
            Instantiate(explosion, gameObject.transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }else if (obj.gameObject.tag == "RoadEnd")
        {
            PointsManager.Points += pointsPerCar;
            Destroy(this.gameObject);
        }

    }
}

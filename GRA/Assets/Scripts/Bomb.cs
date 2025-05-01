using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{

public GameObject explosion;
    public int bombDamage;
    public float bombSpeed;
    [HideInInspector]
    public int pointsPerBomb;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.gameObject.transform.Translate(new Vector3(0, -1, 0) * bombSpeed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D obj){
        if(obj.gameObject.tag == "Player"){
            PointsManager.Points -= pointsPerBomb;
            obj.gameObject.GetComponent<PlayerCarMovie>().durability-=bombDamage;
            Instantiate(explosion, gameObject.transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }else if(obj.gameObject.tag=="Shield"){
            Instantiate(explosion, gameObject.transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }else if(obj.gameObject.tag=="RoadEnd"){
            Destroy(this.gameObject);
            PointsManager.Points += pointsPerBomb;
        }

    }
}

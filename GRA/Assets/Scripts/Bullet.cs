using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int bulletDamage;
    public int direction;
    public float bulletSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.gameObject.transform.Translate(new Vector3(direction, 0, 0) * bulletSpeed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D obj){

        if(obj.gameObject.tag=="Player"){
            obj.gameObject.GetComponent<PlayerCarMovie>().durability -= bulletDamage;
            Destroy(this.gameObject);
        }else if(obj.gameObject.tag=="Shield" || obj.gameObject.tag=="Barrier" || obj.gameObject.tag=="PoliceCar" ){
            Destroy(this.gameObject);
        }
    }
}

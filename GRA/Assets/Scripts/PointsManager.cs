using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsManager : MonoBehaviour
{

    static public int Points;
    private float secondDelay = 1;
    // Start is called before the first frame update
    void Start()
    {
        Points=0;
        this.gameObject.GetComponent<MeshRenderer>().sortingLayerName = "Points";
        this.gameObject.GetComponent<TextMesh>().color = new Color(1f, 1f, 1f, 0.7f);
    }

    // Update is called once per frame
    void Update()
    {
        this.gameObject.GetComponent<TextMesh>().text = Points.ToString();
        secondDelay-= Time.deltaTime;
        if(secondDelay<=0){
            Points+=1;
            secondDelay=1;
            if(Points<0){
                Points=0;
            }
        }
    }
}

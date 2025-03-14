using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadInfiniteScrolling : MonoBehaviour
{
    public float scrollSpeed;
    private Vector2 offset;
   void Update(){
    offset = new Vector2(0, Time.time * scrollSpeed);
    GetComponent<Renderer>().material.mainTextureOffset = offset;
   }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCarMovie : MonoBehaviour
{

    public float carHorizontalSpeed = 5f;
    private Vector3 carPosition;
    // Start is called before the first frame update
    void Start()
    {
        carPosition = this.gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        carPosition.x += Input.GetAxis("Horizontal") * carHorizontalSpeed * Time.deltaTime;
        carPosition.x = Mathf.Clamp(carPosition.x, -2.211f, 2.211f);
        this.gameObject.transform.position = carPosition;
    }
}

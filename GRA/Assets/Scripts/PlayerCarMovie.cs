using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCarMovie : MonoBehaviour
{
    public float carHorizontalSpeed = 5f;
    private Vector3 carPosition;
    public float maxDurability = 100f;
    public float durability;

    void Start()
    {
        carPosition = this.gameObject.transform.position;
        durability = maxDurability;
    }

    void Update()
    {
        // Input da tastiera (freccia destra/sinistra)
        float horizontalInput = Input.GetAxis("Horizontal");

        // Override con input da mobile se presenti
        if (MobileInput.leftHeld)
            horizontalInput = -1f;
        else if (MobileInput.rightHeld)
            horizontalInput = 1f;

        // Movimento orizzontale
        carPosition.x += horizontalInput * carHorizontalSpeed * Time.deltaTime;
        carPosition.x = Mathf.Clamp(carPosition.x, -1.9f, 1.9f);
        this.gameObject.transform.position = carPosition;

        // Gestione pausa da MobileInput (tasto pausa touch)
        if (MobileInput.pausePressed)
        {
            MobileInput.pausePressed = false; // resetta il flag
            TogglePause();
        }
    }

    void TogglePause()
    {
        // Pausa base: blocca/sblocca il tempo di gioco
        Time.timeScale = (Time.timeScale == 0) ? 1 : 0;
    }
}

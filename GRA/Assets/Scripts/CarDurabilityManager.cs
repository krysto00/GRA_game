using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarDurabilityManager : MonoBehaviour
{
    public GameObject playerCarPrefab;
    public GameObject spawnPoint;
    public TextMesh durabilityText;
    public int lifes;
    private GameObject playerCar;

    void Start()
    {
        playerCar = Instantiate(playerCarPrefab, spawnPoint.transform.position, Quaternion.identity);
    }

    void Update()
    {
        if (playerCar.GetComponent<PlayerCarMovie>().durability <= 0)
        {
            Destroy(playerCar);
            lifes--;
            if (lifes > 0)
            {
                StartCoroutine(SpawnaCar());
            }
        } else if(playerCar.GetComponent<PlayerCarMovie>().durability > playerCar.GetComponent<PlayerCarMovie>().maxDurability){
            playerCar.GetComponent<PlayerCarMovie>().durability = playerCar.GetComponent<PlayerCarMovie>().maxDurability;
        }

        durabilityText.text = "Durability: " + playerCar.GetComponent<PlayerCarMovie>().durability + "/" + playerCar.GetComponent<PlayerCarMovie>().maxDurability;
    }

    IEnumerator SpawnaCar()
    {
        playerCar = Instantiate(playerCarPrefab, spawnPoint.transform.position, Quaternion.identity);
        playerCar.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0.4f);
        playerCar.GetComponent<BoxCollider2D>().isTrigger = true;
        playerCar.tag = "Untouchable";
        yield return new WaitForSeconds(3);
        playerCar.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
        playerCar.GetComponent<BoxCollider2D>().isTrigger = false;
        playerCar.tag = "Player";
    }
}

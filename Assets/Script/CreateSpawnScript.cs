using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateSpawnScript : MonoBehaviour
{
    public GameObject spawnPrefab;
     public float minDistanceFromPlayer = 5f;
    public float numSpawn = 4f;
    private GameObject player;
    private float countSpawn = 0f;

    void Start()
    {
        numSpawn = NextStage.instance.enemyCount;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        if (countSpawn < numSpawn)
        {
            CreateSpawn();
            countSpawn++;
        }
    }

    void CreateSpawn()
    {
        // หา tiles ที่มี tag เป็น floor
        GameObject[] floorTiles = GameObject.FindGameObjectsWithTag("Floor");

        // สุ่มเลือก tile ที่จะ spawn ศัตรู จำนวน numSpawn ครั้ง
        Vector3 tilePosition = Vector3.zero;
        float distanceFromPlayer = 0f;
        do {
            GameObject randomTile = floorTiles[Random.Range(0, floorTiles.Length)];
            tilePosition = randomTile.transform.position;
            distanceFromPlayer = Vector3.Distance(tilePosition, player.transform.position);
        } while (distanceFromPlayer < minDistanceFromPlayer);

        float xPos = Random.Range(0f, 1f) + tilePosition.x;
        float yPos = Random.Range(0f, 1f) + tilePosition.y;
        float zPos = tilePosition.z;
        Instantiate(spawnPrefab, new Vector3(xPos, yPos, zPos), Quaternion.identity);
    }
}

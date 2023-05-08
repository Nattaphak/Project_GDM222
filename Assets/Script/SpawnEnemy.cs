using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
   public GameObject enemyPrefab;
    public float spawnRate = 2f;
    private float nextSpawnTime = 0f;

    void Update()
    {
        if (Time.time >= nextSpawnTime)
        {
            SpawnEn();
            nextSpawnTime = Time.time + 1f / spawnRate;
        }
    }

    void SpawnEn()
    {
        // สุ่มตำแหน่ง spawn บนพื้นที่ floor
        Vector3 randomPosition = FindRandomFloorPosition();
        // สร้าง enemy ในตำแหน่งที่สุ่มได้
        Instantiate(enemyPrefab, randomPosition, Quaternion.identity);
    }

    Vector3 FindRandomFloorPosition()
    {
        // หา tiles ที่มี tag เป็น floor
        GameObject[] floorTiles = GameObject.FindGameObjectsWithTag("Floor");

        // สุ่มเลือก tile ที่จะ spawn ศัตรู
        GameObject randomTile = floorTiles[Random.Range(0, floorTiles.Length)];

        // หาตำแหน่งบน tile ที่สุ่มได้ โดยสุ่ม x, y ในช่วง (0,1) และใช้ z จากตำแหน่งของ tile
        Vector3 tilePosition = randomTile.transform.position;
        float xPos = Random.Range(0f, 1f) + tilePosition.x;
        float yPos = Random.Range(0f, 1f) + tilePosition.y;
        float zPos = tilePosition.z;

        return new Vector3(xPos, yPos, zPos);
    }
}

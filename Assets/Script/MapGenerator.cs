using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    //public GameObject playerPrefab;
    public GameObject floorTilePrefab;
    public GameObject wallTilePrefab;
    public int mapWidth = 50;
    public int mapHeight = 50;
    public int wallThreshold = 45;
    public int smoothingIterations = 5;

    private int[,] map;

    void Start()
    {
        GenerateMap();
        //SpawnPlayer();
    }

    void GenerateMap()
    {
        map = new int[mapWidth, mapHeight];

        // Randomly initialize the map
        for (int x = 0; x < mapWidth; x++)
        {
            for (int y = 0; y < mapHeight; y++)
            {
                // ให้รอบนอกของแผนที่เป็น Wall
                if (x == 0 || x == mapWidth - 1 || y == 0 || y == mapHeight - 1)
                {
                    map[x, y] = 1;
                }
                else
                {
                    map[x, y] = (Random.Range(0, 100) < wallThreshold) ? 1 : 0;
                }
            }
        }

        // Perform smoothing iterations
        for (int i = 0; i < smoothingIterations; i++)
        {
            SmoothMap();
        }

        // Create tiles from the map
        for (int x = 0; x < mapWidth; x++)
        {
            for (int y = 0; y < mapHeight; y++)
            {
                if (map[x, y] == 1)
                {
                    Instantiate(wallTilePrefab, new Vector3(x, y, 0), Quaternion.identity);
                }
                else
                {
                    Instantiate(floorTilePrefab, new Vector3(x, y, 0), Quaternion.identity);
                }
            }
        }
    }


    void SmoothMap()
    {
        for (int x = 0; x < mapWidth; x++)
        {
            for (int y = 0; y < mapHeight; y++)
            {
                int neighbourWallTiles = GetSurroundingWallCount(x, y);

                if (neighbourWallTiles > 4)
                {
                    map[x, y] = 1;
                }
                else if (neighbourWallTiles < 4)
                {
                    map[x, y] = 0;
                }
            }
        }
    }


    int GetSurroundingWallCount(int gridX, int gridY)
    {
        int wallCount = 0;
        for (int neighbourX = gridX - 1; neighbourX <= gridX + 1; neighbourX++)
        {
            for (int neighbourY = gridY - 1; neighbourY <= gridY + 1; neighbourY++)
            {
                if (neighbourX >= 0 && neighbourX < mapWidth && neighbourY >= 0 && neighbourY < mapHeight)
                {
                    if (neighbourX != gridX || neighbourY != gridY)
                    {
                        wallCount += map[neighbourX, neighbourY];
                    }
                }
                else
                {
                    wallCount++;
                }
            }
        }

        return wallCount;
    }



    /*void SpawnPlayer()
    {
        // Spawn player in the center of the map
        Vector3 spawnPosition = new Vector3(mapWidth / 2 , mapHeight / 2 , 0);

        // Check if spawn position is on a wall
        while (IsOnWall(spawnPosition))
        {
            // Spawn position is on a wall, so choose a new position
            spawnPosition = new Vector3(Random.Range(0, mapWidth), Random.Range(0, mapHeight), 0);
        }

        Instantiate(playerPrefab, spawnPosition, Quaternion.identity);
    }

    bool IsOnWall(Vector3 position)
    {
        // Check if position is on a wall
            if (wallTilePrefab.transform.position == position)
            {
                return true;
            }
        

        return false;
    }*/

}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// O'yinning asosiy o'yinini boshqaradi.
/// </summary>
public class GameManager : MonoBehaviour
{


    [Tooltip("Biz yaratmoqchi bolgan kafelga havola")]
    public Transform tile;

    [Tooltip("Birinchi plitkani qaerga qoyish kerak?")]
    public Vector3 startPoint = new Vector3(0, 0, -5);

    [Tooltip("Biz tugdirmoqchi bolgan tosiq")]
    public Transform obstacle;

    [Tooltip("Oldindan qancha plitka yaratishimiz kerak?")]
    [Range(1, 100)]
    public int initSpawnNum = 10;

    [Tooltip("How many tiles to spawn with no obstacles")]
    public int initNoObstacles = 4;

    //Keyingi kafel qaerda paydo bo'lishi kerak.
    private Vector3 nextTileLocation;


   //Keyingi kafelni qanday aylantirish kerak?
    private Quaternion nextTileRotation;
    //Start birinchi kadr yangilanishidan oldin chaqiriladi
    void Start()
    {
        // Boshlanish nuqtamizni belgilang
        nextTileLocation = startPoint;
        nextTileRotation = Quaternion.identity;

        for (int i = 0; i < initSpawnNum; ++i)
        {
            spawnNextTile(i >= initNoObstacles);
        }



    }
    /// <summary>
    /// Muayyan joyda plitka yaratadi va keyingi pozitsiyani o'rnatadi.
    /// </summary>
    /// <param name="spawnObstacles">If we should spawn an
    /// obstacle</param>
    public void spawnNextTile(bool spawnObstacles = true)
    {
        var newTile = Instantiate(tile, nextTileLocation, nextTileRotation);

        //Keyingi elementni qayerda va qaysi aylanishda chiqarishimiz kerakligini aniqlang
        var nextTile = newTile.Find("Next Spawn Point");
        nextTileLocation = nextTile.position;
        nextTileRotation = nextTile.rotation;



        if (spawnObstacles)
        {

            spawnObstacle(newTile);

        }


    }

    private void spawnObstacle(Transform newTile)
    {
        // Endi biz barcha mumkin bo'lgan joylarni olishimiz kerak.
        // to'siq yaratish
        var obstacleSpawnPoints = new List<GameObject>();
        // Bolalar o'yinining har bir ob'ektini aylanib chiqing
        // our tile
        foreach (Transform child in newTile)
        {
            // If it has the ObstacleSpawn tag
            if (child.CompareTag("ObstracleSpawn"))
            {
                // We add it as a possibility
                obstacleSpawnPoints.Add(child.gameObject);
            }
        }

        // Make sure there is at least one
        if (obstacleSpawnPoints.Count > 0)
        {
            // Get a random spawn point from the ones we
            // have
            int index = Random.Range(0, obstacleSpawnPoints.Count);
            var spawnPoint = obstacleSpawnPoints[index];
            // Store its position for us to use
            var spawnPos = spawnPoint.transform.position;
            // Create our obstacle
            var newObstacle = Instantiate(obstacle,
            spawnPos, Quaternion.identity);
            // Have it parented to the tile
            newObstacle.SetParent(spawnPoint.transform);
        }


    }

}

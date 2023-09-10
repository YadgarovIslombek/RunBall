using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Управляет основным игровым процессом игры.
/// </summary>
public class GameManager : MonoBehaviour
{


    [Tooltip("Ссылка на плитку, которую мы хотим создать")]
    public Transform tile;

    [Tooltip("Где должна быть размещена первая плитка")]
    public Vector3 startPoint = new Vector3(0, 0, -5);

    [Tooltip("Сколько плиткi нам нужно создать заранее")]
    [Range(1, 15)]
    public int initSpawnNum = 10;

    //Где должна появиться следующая плитка.
    private Vector3 nextTileLocation;


    //Как следует повернуть следующую плитку?
    private Quaternion nextTileRotation;

    //Start вызывается перед обновлением первого кадра 
    void Start()
    {
        // Устанавливаем нашу start точку
        nextTileLocation = startPoint;
        nextTileRotation = Quaternion.identity;

        for (int i = 0; i < initSpawnNum; ++i)
        {
            spawnNextTile();
        }



    }
    /// <summary>
    /// Создаст плитку в определенном месте и установит следующую позицию.
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

    }









    // Update is called once per frame
    void Update()
    {

    }
}

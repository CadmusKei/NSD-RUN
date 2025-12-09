using System;
using UnityEngine;

public class ChunkHandler : MonoBehaviour
{
    private float moveSpeed;

    private SpawnChunks spawnChunkScript;

    [SerializeField] int destroyPoint = 25;
    [SerializeField] private ScriptableObjectScript dataScript;
    [SerializeField] private GameObject[] spawnPoints;
    [SerializeField] private ChunkType chunkType;
    [SerializeField] private GameObject[] obstacleArray;
    [SerializeField] private bool shouldSpawnObstacles;

    private int randomNumber;

    public enum ChunkType
    {
        Coffee_Shop,
        Pet_Shop,
        House,
        Thrift_Store,
        Shop
    }


    private void Start()
    {

        GameObject map = GameObject.FindGameObjectWithTag("Map");
        spawnChunkScript = map.GetComponent<SpawnChunks>();
        moveSpeed = spawnChunkScript.chunkSpeed;

        if (shouldSpawnObstacles)
        {
            GameObject randomSpawnPoint = spawnPoints[UnityEngine.Random.Range(0, spawnPoints.Length)];
            randomNumber = UnityEngine.Random.Range(0, obstacleArray.Length);
            GameObject obstacle = Instantiate(obstacleArray[randomNumber], randomSpawnPoint.transform.position, Quaternion.identity, this.transform);
            SpriteRenderer sr = obstacle.GetComponentInChildren<SpriteRenderer>();
            sr.sortingOrder = 3;

        }
    }

    private void Update()
    {
        moveSpeed = spawnChunkScript.chunkSpeed;
        MoveChunks();
    }

    private void MoveChunks()
    {
        transform.position -= new Vector3(moveSpeed, 0, 0) * Time.deltaTime;

        if (transform.position.x < -destroyPoint) { Destroy(gameObject); }
    }
}

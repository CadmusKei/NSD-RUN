using UnityEngine;


public class SpawnChunks : MonoBehaviour
{
    [SerializeField] private Vector3 spawnPos = new Vector3(0, 25, 0);
    [SerializeField] private float chunkLength = 12.6f;
    [SerializeField] playerScript player;

    public float chunkSpeed;

    public GameObject[] chunkArray;
    private GameObject lastPlaceChunk;
    private int lastNumber = 999;
    private int shardsCollected;

    [SerializeField] private ScriptableObjectScript dataScript;

    private void Start()
    {
        chunkSpeed = dataScript.chunkSpeed;
    }

    private void Update()
    {
        shardsCollected = player.shardsCollected;

        switch (shardsCollected)
        {
            case 0:
                chunkSpeed = 8;
                break;
            case 1:
                chunkSpeed = 8.5f;
                break;
            case 2:
                chunkSpeed = 9.5f;
                break;
            case 3:
                chunkSpeed = 10f;
                break;
            case 4:
                chunkSpeed = 10.5f;
                break;
            case 5:
                chunkSpeed = 11f;
                break;
            case 6:
                chunkSpeed = 11.2f;
                break;
            case 7:
                chunkSpeed = 11.4f;
                break;
            case 8:
                chunkSpeed = 11.6f;
                break;

        }
    }

    public void SpawnAt()
    {
        int randomNumber = Random.Range(0, chunkArray.Length);
        if (randomNumber == lastNumber) { SpawnAt(); }
        if (lastPlaceChunk == null) { lastPlaceChunk = Instantiate(chunkArray[randomNumber], spawnPos, Quaternion.identity); }
        else
        {
            var predictedMovement = chunkSpeed * Time.deltaTime;
            var lastChunkPos = lastPlaceChunk.transform.localPosition;
            var lastChunkEndX = lastChunkPos.x + chunkLength;
            var spawnPos = new Vector2(lastChunkEndX - predictedMovement, lastChunkPos.y);

            lastPlaceChunk = Instantiate(chunkArray[randomNumber], spawnPos, Quaternion.identity);
        }
        lastNumber = randomNumber;
    }
}

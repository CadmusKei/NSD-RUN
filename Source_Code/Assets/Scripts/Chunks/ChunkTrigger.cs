using Unity.Mathematics;
using UnityEngine;

public class ChunkTrigger : MonoBehaviour
{

    public SpawnChunks spawner;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Chunk"))
        {
            spawner.SpawnAt();
        }
    }

}


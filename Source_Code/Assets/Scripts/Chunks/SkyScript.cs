using UnityEngine;

public class SkyScript : MonoBehaviour
{
    public float moveSpeed;
    [SerializeField] int destroyPoint = 25;
    [SerializeField] private GameObject sky;
    [SerializeField] private float nextSkyPoint = -30;
    [SerializeField] Vector3 spawnPoint = new Vector3(100, 0, 0);
    [SerializeField] private ScriptableObjectScript dataScript;
    private bool hasSpawned = false;

    private void Start()
    {

    }

    private void Update()
    {
        MoveChunks();
    }

    private void MoveChunks()
    {
        transform.position -= new Vector3(moveSpeed, 0, 0) * Time.deltaTime;
        if (transform.position.x <= nextSkyPoint && !hasSpawned)
        {
            GameObject skyObject = Instantiate(sky, spawnPoint, Quaternion.identity);
            hasSpawned = true;
        }
        if (transform.position.x < -destroyPoint) { Destroy(gameObject); }
    }
}

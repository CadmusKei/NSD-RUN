using UnityEngine;

public class ShardScript : MonoBehaviour
{

    [SerializeField] private playerScript player;
    [SerializeField] private Sprite[] stopSignSprites;

    private UnityEngine.UI.Image stopSignImage;
    private int shardsCollected = 0;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        stopSignImage = GetComponent<UnityEngine.UI.Image>();

    }

    // Update is called once per frame
    void Update()
    {
        shardsCollected = player.shardsCollected;
        stopSignImage.sprite = stopSignSprites[shardsCollected];
    }


}


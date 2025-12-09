using UnityEngine;
using UnityEngine.UI;

public class LifeScript : MonoBehaviour
{

    [SerializeField] private int playerLives;
    [SerializeField] private playerScript player;

    [SerializeField] Image green;
    [SerializeField] Image orange;
    [SerializeField] Image red;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        playerLives = player.Lives;

        if (playerLives == 3)
        {
            green.enabled = true;
            orange.enabled = true;
            red.enabled = true;
        }
        else if (playerLives == 2)
        {
            green.enabled = false;
            orange.enabled = true;
            red.enabled = true;
        }
        else if (playerLives == 1)
        {
            green.enabled = false;
            orange.enabled = false;
            red.enabled = true;
        }
        else if (playerLives <= 0)
        {
            green.enabled = false;
            orange.enabled = false;
            red.enabled = false;
        }

    }
}

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameHandler : MonoBehaviour
{

    [SerializeField] playerScript player;
    [SerializeField] Image shade_game_won;
    [SerializeField] Image shade_game_over;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        int shards = player.shardsCollected;
        Debug.Log(shards);

        if (shards == 8)
        {
            shade_game_won.gameObject.SetActive(true);
        }
        if (player.Lives == 0)
        {
            shade_game_over.gameObject.SetActive(true);
        }
    }

    public void RestartScene()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }

    public void GameOver()
    {

    }

    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Game Quit!");
    }
}

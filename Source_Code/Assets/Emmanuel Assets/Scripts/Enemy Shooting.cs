using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class EnemyShooting : MonoBehaviour
{
    // Animator anim;
    public GameObject[] projectiles;

    private GameObject player;

    public Transform projectilePosition;

    [SerializeField] private Animator animator;
    [SerializeField] private float _timerMax = 2;


    private float timer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // anim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");

    }

    // Update is called once per frame
    void Update()
    {

        timer += Time.deltaTime;

        if (timer >= _timerMax)
        {
            timer = 0;
            animator.SetTrigger("ThrowItem");
            //Shoot();
        }

        else
        {
            // anim.SetBool("isShooting", false);
        }

    }

    public void Shoot()
    {
        // anim.SetBool("isShooting", true);

        int randomNumber = UnityEngine.Random.Range(0, projectiles.Length);
        Instantiate(projectiles[randomNumber], projectilePosition.transform.position, Quaternion.identity);

    }

    public void Pause()
    {
        Time.timeScale = 0;
    }
}

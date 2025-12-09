using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class playerScript : MonoBehaviour
{
    [SerializeField] private ScriptableObjectScript dataScript;

    [SerializeField] private int lives;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private GameObject floorCheck;
    [SerializeField] private LayerMask curb;
    [SerializeField] private float raycastDistance = 1f;
    [SerializeField] private float defaultJumpVelocity = 600f;
    [SerializeField] private float superJumpVelocity = 1000f;
    private float jumpVelocity = 600f;
    private bool canJump = true;

    [SerializeField] Animator animator;

    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip jumpSound;
    [SerializeField] AudioClip hitSound;
    [SerializeField] AudioClip pickupSound;

    [SerializeField] CapsuleCollider2D capsuleCollider;
    [SerializeField] BoxCollider2D boxCollider;

    public int Lives => lives;
    public int shardsCollected;

    private bool isGrounded = true;

    // [SerializeField] private Animator animator;

    private void Start()
    {

        jumpVelocity = defaultJumpVelocity;

        // animator.SetBool("Test", true);
        lives = dataScript.playerLives;

        shardsCollected = dataScript.shardsCollected;

    }


    private void FixedUpdate()
    {
        IsGrounded();

    }

    public void OnCrouch(InputAction.CallbackContext callbackContext)
    {
        if (callbackContext.started)
        {
            jumpVelocity = superJumpVelocity;
            animator.SetBool("isSliding", true);
            // canJump = false;
            capsuleCollider.enabled = false;
            boxCollider.enabled = true;
        }
        if (callbackContext.canceled)
        {

            jumpVelocity = defaultJumpVelocity;


            animator.SetBool("isSliding", false);
            // canJump = true;
            capsuleCollider.enabled = true;
            boxCollider.enabled = false;
        }
    }

    public void OnJump(InputAction.CallbackContext callbackContext)
    {
        if (callbackContext.started)
        {
            if (isGrounded && canJump)
            {
                rb.AddForce(Vector2.up * jumpVelocity);
                audioSource.PlayOneShot(jumpSound);
            }
        }
        if (callbackContext.canceled)
        {

        }
    }

    private void IsGrounded()
    {
        isGrounded = Physics2D.Raycast(floorCheck.transform.position, Vector2.down, raycastDistance, curb);
        Debug.DrawRay(floorCheck.transform.position, Vector2.down * raycastDistance);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Obstacle"))
        {
            lives--;
            animator.SetTrigger("playerHit");
            Destroy(other.gameObject);
            audioSource.PlayOneShot(hitSound);

        }
        if (other.CompareTag("Shard"))
        {
            shardsCollected += 1;
            Destroy(other.gameObject);
            audioSource.PlayOneShot(pickupSound);
        }
    }

}

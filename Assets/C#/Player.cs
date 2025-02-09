using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Player : MonoBehaviour
{
    bool isAlive = true;
    private Rigidbody rb;
    [SerializeField] float speed = 20f;
    private float horizontalInput;
    [SerializeField] float jumpForce = 100f;
    private bool isGrounded = false;
    private Animator animator;
   
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = gameObject.GetComponentInChildren<Animator>();
    }

 
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Jump();
        }
        if(transform.position.y < -5)
        {
            Die();
        }
    }
    private void FixedUpdate()
    {
        if (isAlive == false) return;
        Vector3 forwrdMove = transform.forward * speed * Time.fixedDeltaTime;
        Vector3 horizontalMove = transform.right * horizontalInput * speed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + horizontalMove + forwrdMove);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
        void Jump()
        {
        animator.SetTrigger("Jump");
            rb.AddForce(Vector3.up * jumpForce);
        }
    public void Die()
    {
        isAlive = false;
        GameOver();
    }
    void GameOver()
    {
        SceneManager.LoadScene("SampleScene");
    }
}

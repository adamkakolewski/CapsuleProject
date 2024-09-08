using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject controlsInfoPanel;
    [SerializeField] float moveSpeed = 8f;
    [SerializeField] float jumpForce = 8f;
    public bool isGrounded;
    private bool isMoving;
    Vector2 dir;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        isMoving = false;

        if (controlsInfoPanel != null)
        { 
            controlsInfoPanel.SetActive(true);        
        }

    }

  
    void Update()
    {
        isGrounded = Physics.Raycast(transform.position, Vector3.down, 1.1f);

        dir.x = Input.GetAxisRaw("Horizontal");
        dir.y = Input.GetAxisRaw("Vertical");

        transform.Translate(moveSpeed * Time.deltaTime * dir);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded) 
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
       
        if (dir.x != 0 || dir.y != 0)
        { 
            isMoving = true;
        }
        else
        {
            isMoving = false;
        }
        if (isMoving && controlsInfoPanel != null)
        { 
            controlsInfoPanel.SetActive(false);        
        }
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        isGrounded = false;
    }
}

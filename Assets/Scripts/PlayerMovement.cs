using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]

public class PlayerMovement : MonoBehaviour
{


    [SerializeField] private float xSpeed = 5f;
    
    [SerializeField] private float jumpForce = 300f;
 

    private Rigidbody2D _rb;

    private float _xMoveInput;

    private bool _shouldJump;
    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        _xMoveInput = Input.GetAxis("Horizontal") * xSpeed;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _shouldJump = true;
        }
    }

    private void FixedUpdate()
    {
        _rb.velocity = new Vector2(_xMoveInput, _rb.velocity.y);
        if (_shouldJump )
        {

            _rb.AddForce(Vector2.up * jumpForce);
          
            _shouldJump = false;
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("MovingPlatform"))
        {
            transform.SetParent(other.transform, true);
        }
    }
    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("MovingPlatform"))
        {
            transform.SetParent(null, true);
        }
    }
}

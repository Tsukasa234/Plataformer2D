using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float runSpeed = 2;
    [SerializeField] private float jumpSpeed = 3;

    [SerializeField] private bool betterJump = false;
    [SerializeField] private float fallMultiplier = 0.5f, lowJumpMultiplier = 1f;

    private Rigidbody2D _rb;
    private Animator _anim;

    private SpriteRenderer _sr;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
        _sr = GetComponent<SpriteRenderer>();
    }

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            _rb.velocity = new Vector2(-runSpeed, _rb.velocity.y);
            _anim.SetBool("Run", true);
            _sr.flipX = true;            
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            _rb.velocity = new Vector2(runSpeed, _rb.velocity.y);
            _anim.SetBool("Run", true);
            _sr.flipX = false;
        }
        else{
            _rb.velocity = new Vector2(0, _rb.velocity.y);
            _anim.SetBool("Run", false);
        }

        if (Input.GetKey(KeyCode.Space) && CheckGround.isGrounded)
        {
            _rb.velocity = new Vector2(_rb.velocity.x, jumpSpeed);
            _anim.SetBool("Jump", true);
        }

        if (betterJump)
        {
            if (_rb.velocity.y < 0)
            {
                _rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier) * Time.deltaTime;
                _anim.SetBool("Jump", false);
            }
            else if (_rb.velocity.y > 0 && !Input.GetKey(KeyCode.Space))
            {
                _rb.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier) * Time.deltaTime;
            }
        }
    }
}

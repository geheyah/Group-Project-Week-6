using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorScript : MonoBehaviour
{
    [SerializeField]private Animator _animator;
    [SerializeField] private Rigidbody2D _playerRigidbody;
    [SerializeField] private SpriteRenderer _spriteRenderer;

    private static readonly int IsWalking = Animator.StringToHash("isWalking");
    private static readonly int IsJumping = Animator.StringToHash("isJumping");
    private static readonly int IsSprinting = Animator.StringToHash("isSprinting");
    private static readonly int IsAttacking = Animator.StringToHash("isAttacking");
    private static readonly int IsMagic = Animator.StringToHash("isMagic");

    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _playerRigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    void Update()
    {

        //checking if animator is working
        Debug.Log("your animator is working");

        //walking
        _animator.SetBool("isWalking", Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A));

        //jumping

        _animator.SetBool("isJumping", Input.GetKey(KeyCode.W));

        //sprinting

        _animator.SetBool("isSprinting", Input.GetKey(KeyCode.LeftShift));

        //attacking
        _animator.SetBool("isAttacking", Input.GetKey(KeyCode.Mouse0));

        //magic spell
        _animator.SetBool("isMagic", Input.GetKey(KeyCode.Mouse1));

    }
}

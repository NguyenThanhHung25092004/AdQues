using NUnit.Framework.Constraints;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    private CharacterController2D controller;
    public float runSpeed = 10f;
    public string horizontalInput = "Horizontal";
    public KeyCode jumpKey = KeyCode.UpArrow;
    private float horizontalMove;
    private bool jump;
    private Animator ani;

    void Awake()
    {
        controller = GetComponent<CharacterController2D>();
        ani = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        horizontalMove = Input.GetAxisRaw(horizontalInput) * runSpeed;
        ani.SetFloat("Speed", Mathf.Abs(horizontalMove));
        
        if(Input.GetKeyDown(jumpKey))
        {
            jump = true;
            ani.SetBool("IsJumping", true);
        }
    }
    public void stopJumping()
    {
        ani.SetBool("IsJumping", false);
    }

    private void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, jump);
        jump = false;
    }


}

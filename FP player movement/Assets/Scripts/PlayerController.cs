using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private int _walkSpeed = 2;

    public Animator Animator;
    public float _horizontalInput;
    public float _forwardInput;
    public CapsuleCollider PlayerCollider;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.LeftShift))
        {
            Animator.SetBool("IsCrouchIdling", true);
        }
        else
        {
            Animator.SetBool("IsCrouchIdling", false);

        }

        if (_forwardInput > 0)
        {
            Animator.SetBool("IsWalkingForward", true);
            Animator.SetBool("IsWalkingBackward", false);

            Animator.SetBool("IsIdling", false);
        }
        else if(_forwardInput < 0)
        {
            Animator.SetBool("IsWalkingBackward", true);
            Animator.SetBool("IsWalkingForward", false);

            Animator.SetBool("IsIdling", false);
        }
        else
        {
            Animator.SetBool("IsWalkingForward", false);
            Animator.SetBool("IsWalkingBackward", false);
            Animator.SetBool("IsIdling", true);



        }


    }

    void FixedUpdate()
    {
        _horizontalInput = Input.GetAxis("Horizontal");
        _forwardInput = Input.GetAxis("Vertical");

        transform.Translate(Vector3.forward * Time.deltaTime * _walkSpeed * _forwardInput);
        transform.Translate(Vector3.right * Time.deltaTime * _walkSpeed * _horizontalInput);
    }
}

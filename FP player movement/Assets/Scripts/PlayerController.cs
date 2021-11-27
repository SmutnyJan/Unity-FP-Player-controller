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
            Animator.SetBool("isCrouchIdling", true);
            PlayerCollider.center = new Vector3(PlayerCollider.center.x, 0.6f, PlayerCollider.center.z);
            PlayerCollider.height = 1.11f;

        }
        else
        {
            Animator.SetBool("isCrouchIdling", false);
            PlayerCollider.center = new Vector3(PlayerCollider.center.x, 0.88f, PlayerCollider.center.z);
            PlayerCollider.height = 1.68f;

        }

        if (_forwardInput > 0)
        {
            if(Input.GetKey(KeyCode.LeftShift))
            {
                Animator.SetBool("isCrouchWalkingForward", true);
            }
            else
            {
                Animator.SetBool("isWalkingForward", true);
                Animator.SetBool("isWalkingBackwards", false);
            }

        }
        else if(_forwardInput < 0)
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                Animator.SetBool("isCrouchWalkingBackwards", true);
            }
            else
            {
                Animator.SetBool("isWalkingBackwards", true);
                Animator.SetBool("isWalkingForward", false);
            }


        }
        else
        {
            Animator.SetBool("isWalkingForward", false);
            Animator.SetBool("isWalkingBackwards", false);
            Animator.SetBool("isCrouchWalkingForward", false);
            Animator.SetBool("isCrouchWalkingBackwards", false);


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

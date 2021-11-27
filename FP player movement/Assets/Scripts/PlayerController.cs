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
        }
        else
        {
            Animator.SetBool("isCrouchIdling", false);

        }

        if (_forwardInput > 0)
        {
            Animator.SetBool("isWalkingForward", true);
            Animator.SetBool("isWalkingBackwards", false);

        }
        else if(_forwardInput < 0)
        {
            Animator.SetBool("isWalkingBackwards", true);
            Animator.SetBool("isWalkingForward", false);

        }
        else
        {
            Animator.SetBool("isWalkingForward", false);
            Animator.SetBool("isWalkingBackwards", false);
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

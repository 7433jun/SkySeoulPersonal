using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseCharacter : MonoBehaviour
{
    [SerializeField] private float speed = 5.0f;
    [SerializeField] private float jumpForce = 7.0f;
    [SerializeField] private float rotationSpeed = 10.0f;

    private float horizontal;
    private float vertical;


    public bool grounded = true;
    private static float groundOffset = -0.14f;
    private static float groundRadius = 0.28f;
    public LayerMask groundLayers;

    private float verticalVelocity;
    private float limitVelocity = 53.0f;

    private Transform cameraTransform;

    private CharacterController controller;

    protected virtual void Start()
    {
        controller = GetComponent<CharacterController>();

        cameraTransform = Camera.main.transform;
    }

    
    protected virtual void Update()
    {
        GroundedCheck();
        JumpAndGravity();
        Move();
    }

    private void GroundedCheck()
    {
        Vector3 spherePosition = new Vector3(transform.position.x, transform.position.y - groundOffset, transform.position.z);
        grounded = Physics.CheckSphere(spherePosition, groundRadius, groundLayers, QueryTriggerInteraction.Ignore);
    }

    private void JumpAndGravity()
    {
        if (grounded)
        {
            if (verticalVelocity < 0.0f)
            {
                verticalVelocity = -2f;
            }

            FallAni(false);
        }
        else
        {
            FallAni(true);
        }

        if (verticalVelocity < limitVelocity)
        {
            verticalVelocity += Physics.gravity.y * Time.deltaTime;
        }
    }

    private void Move()
    {
        Vector3 cameraForward = cameraTransform.forward;
        Vector3 cameraRight = cameraTransform.right;

        cameraForward.y = 0;
        cameraRight.y = 0;
        cameraForward.Normalize();
        cameraRight.Normalize();

        Vector3 dir = (cameraForward * vertical + cameraRight * horizontal) * speed;

        if (dir != Vector3.zero)
        {
            Quaternion newRotation = Quaternion.LookRotation(dir);
            transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, rotationSpeed * Time.deltaTime);
        }

        dir.y += verticalVelocity;
        controller.Move(dir * Time.deltaTime);

        MoveAni(horizontal, vertical);
    }

    public void SetMove(float _horizontal, float _vertical)
    {
        horizontal = _horizontal;
        vertical = _vertical;
    }

    public void SetJump()
    {
        if (grounded)
        {
            verticalVelocity = Mathf.Sqrt(jumpForce * -2f * Physics.gravity.y);

            JumpAni();
        }
    }

    public void Fire()
    {
        Debug.Log("Fire");
    }

    public void Aim()
    {
        Debug.Log("Aim");
    }

    public void SetCrouch()
    {
        Debug.Log("Crouch");
    }

    public void DodgeAndRun()
    {
        Debug.Log("DodgeAndRun");
    }

    public void LockOn()
    {
        Debug.Log("LockOn");
    }

    public abstract void UseQuickSlot(int index);

    public abstract void ChangeWeapon(int change);

    protected abstract void MoveAni(float horizontal, float vertical);
    protected abstract void JumpAni();
    protected abstract void FallAni(bool isFall);
}

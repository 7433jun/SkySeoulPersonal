using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HanCharacter : BaseCharacter
{
    private Animator animator;


    protected override void Start()
    {
        base.Start();

        animator = GetComponent<Animator>();
    }

    protected override void Update()
    {
        base.Update();


    }

    public void RobotSelect()
    {
        Debug.Log("RobotSelect");
    }

    public void RobotSkill()
    {
        Debug.Log("RobotSkill");
    }

    public void RobotAction()
    {
        Debug.Log("RobotAction");
    }

    public void RobotRelease()
    {
        Debug.Log("RobotRelease");
    }

    public void Hacking()
    {
        Debug.Log("Hacking");
    }

    protected override void MoveAni(float horizontal, float vertical)
    {
        animator.SetFloat("Horizontal", horizontal);
        animator.SetFloat("Vertical", vertical);
    }

    protected override void FallAni(bool isFall)
    {
        animator.SetBool("IsFall", isFall);
    }

    protected override void JumpAni()
    {
        animator.SetTrigger("Jump");
    }
}

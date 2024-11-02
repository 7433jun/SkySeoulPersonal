using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HanCharacter : BaseCharacter
{
    private Animator animator;

    public float baseHP = 250.0f;
    public float additionalHP = 0;
    public float maxHP;
    public float currentHP = 90.0f;

    public float baseSP = 100.0f;
    public float additionalSP = 0;
    public float maxSP;
    public float currentSP = 80.0f;

    public float baseSH = 170.0f;
    public float additionalSH = 0;
    public float maxSH;
    public float currentSH = 170.0f;

    private HanInventoryManager inventoryManager;
    public int currentHand = -1;

    protected override void Start()
    {
        base.Start();

        animator = GetComponent<Animator>();

        inventoryManager = GameManager.Instance.inventoryManager as HanInventoryManager;

        SetHP(0);
        SetSP(0);
        SetSH(0);
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

    public override void UseQuickSlot(int index)
    {
        if ((GameManager.Instance.inventoryManager as HanInventoryManager).quickSlot[index] != null)
        {
            Debug.Log((GameManager.Instance.inventoryManager as HanInventoryManager).quickSlot[index]);
        }
    }

    public override void ChangeWeapon(int change)
    {
        SetHand(change);

        GameManager.Instance.hudManager.SetWheelUI();
    }

    public void SetHand(int change)
    {
        if (inventoryManager.gun == null && inventoryManager.phone == null && inventoryManager.laptop == null)
        {
            currentHand = -1;
            return;
        }

        currentHand = (currentHand + change + 3) % 3;

        while (true)
        {
            switch (currentHand)
            {
                case 0:
                    if (inventoryManager.gun != null)
                    {
                        OnHandGun();
                        return;
                    }
                    break;
                case 1:
                    if (inventoryManager.phone != null)
                    {
                        OnHandPhone();
                        return;
                    }
                    break;
                case 2:
                    if (inventoryManager.laptop != null)
                    {
                        OnHandLaptop();
                        return;
                    }
                    break;
            }

            currentHand = (currentHand + change + 3) % 3;
        }
    }

    public void SetHand()
    {
        if (inventoryManager.gun == null && inventoryManager.phone == null && inventoryManager.laptop == null)
        {
            currentHand = -1;
            return;
        }

        while (true)
        {
            switch (currentHand)
            {
                case 0:
                    if (inventoryManager.gun != null)
                    {
                        OnHandGun();
                        return;
                    }
                    break;
                case 1:
                    if (inventoryManager.phone != null)
                    {
                        OnHandPhone();
                        return;
                    }
                    break;
                case 2:
                    if (inventoryManager.laptop != null)
                    {
                        OnHandLaptop();
                        return;
                    }
                    break;
            }

            currentHand = (currentHand + 4) % 3;
        }
    }

    private void OnHandGun()
    {

    }

    private void OnHandPhone()
    {

    }

    private void OnHandLaptop()
    {

    }

    public void SetHP(float value)
    {
        additionalHP += value;
        maxHP = baseHP + additionalHP;
        if (currentHP > maxHP)
            currentHP = maxHP;
    }

    public void SetSP(float value)
    {
        additionalSP += value;
        maxSP = baseSP + additionalSP;
        if (currentSP > maxSP)
            currentSP = maxSP;
    }

    public void SetSH(float value)
    {
        additionalSH += value;
        maxSH = baseSH + additionalSH;
        if (currentSH > maxSH)
            currentSH = maxSH;
    }
}

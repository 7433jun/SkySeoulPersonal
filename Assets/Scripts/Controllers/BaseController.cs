using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class BaseController : MonoBehaviour
{
    protected BaseCharacter baseCharacter;



    protected virtual void Start()
    {
        baseCharacter = GetComponent<BaseCharacter>();
    }

    protected virtual void Update()
    {
        MoveInput();
        ActionInput();
        ConsumeItem();
        CustomActionInput();
    }

    private void MoveInput()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        baseCharacter.SetMove(h, v);

        if (Input.GetButtonDown("Jump"))
        {
            baseCharacter.SetJump();
        }

        //Photon.SendMove(h, v);
    }

    private void ActionInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //baseCharacter.Fire();
        }
        if (Input.GetMouseButton(0))
        {
            //baseCharacter.Fire();
        }
        if (Input.GetMouseButtonUp(0))
        {
            //baseCharacter.Fire();
        }

        if (Input.GetMouseButtonDown(1))
        {
            //baseCharacter.Aim();
        }
        if (Input.GetMouseButton(1))
        {
            //baseCharacter.Aim();
        }
        if (Input.GetMouseButtonUp(1))
        {
            //baseCharacter.Aim();
        }

        float wheelInput = Input.GetAxis("Mouse ScrollWheel");
        if (wheelInput > 0)
        {
            baseCharacter.ChangeWeapon(1);
        }
        else if (wheelInput < 0)
        {
            baseCharacter.ChangeWeapon(-1);
        }

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            baseCharacter.LockOn();
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            baseCharacter.DodgeAndRun();
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            baseCharacter.DodgeAndRun();
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            baseCharacter.DodgeAndRun();
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            baseCharacter.SetCrouch();
        }

        if (Input.GetKeyDown(KeyCode.I))
        {
            GameManager.Instance.uiManager.ToggleInventory();
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            //상호작용 버튼이벤트
            Debug.Log("interaction");
        }
        if (Input.GetKey(KeyCode.F))
        {
            //상호작용 버튼이벤트
            Debug.Log("interaction");
        }
        if (Input.GetKeyUp(KeyCode.F))
        {
            //상호작용 버튼이벤트
            Debug.Log("interaction");
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //뒤로가기 UI
            Debug.Log("Escape");
        }
    }

    private void ConsumeItem()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            // 소비아이템 슬롯 1 사용
            Debug.Log("Consume Item 1");
            baseCharacter.UseQuickSlot(0);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            // 소비아이템 슬롯 2 사용
            Debug.Log("Consume Item 2");
            baseCharacter.UseQuickSlot(1);
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            // 소비아이템 슬롯 3 사용
            Debug.Log("Consume Item 3");
            baseCharacter.UseQuickSlot(2);
        }

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            // 소비아이템 슬롯 4 사용
            Debug.Log("Consume Item 4");
            baseCharacter.UseQuickSlot(3);
        }
    }
    protected abstract void CustomActionInput();
}

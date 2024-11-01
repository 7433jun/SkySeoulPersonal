using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HanHUDManager : MonoBehaviour
{
    [SerializeField] private Slider hpBar;
    [SerializeField] private Slider spBar;
    [SerializeField] private Slider shBar;

    [SerializeField] private Image[] slotImages;

    [SerializeField] private GameObject wheelUIPrefab;

    private HanCharacter hanCharacter;
    private HanInventoryManager inventoryManager;

    void Start()
    {
        StartCoroutine(InitHUD());
    }

    void Update()
    {
        if (hanCharacter)
        {
            hpBar.value = hanCharacter.currentHP / hanCharacter.maxHP;
            spBar.value = hanCharacter.currentSP / hanCharacter.maxSP;
            shBar.value = hanCharacter.currentSH / hanCharacter.maxSH;
        }

        if (inventoryManager)
        {
            for (int i = 0; i < slotImages.Length; i++)
            {
                if (inventoryManager.quickSlot[i] != null)
                {
                    slotImages[i].sprite = inventoryManager.quickSlot[i].itemInfo.sprite;
                    Color _color = slotImages[i].color;
                    _color.a = 1.0f;
                    slotImages[i].color = _color;
                }
                else
                {
                    slotImages[i].sprite = null;
                    Color _color = slotImages[i].color;
                    _color.a = 0.0f;
                    slotImages[i].color = _color;
                }
            }
        }
    }

    private IEnumerator InitHUD()
    {
        yield return null;

        Debug.Log("hud");

        hanCharacter = GameManager.Instance.playerCharacter.GetComponent<BaseCharacter>() as HanCharacter;
        inventoryManager = GameManager.Instance.inventoryManager as HanInventoryManager;
    }
}

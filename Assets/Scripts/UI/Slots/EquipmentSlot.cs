using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class EquipmentSlot : MonoBehaviour, IPointerClickHandler, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public EquipmentType equipmentType;

    private bool isItemExist;
    private Image image;

    void Start()
    {
        image = GetComponent<Image>();
    }

    public void SetImage(Item item)
    {
        if (item != null)
        {
            if (item.itemInfo.sprite != null)
            {
                image.sprite = item.itemInfo.sprite;
            }
            else
            {
                image.sprite = null;
            }
            Color _color = image.color;
            _color.a = 1.0f;
            image.color = _color;

            isItemExist = true;
        }
        else
        {
            image.sprite = null;
            Color _color = image.color;
            _color.a = 0.0f;
            image.color = _color;

            isItemExist = false;
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (!isItemExist)
            return;

        if (eventData.button == PointerEventData.InputButton.Left)
        {
            if (GameManager.Instance.uiManager.descriptionUI.gameObject.activeSelf)
                GameManager.Instance.uiManager.descriptionUI.SetDescription(GameManager.Instance.inventoryManager.GetEquipmentItem(equipmentType));
            else if (GameManager.Instance.uiManager.enhancementUI.gameObject.activeSelf)
                GameManager.Instance.uiManager.enhancementUI.SetEnhance(GameManager.Instance.inventoryManager.GetEquipmentItem(equipmentType));
        }
        else if (eventData.button == PointerEventData.InputButton.Right)
        {
            GameManager.Instance.inventoryManager.Unequip(equipmentType);
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (!isItemExist)
            return;

        if (eventData.button == PointerEventData.InputButton.Left)
        {
            GameManager.Instance.uiManager.dragIcon.GetComponent<Image>().sprite = GameManager.Instance.inventoryManager.GetEquipmentItem(equipmentType).itemInfo.sprite;
            GameManager.Instance.uiManager.dragIcon.SetActive(true);
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (!isItemExist)
            return;

        if (eventData.button == PointerEventData.InputButton.Left)
        {
            GameManager.Instance.uiManager.dragIcon.transform.position = Input.mousePosition;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (!isItemExist)
            return;

        if (eventData.button == PointerEventData.InputButton.Left)
        {
            GameManager.Instance.uiManager.dragIcon.SetActive(false);

            ItemSlot itemSlot = eventData.pointerCurrentRaycast.gameObject.GetComponent<ItemSlot>();

            if (itemSlot)
            {
                if (itemSlot.itemType == ItemType.Equipment)
                {
                    GameManager.Instance.inventoryManager.Unequip(equipmentType, itemSlot.slotIndex);
                }
            }
        }
    }
}

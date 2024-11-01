using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager instance = null;
    public BaseInventoryManager inventoryManager { get; private set; }
    public BaseUIManager uiManager { get; private set; }

    private CharacterType characterType;

    [SerializeField] CinemachineFreeLook cinemachineFreeLook;

    [SerializeField] Transform spawnPoint;
    [SerializeField] GameObject hanPrefab;
    [SerializeField] GameObject hanHUDPrefab;
    [SerializeField] GameObject hanInventoryManagerPrefab;
    [SerializeField] GameObject hanUIManagerPrefab;

    public GameObject playerCharacter { get; private set; }

    public GameObject hudCanvas;
    public GameObject inventoryCanvas;
    public List<ItemInfo> itemInfoList;

    void Awake()
    {
        if (null == instance)
        {
            instance = this;
        }

        characterType = PlayerData.Instance().characterType;
    }

    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                return null;
            }
            return instance;
        }
    }

    void Start()
    {
        switch (characterType)
        {
            case CharacterType.Han:

                playerCharacter = Instantiate(hanPrefab, spawnPoint);
                playerCharacter.transform.parent = null;
                playerCharacter.AddComponent<HanController>();

                cinemachineFreeLook.Follow = playerCharacter.transform;
                cinemachineFreeLook.LookAt = playerCharacter.transform;

                Instantiate(hanHUDPrefab, hudCanvas.transform);
                inventoryManager = Instantiate(hanInventoryManagerPrefab, inventoryCanvas.transform).GetComponent<HanInventoryManager>();
                uiManager = Instantiate(hanUIManagerPrefab, inventoryCanvas.transform).GetComponent<HanUIManager>();

                break;
            case CharacterType.Jo:
                break;
            case CharacterType.Other:
                break;
            default:
                break;
        }
    }

    public void SwitchScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}

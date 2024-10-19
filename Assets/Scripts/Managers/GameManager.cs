using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager instance = null;
    public BaseInventoryManager inventoryManager;
    public BaseUIManager uiManager;

    private CharacterType characterType;

    [SerializeField] CinemachineFreeLook cinemachineFreeLook;

    [SerializeField] Transform spawnPoint;
    [SerializeField] GameObject hanPrefab;
    [SerializeField] GameObject hanInventoryManagerPrefab;
    [SerializeField] GameObject hanUIManagerPrefab;

    public GameObject playerCharacter;

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

                inventoryManager = Instantiate(hanInventoryManagerPrefab).GetComponent<HanInventoryManager>();
                uiManager = Instantiate(hanUIManagerPrefab).GetComponent<HanUIManager>();

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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LobbySceneUI : MonoBehaviour
{
    [SerializeField] Button _dungeonBtn;
    private Dungeon _dungeon;

    // Start is called before the first frame update
    private void Start()
    {
        _dungeon = new Dungeon();
        _dungeonBtn.onClick.AddListener(DungeonSceneEnter);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void DungeonSceneEnter()
    {
        SceneMgr.Instance.ChangeScene(_dungeon);
    }

    private void OnDestroy()
    {
        _dungeon = null;
    }
}

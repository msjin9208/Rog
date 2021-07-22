using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneMgr : MonoBehaviour
{
    public static SceneMgr Instance;

    private List<SceneBase> _stackScene;
    private SceneBase _previewScene;
    private SceneBase _currentScene;
    private SceneBase _nextScene;

    public bool _readyToLoad = false;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            Debug.Log("씬 매니저 인스턴스 생성 완료!");
        }
        if(_stackScene == null)
            _stackScene = new List<SceneBase>();

        DontDestroyOnLoad(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        _previewScene = null;
        _nextScene = null;


        _currentScene = new GameStart();
    }

    // Update is called once per frame
    void Update()
    {
        if(_readyToLoad == true)
        {
            LoadScene();
            _readyToLoad = false;  
        }
    }

    public void ChangeScene(SceneBase scene)
    {
        if(_nextScene == null)
            _nextScene = scene;

        if(_nextScene == _currentScene)
            Debug.LogError("중복 씬 들어오면 안되는 부분");

        if(_currentScene == null)
        {
            Debug.LogError("중복 씬 들어오면 안되는 부분");
            return;
        }

        SwichingScene();
    }



    private void SwichingScene()
    {
        _currentScene.ExitScene();

        _previewScene = _currentScene;
        _currentScene = _nextScene;
        _nextScene = null;
    }

    public void LoadScene()
    {
        SceneManager.LoadScene(_currentScene.ToString());
        _currentScene.EnterScene();
    }


   
}

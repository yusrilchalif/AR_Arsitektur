using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    public SceneTransitionController sceneTransition;
    public string sceneName;

    public Button buttonStart;
    public Button buttonExit;

    // Start is called before the first frame update
    void Start()
    { 
        buttonStart = GetComponent<Button>();
        buttonStart.onClick.AddListener(MoveScene);
        buttonExit.onClick.AddListener(ExitApp);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void MoveScene()
    {
        sceneTransition.TransitionScene(sceneName);
    }

    void ExitApp()
    {
        sceneTransition.ExitGame();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG;
using DG.Tweening;

public class SceneTransitionController : MonoBehaviour
{
    [SerializeField] float transitionDuration = 2.0f;
    public Ease transitionEase;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TransitionScene(string sceneName)
    {
        DOTween.Sequence()
            .Append(DOTween.To(() => 1.0f, x => { }, 0.0f, transitionDuration)
                .SetEase(transitionEase)
                .OnComplete(() =>
                {
                    // Memuat scene baru setelah animasi transisi selesai
                    SceneManager.LoadScene(sceneName);
                })
            );
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}

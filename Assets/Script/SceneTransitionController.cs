using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG;
using DG.Tweening;
using UnityEngine.UI;

public class SceneTransitionController : MonoBehaviour
{
    public GameObject fadePanelPrefab;
    public float fadeDuration = 5.0f;
    public Ease fadeEase = Ease.Linear;

    private GameObject fadePanel;

    private void Start()
    {
        fadePanel = Instantiate(fadePanelPrefab, transform);
        fadePanel.SetActive(false);
    }

    public void TransitionToScene(string sceneName)
    {
        StartCoroutine(TransitionRoutine(sceneName));
    }

    private IEnumerator TransitionRoutine(string sceneName)
    {
        fadePanel.SetActive(true);

        // Fade Out
        fadePanel.GetComponent<Image>().DOFade(1f, fadeDuration)
            .SetEase(fadeEase);

        yield return new WaitForSeconds(fadeDuration);

        // Load Scene
        SceneManager.LoadScene(sceneName);

        // Fade In
        fadePanel.GetComponent<Image>().DOFade(0f, fadeDuration)
            .SetEase(fadeEase);

        yield return new WaitForSeconds(fadeDuration);

        fadePanel.SetActive(false);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}

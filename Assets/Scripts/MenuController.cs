using UnityEngine;

public class MenuController : MonoBehaviour
{
    public GameObject menuRoot;        
    public PauseManager pauseManager;  

    void Start()
    {
       
        if (menuRoot && menuRoot.activeSelf)
        {
            Time.timeScale = 0f;
            if (pauseManager) pauseManager.enabled = false;
        }
    }

    public void OnStart()
    {
        if (menuRoot) menuRoot.SetActive(false);
        Time.timeScale = 1f;
        if (pauseManager) pauseManager.enabled = true;
    }

    public void OnQuit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}

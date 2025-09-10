using UnityEngine;

public class CanvasManager : Singleton<CanvasManager>
{
    [SerializeField] private GameObject m_Logo;
    [SerializeField] private GameObject m_StartScreen;
    [SerializeField] private GameObject m_MenuScreen;

    private void Start()
    {
        m_Logo.SetActive(true);
        m_StartScreen.SetActive(true);
        m_MenuScreen.SetActive(false);
    }
    
    public void OnStartButtonClickedHandler()
    {
        GameManager.Instance.OnStartGameClicked();
        m_Logo.SetActive(false);
        m_StartScreen.SetActive(false);
        m_MenuScreen.SetActive(false);
    }



}

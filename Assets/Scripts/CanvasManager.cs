using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CanvasManager : Singleton<CanvasManager>
{
    [SerializeField] private GameObject m_Logo;
    [SerializeField] private GameObject m_StartScreen;
    [SerializeField] private GameObject m_MenuScreen;
    [SerializeField] private List<TextMeshProUGUI> m_LeaderBoardTexts;
    [SerializeField] private TextMeshProUGUI m_CurrentScoreText;
 
    private void Start()
    {
        m_Logo.SetActive(true);
        m_StartScreen.SetActive(true);
        m_MenuScreen.SetActive(false);
    }
    
    public void OnStartButtonClickedHandler()
    {
        m_Logo.SetActive(false);
        m_StartScreen.SetActive(false);
        m_MenuScreen.SetActive(false);
        GameManager.Instance.OnStartGameClicked();
        PlayerController.Instance.ActivateController();
    }


    public void ShowMenuScreen(int i_CurrentScore, List<int> i_LeaderBoard)
    {
        m_Logo.SetActive(true);
        m_MenuScreen.SetActive(true);
        populateMenu(i_CurrentScore, i_LeaderBoard);
    }

    private void populateMenu(int i_CurrentScore, List<int> i_LeaderBoard)
    {
        m_CurrentScoreText.text = "Score: " + i_CurrentScore;

        for(int i = 0; i < i_LeaderBoard.Count; i++)
        {
            m_LeaderBoardTexts[i].text = (i + 1) + ":........ " + i_LeaderBoard[i];
        }
    }
}

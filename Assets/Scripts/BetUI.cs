using UnityEngine;
using UnityEngine.UI;


public class BetUI : MonoBehaviour
{
    [Header("Popup Panel")]
    public GameObject betPanel;      

[Header("Lever")]
public LeverAnimator leverAnimator;
    [Header("Bet Buttons")]
    public Button bet10Button;
    public Button bet50Button;
    public Button bet100Button;
    public Button exitButton;

    [Header("References")]
    public SlotManager slotManager;

    void Start()
    {
      
        ShowBetPanel();

 
        bet10Button.onClick.AddListener(() => SelectBet(10));
        bet50Button.onClick.AddListener(() => SelectBet(50));
        bet100Button.onClick.AddListener(() => SelectBet(100));
        exitButton.onClick.AddListener(ExitGame);
    }


    public void ShowBetPanel()
    {
        betPanel.SetActive(true);
    }


    void SelectBet(int amount)
    {
        GameManager.Instance.SetBet(amount);
        betPanel.SetActive(false);      
          leverAnimator.OnLeverClicked();   
    }

    void ExitGame()
    {
        Application.Quit();
    }
}
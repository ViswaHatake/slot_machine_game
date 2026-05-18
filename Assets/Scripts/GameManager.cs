using UnityEngine;
using TMPro;


public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("Player Stats")]
    public int totalCoins = 100;
    public int currentBet = 0;
    public TMP_Text betText;
    [Header("UI")]
    public TMP_Text coinText;

    void Awake()
    {
    
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    void Start()
    {
        UpdateCoinUI();
    }

  
   public void SetBet(int amount)
{
    currentBet = amount;
    betText.text = "Bet: " + amount + "G";
}

  
    public bool PlaceBet()
    {
        if (totalCoins >= currentBet && currentBet > 0)
        {
            totalCoins -= currentBet;
            UpdateCoinUI();
            return true;
        }
        return false;
    }

  
    public void AddWinnings(int multiplier)
    {
        totalCoins += currentBet * multiplier;
        UpdateCoinUI();
    }

     void UpdateCoinUI()
    {
        if (coinText != null)
            coinText.text = totalCoins.ToString() + "G";
    }
    
}

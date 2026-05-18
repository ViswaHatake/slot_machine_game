using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class SlotManager : MonoBehaviour
{
    [Header("Reels")]
    public ReelController reel1;
    public ReelController reel2;
    public ReelController reel3;

    [Header("UI")]
    public TMP_Text resultText;

    [Header("Win Multipliers")]
    public int cherryMultiplier = 2;
    public int bellMultiplier = 3;
    public int barMultiplier = 5;
    public int sevenMultiplier = 10;

    [Header("References")]
    public BetUI betUI;
    public LeverAnimator leverAnimator;

    void Start()
    {

        leverAnimator = FindAnyObjectByType<LeverAnimator>();
        resultText.text = "";
    }


    public void StartSpin()
    {

        if (!GameManager.Instance.PlaceBet())
        {
            betUI.ShowBetPanel();
            resultText.text = "NOT ENOUGH COINS!";
            return;
        }
        StartCoroutine(SpinAllReels());
    }




    IEnumerator SpinAllReels()
    {

        resultText.text = "Spinning...";


        int chance = Random.Range(0, 100);

        if (chance < 30)
        {

            int forcedSymbol = Random.Range(0, 4);

            Coroutine c1 = StartCoroutine(reel1.Spin(forcedSymbol));
            Coroutine c2 = StartCoroutine(reel2.Spin(forcedSymbol));
            Coroutine c3 = StartCoroutine(reel3.Spin(forcedSymbol));

            yield return c1;
            yield return c2;
            yield return c3;
        }
        else
        {

            Coroutine c1 = StartCoroutine(reel1.Spin());
            Coroutine c2 = StartCoroutine(reel2.Spin());
            Coroutine c3 = StartCoroutine(reel3.Spin());

            yield return c1;
            yield return c2;
            yield return c3;
        }

        CheckWin();



        betUI.ShowBetPanel();

    }


    void CheckWin()
    {
        int s1 = reel1.GetResult();
        int s2 = reel2.GetResult();
        int s3 = reel3.GetResult();

        if (s1 == s2 && s2 == s3)
        {

            int multiplier = GetMultiplier(s1);
            GameManager.Instance.AddWinnings(multiplier);
            resultText.text = "YOU WIN! x" + multiplier;
        }
        else
        {
            resultText.text = "TRY AGAIN!";
        }
    }


    int GetMultiplier(int symbolIndex)
    {
        switch (symbolIndex)
        {
            case 0: return sevenMultiplier;
            case 1: return cherryMultiplier;
            case 2: return bellMultiplier;
            case 3: return barMultiplier;
            default: return 1;
        }
    }
}
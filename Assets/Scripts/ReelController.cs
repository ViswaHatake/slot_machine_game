using System.Collections;
using UnityEngine;
using UnityEngine.UI;


public class ReelController : MonoBehaviour
{
    [Header("References")]
    public Image symbolImage; 

    [Header("Symbols")]
    public Sprite[] symbols;

    [Header("Spin Settings")]
    public float spinDuration = 2f;
    public float shuffleSpeed = 0.1f;

    private int finalSymbolIndex;

    public IEnumerator Spin(int forcedSymbol = -1)
    {
        finalSymbolIndex = forcedSymbol >= 0 ?
            forcedSymbol : Random.Range(0, symbols.Length);

        float timer = 0f;

        
        while (timer < spinDuration)
        {
            int randomIndex = Random.Range(0, symbols.Length);
            symbolImage.sprite = symbols[randomIndex];
            timer += shuffleSpeed;
            yield return new WaitForSeconds(shuffleSpeed);
        }


        symbolImage.sprite = symbols[finalSymbolIndex];
    }

    public int GetResult()
    {
        return finalSymbolIndex;
    }
}
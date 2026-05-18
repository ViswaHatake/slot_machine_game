using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class LeverAnimator : MonoBehaviour
{
    [Header("References")]
    public Animator leverAnim;
    public SlotManager slotManager;
    [Header("Sprites")]


    private bool isAnimating = false;

    void Start()
    {

        leverAnim.enabled = true;
        leverAnim.speed = 0; 
    }

    public void OnLeverClicked()
    {
        if (!isAnimating)
            StartCoroutine(PlayAndSpin());
    }

    IEnumerator PlayAndSpin()
    {
        isAnimating = true;

      
        leverAnim.speed = 1; 
        leverAnim.Play("Liver Animation", 0, 0); 

        yield return new WaitForSeconds(0.6f);

        leverAnim.speed = 0; 


        slotManager.StartSpin();

        isAnimating = false;
    }

    public void EnableLever()
    {
        GetComponent<Button>().interactable = true;
    }

    public void DisableLever()
    {
        GetComponent<Button>().interactable = false;
    }
}
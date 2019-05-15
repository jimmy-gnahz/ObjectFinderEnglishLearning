using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Button firstWord;
    public Button secondWord;

    public GameObject firstHeart;
    public GameObject secondHeart;
    public GameObject thirdHeart;

    public static string currentLockedObjectTag;
    public GameObject FPC;
    public Text MessageText;
    public static ArrayList wordlist;
    private ArrayList buttonList;
    private int currentHealth;

    public void Start()
    {
        buttonList = new ArrayList() { firstWord, secondWord };
        wordlist = new ArrayList(){"Tree", "Flower"};
        currentHealth = 3;
    }

    public void CheckIfCorrect(Text buttonText)
    {
        // Selected the right word
        for(int i=0; i<wordlist.Count; i++){
            if (GameManager.currentLockedObjectTag == (string) wordlist[i] &&
                GameManager.currentLockedObjectTag == buttonText.text)
            {
                StartCoroutine(ShowMessage("Correct!", 2));
                Debug.Log(wordlist[i]);
                Button currentButton = (Button) buttonList[i];
                currentButton.gameObject.SetActive(false);
                wordlist.RemoveAt(i);
                buttonList.RemoveAt(i);
                FPC.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().m_MouseLook.SetCursorLock(true);
                return;
            }
        }

        // Selected the wrong word 
        StartCoroutine(ShowMessage("Incorrect!", 1));
        currentHealth--;
        updateHealth();
        if (currentHealth <= 0)
        {
            StartCoroutine(ShowMessage("GAME OVER", 10));
        }
    }

    void updateHealth()
    {
        if (currentHealth < 1)
        {
            firstHeart.SetActive(false);
        }
        if (currentHealth < 2)
        {
            secondHeart.SetActive(false);
        }
        if (currentHealth < 3)
        {
            thirdHeart.SetActive(false);
        }
    }

    IEnumerator ShowMessage(string message, float delay)
    {
        MessageText.enabled = true;
        MessageText.text = message;
        yield return new WaitForSeconds(delay);
        MessageText.enabled = false;
    }

}

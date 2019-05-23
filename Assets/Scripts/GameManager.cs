using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Button Word1;
    public Button Word2;
    public Button Word3;
    public Button Word4;
    public Button Word5;
    public Button Word6;
    public Button Word7;
    public Button Word8;
    public Button Word9;
    public Button Word10;
    public Button Word11;
    public Button Word12;

    public GameObject firstHeart;
    public GameObject secondHeart;
    public GameObject thirdHeart;

    public static string currentLockedObjectTag;
    public GameObject FPC;
    public Text MessageText;
    public static ArrayList wordlist;

    public GameObject gameOverScreen;
    public GameObject LevelAudio;
    public GameObject fadeOut;

    public GameObject finishLevel;

    private ArrayList buttonList;
    public static int currentHealth;

        
    public void Start()
    {
        buttonList = new ArrayList() { Word1, Word2, Word3, Word4, Word5, Word6, Word7, Word8, Word9, Word10, Word11, Word12 };
        wordlist = new ArrayList(){"Tree", "Flower", "Grass", "Soil", "Bud", "Leaf","Root","Stem","Sprout","Sunshine", "Branch","Seed"};
        currentHealth = 3;
    }

    public void CheckIfCorrect(Text buttonText)
    {
        
        // Selected the right word
        for (int i=0; i<wordlist.Count; i++){
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
                CheckWin();
                return;
            }
        }

        if (GameManager.currentLockedObjectTag == "Leaf" ||
                GameManager.currentLockedObjectTag == "Branch")
        {
            if (buttonText.text == "Tree")
            {
                StartCoroutine(ShowMessage("Correct!", 2));
                int i = wordlist.IndexOf("Tree");
                Button currentButton = (Button)buttonList[i];
                currentButton.gameObject.SetActive(false);
                wordlist.RemoveAt(i);
                buttonList.RemoveAt(i);
                FPC.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().m_MouseLook.SetCursorLock(true);
                CheckWin();
                return;
            }
        }

        if (GameManager.currentLockedObjectTag == "Stem")
        {
            if (buttonText.text == "Flower")
            {
                StartCoroutine(ShowMessage("Correct!", 2));
                int i = wordlist.IndexOf("Flower");
                Button currentButton = (Button)buttonList[i];
                currentButton.gameObject.SetActive(false);
                wordlist.RemoveAt(i);
                buttonList.RemoveAt(i);
                FPC.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().m_MouseLook.SetCursorLock(true);
                CheckWin();
                return;
            }
        }

        // Selected the wrong word 
        StartCoroutine(ShowMessage("Incorrect!", 1));
        currentHealth--;
        updateHealth();
        if (currentHealth <= 0)
        {
            StartCoroutine(GameOver());
        }
    }

    void CheckWin()
    {
        if (wordlist.Count <= 0)
        {
            fadeOut.SetActive(true);
            finishLevel.GetComponent<FinishLevel>().Finish();
            
        }
    }

    IEnumerator GameOver()
    {
        gameOverScreen.SetActive(true);
        Time.timeScale = 0.3f;
        yield return new WaitForSecondsRealtime(1);
        LevelAudio.SetActive(false);
        fadeOut.SetActive(true);
        yield return new WaitForSecondsRealtime(2);
        SceneManager.LoadScene(1);
        Time.timeScale = 1f;
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

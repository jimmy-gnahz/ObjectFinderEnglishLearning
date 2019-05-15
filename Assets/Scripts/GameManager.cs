using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Button firstWord;
    public Button secondWord;

    public static string currentLockedObjectTag;
    public GameObject FPC;
    public Text MessageText;
    public static ArrayList wordlist;
    private ArrayList buttonList;

    public void Start()
    {
        buttonList = new ArrayList() { firstWord, secondWord };
        wordlist = new ArrayList(){"Tree", "Flower"};
    }

    public void CheckIfCorrect(Text buttonText)
    {
        // Selected the right word
        for(int i=0; i<wordlist.Count; i++){
            if (GameManager.currentLockedObjectTag == (string) wordlist[i] &&
                GameManager.currentLockedObjectTag == buttonText.text)
            {
                StartCoroutine(ShowMessage("Select the word.", 2));
                Debug.Log(wordlist[i]);
                Button currentButton = (Button) buttonList[i];
                Destroy(currentButton);
                wordlist.RemoveAt(i);
                buttonList.RemoveAt(i);
                FPC.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().m_MouseLook.SetCursorLock(true);
                return;
            }
        }

        // Selected the wrong word 
        StartCoroutine(ShowMessage("Incorrect", 1));

    }

    IEnumerator ShowMessage(string message, float delay)
    {
        MessageText.enabled = true;
        MessageText.text = message;
        yield return new WaitForSeconds(delay);
        MessageText.enabled = false;
    }

}

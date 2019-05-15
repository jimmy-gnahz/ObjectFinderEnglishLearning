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
    public GameObject WhatIsThisText;
    private ArrayList wordlist;
    private ArrayList buttonList;

    public void Start()
    {
        buttonList = new ArrayList() { firstWord, secondWord };
        wordlist = new ArrayList(){ "Tree", "Flower"};
    }

    public void CheckIfCorrect(Text buttonText)
    {
        for(int i=0; i<wordlist.Count; i++){
            if (GameManager.currentLockedObjectTag == (string) wordlist[i] &&
                GameManager.currentLockedObjectTag == buttonText.text)
            {
                WhatIsThisText.SetActive(false);
                Debug.Log(wordlist[i]);
                Button currentButton = (Button) buttonList[i];
                Destroy(currentButton);
                wordlist.RemoveAt(i);
                FPC.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().m_MouseLook.SetCursorLock(true);
                return;
            }
        }
    }



}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Button firstWord;
    public static string currentLockedObjectTag;
    public GameObject FPC;

    public void CheckIfCorrect()
    {
        if (GameManager.currentLockedObjectTag == "tree")
        {
            Debug.Log("GameManager.currentLockedObjectTag");
            Destroy(firstWord);
            FPC.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().m_MouseLook.SetCursorLock(true);

        }

    }



}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectBehaviour : MonoBehaviour
{
    public float TheDistance;
    public GameObject ActionDisplay;
    public GameObject ActionText;
    public Text MessageText;
    public GameObject FPC;

    // Update is called once per frame
    void Update()
    {
        TheDistance = PlayerCasting.DistFromTarget;
    }

    void OnMouseOver()
    {
        if (TheDistance <= 3)
        {
            ActionDisplay.SetActive(true);
            ActionText.SetActive(true);
        }

        if (Input.GetMouseButtonDown(0))
        {
            if (TheDistance <= 3)
            {
                if (GameManager.wordlist.Contains(PlayerCasting.currentObjectTag))
                {
                    FPC.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().m_MouseLook.SetCursorLock(false);
                    GameManager.currentLockedObjectTag = PlayerCasting.currentObjectTag;
                    ActionDisplay.SetActive(false);
                    ActionText.SetActive(false);
                    StartCoroutine(ShowMessage("What is this?", 2));
                    //ThePlayer.SetActive(false)
                }
                else
                {
                    StartCoroutine(ShowMessage("You have already found this object!",1));

                }

            }
        }
    }

    IEnumerator ShowMessage(string message, float delay)
    {
        MessageText.enabled = true;
        MessageText.text = message;
        yield return new WaitForSeconds(delay);
        MessageText.enabled = false;
    }

    void OnMouseExit()
    {
        ActionDisplay.SetActive(false);
        ActionText.SetActive(false);
    }
}

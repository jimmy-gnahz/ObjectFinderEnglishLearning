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
    private bool wasFacingSun = false;


    // Update is called once per frame
    void Update()
    {
        if (IsFacingSun() && GameManager.wordlist.Contains("Sunshine"))
        {
            wasFacingSun = true;
            ActionDisplay.SetActive(true);
            if (Input.GetMouseButtonDown(0))
            {
                FPC.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().m_MouseLook.SetCursorLock(false);
                ActionDisplay.SetActive(false);
                StartCoroutine(ShowMessage("What is this?", 2));
                GameManager.currentLockedObjectTag = "Sunshine";
            }
        }
        else if (wasFacingSun)
        {
            ActionDisplay.SetActive(false);
            wasFacingSun = false;
        }
        TheDistance = PlayerCasting.DistFromTarget;
    }

    private bool IsFacingSun()
    {
        if (PlayerCasting.currentDirection.y < 0.9f 
            && PlayerCasting.currentDirection.y > 0.7f
            && PlayerCasting.currentDirection.x > 0.2f
            && PlayerCasting.currentDirection.x < 0.4f
            && PlayerCasting.currentDirection.z > -0.7f
            && PlayerCasting.currentDirection.z < -0.5f)
        {
            return true;
        }
        return false;

    }

    void OnMouseOver()
    {
        //StartCoroutine(ShowMessage(PlayerCasting.currentObjectTag, 0.5f));
        if (TheDistance <= 3 && GameManager.wordlist.Contains(PlayerCasting.currentObjectTag))
        {
            ActionDisplay.SetActive(true);
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
                    StartCoroutine(ShowMessage("What is this?", 2));
                    //ThePlayer.SetActive(false)
                }
            }
            
            else
            {
                StartCoroutine(ShowMessage("You have already found this object!", 1));
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
    }
}

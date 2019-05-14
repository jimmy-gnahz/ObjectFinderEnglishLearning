using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest001 : MonoBehaviour
{
    public float TheDistance;
    public GameObject ActionDisplay;
    public GameObject ActionText;
    public GameObject WhatIsThisText;
    public GameObject FPC;

    // Update is called once per frame
    void Update()
    {
        TheDistance = PlayerCasting.DistFromTarget;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
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
                FPC.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().m_MouseLook.SetCursorLock(false);
                GameManager.currentLockedObjectTag = PlayerCasting.currentObjectTag;
                ActionDisplay.SetActive(false);
                ActionText.SetActive(false);
                WhatIsThisText.SetActive(true);
                //ThePlayer.SetActive(false)

            }
        }
    }
    

    void OnMouseExit()
    {
        ActionDisplay.SetActive(false);
        ActionText.SetActive(false);
    }
}

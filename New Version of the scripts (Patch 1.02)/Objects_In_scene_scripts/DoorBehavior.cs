using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorBehavior : MonoBehaviour
{
    [SerializeField] Switch[] listOfSwitches;
    private bool isDoorOpened;

    public delegate bool OpenDoor();
    public static event OpenDoor OnSwitchsTriggered;

    private SpriteRenderer sr;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        isDoorOpened = false;
    }

    // Update is called once per frame
    void Update()
    {
        //if()
        //CheckSwitchStates(listOfSwitches);

        if (OnSwitchsTriggered())
        {
            isDoorOpened = true;
        }
        else if (!OnSwitchsTriggered())
        {
            isDoorOpened = false;
        }

        if (isDoorOpened)
        {
            OpenDoorAction();
        }
        else if (!isDoorOpened)
        {
            CloseDoorAction();
        }
    }

    private void CheckSwitchStates(Switch[] switches)
    {

    }

    // These are temp functions until a door sprite & anim are made.
    private void OpenDoorAction()
    {
        sr.enabled = false;
    }

    private void CloseDoorAction()
    {
        sr.enabled = true;
    }

}

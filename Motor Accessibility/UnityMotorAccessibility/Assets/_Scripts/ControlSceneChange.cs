using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ControlSceneChange : MonoBehaviour
{
    //You can either serialize this and drag in the EventSystem gameobject or find it OnEnable
    private PlayerInput playerInput;

    [SerializeField]
    private GameObject[] panels;

    private void Awake()
    {
        //This finds the EventSystem gameobject with the PlayerInput component
        playerInput = FindObjectOfType<PlayerInput>();
        //This sets the inital input to keyboard and mouse
        SwitchInput(0);
    }

    public void SwitchInput(int num)
    {
        //Set all the different panels (which contain the different key rebindings) to inactive
        foreach(GameObject panel in panels)
        {
            panel.SetActive(false);
        }

        //Set the correct panel to active
        panels[num].SetActive(true);

        //Switch the current control scheme to the one specified by the dropdown
        switch (num)
        {
            case 0:
                playerInput.defaultControlScheme = "Keyboard and Mouse";
                playerInput.SwitchCurrentControlScheme("Keyboard and Mouse");
                break;
            case 1:
                playerInput.defaultControlScheme = "Keyboard";
                playerInput.SwitchCurrentControlScheme("Keyboard", devices: Keyboard.current);
                break;
        }
    }
}

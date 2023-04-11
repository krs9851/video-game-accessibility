using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class ControlRebinding : MonoBehaviour
{
    //Select the action that needs to be rebound
    [SerializeField]
    private InputActionReference inputAction;

    //Give the textmeshpro component of the button
    [SerializeField]
    private TextMeshProUGUI bindingDisplay;

    //Give the button that starts the rebinding process
    [SerializeField]
    private GameObject button;

    //For the inputAction, give the index of which action is being bound
    [SerializeField]
    private int binding;

    //You can either serialize this and drag in the EventSystem gameobject or find it OnEnable
    private PlayerInput playerInput;

    //This is the popup that appears if the player tries to input a duplicate keybinding
    [SerializeField]
    private GameObject duplicates;

    //This is the rebinding operation
    private InputActionRebindingExtensions.RebindingOperation rebindingOperation;

    //The game component is enabled
    private void OnEnable()
    {
        //This finds the EventSystem gameobject with the PlayerInput component
        playerInput = FindObjectOfType<PlayerInput>();

        //This sets up the visual appearance of the gameobjects and makes sure the bindingDisplay text matches the actual initial keybinding
        if (duplicates != null)
        {
            duplicates.SetActive(false);
        }
        bindingDisplay.text = InputControlPath.ToHumanReadableString(inputAction.action.bindings[binding].effectivePath, InputControlPath.HumanReadableStringOptions.OmitDevice);
    }

    //The player has pressed the button to start the rebinding
    public void StartRebind()
    {
        //Make sure the player cannot press the button again
        button.SetActive(false);
        //Make sure the player cannot perform any actions during the rebinding process
        inputAction.action.Disable();
        //Start the rebinding operation with the values given
        rebindingOperation = inputAction.action.PerformInteractiveRebinding().WithTargetBinding(binding).OnMatchWaitForAnother(0.1f).OnComplete(operation => RebindComplete()).Start();
    }

    //The player has pressed the button they want the action to be rebound to
    private void RebindComplete()
    {
        //If this is a duplicant rebind, cancel the rebinding and tell the player it cannot be done
        if (CheckDuplicates())
        {
            inputAction.action.RemoveBindingOverride(binding);
            rebindingOperation.Dispose();
            inputAction.action.Enable();
            StartCoroutine(NoDuplicates());

        }

        //Show the button again and set the button text to the current action binding
        button.SetActive(true);
        bindingDisplay.text = InputControlPath.ToHumanReadableString(inputAction.action.bindings[binding].effectivePath, InputControlPath.HumanReadableStringOptions.OmitDevice);

        //Get rid of the old rebinding operation. This is important, do not remove
        rebindingOperation.Dispose();

        //Enable user actions again
        inputAction.action.Enable();

    }

    //A duplicant rebinding has been pressed. A popup will show for 1 second to alert the user this is not possible
    private IEnumerator NoDuplicates()
    {
        //Set the duplicant alert to true
        duplicates.SetActive(true);
        //Wait one second, or input a number of your choosing
        yield return new WaitForSeconds(1);
        //Set the duplicant alert to false
        duplicates.SetActive(false);
    }

    //Check to make sure that the player's chosen key is not a duplicant of another user action
    private bool CheckDuplicates()
    {
        //Check to make sure the inputed key is not duplicated in other bindings
        foreach (InputBinding bind in playerInput.actions.bindings)
        {
            /*
             * First, the if statement checks to see if the control scheme of the binding is active. This way, different control schemes do not interfere with eachother.
             * Secondarily, it checks to make sure it is not checking itself.
             * Finally, it checks to see if the keybindings chosen are not the same.
             */
            if (bind.groups.Contains(playerInput.currentControlScheme) && bind.action != inputAction.action.bindings[binding].action && bind.effectivePath == inputAction.action.bindings[binding].effectivePath)
            {
                //The key was a duplicant
                return true;
            }
        }
        //Check to make sure the inputed key is not duplicated in the composite 
        for (int i = 0; i < inputAction.action.bindings.Count; i++)
        {
            //Check to make sure the binding is not checking itself
            if (i != binding)
            {
                /*
                 * First, the if statement checks to see if the control scheme of the binding is active. This way, different control schemes do not interfere with eachother.
                 * Finally, it checks to see if the keybindings chosen are not the same.
                 */
                if (inputAction.action.bindings[i].groups.Contains(playerInput.currentControlScheme) && inputAction.action.bindings[i].effectivePath == inputAction.action.bindings[binding].effectivePath)
                {
                    //The key was a duplicant
                    return true;
                }
            }
        }

        //The key was not a duplicant 
        return false;
    }
}

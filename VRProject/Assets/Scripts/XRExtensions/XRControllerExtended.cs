using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR;
using DilmerGames.Core;

public class XRControllerExtended : MonoBehaviour
{
    public enum InputAxesExtended
    {
        NoSet,
        PrimaryButton,
        SecondaryButton,
    };
    
    [SerializeField]
    private InputAxesExtended ButtonSelected = InputAxesExtended.NoSet;

    [SerializeField]
    public XRNode ControllerNode;

    [SerializeField]
    private UnityEvent OnButtonDown;

    private InputDevice inputDevice;

    private bool buttonPressed;

    public InputDevice InputDevice 
    { 
        get
        {
            return inputDevice.isValid ? inputDevice : (inputDevice = InputDevices.GetDeviceAtXRNode(ControllerNode));
        }
    }

    void Update() => UpdateInput();

    void UpdateInput()
    {
        if(ButtonSelected == InputAxesExtended.NoSet)
            return;

        bool primaryButtonState = false;
        bool secondaryButtonState = false;

        if (InputDevice.isValid && InputDevice.TryGetFeatureValue(CommonUsages.primaryButton, out primaryButtonState)
            && primaryButtonState && !buttonPressed && ButtonSelected == InputAxesExtended.PrimaryButton)
        {
            buttonPressed = true;
        }
        

        if (InputDevice.isValid && InputDevice.TryGetFeatureValue(CommonUsages.secondaryButton, out secondaryButtonState)
            && secondaryButtonState && !buttonPressed && ButtonSelected == InputAxesExtended.SecondaryButton)
        {
            buttonPressed = true;
        }

        if (buttonPressed)
        {
            XRLogger.Instance.LogInfo("Button pressed is true");
            OnButtonDown?.Invoke();
            buttonPressed = false;
        }
    }
}
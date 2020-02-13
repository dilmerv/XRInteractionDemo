using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.AR;

public class ARSelectionInteractableAuto : ARSelectionInteractable
{
    public bool m_GestureSelected { get; private set;} = true;

    public override bool IsSelectableBy(XRBaseInteractor interactor)
    {
        return true;
    }
}
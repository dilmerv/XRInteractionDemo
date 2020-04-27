using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.AR;

public class ARPlacementInteractableBlocking : ARPlacementInteractable
{
    protected override bool CanStartManipulationForGesture(TapGesture gesture)
    {
        if (gesture.StartPosition.IsPointOverUIObject())
        {
            return false;
        }

        // Allow for test planes
        if (gesture.TargetObject == null || gesture.TargetObject.layer == 9)
            return true;

        return false;
    }
}

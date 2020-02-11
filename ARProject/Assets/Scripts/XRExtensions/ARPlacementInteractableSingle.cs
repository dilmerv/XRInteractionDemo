using UnityEngine.XR.Interaction.Toolkit.AR;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ARPlacementInteractableSingle : ARBaseGestureInteractable
{
    [SerializeField]
    private GameObject placementPrefab;

    [SerializeField]
    private ARObjectPlacementEvent onObjectPlaced;

    private GameObject placementObject;

    private static List<ARRaycastHit> hits = new List<ARRaycastHit>();

    private static GameObject trackablesObject;

    protected override bool CanStartManipulationForGesture(TapGesture gesture)
    {
        if(gesture.TargetObject == null)
        {
            return true;
        }
        return false;
    }

    protected override void OnEndManipulation(TapGesture gesture)
    {
        if(gesture.WasCancelled)
        {
            return;
        }

        if(gesture.TargetObject != null)
        {
            return;
        }

        if(GestureTransformationUtility.Raycast(gesture.StartPosition, hits, TrackableType.PlaneWithinPolygon))
        {
            var hit = hits[0];

            if(Vector3.Dot(Camera.main.transform.position - hit.pose.position, hit.pose.rotation * Vector3.up) < 0)
            {
                return;
            }

            // allowing a new game object for AR placement object
            if(placementObject == null)
            {
                placementObject = Instantiate(placementPrefab, hit.pose.position, hit.pose.rotation);

                var anchorObject = new GameObject("PlacementAnchor");
                anchorObject.transform.position = hit.pose.position;
                anchorObject.transform.rotation = hit.pose.rotation;

                if(trackablesObject == null)
                {
                    trackablesObject = GameObject.Find("Trackables");
                }
                if(trackablesObject != null)
                {
                    anchorObject.transform.parent = trackablesObject.transform;
                }

                onObjectPlaced?.Invoke(this, placementObject);
            }
        }
    }
}
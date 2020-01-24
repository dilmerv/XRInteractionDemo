using System;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.AR;

[RequireComponent(typeof(ARGestureInteractor))]
public class ARGestureInteractorLog : MonoBehaviour
{
    private ARGestureInteractor arGestureInteractor;

    void Start()
    {
        arGestureInteractor = GetComponent<ARGestureInteractor>();
        arGestureInteractor.DragGestureRecognizer.onGestureStarted += DragGestureRecognizerStarted;
        arGestureInteractor.PinchGestureRecognizer.onGestureStarted += PinchGestureRecognizerStarted;
        arGestureInteractor.TwoFingerDragGestureRecognizer.onGestureStarted += TwoFingerDragGestureRecognizerStarted;
    }

    void DragGestureRecognizerStarted(Gesture<DragGesture> dragGesture)
    {
        Logger.Instance.LogInfo("DragGestureRecognizerStarted executed");

        dragGesture.onStart += (s) => 
        {
            Logger.Instance.LogInfo("DragGesture.onStart executed");
        };

        dragGesture.onUpdated += (s) => 
        {
            Logger.Instance.LogInfo("DragGesture.onUpdated executed");
        };

        dragGesture.onFinished += (s) => 
        {
            Logger.Instance.LogInfo("DragGesture.onFinished executed");
        };
    }

    void PinchGestureRecognizerStarted(Gesture<PinchGesture> pinchGesture)
    {
        Logger.Instance.LogInfo("PinchGestureRecognizerStarted executed");

        pinchGesture.onStart += (s) => 
        {
            Logger.Instance.LogInfo("PinchGesture.onStart executed");
        };

        pinchGesture.onUpdated += (s) => 
        {
            Logger.Instance.LogInfo("PinchGesture.onUpdated executed");
        };

        pinchGesture.onFinished += (s) => 
        {
            Logger.Instance.LogInfo("PinchGesture.onFinished executed");
        };
    }

    void TwoFingerDragGestureRecognizerStarted(Gesture<TwoFingerDragGesture> twoFingerDragGesture)
    {
        Logger.Instance.LogInfo("TwoFingerDragGestureRecognizerStarted executed");

        twoFingerDragGesture.onStart += (s) => 
        {
            Logger.Instance.LogInfo("TwoFingerDragGesture.onStart executed");
        };

        twoFingerDragGesture.onUpdated += (s) => 
        {
            Logger.Instance.LogInfo("TwoFingerDragGesture.onUpdated executed");
        };

        twoFingerDragGesture.onFinished += (s) => 
        {
            Logger.Instance.LogInfo("TwoFingerDragGesture.onFinished executed");
        };
    }
}

using UnityEngine;
using Vuforia;

public class MarkerTracker : MonoBehaviour
{
    private ObserverBehaviour observerBehaviour;

    void Awake()
    {
        observerBehaviour = GetComponent<ObserverBehaviour>();
        observerBehaviour.OnTargetStatusChanged += OnTargetStatusChanged;
    }

    void OnDestroy()
    {
        observerBehaviour.OnTargetStatusChanged -= OnTargetStatusChanged;
    }

    private void OnTargetStatusChanged(ObserverBehaviour behaviour, TargetStatus targetStatus)
    {
        if (targetStatus.Status == Status.TRACKED || targetStatus.Status == Status.EXTENDED_TRACKED)
        {
            // Target is tracked, do something
            Debug.Log("Target is tracked!");
        }
        else
        {
            // Target is lost
            Debug.Log("Target is lost!");
        }
    }
}

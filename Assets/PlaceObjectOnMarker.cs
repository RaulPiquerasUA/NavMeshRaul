using UnityEngine;
using Vuforia;
using UnityEngine.AI;

public class PlaceObjectOnMarker : MonoBehaviour
{
    public GameObject slimePrefab;
    public GameObject turtlePrefab;
    public Transform planePlaceMarker;

    private GameObject slimeInstance;
    private GameObject turtleInstance;

    void Awake()
    {
        VuforiaApplication.Instance.OnVuforiaStarted += OnVuforiaStarted;
    }

    void OnDestroy()
    {
        VuforiaApplication.Instance.OnVuforiaStarted -= OnVuforiaStarted;
    }

    private void OnVuforiaStarted()
    {
        if (planePlaceMarker != null)
        {
            CreateInstances();
        }
    }

    private void CreateInstances()
    {
        // Instantiate the prefabs at the marker's position and rotation
        slimeInstance = Instantiate(slimePrefab, planePlaceMarker.position, planePlaceMarker.rotation);
        turtleInstance = Instantiate(turtlePrefab, planePlaceMarker.position, planePlaceMarker.rotation);

        // Adjust positions if necessary
        slimeInstance.transform.localPosition = new Vector3(0, 0, 0); // Adjust as needed
        turtleInstance.transform.localPosition = new Vector3(1, 0, 0); // Adjust as needed

        // Add NavMeshAgent components if needed
        slimeInstance.AddComponent<NavMeshAgent>();
        turtleInstance.AddComponent<NavMeshAgent>();
    }
}

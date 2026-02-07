using UnityEngine;

public class VoidEventListener : MonoBehaviour
{
    [SerializeField]
    private VoidEventChannel channel;

    [SerializeField]
    private UnityEngine.Events.UnityEvent response;

    private void OnEnable()
    {
        channel.OnEventRaised += OnEvent;
    }

    private void OnDisable()
    {
        channel.OnEventRaised -= OnEvent;
    }

    private void OnEvent()
    {
        response.Invoke();
    }
}

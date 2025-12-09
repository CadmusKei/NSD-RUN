using UnityEngine;
using UnityEngine.Events;

public class AnimationEvents : MonoBehaviour
{

    [SerializeField] private UnityEvent unityEvent;

    public void CallEvent()
    {
        unityEvent?.Invoke();
    }

}

using UnityEngine;
[RequireComponent (typeof(MoveBehaviour))]

public class Character : MonoBehaviour
{
    protected MoveBehaviour _mb;
    protected void Awake()
    {
        _mb = GetComponent<MoveBehaviour>();
    }
}

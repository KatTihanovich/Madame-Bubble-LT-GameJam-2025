using UnityEngine;

public class Ingredient : MonoBehaviour
{
    public Vector3 StartPosition { get; private set; }

    private void Awake()
    {
        StartPosition = transform.localPosition;
    }
}

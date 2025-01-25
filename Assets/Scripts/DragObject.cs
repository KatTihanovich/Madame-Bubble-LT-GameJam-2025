using UnityEngine;

public class DragObject : MonoBehaviour
{
    private Camera _mainCamera; 
    private bool _isDragging;   

    private void Start()
    {
        _mainCamera = Camera.main;  
    }

    private void OnMouseDown()
    {

        if (Input.GetMouseButton(0))
        {
            _isDragging = true; 
        }
    }

    private void OnMouseUp()
    {
        _isDragging = false;
    }

    private void Update()
    {
        if (_isDragging)
        {

            Vector3 mousePosition = Input.mousePosition;
            mousePosition.z = Mathf.Abs(_mainCamera.transform.position.z - transform.position.z);
            Vector3 worldPosition = _mainCamera.ScreenToWorldPoint(mousePosition);
            transform.position = new Vector3(worldPosition.x, worldPosition.y, transform.position.z);
        }
    }
}

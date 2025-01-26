using UnityEngine;

public class DragAmulets : MonoBehaviour
{
    private Camera _mainCamera;
    private bool _isDragging;
    private Vector3 _startPosition; 
    private DropPotion _dropPotion;

    private void Start()
    {
        _dropPotion = FindFirstObjectByType<DropPotion>();
        _mainCamera = Camera.main;
        _startPosition = transform.position; 
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
        if (_isDragging)
        {
            _isDragging = false;
            _dropPotion.ResetDrop();
            ReturnToStartPosition(); 
        }
    }

    private void Update()
    {
        if (_isDragging)
        {
            DragObject(); // Перетаскиваем объект
        }
    }

    private void DragObject()
    {
        Vector3 mousePosition = Input.mousePosition; // Получаем позицию мыши на экране
        mousePosition.z = Mathf.Abs(_mainCamera.transform.position.z - transform.position.z); // Учитываем глубину объекта
        Vector3 worldPosition = _mainCamera.ScreenToWorldPoint(mousePosition); // Преобразуем в мировую позицию
        transform.position = new Vector3(worldPosition.x, worldPosition.y, transform.position.z); // Обновляем позицию объекта
    }

    private void ReturnToStartPosition()
    {
        transform.position = _startPosition; // Возвращаем объект на стартовую позицию
    }
}

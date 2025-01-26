using UnityEngine;
using UnityEngine.UI;

public class CheckboxSwitcher : MonoBehaviour
{
    // Структура для хранения галочки и связанной кнопки
    [System.Serializable]
    public class CheckboxData
    {
        public GameObject checkbox; // Галочка (элемент)
        public Button button;       // Кнопка для активации галочки
    }

    // Массив галочек
    public CheckboxData[] checkboxes;

    // Метод для обработки кликов по кнопкам
    public void OnButtonClick(int index)
    {
        // Скрываем все галочки
        foreach (var checkboxData in checkboxes)
        {
            checkboxData.checkbox.SetActive(false); // Скрыть галочку
        }

        // Показываем только выбранную галочку
        if (index >= 0 && index < checkboxes.Length)
        {
            checkboxes[index].checkbox.SetActive(true); // Показать выбранную галочку
        }
    }
}
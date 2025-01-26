using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Для работы с UI

public class PageFlipper : MonoBehaviour
{
    // Список всех страниц (назначается в инспекторе)
    public List<GameObject> pages;

    // Индекс первой отображаемой страницы (всегда показываются две страницы)
    private int currentPage = 0;

    // UI-кнопки (назначаются в инспекторе)
    public Button nextButton;
    public Button previousButton;

    void Start()
    {
        // Инициализация: показать первые две страницы
        UpdatePageVisibility();

        // Назначение методов кнопкам
        if (nextButton != null)
        {
            nextButton.onClick.AddListener(NextPages);
        }
        if (previousButton != null)
        {
            previousButton.onClick.AddListener(PreviousPages);
        }
    }

    void Update()
    {
        // Обработка нажатий на стрелки клавиатуры
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            NextPages();
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            PreviousPages();
        }
    }

    public void NextPages()
    {
        // Переход к следующим двум страницам, если это возможно
        if (currentPage < pages.Count - 2)
        {
            currentPage += 2;
            Debug.Log("Next Pages: " + currentPage); // Отладка
            UpdatePageVisibility();
        }
        else
        {
            Debug.Log("No more pages to go forward!");
        }
    }

    public void PreviousPages()
    {
        // Переход к предыдущим двум страницам, если это возможно
        if (currentPage > 0)
        {
            currentPage -= 2;
            Debug.Log("Previous Pages: " + currentPage); // Отладка
            UpdatePageVisibility();
        }
        else
        {
            Debug.Log("No more pages to go back!");
        }
    }

    void UpdatePageVisibility()
    {
        // Обновление видимости страниц: показывать только текущие две
        for (int i = 0; i < pages.Count; i++)
        {
            if (i == currentPage || i == currentPage + 1)
            {
                pages[i].SetActive(true);
            }
            else
            {
                pages[i].SetActive(false);
            }
        }

        // Обновление состояния кнопок (например, если нельзя листать дальше)
        UpdateButtonInteractivity();
    }

    void UpdateButtonInteractivity()
    {
        // Активировать или деактивировать кнопки в зависимости от текущей страницы
        if (previousButton != null)
        {
            previousButton.interactable = currentPage > 0;
        }
        if (nextButton != null)
        {
            nextButton.interactable = currentPage < pages.Count - 2;
        }
    }
}
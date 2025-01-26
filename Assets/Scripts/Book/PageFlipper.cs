using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Для работы с UI

public class PageFlipper : MonoBehaviour
{
    // Список всех страниц (назначается в инспекторе)
    public List<GameObject> pages;

    // Индекс текущей отображаемой страницы
    private int currentPage = 0;

    // UI-кнопки (назначаются в инспекторе)
    public Button nextButton;
    public Button previousButton;

    void Start()
    {
        // Инициализация: показать первую страницу
        UpdatePageVisibility();

        // Назначение методов кнопкам
        if (nextButton != null)
        {
            nextButton.onClick.AddListener(NextPage);
        }
        if (previousButton != null)
        {
            previousButton.onClick.AddListener(PreviousPage);
        }
    }

    void Update()
    {
        // Обработка нажатий на стрелки клавиатуры
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            NextPage();
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            PreviousPage();
        }
    }

    public void NextPage()
    {
        // Переход к следующей странице, если это возможно
        if (currentPage < pages.Count - 1)
        {
            currentPage += 1;
            Debug.Log("Next Page: " + currentPage); // Отладка
            UpdatePageVisibility();
        }
        else
        {
            Debug.Log("No more pages to go forward!");
        }
    }

    public void PreviousPage()
    {
        // Переход к предыдущей странице, если это возможно
        if (currentPage > 0)
        {
            currentPage -= 1;
            Debug.Log("Previous Page: " + currentPage); // Отладка
            UpdatePageVisibility();
        }
        else
        {
            Debug.Log("No more pages to go back!");
        }
    }

    void UpdatePageVisibility()
    {
        // Обновление видимости страниц: показывать только текущую
        for (int i = 0; i < pages.Count; i++)
        {
            pages[i].SetActive(i == currentPage);
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
            nextButton.interactable = currentPage < pages.Count - 1;
        }

    }
}
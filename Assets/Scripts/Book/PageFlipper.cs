using System.Collections.Generic;
using UnityEngine;

public class PageFlipper : MonoBehaviour
{
    // List of all pages (assign these in the Unity Inspector)
    public List<GameObject> pages;

    // Index of the first visible page (always display two pages)
    private int currentPage = 0;

    void Start()
    {
        // Initialize by showing the first two pages
        UpdatePageVisibility();
    }

    void Update()
    {
        // Listen for arrow key inputs
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            NextPages();
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            PreviousPages();
        }
    }

    void NextPages()
    {
        // Move to the next two pages if there are more pages available
        if (currentPage < pages.Count - 2)
        {
            currentPage += 2;
            UpdatePageVisibility();
        }
    }

    void PreviousPages()
    {
        // Move to the previous two pages if possible
        if (currentPage > 0)
        {
            currentPage -= 2;
            UpdatePageVisibility();
        }
    }

    void UpdatePageVisibility()
    {
        // Show the current two pages and hide all others
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
    }
}
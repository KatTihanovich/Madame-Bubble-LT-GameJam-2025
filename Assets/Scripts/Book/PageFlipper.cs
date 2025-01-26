using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PageFlipper : MonoBehaviour
{
    // List of page spreads (each GameObject represents a spread with two pages on one image)
    public List<GameObject> pageSpreads;

    // Index of the current spread
    private int currentSpread = 0;

    // Shadow panel overlay (assign in the Inspector)
    public GameObject shadowPanel;

    // UI Buttons (assign in the Inspector)
    public Button nextButton;
    public Button previousButton;
    public Button crossButton;

    // UI Arrow Buttons (assign in the Inspector)
    public Button rightArrowButton;
    public Button leftArrowButton;

    // Container for all buttons (optional grouping)
    public GameObject buttonContainer;

    void Start()
    {
        // Initialize: show the first spread and shadow panel
        ShowBook();

        // Assign listeners for navigation buttons
        if (nextButton != null)
        {
            nextButton.onClick.AddListener(NextSpread);
        }
        if (previousButton != null)
        {
            previousButton.onClick.AddListener(PreviousSpread);
        }

        // Assign listeners for on-screen arrow buttons
        if (rightArrowButton != null)
        {
            rightArrowButton.onClick.AddListener(NextSpread);
        }
        if (leftArrowButton != null)
        {
            leftArrowButton.onClick.AddListener(PreviousSpread);
        }

        // Assign listener for the cross button
        if (crossButton != null)
        {
            crossButton.onClick.AddListener(CloseBook);
        }
    }

    void Update()
    {
        // Handle keyboard input for flipping pages
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            NextSpread();
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            PreviousSpread();
        }
    }

    public void NextSpread()
    {
        // Go to the next spread, if possible
        if (currentSpread < pageSpreads.Count - 1)
        {
            currentSpread++;
            Debug.Log("Next Spread: " + currentSpread); // Debug
            UpdatePageVisibility();
        }
        else
        {
            Debug.Log("No more spreads to go forward!");
        }
    }

    public void PreviousSpread()
    {
        // Go to the previous spread, if possible
        if (currentSpread > 0)
        {
            currentSpread--;
            Debug.Log("Previous Spread: " + currentSpread); // Debug
            UpdatePageVisibility();
        }
        else
        {
            Debug.Log("No more spreads to go back!");
        }
    }

    void UpdatePageVisibility()
    {
        // Update the visibility of the page spreads
        for (int i = 0; i < pageSpreads.Count; i++)
        {
            pageSpreads[i].SetActive(i == currentSpread);
        }

        // Update button interactivity
        UpdateButtonInteractivity();
    }

    void UpdateButtonInteractivity()
    {
        // Enable or disable buttons based on the current spread
        if (previousButton != null)
        {
            previousButton.interactable = currentSpread > 0;
        }
        if (nextButton != null)
        {
            nextButton.interactable = currentSpread < pageSpreads.Count - 1;
        }

        // Update arrow button interactivity (if separate from next/previous buttons)
        if (rightArrowButton != null)
        {
            rightArrowButton.interactable = currentSpread < pageSpreads.Count - 1;
        }
        if (leftArrowButton != null)
        {
            leftArrowButton.interactable = currentSpread > 0;
        }
    }

    public void ShowBook()
    {
        // Enable the shadow panel and all UI buttons
        if (shadowPanel != null)
        {
            shadowPanel.SetActive(true);
        }

        if (buttonContainer != null)
        {
            buttonContainer.SetActive(true); // Optional grouping for buttons
        }
        else
        {
            // Enable buttons individually if no container is used
            if (nextButton != null) nextButton.gameObject.SetActive(true);
            if (previousButton != null) previousButton.gameObject.SetActive(true);
            if (crossButton != null) crossButton.gameObject.SetActive(true);
            if (rightArrowButton != null) rightArrowButton.gameObject.SetActive(true);
            if (leftArrowButton != null) leftArrowButton.gameObject.SetActive(true);
        }

        // Show the first spread
        UpdatePageVisibility();
    }

    public void CloseBook()
    {
        // Disable the shadow panel and all UI buttons
        if (shadowPanel != null)
        {
            shadowPanel.SetActive(false);
        }

        if (buttonContainer != null)
        {
            buttonContainer.SetActive(false); // Optional grouping for buttons
        }
        else
        {
            // Disable buttons individually if no container is used
            if (nextButton != null) nextButton.gameObject.SetActive(false);
            if (previousButton != null) previousButton.gameObject.SetActive(false);
            if (crossButton != null) crossButton.gameObject.SetActive(false);
            if (rightArrowButton != null) rightArrowButton.gameObject.SetActive(false);
            if (leftArrowButton != null) leftArrowButton.gameObject.SetActive(false);
        }

        // Hide all spreads
        foreach (var spread in pageSpreads)
        {
            spread.SetActive(false);
        }

        Debug.Log("Book Closed!");
    }
}

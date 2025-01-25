using System.Collections;
using UnityEngine;
using TMPro;

public class TypewriterEffect : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _textMeshPro; // TextMeshPro reference
    public string[] stringArray; // Array of text strings
    [SerializeField] float timeBtwCharacters = 0.05f; // Time between typing characters
    [SerializeField] float timeBtwWords = 0.5f; // Time between typing words

    private int i = 0; // Index for string array
    [SerializeField] private AudioSource typingSound; // Audio source for typing sound

    void Start()
    {
        EndCheck(); // Start typing the first string
    }

    void EndCheck()
    {
        // If there's more text to display, start typing it
        if (i < stringArray.Length)
        {
            _textMeshPro.text = stringArray[i]; // Set the current string
            StartCoroutine(TextVisible()); // Start the typing effect
        }
    }

    private IEnumerator TextVisible()
    {
        _textMeshPro.ForceMeshUpdate(); // Ensure text mesh updates properly
        int totalVisibleCharacters = _textMeshPro.textInfo.characterCount; // Get total characters in the text
        int counter = 0;

        // Start playing the typing sound if it's not already playing
        if (!typingSound.isPlaying)
        {
            typingSound.loop = true; // Set the sound to loop while typing
            typingSound.Play();
        }

        // Gradually reveal characters one by one
        while (counter < totalVisibleCharacters)
        {
            _textMeshPro.maxVisibleCharacters = counter; // Reveal characters up to `counter`
            counter++; // Increment the counter
            yield return new WaitForSeconds(timeBtwCharacters); // Wait before revealing the next character
        }

        // Ensure all characters are visible after finishing
        _textMeshPro.maxVisibleCharacters = totalVisibleCharacters;

        // Stop the typing sound after the text is fully displayed
        if (typingSound.isPlaying)
        {
            typingSound.loop = false; // Disable looping
            typingSound.Stop(); // Stop the sound
        }

        // Move to the next string after a delay
        i++;
        Invoke("EndCheck", timeBtwWords);
    }
}

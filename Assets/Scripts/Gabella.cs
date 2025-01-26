using UnityEngine;
using System.Collections;

public class Gubella : MonoBehaviour
{
    public GameObject first;
    public GameObject second;

    // Method to start the process: deactivate first, wait, and activate it back
    public void StartUnactiveProcess()
    {
        StartCoroutine(UnactiveAndActivate());
    }

    // Coroutine to handle Unactive, wait, and then call Asctive
    private IEnumerator UnactiveAndActivate()
    {
        // Deactivate first and activate second
        first.SetActive(false);
        second.SetActive(true);

        // Wait for 5 seconds
        yield return new WaitForSeconds(5);

        // Activate first and deactivate second
        second.SetActive(false);
        first.SetActive(true);

        yield return new WaitForSeconds(8);

        first.SetActive(false);
        second.SetActive(true);

        yield return new WaitForSeconds(3);

        second.SetActive(false);
        first.SetActive(true);
    }
}

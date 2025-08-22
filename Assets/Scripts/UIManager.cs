using TMPro;
using UnityEngine;

/// <summary>
/// Example UI script that listens for the score change event.
/// You would attach this to a UI object with a Text component.
/// </summary>
public class UIManager : MonoBehaviour
{
    // You would assign this in the Unity Editor.
    // For modern UI, you would use: public TMPro.TextMeshProUGUI scoreText;
    public TMP_Text _scoreText;

    /// <summary>
    /// OnEnable is called when the object becomes enabled and active.
    /// It's a good place to subscribe to events.
    /// </summary>
    private void OnEnable()
    {
        // Subscribe the HandleScoreChanged method to the OnScoreChanged event.
        GameManager.OnScoreChanged += HandleScoreChanged;
    }

    /// <summary>
    /// OnDisable is called when the object becomes disabled or inactive.
    /// It's crucial to unsubscribe from events to prevent memory leaks.
    /// </summary>
    private void OnDisable()
    {
        // Unsubscribe from the event.
        GameManager.OnScoreChanged -= HandleScoreChanged;
    }

    /// <summary>
    /// This method is called whenever the OnScoreChanged event is invoked.
    /// The method signature must match the event's delegate (takes an int).
    /// </summary>
    /// <param name="newScore">The new score passed from the event.</param>
    private void HandleScoreChanged(int newScore)
    {
        if (_scoreText != null)
        {
            _scoreText.text = "Score: " + newScore;
        }
    }
}
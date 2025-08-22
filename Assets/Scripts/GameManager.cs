using System;
using UnityEngine;

/// <summary>
/// Manages the overall game state, score, and events.
/// Implements the Singleton pattern to ensure only one instance exists.
/// </summary>
public class GameManager : MonoBehaviour
{
    // --- SINGLETON PATTERN ---
    // A public static reference to the single instance of this class.
    public static GameManager Instance { get; private set; }

    // --- EVENTS ---
    // A static event that other classes can subscribe to.
    // It passes an integer representing the new total score.
    public static event Action<int> OnScoreChanged;

    // --- STATE ---
    // Private field to hold the current score.
    private int _score = 0;

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// This is where we enforce the singleton pattern.
    /// </summary>
    private void Awake()
    {
        // Check if an instance of the GameManager already exists.
        if (Instance != null && Instance != this)
        {
            // If an instance already exists, destroy this new one.
            Debug.LogWarning("Another instance of GameManager was found and destroyed.");
            Destroy(gameObject);
        }
        else
        {
            // If this is the first instance, set it as the singleton instance.
            Instance = this;
            // Mark this object to not be destroyed when loading a new scene.
            DontDestroyOnLoad(gameObject);
        }
    }

    /// <summary>
    /// Public method to increase the score.
    /// This is what other scripts will call.
    /// </summary>
    /// <param name="amount">The amount to add to the current score.</param>
    public void IncreaseScore(int amount)
    {
        if (amount <= 0)
        {
            Debug.LogWarning("IncreaseScore called with a non-positive amount.");
            return;
        }

        _score += amount;
        Debug.Log($"Score increased! New Score: {_score}");

        // --- TRIGGER THE EVENT ---
        // Invoke the event and pass the new score to all listeners.
        // The '?' is a null-conditional operator, which checks if OnScoreChanged is not null
        // before trying to invoke it. This prevents errors if no scripts are listening.
        OnScoreChanged?.Invoke(_score);
    }

    /// <summary>
    /// Gets the current score.
    /// </summary>
    /// <returns>The current score.</returns>
    public int GetScore()
    {
        return _score;
    }
}

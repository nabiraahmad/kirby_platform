using UnityEngine;

public class musicManager : MonoBehaviour
{
    private static musicManager instance;

    // Ensure only one instance of MusicManager exists across all scenes
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Prevent this object from being destroyed when changing scenes
        }
        else
        {
            Destroy(gameObject); // Destroy any duplicates of MusicManager when a new scene is loaded
        }
    }

    // You can add more features like controlling volume or changing tracks here if needed
}

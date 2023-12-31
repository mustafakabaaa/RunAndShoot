using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerPositionController : MonoBehaviour
{
    void Start()
    {
        // Oyuncuyu taşımayı sağla
        DontDestroyOnLoad(gameObject);

        // Yeni sahne yüklendiğinde çağrılacak olan metodun dinleyicisini ekle
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Yeni sahne yüklendiğinde, oyuncunun konumunu ayarla
        if (scene.name == "SeconspMap")
        {
            // İstediğiniz konumu ayarlayın
            transform.position = new Vector3(0f, 2f, 0f);
        }
    }
}

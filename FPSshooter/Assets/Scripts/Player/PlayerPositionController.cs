using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerPositionController : MonoBehaviour
{
    void Start()
    {
        // Oyuncuyu taþýmayý saðla
        DontDestroyOnLoad(gameObject);

        // Yeni sahne yüklendiðinde çaðrýlacak olan metodun dinleyicisini ekle
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Yeni sahne yüklendiðinde, oyuncunun konumunu ayarla
        if (scene.name == "SeconspMap")
        {
            // Ýstediðiniz konumu ayarlayýn
            transform.position = new Vector3(0f, 2f, 0f);
        }
    }
}

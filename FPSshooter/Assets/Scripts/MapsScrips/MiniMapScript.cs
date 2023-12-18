using UnityEngine;

public class MiniMapScript : MonoBehaviour
{
    public Transform takipEdilecekNesne;  // Oyuncuyu içeren nesnenin Transform bileþeni

    void LateUpdate()
    {
        if (takipEdilecekNesne != null)
        {
            // Minimap kamerasýný oyuncuyu takip edecek þekilde konumlandýr
            transform.position = new Vector3(takipEdilecekNesne.position.x, transform.position.y, takipEdilecekNesne.position.z);
        }
    }
}



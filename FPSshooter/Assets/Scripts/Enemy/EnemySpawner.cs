using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject liveEnemy;
    public GameObject enemyPrefab;  // Düþmanýn prefab'ý
    public float respawnDelay = 60f; // 60 saniye (1 dakika)
    private bool canSpawn = true; // Spawn iþleminin yapýlýp yapýlamayacaðýný kontrol etmek için kullanýlan boolean deðeri

    void Start()
    {
        StartCoroutine(SpawnEnemyRoutine());
    }

    IEnumerator SpawnEnemyRoutine()
    {
        while (canSpawn)
        {
            if (liveEnemy == null)
            {
                // liveEnemy null olduðunda buraya geçer ve spawn iþlemi yapýlýr
                GameObject newEnemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
                liveEnemy = newEnemy;

                // Spawn iþlemi yapýldýktan sonra belirli bir süre bekleyerek tekrar kontrol etmek için
                yield return new WaitForSeconds(respawnDelay);
            }
            else
            {
                // liveEnemy null deðilse bir sonraki kontrol için bir süre bekleyin
                yield return null;
            }
        }
    }

    // Bir durumda spawn iþlemini durdurmak için bu fonksiyonu kullanabilirsiniz
    public void StopSpawn()
    {
        canSpawn = false;
    }
}

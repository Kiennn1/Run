using UnityEngine;

public class GroundSpam : MonoBehaviour
{
    public static GroundSpam Instance;
    private Vector3 nextSpawnPoint;
    public GameObject groundTile;
    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
           
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        for (int i = 0;i<20;i++)
        {
            SpawnTile();
        }
    }

    public void SpawnTile()
    {
        GameObject temp = Instantiate(groundTile, nextSpawnPoint, Quaternion.identity);
        nextSpawnPoint = temp.transform.GetChild(1).position;
    }
}

using UnityEngine;

public class GroundTile : MonoBehaviour
{
    public GameObject RaoChanPrefabs;
    public GameObject coinPrefabs;
    private void Start()
    {
        SpawnRaoChan();
        SpawnCoin();
    }
    private void OnTriggerExit(Collider other)
    {

        if (other.gameObject.tag =="Player")
        {
            GroundSpam.Instance.SpawnTile();
            Destroy(gameObject, 2);
        }
    }
    void SpawnRaoChan()
    {
        int raoChanChiMuc = Random.Range(2, 5);
        Transform spawnPoint = transform.GetChild(raoChanChiMuc).transform;
        Instantiate(RaoChanPrefabs, spawnPoint.position, Quaternion.identity, transform);
    }
    void SpawnCoin()
    {
        GameObject temp = Instantiate(coinPrefabs, transform);
        temp.transform.position = RanDomPos(GetComponent<Collider>());
    }
    Vector3 RanDomPos(Collider collider)
    {
        Vector3 point = new Vector3(
        Random.Range (collider.bounds.min.x,collider.bounds.max.x),
        Random.Range(collider.bounds.min.y, collider.bounds.max.y),
        Random.Range(collider.bounds.min.z, collider.bounds.max.z));
            if(point != collider.ClosestPoint(point))
        {
            point = RanDomPos(collider);
        }
        point.y = 1;
        return point;
    }
}

using UnityEngine;

public class Coin : MonoBehaviour
{
    public float rotationSpeed = 100f;
    void Update()
    {
        transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);   
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            GameManager.instance.scores++;
            Destroy(gameObject);
        }
        if(other.gameObject.tag == "RaoChan")
        {
            Destroy(gameObject);
        }
    }
}

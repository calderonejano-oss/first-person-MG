using UnityEngine;

public class SpawGun : MonoBehaviour
{
    public GameObject ObjectInstatiate;
    public Vector3 SpawnPoint;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Instantiate(ObjectInstatiate, SpawnPoint, transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

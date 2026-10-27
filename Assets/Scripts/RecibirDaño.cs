using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public float VidaEnemy;
    public TextMeshProUGUI textMeshPro;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Projectile"))
        {
            Debug.Log("recibirdaño");
            Destroy(collision.gameObject);
            VidaEnemy -= 25f;
            if(VidaEnemy <= 0)
            {
                Destroy(gameObject);
            }
            
        }
    }
}

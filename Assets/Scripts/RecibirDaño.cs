using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEditor.SearchService;
using System;
using Unity.VisualScripting;

public class NewMonoBehaviourScript : MonoBehaviour
{
    [Header("Vida Enemigo")]
    [SerializeField] private float VidaEnemy;

    [Header("FillAmount barra de vida")]
    [SerializeField]private float FillAmount;

    [Header("objeto a asignar")]
    public TextMeshProUGUI TextoVida;
    public Image BarraDeVida;
   
   [SerializeField, TextArea(5,10)] private string descripcion;
    void Start()
    {
       
    }

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
            TextoVida.text = VidaEnemy.ToString();
            BarraDeVida.fillAmount = VidaEnemy/FillAmount;
            if(VidaEnemy <= 0)
            {
                Destroy(gameObject);
            }
            
        }
    }
}

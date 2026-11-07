using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerVida : MonoBehaviour
{
    [SerializeField] private float VidaPlayer;
    [SerializeField]private float FillAmountPlayer;
    public Image BarraDeVida;
    public GameObject gameObjectCanvaDerrota;
    public CharacterController characterController;
    public Navegation navegation;
    [Header("Canvas de Victoria")]
    public GameObject gameObjectCanvasVictoria; 
    void Awake()
    {
        gameObjectCanvaDerrota.SetActive(false);
        gameObjectCanvasVictoria.SetActive(false);
    }
    void Start()
    {   
       
    }
    void Update()
    {
        if (VidaPlayer <= 0)
        {
            Time.timeScale=0f;
            gameObjectCanvaDerrota.SetActive(true);
        }
        VerificarVictoria();
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("recibirdañoPlayer");
            VidaPlayer -= 5f;
            BarraDeVida.fillAmount = VidaPlayer/FillAmountPlayer;
        }
    }
    void VerificarVictoria()
    {
        GameObject[] enemigosRestantes = GameObject.FindGameObjectsWithTag("Enemy");
        if (enemigosRestantes.Length == 0)
        {
            gameObjectCanvasVictoria.SetActive(true);
            Time.timeScale=0f;
        }
    }
}
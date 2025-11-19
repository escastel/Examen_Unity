using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator    animator;

    public float velocidad = 2f;
    public float fuerzaSalto = 4f;

    public float radioSuelo = 0.1f;
    public Transform tocaSuelo;
    public LayerMask suelo;

    private float   movimientoX;
    private bool    enSuelo;

    MonedasManager  monedasManager;
    VidasManager    vidasManager;

    public float alturaCaida = -4f;

    public AudioSource  playerAudio;
    public AudioClip    recolectarMoneda;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        monedasManager = FindObjectOfType<MonedasManager>();
        vidasManager = FindObjectOfType<VidasManager>();
    }

    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(movimientoX * velocidad, rb.linearVelocity.y);
        enSuelo = Physics2D.OverlapCircle(tocaSuelo.position, radioSuelo, suelo);

        if (alturaCaida > rb.position.y)
        {
            vidasManager.RestarVidas();
        }
    }

    private void OnMove(InputValue playerInput)
    {
       
    }

    private void OnJump()
    {
        if (enSuelo)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocityX, fuerzaSalto);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Moneda"))
        {
            monedasManager.SumarMonedas();
            playerAudio.PlayOneShot(recolectarMoneda);
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("Enemigo"))
        {
            vidasManager.RestarVidas();
        }
    }
}

using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator    animator;

    public float velocidad = 2f;
    public float fuerzaSalto = 4f;

    public float radioSuelo = 0.1f;
    public Transform tocaSuelo;
    public Transform puntoReinicio;
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
            rb.position = puntoReinicio.position;
        }
        if (movimientoX != 0)
            animator.SetBool("estaCorriendo", true);
        else
            animator.SetBool("estaCorriendo", false);
    }

    private void OnMove(InputValue playerInput)
    {
        movimientoX = playerInput.Get<Vector2>().x;
        if (movimientoX != 0)
        {
            transform.localScale = new Vector3(Mathf.Sign(movimientoX) * 2f, 2f, 2f);
        }
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
        if (collision.gameObject.CompareTag("Castillo"))
        {
            SceneManager.LoadScene("Victoria");
        }
        if (collision.gameObject.CompareTag("Enemigo"))
        {
            vidasManager.RestarVidas();
            rb.position = puntoReinicio.position;
        }
    }
}

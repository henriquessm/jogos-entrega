using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private AudioSource audioSource;
    private SpriteRenderer[] spriteRenderers;

    public float speed = 5f;
    public float invulnerabilityTime = 2f;

    public GameObject successPanel;

    private bool isInvulnerable = false;
    private Coroutine invulnerabilityCoroutine;

    private int playerLayer;
    private int enemyLayer;

    public Vector2 minBounds;
    public Vector2 maxBounds;

    private Vector2 lastSafePosition;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
        spriteRenderers = GetComponentsInChildren<SpriteRenderer>();

        playerLayer = LayerMask.NameToLayer("Player");
        enemyLayer = LayerMask.NameToLayer("Enemy");

        Physics2D.IgnoreLayerCollision(playerLayer, enemyLayer, false);
        lastSafePosition = rb.position;
    }



    void FixedUpdate()
    {
        if (!GameController.IsRodando) return;

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        Vector2 newPosition = rb.position + movement.normalized * speed * Time.fixedDeltaTime;

        if (newPosition.x >= minBounds.x && newPosition.x <= maxBounds.x &&
            newPosition.y >= minBounds.y && newPosition.y <= maxBounds.y)
        {
            rb.MovePosition(newPosition);
            lastSafePosition = newPosition;
        }
        else
        {
            rb.position = lastSafePosition;

        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Coletavel"))
        {
            if (audioSource != null)
                audioSource.Play();

            GameController.ColetarItem();
            Destroy(other.gameObject, 0.3f);
        }
        if (other.CompareTag("Saida"))
        {
            GameController.Win();
            Destroy(other.gameObject, 0.3f);
        }
    }

    public void TakeDamage()
    {
        if (!isInvulnerable)
        {
            GameController.TomarDano();

            if (invulnerabilityCoroutine != null){

                StopCoroutine(invulnerabilityCoroutine);
            }

            invulnerabilityCoroutine = StartCoroutine(Invulnerability());
        }
    }

    private IEnumerator Invulnerability()
    {
        isInvulnerable = true;

        Physics2D.IgnoreLayerCollision(playerLayer, enemyLayer, true);

        float elapsed = 0f;
        bool visible = true;

        while (elapsed < invulnerabilityTime)
        {
            visible = !visible;
            foreach (var sr in spriteRenderers)
                sr.enabled = visible;

            yield return new WaitForSeconds(0.1f);
            elapsed += 0.1f;
        }

        Physics2D.IgnoreLayerCollision(playerLayer, enemyLayer, false);

        foreach (var sr in spriteRenderers)
            sr.enabled = true;

        isInvulnerable = false;
    }
}

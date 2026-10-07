using UnityEngine;

public class Coin : MonoBehaviour
{
    [Header("Hover Settings")]
    [SerializeField] private float hoverHeight = 0.3f;
    [SerializeField] private float hoverSpeed = 1.5f;
    [SerializeField] private float rotationSpeed = 90f;

    [Header("Collection Settings")]
    [SerializeField] private GameObject particlePrefab;
    [SerializeField] private float particleDuration = 2f;

    [Header("Audio (opcional)")]
    [SerializeField] private AudioClip collectSound;
    [SerializeField] private float soundVolume = 1f;

    // Referências internas
    private Vector3 startPosition;
    private float randomOffset;

    // Evita contar a mesma moeda duas vezes
    private bool coletada = false;

    private void Start()
    {
        // Guarda a posição inicial
        startPosition = transform.position;

        // Faz cada moeda flutuar em um momento diferente
        randomOffset = Random.Range(0f, Mathf.PI * 2f);
    }

    private void Update()
    {
        // --- Flutuação ---
        float newY = startPosition.y +
            Mathf.Sin((Time.time + randomOffset) * hoverSpeed) * hoverHeight;

        transform.position = new Vector3(
            transform.position.x,
            newY,
            transform.position.z
        );

        // --- Rotação ---
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Collect();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Collect();
        }
    }

    private void Collect()
    {
        // Impede a moeda de ser coletada duas vezes
        if (coletada)
            return;

        coletada = true;

        // --- Atualiza o contador ---
        if (CoinManager.instance != null)
        {
            CoinManager.instance.ColetarMoeda();
        }

        // --- Som ---
        if (collectSound != null)
        {
            AudioSource.PlayClipAtPoint(
                collectSound,
                transform.position,
                soundVolume
            );
        }

        // --- Partículas ---
        if (particlePrefab != null)
        {
            GameObject particles = Instantiate(
                particlePrefab,
                transform.position,
                Quaternion.identity
            );

            Destroy(particles, particleDuration);
        }

        // --- Remove a moeda ---
        gameObject.SetActive(false);
        Destroy(gameObject, 0.5f);
    }
}
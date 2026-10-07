using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class BossController : MonoBehaviour
{
    [Header("Jogador")]
    [SerializeField] private Transform player;

    [Header("Perseguição")]
    [SerializeField] private float distanciaAtivacao = 15f;

    private NavMeshAgent agent;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (player == null)
            return;

        float distancia = Vector3.Distance(transform.position, player.position);

        if (distancia <= distanciaAtivacao)
        {
            agent.SetDestination(player.position);
        }
        else
        {
            agent.ResetPath();
        }
    }
}
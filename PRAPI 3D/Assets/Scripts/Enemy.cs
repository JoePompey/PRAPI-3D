using UnityEngine;
using UnityEngine.AI;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public Transform player;
    private NavMeshAgent agent;

    //Calls at start.
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = true;
    }
    //.

    //Calls every frame.
    void Update()
    {
        agent.SetDestination(player.position);
    }
    //.
}

using UnityEngine;

public class NPCWalk : MonoBehaviour
{
    public float speed = 2f;
    public float walkTime = 3f;
    public float waitTime = 1f;
    private Vector3 targetPosition;
    private float timer;

    void Start()
    {
        SetNewDestination();
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= walkTime)
        {
            timer = 0f;
            SetNewDestination();
        }

        MoveTowardsTarget();
    }

    void MoveTowardsTarget()
    {
        if (Vector3.Distance(transform.position, targetPosition) > 0.1f)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
            Vector3 direction = (targetPosition - transform.position).normalized;
            transform.rotation = Quaternion.LookRotation(direction);
        }
    }

    void SetNewDestination()
    {
        targetPosition = new Vector3(Random.Range(-5f, 5f), transform.position.y, Random.Range(-5f, 5f));
        timer = waitTime;
    }

    void OnCollisionEnter(Collision collision)
    {
        SetNewDestination();
    }
}

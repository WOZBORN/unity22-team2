using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] Transform target;
    private bool playerEntered;

    // Update is called once per frame
    void Update()
    {
        if (playerEntered)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, speed);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.transform.parent = transform;
            playerEntered = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.transform.parent = null;
            playerEntered = false;
        }
    }
}

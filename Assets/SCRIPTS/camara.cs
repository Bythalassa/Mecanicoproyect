using UnityEngine;

public class camara : MonoBehaviour
{
    [SerializeField] private float followSpeed = 5f;
    [SerializeField] private float radiusMovement = 1.7f;

    private Transform target;

    private void Update()
    {      
            GameObject player = GameObject.FindWithTag("Player");
        if (player == null)
        {
            Debug.Log("not found Player");
            return;
        }

            target = player.transform;

        Vector3 myPos = transform.position;
        Vector3 filterPos = new Vector3(target.position.x, target.position.y, myPos.z);

        if (Vector3.Distance(filterPos, myPos) > radiusMovement)
        {
            Vector3 direction = (filterPos - myPos).normalized;
            transform.position += direction * followSpeed * Time.deltaTime;
        }
    }
}
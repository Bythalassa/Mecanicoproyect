using UnityEngine.InputSystem;
using UnityEngine;

public class CamaraFollow : MonoBehaviour
{
    [SerializeField] private Transform Target;
    [SerializeField] private float followSpeed;

    public Vector2 offset;
    public float DynamicCamera;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetPos = new Vector3(
            Target.transform.position.x + offset.x,
            Target.transform.position.y + offset.y, 
            -10);

        Vector3 mousePos = Camera.main.ScreenToViewportPoint(Mouse.current.position.ReadValue()) - new Vector3(0.5f, 0.5f, 0.5f);
        
        Vector3 DynamicPos = targetPos + mousePos * DynamicCamera ;

        transform.position = Vector3.Lerp(
            transform.position,
            DynamicPos,
            followSpeed * Time.deltaTime);


    }
}

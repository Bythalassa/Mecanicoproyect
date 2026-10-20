using UnityEngine;

public class Parallax : MonoBehaviour
{
    [SerializeField] private Transform targetCamera;

    [SerializeField, Range(-1, 1)]
    private float parallaxEffect = 0;

    [SerializeField]
    private float spriteLenght;//->ancho original

    private float initialPos;


    void Start()
    {
        initialPos = transform.position.x;
    }
    private void LateUpdate()
    {
        //->Calcula cuánto debe desplazarse el fondo: la posición X de la cámara por el efecto.
        float parallaxDistance = targetCamera.position.x - parallaxEffect;

        //->
        transform.position = new Vector3(initialPos + parallaxDistance, transform.position.y, transform.position.z);

        float TemporalDistance = targetCamera.position.x * (1 - parallaxEffect);//

        if (TemporalDistance > initialPos + spriteLenght)
        {
            initialPos += spriteLenght;
        }
        else if (TemporalDistance < initialPos - spriteLenght)
        {
            initialPos -= spriteLenght;
        }

    }

    void Update()
    {

    }
}

using System.Collections;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    [Header("Configuracion del Camera Shake")]
    [SerializeField] private float duracion = 0.15f;
    [SerializeField] private float intensidad = 0.12f;

    private Vector3 posicionOriginal;
    private Coroutine sacudidaActual;

    public void Sacudir()
    {
        if (sacudidaActual != null)
        {
            StopCoroutine(sacudidaActual);
            transform.localPosition = posicionOriginal;
        }

        sacudidaActual = StartCoroutine(EfectoSacudida());
    }

    private IEnumerator EfectoSacudida()
    {
        posicionOriginal = transform.localPosition;

        float tiempo = 0f;

        while (tiempo < duracion)
        {
            float x = Random.Range(-1f, 1f) * intensidad;
            float y = Random.Range(-1f, 1f) * intensidad;

            transform.localPosition = posicionOriginal
                + new Vector3(x, y, 0f);

            tiempo += Time.unscaledDeltaTime;

            yield return null;
        }

        transform.localPosition = posicionOriginal;
        sacudidaActual = null;
    }
}

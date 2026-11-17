using UnityEngine;

public class TransformInputController : MonoBehaviour
{
    //referencia A! ClockborgInputController -> crear aqui la accion de LLAMADA A BIRBOT AQUI ES EL CALL 
    // dentro del input y la accion estara la accion de tocar el timbre ClockborgInputController.CallBirdbot. AQUI SE INVOCA.
    // Y NORMAL el ClockbrgAnimatorController escucha el timbre desde este  // TransformationInputController.IsCalled += PlayCallBirdbotAnimation; y set trigger y boom la magia de lo demas pertenece a la otra magia

    // el dilema es -- que la tecla 1 va a desaparecer al player asi que tiene que tener un delay de 60 segundos y luego spawnea al Birdbot en un punto transform muy cerca al player 
    // desaparece el player y el birdbot aparece y se activa el idle animation cuando se mueva con normalidad se movera y cuando no se quedara en idle




    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

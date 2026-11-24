using UnityEngine;

public static class ReadMe_2_0 { }
/*
   // ╔══════════════════════════════════════════════════════════════╗
   // ║  INDEX                                                       ║
   // ║  1 PLAYER INPUTS                                             ║
   // ║  2 METRICS                                                   ║
   // ║  3 ANIMATIONS                                                ║
   // ║  4 Learning Forces formula and UNITY                         ║
   // ║  5 Errores                                                   ║   
   // ╚══════════════════════════════════════════════════════════════╝

    [Header("PLAYER INPUTS")]
  - Movement "wasd""arrows"
  - Jump "space"
  - Punch Impulse "w" 
  - Spin "s
  - Attack "left click"
  - Speed Gear "right click" 
  - Clocksiniester "Q" 
  - Birdbot "1"


   [Header("METRICS")]
   [Header("Clockborg Actions")]
   -   Run    -----------------------------[ ]                                
   -   ShortJump---------------------------[ ]
   -   Punch Impulse ----------------------[ ]
   -   Rodar  -----------------------------[ ]

   [Header("Clocksiniester Actions")]
   - Walk Upsidedown ----------------------[ ]
   - ShortJump (mayor fuerza de salto) ----[ ]
   - Punch Impulse-------------------------[ ]
   - Rodar  -------------------------------[ ]
   
   - Basic Shoot Distance------------------[ ]


   [Header("ANIMATIONS")]  
   [Header("Clockborg")]

   -   Run
   -   ShortJump
   -   Call Birdbot
   -   Idle
   -   Fall
   -   Rodar
   -   RecieveDamage
   -   Death

   [Header("Clocksiniester")]

   - Walk Upsidedown
   - ShortJump (mayor fuerza de salto)
   - Punch Impulse
   - Speed Gear
   - Attack disparo 1/ habilidad pasiva
   - Attack Disparo 2 (pausa)
   - Attack Melee 1 (pausa)
   - Idle
   - Fall
   - Rodar  
   - RecieveDamage

    [Header(" Birdbot ! ")]
   - Fly  
   - Idle
   - Aparición
   - FlyAway
   - RecieveDamage

    ## Pendientes

    - [x] Attack disparo 1/ habilidad pasiva
    - [x] Speed Gear
    - [ ] Efectos del ataque 
    - [ ] Escenario



   [Header("Learning Forces formula and UNITY")] 

    # Pendientes     Clockborg x Clocksiniester
    - [x] Add Gravity from Physics 2D
    - [ ] Rodar -> Add a force rb.AddForce(Vector2.down * algo hacia abajo)
    - [ ] no punch impulse twice 


 [Header("Jump Cut")] 
  
[SerializedField] private float jumpCutMultiplier = 0.1

 public void OnJump ()
 {
    
    //reduces currect rb.velocity.y by amount (0-1)
    if (rb.velocity.y > 0 && OnJump )    
    {
        rb.AddForce(Vector2.down * rb.velocity.y * ( 1 - jumpCutMultiplier), ForceMode2D.Impulse);    
    }

    JumpInputRelease = true; // llamando al input(?
    lastJumpTime = 0 //khe 
  }

 [Header("Errores")] 

 Implementación de colision por capa Layer  "Suelo"

    [Header("Ground Check")]
    public bool isGrounded;
    public float MoveInput;

    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundCheckRadius = 0.15f;
    [SerializeField] private LayerMask groundLayer;

    private void FixedUpdate()
    {
        bool grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        /*Collider2D Physics2D.OverlapCircle(Vector2 punto, float radio, LayerMask capas);

        Debuger
        Collider2D hit = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);    
        Debug.Log($"[{name}] groundCheck de: {groundCheck.parent.name} | mask: {groundLayer.value} | toca: {(hit ? hit.name : "nada")}");

        if (grounded != isGrounded)
        {
            isGrounded = grounded;

            if (grounded)
                airPunchUsed = false;

            OnGround?.Invoke(grounded);
        }
            }

      El problema es que el círculo no está tocando ningún collider de la layer Suelo.
      Asegurar que el Punto Ground este lo suficiente abajo o muy abajo para detectar el suelo, 
      Opción B es subir el Radio.


*/














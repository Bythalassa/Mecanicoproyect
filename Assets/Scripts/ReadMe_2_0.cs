public static class ReadMe_2_0 { }
/*
   // ╔══════════════════════════════════════════════════════════════╗
   // ║  INDEX                                                       ║
   // ║  1 PLAYER INPUTS                                             ║
   // ║  2 METRICS                                                   ║
   // ║  3 ANIMATIONS                                                ║
   // ║  4 Learning Forces formula and UNITY                         ║
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





*/














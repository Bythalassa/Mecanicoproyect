// Fondo estilo "Hue": gris con manchas suaves, pelotas oscuras que orbitan
// y una sombra difusa que las sigue (con retraso). Todo procedural, sin texturas.
// Funciona en Built-in y en URP (2D o 3D) como shader Unlit.
Shader "Custom/HueBackground"
{
    Properties
    {
        [Header(Colores)]
        _ColorLight     ("Gris de fondo", Color) = (0.40, 0.40, 0.40, 1)
        _ColorDark      ("Color pelotas / sombras", Color) = (0.06, 0.06, 0.06, 1)

        [Header(Distribucion)]
        _Scale          ("Escala (celdas por unidad de mundo)", Float) = 0.35
        _Density        ("Densidad de pelotas", Range(0, 1)) = 0.75
        _Parallax       ("Parallax (0 = pegado al mundo, 1 = fijo en pantalla)", Range(0, 1)) = 0.7

        [Header(Pelotas)]
        _BallSize       ("Tamano pelota", Range(0.01, 0.4)) = 0.10
        _BallStrength   ("Opacidad pelota", Range(0, 1)) = 0.55
        _OrbitRadius    ("Radio de giro", Range(0, 0.4)) = 0.22
        _Speed          ("Velocidad de giro", Float) = 0.35

        [Header(Sombras)]
        _ShadowSize     ("Tamano sombra", Range(0.05, 0.5)) = 0.30
        _ShadowStrength ("Opacidad sombra", Range(0, 1)) = 0.55
        _TrailLag       ("Retraso de la sombra (radianes)", Range(0, 2)) = 0.5
        _ShadowOffset   ("Desplazamiento sombra (xy)", Vector) = (0.04, -0.06, 0, 0)

        [Header(Textura)]
        _NoiseStrength  ("Manchas del fondo", Range(0, 0.4)) = 0.12
        _NoiseScale     ("Escala manchas", Float) = 1.3
        _Grain          ("Grano de pelicula", Range(0, 0.1)) = 0.015
    }

    SubShader
    {
        Tags { "Queue"="Background" "RenderType"="Opaque" "IgnoreProjector"="True" "PreviewType"="Plane" }
        ZWrite Off
        Cull Off

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            float4 _ColorLight, _ColorDark;
            float  _Scale, _Density, _Parallax;
            float  _BallSize, _BallStrength, _OrbitRadius, _Speed;
            float  _ShadowSize, _ShadowStrength, _TrailLag;
            float4 _ShadowOffset;
            float  _NoiseStrength, _NoiseScale, _Grain;

            struct appdata { float4 vertex : POSITION; };
            struct v2f
            {
                float4 pos      : SV_POSITION;
                float3 worldPos : TEXCOORD0;
            };

            v2f vert (appdata v)
            {
                v2f o;
                o.pos = UnityObjectToClipPos(v.vertex);
                o.worldPos = mul(unity_ObjectToWorld, v.vertex).xyz;
                return o;
            }

            // ---------- utilidades de ruido ----------
            float2 hash22(float2 p)
            {
                float3 p3 = frac(float3(p.xyx) * float3(0.1031, 0.1030, 0.0973));
                p3 += dot(p3, p3.yzx + 33.33);
                return frac((p3.xx + p3.yz) * p3.zy);
            }

            float hash21(float2 p)
            {
                p = frac(p * float2(123.34, 456.21));
                p += dot(p, p + 45.32);
                return frac(p.x * p.y);
            }

            float vnoise(float2 p)
            {
                float2 i = floor(p);
                float2 f = frac(p);
                float2 u = f * f * (3.0 - 2.0 * f);
                float a = hash21(i);
                float b = hash21(i + float2(1, 0));
                float c = hash21(i + float2(0, 1));
                float d = hash21(i + float2(1, 1));
                return lerp(lerp(a, b, u.x), lerp(c, d, u.x), u.y);
            }

            float fbm(float2 p)
            {
                float v = 0.0, a = 0.5;
                for (int k = 0; k < 4; k++)
                {
                    v += a * vnoise(p);
                    p = p * 2.03 + 11.7;
                    a *= 0.5;
                }
                return v;
            }

            // ---------- fragment ----------
            fixed4 frag (v2f i) : SV_Target
            {
                // Coordenadas con parallax: el patron se mueve mas lento que el nivel
                float2 world = i.worldPos.xy - _WorldSpaceCameraPos.xy * _Parallax;
                float2 p = world * _Scale;

                float2 cell = floor(p);
                float2 f    = frac(p);
                float  t    = _Time.y;

                float ball   = 0.0;
                float shadow = 0.0;

                // Revisamos la celda actual y las 8 vecinas
                [unroll] for (int y = -1; y <= 1; y++)
                [unroll] for (int x = -1; x <= 1; x++)
                {
                    float2 g  = float2(x, y);
                    float2 h  = hash22(cell + g);
                    float2 h2 = hash22(cell + g + 17.31);

                    // Algunas celdas quedan vacias segun la densidad
                    if (h2.y > _Density) continue;

                    float2 center  = g + 0.25 + 0.5 * h;                 // centro de la orbita
                    float  radius  = _OrbitRadius * (0.4 + 0.6 * h2.x);  // radio variable
                    float  dir     = (h.x > 0.5) ? 1.0 : -1.0;           // sentido horario/antihorario
                    float  spd     = _Speed * (0.5 + h.y) * dir;
                    float  ang     = t * spd + h.y * 6.2831;
                    float  sizeMul = 0.6 + 0.8 * h2.x;

                    // Pelota
                    float2 bp = center + radius * float2(cos(ang), sin(ang));
                    float  db = length(f - bp);
                    float  r  = _BallSize * sizeMul;
                    float  b  = 1.0 - smoothstep(r * 0.35, r, db);   // borde suave
                    ball = 1.0 - (1.0 - ball) * (1.0 - b);

                    // Sombra: va detras en la orbita + desplazamiento fijo
                    float  sang = ang - _TrailLag * dir;
                    float2 sp   = center + radius * float2(cos(sang), sin(sang)) + _ShadowOffset.xy;
                    float  ds   = length(f - sp);
                    float  ss   = _ShadowSize * sizeMul;
                    float  s    = exp(-(ds * ds) / (ss * ss));        // gaussiana
                    shadow = 1.0 - (1.0 - shadow) * (1.0 - s);
                }

                // Manchas lentas del fondo
                float n = fbm(world * _NoiseScale * _Scale + t * 0.02);
                float mottle = (n - 0.5) * 2.0 * _NoiseStrength;

                float dark = saturate(shadow * _ShadowStrength + ball * _BallStrength + mottle);
                float3 col = lerp(_ColorLight.rgb, _ColorDark.rgb, dark);

                // Grano animado
                float grain = hash21(i.pos.xy + frac(t * 7.13) * 100.0) - 0.5;
                col += grain * _Grain;

                return fixed4(col, 1);
            }
            ENDCG
        }
    }
    FallBack Off
}

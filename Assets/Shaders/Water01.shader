Shader "Custom/SimpleWater"
{
    Properties
    {
        _Color ("Water Color", Color) = (0, 0.5, 1, 0.5) // Azul semitransparente
        _MainTex ("Water Texture", 2D) = "white" {}
        _Speed ("Wave Speed", Float) = 0.1
        _Scale ("Wave Scale", Float) = 10.0
    }
    SubShader
    {
        Tags { "Queue"="Transparent" }
        Pass
        {
            Blend SrcAlpha OneMinusSrcAlpha // Habilita transparencia
            ZWrite Off // Evita problemas de profundidad
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            struct appdata_t {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            float4 _Color;
            float _Speed;
            float _Scale;

            v2f vert (appdata_t v) {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv + float2(_Time.y * _Speed, _Time.y * _Speed); // Movimiento del agua
                return o;
            }

            fixed4 frag (v2f i) : SV_Target {
                fixed4 col = tex2D(_MainTex, i.uv * _Scale); // Aplica textura con escala
                return col * _Color; // Combina color y textura
            }
            ENDCG
        }
    }
}

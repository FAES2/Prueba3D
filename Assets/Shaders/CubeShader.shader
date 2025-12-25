Shader "Custom/AtlasUVShader" {
    Properties {
        _MainTex ("Atlas", 2D) = "white" {}
        _CellSize ("Cell Size", Vector) = (0.25, 0.25, 0, 0)
        _CellOffset ("Cell Offset", Vector) = (0.0, 0.0, 0, 0)
    }
    SubShader {
        Tags { "RenderType"="Opaque" }
        LOD 100

        Pass {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            sampler2D _MainTex;
            float4 _CellSize;
            float4 _CellOffset;

            struct appdata {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            v2f vert (appdata v) {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);

                // Aplicar transformación UV para recortar la celda deseada
                o.uv = v.uv * _CellSize.xy + _CellOffset.xy;
                return o;
            }

            fixed4 frag (v2f i) : SV_Target {
                fixed4 col = tex2D(_MainTex, i.uv);
                col.a = 1.0; // Ignora canal alpha si no lo usas
                return col;
            }
            ENDCG
        }
    }
}

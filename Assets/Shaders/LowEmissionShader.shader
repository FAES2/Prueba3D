Shader "FAESMuseum/LowEmissionShader"
{
    Properties
    {
        _Color ("Base Color", Color) = (1,1,1,1)
        _EmissionColor ("Emission Color", Color) = (0.1, 0.1, 0.1)
        _MainTex ("Texture", 2D) = "white" {}
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 200

        CGPROGRAM
        #pragma surface surf Standard fullforwardshadows

        sampler2D _MainTex;
        fixed4 _Color;
        fixed4 _EmissionColor;

        struct Input
        {
            float2 uv_MainTex;
        };

        void surf (Input IN, inout SurfaceOutputStandard o)
        {
            fixed4 tex = tex2D(_MainTex, IN.uv_MainTex);
            o.Albedo = tex.rgb * _Color.rgb;
            o.Emission = max(_EmissionColor.rgb, fixed3(0.1, 0.1, 0.1)); // Evita #000000
        }
        ENDCG
    }
    FallBack "Diffuse"
}

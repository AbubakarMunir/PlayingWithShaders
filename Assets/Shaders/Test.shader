Shader "Unlit/TestShader"
{
    Properties
    {
        _MainTex("Texture", 2D) = "white" {}
        _StateProperty("state", Int) = 0
    }
        SubShader
        {
            Tags { "RenderType" = "Opaque" }
            LOD 100

            Pass
            {
                CGPROGRAM
                #pragma vertex vert
                #pragma fragment frag
                // make fog work
                #pragma multi_compile_fog

                #include "UnityCG.cginc"

                struct appdata
                {
                    float4 vertex : POSITION;
                    float2 uv : TEXCOORD0;
                };

                struct v2f
                {
                    float2 uv : TEXCOORD0;
                    UNITY_FOG_COORDS(1)
                    float4 vertex : SV_POSITION;
                };

                sampler2D _MainTex;
                float4 _MainTex_ST;
                int _StateProperty;

                v2f vert(appdata v)
                {
                    v2f o;
                    o.vertex = UnityObjectToClipPos(v.vertex);
                    o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                    UNITY_TRANSFER_FOG(o, o.vertex);
                    return o;
                }

                fixed4 frag(v2f i) : SV_Target
                {
                    fixed4 col = tex2D(_MainTex, i.uv);

                    if (_StateProperty == 1)
                    {
                        if (i.uv.x >= 0.2 && i.uv.x <= 0.8 && i.uv.y >= 0.2 && i.uv.y <= 0.8)
                        {
                            col = fixed4(i.uv.x, 1, 1, 0);
                        }
                        else
                        {
                            col = fixed4(i.uv.x, i.uv.y, 1, 1);
                        }
                    }
                    else
                    {
                        col = fixed4(i.uv.x, i.uv.y, 1, 1);
                    }

                    // Apply fog
                    UNITY_APPLY_FOG(i.fogCoord, col);
                    return col;
                }
                ENDCG
            }
        }
}

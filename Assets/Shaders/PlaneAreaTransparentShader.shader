Shader "Custom/PlaneAreaTransparentShader" {
    SubShader {
        Tags { "RenderType"="Transparent" "Queue"="Geometry" }
        ZWrite Off 
        Blend SrcAlpha OneMinusSrcAlpha 
        Stencil {
            Ref 1
            Comp Always
            Pass Replace
        }
        Pass {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            struct appdata {
                float4 vertex : POSITION;
            };
            struct v2f {
                float4 pos : SV_POSITION;
            };
            v2f vert(appdata v) {
                v2f o;
                o.pos = UnityObjectToClipPos(v.vertex);
                return o;
            }
            half4 frag(v2f i) : SV_Target {
                return half4(0,0,0,0);
            }
            ENDCG
        }
    } 
}

Shader "Unlit/PostProcessSplitScreen"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
		_FirstCamTex ("First Camera RT", 2D) = "white" {}
		_SecondCamTex ("First Camera RT", 2D) = "white" {}

		_VectorDir("Vector Dir", Vector) =  (0,0,0,0)
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            sampler2D _FirstCamTex;
            sampler2D _SecondCamTex;
            float4 _MainTex_ST;
			float4 _VectorDir;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                fixed4 col = tex2D(_MainTex, i.uv);
				float greyScale =  step(0,dot(_VectorDir.xy, i.uv - float2(.5,.5)));
                return step(greyScale, .5) * tex2D(_FirstCamTex,i.uv) + step(.5,greyScale) * tex2D(_SecondCamTex,i.uv);
            }
            ENDCG
        }
    }
}

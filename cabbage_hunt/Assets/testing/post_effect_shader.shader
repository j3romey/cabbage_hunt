// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Custom/testx"
{
	Properties
	{
		

		_MainTex ("Texture", 2D) = "white" {}
		_Tween ("Tween", Range(0,1)) = 0
		_r ("Red", Range(0,1)) = 0
		_g ("Green", Range(0,1)) = 0
		_b ("Blue", Range(0,1)) = 0
	}
	SubShader
	{
		// No culling or depth
		Cull Off ZWrite Off ZTest Always

		Tags
		{
			"Queue" = "Transparent"
		}

		Pass
		{
			Blend SrcAlpha OneMinusSrcAlpha

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

			v2f vert (appdata v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.uv = v.uv*2;
				return o;
			}
			
			sampler2D _MainTex;
			float _r, _g, _b;

			fixed4 frag (v2f i) : SV_Target
			{
				// Hue color all around
				fixed4 col = tex2D(_MainTex, i.uv) * float4( _r, _g, _b, 1);

				// nice color but fixed (no slider)
				//fixed4 col = tex2D(_MainTex, i.uv) * float4((i.uv.r * _r), (i.uv.g * _g), _b, 1);

				return col;
			}
			ENDCG
		}
	}
}

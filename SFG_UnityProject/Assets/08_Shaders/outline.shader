Shader "Unlit/outline"
{
	Properties
	{
		_Color ("Color", color) = (1,1,1,1)
		_OutlineColor ("Outline Color", Color) = (0,0,0,1)
		_OutlineWidth ("Outline Width", Range (0.001,0.1)) = 0.005
		_MainTex ("Texture", 2D) = "white" {}
	}
	SubShader
	{
		Tags { "RenderType"="Opaque" }
		LOD 100

		//***
		//START - texture/color
		//**
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

			fixed4 _Color;
			
			v2f vert (appdata v)
			{
				v2f o;
				o.vertex = mul(UNITY_MATRIX_MVP, v.vertex);
				o.uv = TRANSFORM_TEX(v.uv, _MainTex);
				UNITY_TRANSFER_FOG(o,o.vertex);
				return o;
			}
			
			fixed4 frag (v2f i) : SV_Target
			{
				// sample the texture
				fixed4 col = tex2D(_MainTex, i.uv)*_Color;
				// apply fog
				UNITY_APPLY_FOG(i.fogCoord, col);
				return col;
			}
			ENDCG
		}
		//***
		//END - texture/color
		//***

		//***
		//START - outline
		//***
		Pass
		{
			tags { "Lightmode"="Always" }
			Cull Front

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
				float3 normal : NORMAL;
			};

			struct v2f
			{
				float2 uv : TEXCOORD0;
				UNITY_FOG_COORDS(1)
				float4 pos : POSITION;
				float4 color : COLOR;
			};

			sampler2D _MainTex;
			float4 _MainTex_ST;
				
			uniform float _OutlineWidth;
			uniform float4 _OutlineColor;
			
			v2f vert (appdata v)
			{
				v2f o;

				o.pos = mul(UNITY_MATRIX_MVP, v.vertex);

				float3 norm = mul((float3x3)UNITY_MATRIX_IT_MV, v.normal);
				float2 offset = TransformViewToProjection(norm.xy);

				o.pos.xy += offset * o.pos.z * _OutlineWidth;
				o.color = _OutlineColor;
				return o;
			}
			
			fixed4 frag (v2f i) : SV_Target
			{
				// sample the texture
				fixed4 col = _OutlineColor;
				// apply fog
				UNITY_APPLY_FOG(i.fogCoord, col);
				return col;
			}
			ENDCG
		}
		//***
		//END - outline
		//***
	}

	FALLBACK "Unlit/Color"
}

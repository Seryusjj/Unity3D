Shader "Hidden/ContrastComposite" {
	Properties {
		_MainTex ("Base (RGB)", 2D) = "" {}
		_MainTexBlurred ("Base Blurred (RGB)", 2D) = "" {}
	}
	
	// Shader code pasted into all further CGPROGRAM blocks	
	CGINCLUDE
	
	#include "UnityCG.cginc"
	
	struct v2f {
		float4 pos : POSITION;
		float2 uv : TEXCOORD0;
	};
	
	sampler2D _MainTex;
	sampler2D _MainTexBlurred;
	
	float intensity;
	float threshhold;
		
	v2f vert( appdata_img v ) {
		v2f o;
		o.pos = mul(UNITY_MATRIX_MVP, v.vertex);
		o.uv = v.texcoord.xy;
		return o;
	}
	
	half4 frag(v2f i) : COLOR 
	{
		half4 color = tex2D (_MainTex, i.uv);
		half4 blurred = tex2D (_MainTexBlurred, (i.uv));
		
		half4 difff = color - blurred;
		half4 signs = sign (difff);
		
		difff = saturate ( (color-blurred) - threshhold) * signs * 1.0/(1.0-threshhold);
		color += difff * intensity;
		
		return color;
	}

	ENDCG
	
Subshader {
 Pass {
	  ZTest Always Cull Off ZWrite Off
	  Fog { Mode off }      

      CGPROGRAM
      #pragma fragmentoption ARB_precision_hint_fastest
      #pragma vertex vert
      #pragma fragment frag
      ENDCG
  }
}

Fallback off
	
} // shader
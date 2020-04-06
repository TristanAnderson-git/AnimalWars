// Made with Amplify Shader Editor
// Available at the Unity Asset Store - http://u3d.as/y3X 
Shader "CellShader/Water"
{
	Properties
	{
		_Deep("Deep", Color) = (0.238,0.8079512,1,1)
		_Shadow("Shadow", Color) = (0.1372549,0.6588235,0.8313726,1)
		_Shallow("Shallow", Color) = (0.6556604,1,0.9703381,1)
		_RollSpeed("Roll Speed", Float) = 0.1
		_FoamAmount("FoamAmount", Range( 0 , 1)) = 0.9
		_WaveHeight("Wave Height", Range( 0 , 1)) = 0.25
		_Tessellation("Tessellation", Range( 1 , 16)) = 4
		_ShadowStrength("Shadow Strength", Range( 0 , 1)) = 0
		[HideInInspector] _texcoord( "", 2D ) = "white" {}
		[HideInInspector] __dirty( "", Int ) = 1
	}

	SubShader
	{
		Tags{ "RenderType" = "Transparent"  "Queue" = "Geometry+0" "IgnoreProjector" = "True" "IsEmissive" = "true"  }
		Cull Back
		Blend SrcAlpha OneMinusSrcAlpha , SrcAlpha OneMinusSrcAlpha
		BlendOp Add
		CGPROGRAM
		#include "UnityShaderVariables.cginc"
		#include "UnityCG.cginc"
		#include "Tessellation.cginc"
		#pragma target 5.0
		#pragma surface surf Unlit keepalpha noshadow vertex:vertexDataFunc tessellate:tessFunction 
		struct Input
		{
			float4 screenPos;
			float2 uv_texcoord;
			float3 worldPos;
		};

		uniform float _RollSpeed;
		uniform float _WaveHeight;
		uniform float4 _Deep;
		uniform float4 _Shallow;
		uniform float4 _Shadow;
		uniform float _ShadowStrength;
		UNITY_DECLARE_DEPTH_TEXTURE( _CameraDepthTexture );
		uniform float4 _CameraDepthTexture_TexelSize;
		uniform float _FoamAmount;
		uniform float _Tessellation;


		float3 mod2D289( float3 x ) { return x - floor( x * ( 1.0 / 289.0 ) ) * 289.0; }

		float2 mod2D289( float2 x ) { return x - floor( x * ( 1.0 / 289.0 ) ) * 289.0; }

		float3 permute( float3 x ) { return mod2D289( ( ( x * 34.0 ) + 1.0 ) * x ); }

		float snoise( float2 v )
		{
			const float4 C = float4( 0.211324865405187, 0.366025403784439, -0.577350269189626, 0.024390243902439 );
			float2 i = floor( v + dot( v, C.yy ) );
			float2 x0 = v - i + dot( i, C.xx );
			float2 i1;
			i1 = ( x0.x > x0.y ) ? float2( 1.0, 0.0 ) : float2( 0.0, 1.0 );
			float4 x12 = x0.xyxy + C.xxzz;
			x12.xy -= i1;
			i = mod2D289( i );
			float3 p = permute( permute( i.y + float3( 0.0, i1.y, 1.0 ) ) + i.x + float3( 0.0, i1.x, 1.0 ) );
			float3 m = max( 0.5 - float3( dot( x0, x0 ), dot( x12.xy, x12.xy ), dot( x12.zw, x12.zw ) ), 0.0 );
			m = m * m;
			m = m * m;
			float3 x = 2.0 * frac( p * C.www ) - 1.0;
			float3 h = abs( x ) - 0.5;
			float3 ox = floor( x + 0.5 );
			float3 a0 = x - ox;
			m *= 1.79284291400159 - 0.85373472095314 * ( a0 * a0 + h * h );
			float3 g;
			g.x = a0.x * x0.x + h.x * x0.y;
			g.yz = a0.yz * x12.xz + h.yz * x12.yw;
			return 130.0 * dot( m, g );
		}


		float4 tessFunction( appdata_full v0, appdata_full v1, appdata_full v2 )
		{
			float4 temp_cast_0 = (_Tessellation).xxxx;
			return temp_cast_0;
		}

		void vertexDataFunc( inout appdata_full v )
		{
			float waveTimeScale195 = ( _Time.y * _RollSpeed );
			float2 waveSpeed196 = float2( 0,1 );
			float2 uv_TexCoord2 = v.texcoord.xy * float2( 0.5,4 );
			float2 panner3 = ( waveTimeScale195 * waveSpeed196 + uv_TexCoord2);
			float simplePerlin2D1 = snoise( panner3 );
			simplePerlin2D1 = simplePerlin2D1*0.5 + 0.5;
			float waveBaseTexture200 = simplePerlin2D1;
			v.vertex.xyz += ( waveBaseTexture200 * float3(0,1,0) * _WaveHeight );
		}

		inline half4 LightingUnlit( SurfaceOutput s, half3 lightDir, half atten )
		{
			return half4 ( 0, 0, 0, s.Alpha );
		}

		void surf( Input i , inout SurfaceOutput o )
		{
			float4 ase_screenPos = float4( i.screenPos.xyz , i.screenPos.w + 0.00000000001 );
			float4 ase_screenPosNorm = ase_screenPos / ase_screenPos.w;
			ase_screenPosNorm.z = ( UNITY_NEAR_CLIP_VALUE >= 0 ) ? ase_screenPosNorm.z : ase_screenPosNorm.z * 0.5 + 0.5;
			float temp_output_61_0 = ( ase_screenPosNorm.x - ase_screenPosNorm.y );
			float clampResult62 = clamp( ( temp_output_61_0 - -0.75 ) , 0.0 , 1.0 );
			float4 lerpResult66 = lerp( _Deep , _Shallow , clampResult62);
			float waveTimeScale195 = ( _Time.y * _RollSpeed );
			float2 waveSpeed196 = float2( 0,1 );
			float2 appendResult186 = (float2(0.1 , 0.0));
			float2 uv_TexCoord169 = i.uv_texcoord * float2( 0.5,4 ) + ( i.uv_texcoord - appendResult186 );
			float2 panner170 = ( waveTimeScale195 * waveSpeed196 + uv_TexCoord169);
			float simplePerlin2D164 = snoise( panner170 );
			simplePerlin2D164 = simplePerlin2D164*0.5 + 0.5;
			float2 appendResult187 = (float2(0.0 , 0.1));
			float2 uv_TexCoord176 = i.uv_texcoord * float2( 0.5,4 ) + ( i.uv_texcoord - appendResult187 );
			float2 panner177 = ( waveTimeScale195 * waveSpeed196 + uv_TexCoord176);
			float simplePerlin2D171 = snoise( panner177 );
			simplePerlin2D171 = simplePerlin2D171*0.5 + 0.5;
			float2 appendResult215 = (float2(simplePerlin2D164 , simplePerlin2D171));
			float2 uv_TexCoord204 = i.uv_texcoord * float2( 0.5,4 ) + i.uv_texcoord;
			float2 panner203 = ( waveTimeScale195 * waveSpeed196 + uv_TexCoord204);
			float simplePerlin2D202 = snoise( panner203 );
			simplePerlin2D202 = simplePerlin2D202*0.5 + 0.5;
			float2 temp_cast_0 = (simplePerlin2D202).xx;
			float2 temp_output_216_0 = ( appendResult215 - temp_cast_0 );
			float2 temp_cast_1 = (simplePerlin2D202).xx;
			float2 temp_cast_2 = (simplePerlin2D202).xx;
			float dotResult217 = dot( temp_output_216_0 , temp_output_216_0 );
			float3 appendResult211 = (float3(temp_output_216_0 , sqrt( ( 1.0 - dotResult217 ) )));
			float3 waveNormal199 = appendResult211;
			float3 ase_worldPos = i.worldPos;
			#if defined(LIGHTMAP_ON) && UNITY_VERSION < 560 //aseld
			float3 ase_worldlightDir = 0;
			#else //aseld
			float3 ase_worldlightDir = normalize( UnityWorldSpaceLightDir( ase_worldPos ) );
			#endif //aseld
			float dotResult138 = dot( waveNormal199 , ase_worldlightDir );
			float clampResult139 = clamp( dotResult138 , 0.0 , 1.0 );
			float clampResult229 = clamp( ( temp_output_61_0 - -1.125 ) , 0.0 , 1.0 );
			float eyeDepth57 = LinearEyeDepth(SAMPLE_DEPTH_TEXTURE( _CameraDepthTexture, ase_screenPosNorm.xy ));
			float temp_output_69_0 = ( eyeDepth57 - ase_screenPos.w );
			float clampResult224 = clamp( temp_output_69_0 , 0.0 , 1.0 );
			float4 lerpResult135 = lerp( lerpResult66 , _Shadow , ( step( clampResult139 , _ShadowStrength ) * ( 1.0 - clampResult229 ) * clampResult224 ));
			float clampResult74 = clamp( ( 1.0 - temp_output_69_0 ) , 0.0 , 1.0 );
			float temp_output_2_0_g1 = step( clampResult74 , ( 1.0 - _FoamAmount ) );
			float temp_output_3_0_g1 = ( 1.0 - temp_output_2_0_g1 );
			float3 appendResult7_g1 = (float3(temp_output_3_0_g1 , temp_output_3_0_g1 , temp_output_3_0_g1));
			o.Emission = ( ( lerpResult135.rgb * temp_output_2_0_g1 ) + appendResult7_g1 );
			o.Alpha = 1;
		}

		ENDCG
	}
	CustomEditor "ASEMaterialInspector"
}
/*ASEBEGIN
Version=17800
549;693;1715;587;1130.91;-205.3738;1.037848;True;True
Node;AmplifyShaderEditor.CommentaryNode;132;-2299.687,222.7503;Inherit;False;1776.72;542.7336;Height offset;13;4;5;6;7;195;196;10;11;9;1;3;2;200;Waves;1,1,1,1;0;0
Node;AmplifyShaderEditor.CommentaryNode;193;-5726.121,-632.7894;Inherit;False;2996.575;1148.822;Recalculate normal;24;199;210;209;164;171;202;177;203;170;204;169;176;198;197;191;188;186;187;190;185;211;215;216;217;Normal;1,1,1,1;0;0
Node;AmplifyShaderEditor.SimpleTimeNode;5;-2256.301,506.8731;Inherit;False;1;0;FLOAT;1;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;6;-2244.875,589.8538;Inherit;False;Property;_RollSpeed;Roll Speed;4;0;Create;True;0;0;False;0;0.1;0.1;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;185;-5661.352,-284.6575;Inherit;False;Constant;_VertexDistance;Vertex Distance;11;0;Create;True;0;0;False;0;0.1;0;0;0.1;0;1;FLOAT;0
Node;AmplifyShaderEditor.TexCoordVertexDataNode;190;-5392.691,-514.4333;Inherit;False;0;2;0;5;FLOAT2;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.DynamicAppendNode;187;-5324.366,-246.6115;Inherit;False;FLOAT2;4;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0;False;3;FLOAT;0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.Vector2Node;4;-2010.326,356.0319;Inherit;False;Constant;_Vector0;Vector 0;0;0;Create;True;0;0;False;0;0,1;0,0;0;3;FLOAT2;0;FLOAT;1;FLOAT;2
Node;AmplifyShaderEditor.DynamicAppendNode;186;-5324.366,-359.6117;Inherit;False;FLOAT2;4;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0;False;3;FLOAT;0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;7;-2022.487,491.1308;Inherit;True;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;196;-1803.965,401.0148;Inherit;False;waveSpeed;-1;True;1;0;FLOAT2;0,0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;195;-1805.67,487.1504;Inherit;False;waveTimeScale;-1;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleSubtractOpNode;191;-5065.837,-166.9151;Inherit;False;2;0;FLOAT2;0,0;False;1;FLOAT2;0,0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.SimpleSubtractOpNode;188;-5067.44,-513.4042;Inherit;False;2;0;FLOAT2;0,0;False;1;FLOAT2;0,0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.GetLocalVarNode;198;-5426.946,-49.9252;Inherit;False;195;waveTimeScale;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode;197;-5401.934,-128.2904;Inherit;False;196;waveSpeed;1;0;OBJECT;;False;1;FLOAT2;0
Node;AmplifyShaderEditor.TextureCoordinatesNode;169;-4867.592,-562.717;Inherit;False;0;-1;2;3;2;SAMPLER2D;;False;0;FLOAT2;0.5,4;False;1;FLOAT2;0,0;False;5;FLOAT2;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.TextureCoordinatesNode;176;-4873.222,-212.896;Inherit;False;0;-1;2;3;2;SAMPLER2D;;False;0;FLOAT2;0.5,4;False;1;FLOAT2;0,0;False;5;FLOAT2;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.PannerNode;170;-4576.858,-509.2213;Inherit;True;3;0;FLOAT2;0,0;False;2;FLOAT2;0,0;False;1;FLOAT;1;False;1;FLOAT2;0
Node;AmplifyShaderEditor.PannerNode;177;-4585.055,-141.2637;Inherit;True;3;0;FLOAT2;0,0;False;2;FLOAT2;0,0;False;1;FLOAT;1;False;1;FLOAT2;0
Node;AmplifyShaderEditor.TextureCoordinatesNode;204;-4881.849,-34.48351;Inherit;False;0;-1;2;3;2;SAMPLER2D;;False;0;FLOAT2;0.5,4;False;1;FLOAT2;0,0;False;5;FLOAT2;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.NoiseGeneratorNode;171;-4276.138,-138.5234;Inherit;True;Simplex2D;True;False;2;0;FLOAT2;0,0;False;1;FLOAT;1;False;1;FLOAT;0
Node;AmplifyShaderEditor.PannerNode;203;-4591.278,155.9579;Inherit;True;3;0;FLOAT2;0,0;False;2;FLOAT2;0,0;False;1;FLOAT;1;False;1;FLOAT2;0
Node;AmplifyShaderEditor.NoiseGeneratorNode;164;-4282.782,-510.9826;Inherit;True;Simplex2D;True;False;2;0;FLOAT2;0,0;False;1;FLOAT;1;False;1;FLOAT;0
Node;AmplifyShaderEditor.DynamicAppendNode;215;-4000.202,-254.2112;Inherit;False;FLOAT2;4;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0;False;3;FLOAT;0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.NoiseGeneratorNode;202;-4270.36,149.6982;Inherit;True;Simplex2D;True;False;2;0;FLOAT2;0,0;False;1;FLOAT;1;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleSubtractOpNode;216;-3819.076,-146.1345;Inherit;False;2;0;FLOAT2;0,0;False;1;FLOAT;0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.DotProductOpNode;217;-3613.776,-20.63045;Inherit;False;2;0;FLOAT2;0,0;False;1;FLOAT2;0,0;False;1;FLOAT;0
Node;AmplifyShaderEditor.OneMinusNode;209;-3491.954,-21.57442;Inherit;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SqrtOpNode;210;-3336.975,-23.22722;Inherit;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.DynamicAppendNode;211;-3178.953,-152.6285;Inherit;True;FLOAT3;4;0;FLOAT2;0,0;False;1;FLOAT;0;False;2;FLOAT;0;False;3;FLOAT;0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.ScreenPosInputsNode;77;-3189.417,-898.8824;Float;True;0;False;0;5;FLOAT4;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.RegisterLocalVarNode;199;-2952.098,-156.9653;Inherit;False;waveNormal;-1;True;1;0;FLOAT3;0,0,0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.WorldSpaceLightDirHlpNode;136;-1723.63,-547.4108;Inherit;False;False;1;0;FLOAT;0;False;4;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3
Node;AmplifyShaderEditor.SimpleSubtractOpNode;61;-2920.271,-805.9811;Inherit;False;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;227;-2279.27,-392.6238;Inherit;False;Constant;_Float0;Float 0;0;0;Create;True;0;0;False;0;-1.125;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.CommentaryNode;133;-2298.707,-204.4448;Inherit;False;1263.154;301.3485;Geometry Intersection;8;58;57;73;72;74;78;76;69;Foam;1,1,1,1;0;0
Node;AmplifyShaderEditor.GetLocalVarNode;205;-1723.36,-631.0865;Inherit;False;199;waveNormal;1;0;OBJECT;;False;1;FLOAT3;0
Node;AmplifyShaderEditor.DotProductOpNode;138;-1428.083,-632.4698;Inherit;False;2;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;1;FLOAT;0
Node;AmplifyShaderEditor.ScreenPosInputsNode;58;-2249.559,-107.6236;Float;True;1;False;0;5;FLOAT4;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SimpleSubtractOpNode;228;-2022.684,-410.8058;Inherit;False;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.ScreenDepthNode;57;-2007.401,-141.5708;Inherit;False;0;True;1;0;FLOAT4;0,0,0,0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;60;-2612.307,-750.0117;Inherit;False;Constant;_Float3;Float 3;0;0;Create;True;0;0;False;0;-0.75;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.ClampOpNode;139;-1265.575,-632.7496;Inherit;False;3;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;1;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;194;-1329.205,-514.9946;Inherit;False;Property;_ShadowStrength;Shadow Strength;8;0;Create;True;0;0;False;0;0;0.552;0;1;0;1;FLOAT;0
Node;AmplifyShaderEditor.ClampOpNode;229;-1850.217,-409.9982;Inherit;False;3;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;1;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleSubtractOpNode;69;-1722.433,-138.1563;Inherit;False;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleSubtractOpNode;64;-2432.51,-805.0928;Inherit;False;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.TextureCoordinatesNode;2;-1808.67,276.8227;Inherit;False;0;-1;2;3;2;SAMPLER2D;;False;0;FLOAT2;0.5,4;False;1;FLOAT2;0,0;False;5;FLOAT2;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.ClampOpNode;224;-1452.271,-339.6231;Inherit;False;3;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;1;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;76;-1718.215,-17.34135;Inherit;False;Property;_FoamAmount;FoamAmount;5;0;Create;True;0;0;False;0;0.9;0.032;0;1;0;1;FLOAT;0
Node;AmplifyShaderEditor.PannerNode;3;-1539.606,334.7606;Inherit;True;3;0;FLOAT2;0,0;False;2;FLOAT2;0,0;False;1;FLOAT;1;False;1;FLOAT2;0
Node;AmplifyShaderEditor.OneMinusNode;72;-1529.517,-139.4983;Inherit;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.ColorNode;32;-2004.259,-1141.867;Inherit;False;Property;_Deep;Deep;1;0;Create;True;0;0;False;0;0.238,0.8079512,1,1;0.238,0.8079512,1,1;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.ColorNode;67;-2003.751,-962.7321;Inherit;False;Property;_Shallow;Shallow;3;0;Create;True;0;0;False;0;0.6556604,1,0.9703381,1;0.6556604,1,0.9703381,1;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.ClampOpNode;62;-2264.253,-803.6349;Inherit;True;3;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;1;False;1;FLOAT;0
Node;AmplifyShaderEditor.OneMinusNode;230;-1454.827,-410.4436;Inherit;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.StepOpNode;140;-1043.788,-632.7574;Inherit;False;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.NoiseGeneratorNode;1;-1277.24,331.0124;Inherit;True;Simplex2D;True;False;2;0;FLOAT2;0,0;False;1;FLOAT;1;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;218;-901.3109,-554.5312;Inherit;False;3;3;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.LerpOp;66;-1678.255,-857.7404;Inherit;False;3;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;2;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.OneMinusNode;78;-1359.862,-15.36192;Inherit;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.ClampOpNode;74;-1351.909,-138.5042;Inherit;False;3;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;1;False;1;FLOAT;0
Node;AmplifyShaderEditor.ColorNode;134;-1991.311,-718.0895;Inherit;False;Property;_Shadow;Shadow;2;0;Create;True;0;0;False;0;0.1372549,0.6588235,0.8313726,1;0.1377834,0.6571211,0.832,1;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.RegisterLocalVarNode;200;-1010.171,331.4419;Inherit;False;waveBaseTexture;-1;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.Vector3Node;9;-1004.386,423.8103;Inherit;False;Constant;_Vector1;Vector 1;0;0;Create;True;0;0;False;0;0,1,0;0,0,0;0;4;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3
Node;AmplifyShaderEditor.RangedFloatNode;11;-1094.248,582.8789;Inherit;False;Property;_WaveHeight;Wave Height;6;0;Create;True;0;0;False;0;0.25;0.25;0;1;0;1;FLOAT;0
Node;AmplifyShaderEditor.StepOpNode;73;-1173.47,-136.4261;Inherit;False;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.LerpOp;135;-726.6461,-715.2534;Inherit;False;3;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;2;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;10;-737.6633,336.8828;Inherit;True;3;3;0;FLOAT;0;False;1;FLOAT3;0,0,0;False;2;FLOAT;0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.FunctionNode;75;-495.9668,-150.1803;Inherit;False;Lerp White To;-1;;1;047d7c189c36a62438973bad9d37b1c2;0;2;1;FLOAT3;0,0,0;False;2;FLOAT;0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.RangedFloatNode;8;-779.874,797.1697;Inherit;False;Property;_Tessellation;Tessellation;7;0;Create;True;0;0;False;0;4;16;1;16;0;1;FLOAT;0
Node;AmplifyShaderEditor.StandardSurfaceOutputNode;0;-68.90713,10.96218;Float;False;True;-1;7;ASEMaterialInspector;0;0;Unlit;CellShader/Water;False;False;False;False;False;False;False;False;False;False;False;False;False;False;True;False;False;False;False;False;False;Back;0;False;-1;0;False;-1;False;0;False;-1;0;False;-1;False;0;Custom;0.5;True;False;0;True;Transparent;;Geometry;All;14;all;True;True;True;True;0;False;-1;False;0;False;-1;255;False;-1;255;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;True;2;2;10;25;False;0.5;False;2;5;False;-1;10;False;-1;2;5;False;-1;10;False;-1;1;False;-1;0;False;-1;0;False;0;0,0,0,0;VertexOffset;True;False;Cylindrical;False;Relative;0;;0;-1;-1;-1;0;False;0;0;False;-1;-1;0;False;-1;0;0;0;False;0.1;False;-1;0;False;-1;15;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;2;FLOAT3;0,0,0;False;3;FLOAT;0;False;4;FLOAT;0;False;6;FLOAT3;0,0,0;False;7;FLOAT3;0,0,0;False;8;FLOAT;0;False;9;FLOAT;0;False;10;FLOAT;0;False;13;FLOAT3;0,0,0;False;11;FLOAT3;0,0,0;False;12;FLOAT3;0,0,0;False;14;FLOAT4;0,0,0,0;False;15;FLOAT3;0,0,0;False;0
WireConnection;187;1;185;0
WireConnection;186;0;185;0
WireConnection;7;0;5;0
WireConnection;7;1;6;0
WireConnection;196;0;4;0
WireConnection;195;0;7;0
WireConnection;191;0;190;0
WireConnection;191;1;187;0
WireConnection;188;0;190;0
WireConnection;188;1;186;0
WireConnection;169;1;188;0
WireConnection;176;1;191;0
WireConnection;170;0;169;0
WireConnection;170;2;197;0
WireConnection;170;1;198;0
WireConnection;177;0;176;0
WireConnection;177;2;197;0
WireConnection;177;1;198;0
WireConnection;204;1;190;0
WireConnection;171;0;177;0
WireConnection;203;0;204;0
WireConnection;203;2;197;0
WireConnection;203;1;198;0
WireConnection;164;0;170;0
WireConnection;215;0;164;0
WireConnection;215;1;171;0
WireConnection;202;0;203;0
WireConnection;216;0;215;0
WireConnection;216;1;202;0
WireConnection;217;0;216;0
WireConnection;217;1;216;0
WireConnection;209;0;217;0
WireConnection;210;0;209;0
WireConnection;211;0;216;0
WireConnection;211;2;210;0
WireConnection;199;0;211;0
WireConnection;61;0;77;1
WireConnection;61;1;77;2
WireConnection;138;0;205;0
WireConnection;138;1;136;0
WireConnection;228;0;61;0
WireConnection;228;1;227;0
WireConnection;139;0;138;0
WireConnection;229;0;228;0
WireConnection;69;0;57;0
WireConnection;69;1;58;4
WireConnection;64;0;61;0
WireConnection;64;1;60;0
WireConnection;224;0;69;0
WireConnection;3;0;2;0
WireConnection;3;2;196;0
WireConnection;3;1;195;0
WireConnection;72;0;69;0
WireConnection;62;0;64;0
WireConnection;230;0;229;0
WireConnection;140;0;139;0
WireConnection;140;1;194;0
WireConnection;1;0;3;0
WireConnection;218;0;140;0
WireConnection;218;1;230;0
WireConnection;218;2;224;0
WireConnection;66;0;32;0
WireConnection;66;1;67;0
WireConnection;66;2;62;0
WireConnection;78;0;76;0
WireConnection;74;0;72;0
WireConnection;200;0;1;0
WireConnection;73;0;74;0
WireConnection;73;1;78;0
WireConnection;135;0;66;0
WireConnection;135;1;134;0
WireConnection;135;2;218;0
WireConnection;10;0;200;0
WireConnection;10;1;9;0
WireConnection;10;2;11;0
WireConnection;75;1;135;0
WireConnection;75;2;73;0
WireConnection;0;2;75;0
WireConnection;0;11;10;0
WireConnection;0;14;8;0
ASEEND*/
//CHKSM=2D58DDCA9AA44BD93DB281728197A9C2A1F9B30E
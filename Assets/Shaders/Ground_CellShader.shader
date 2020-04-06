// Made with Amplify Shader Editor
// Available at the Unity Asset Store - http://u3d.as/y3X 
Shader "CellShader/Ground"
{
	Properties
	{
		_Normal("Normal", Color) = (0.5686275,1,0.427451,0)
		_Gradient("Gradient", Color) = (0.1462264,1,0.7363989,1)
		_Shadow("Shadow", Color) = (0.4039216,1,0.6627451,0)
		_ShadowStrength("ShadowStrength", Range( 0 , 1)) = 0.5
		_SandNormal("Sand Normal", Color) = (1,0.9019346,0.5801887,1)
		_SandGradient("Sand Gradient", Color) = (1,0.6608717,0.5707547,1)
		_SandShadow("Sand Shadow", Color) = (0.804,0.637513,0.4057925,1)
		_SandLevel("SandLevel", Range( 0 , 1)) = 0
		_MountainNormal("Mountain Normal", Color) = (0.6969562,0.7735849,0.7713792,1)
		_MountainGradient("Mountain Gradient", Color) = (0.5651032,0.7830189,0.7596708,1)
		_MountainShadow("Mountain Shadow", Color) = (0.3423372,0.418257,0.4622642,1)
		_MountainLevel("Mountain Level", Float) = 1.5
		_SnowNornal("Snow Nornal", Color) = (0.6969562,0.7735849,0.7713792,1)
		_SnowGradient("Snow Gradient", Color) = (0.5651032,0.7830189,0.7596708,1)
		_SnowShadow("Snow Shadow", Color) = (0.3423372,0.418257,0.4622642,1)
		[HideInInspector]_SeaLevel("Sea Level", Float) = 0
		[HideInInspector]_WaterLevel("Water Level", Float) = 0
		[HideInInspector] __dirty( "", Int ) = 1
	}

	SubShader
	{
		Tags{ "RenderType" = "Opaque"  "Queue" = "Geometry+0" "IsEmissive" = "true"  }
		Cull Back
		CGPROGRAM
		#include "UnityCG.cginc"
		#pragma target 4.6
		#pragma surface surf Unlit keepalpha 
		struct Input
		{
			float4 screenPos;
			float3 worldPos;
			float3 worldNormal;
		};

		uniform float4 _Normal;
		uniform float4 _Gradient;
		uniform float4 _Shadow;
		uniform float _ShadowStrength;
		uniform float4 _SandNormal;
		uniform float4 _SandGradient;
		uniform float4 _SandShadow;
		uniform float _WaterLevel;
		uniform float _SeaLevel;
		uniform float _SandLevel;
		uniform float4 _MountainNormal;
		uniform float4 _MountainGradient;
		uniform float4 _MountainShadow;
		uniform float4 _SnowNornal;
		uniform float4 _SnowGradient;
		uniform float4 _SnowShadow;
		uniform float _MountainLevel;

		inline half4 LightingUnlit( SurfaceOutput s, half3 lightDir, half atten )
		{
			return half4 ( 0, 0, 0, s.Alpha );
		}

		void surf( Input i , inout SurfaceOutput o )
		{
			float4 ase_screenPos = float4( i.screenPos.xyz , i.screenPos.w + 0.00000000001 );
			float4 ase_screenPosNorm = ase_screenPos / ase_screenPos.w;
			ase_screenPosNorm.z = ( UNITY_NEAR_CLIP_VALUE >= 0 ) ? ase_screenPosNorm.z : ase_screenPosNorm.z * 0.5 + 0.5;
			float clampResult159 = clamp( ( ( ( ( ase_screenPosNorm.x - 0.375 ) * 2.0 ) - ( 1.0 - ase_screenPosNorm.y ) ) * 0.625 ) , 0.0 , 1.0 );
			float4 lerpResult150 = lerp( _Normal , _Gradient , clampResult159);
			float3 ase_worldPos = i.worldPos;
			#if defined(LIGHTMAP_ON) && UNITY_VERSION < 560 //aseld
			float3 ase_worldlightDir = 0;
			#else //aseld
			float3 ase_worldlightDir = Unity_SafeNormalize( UnityWorldSpaceLightDir( ase_worldPos ) );
			#endif //aseld
			float3 ase_worldNormal = i.worldNormal;
			float dotResult6 = dot( ase_worldlightDir , ase_worldNormal );
			float clampResult9 = clamp( dotResult6 , 0.0 , 1.0 );
			float temp_output_21_0 = step( clampResult9 , _ShadowStrength );
			float4 lerpResult13 = lerp( lerpResult150 , _Shadow , temp_output_21_0);
			float clampResult145 = clamp( ( ase_screenPosNorm.x - ( ( ase_screenPosNorm.y - -0.125 ) * 0.5 ) ) , 0.0 , 1.0 );
			float4 lerpResult100 = lerp( _SandNormal , _SandGradient , clampResult145);
			float clampResult109 = clamp( ( ase_worldPos.y - _WaterLevel ) , 0.0 , 1.0 );
			float4 lerpResult136 = lerp( lerpResult100 , _SandShadow , max( temp_output_21_0 , step( clampResult109 , 0.0 ) ));
			float clampResult96 = clamp( ( ase_worldPos.y - _SeaLevel ) , 0.0 , 1.0 );
			float4 lerpResult97 = lerp( lerpResult13 , lerpResult136 , step( clampResult96 , _SandLevel ));
			float4 lerpResult176 = lerp( _MountainNormal , _MountainGradient , clampResult159);
			float4 lerpResult177 = lerp( lerpResult176 , _MountainShadow , temp_output_21_0);
			float4 lerpResult186 = lerp( _SnowNornal , _SnowGradient , clampResult159);
			float4 lerpResult187 = lerp( lerpResult186 , _SnowShadow , temp_output_21_0);
			float4 lerpResult175 = lerp( lerpResult177 , lerpResult187 , float4( 0,0,0,0 ));
			float clampResult172 = clamp( ( ase_worldPos.y - _MountainLevel ) , 0.0 , 1.0 );
			float4 lerpResult188 = lerp( lerpResult97 , lerpResult175 , ( 1.0 - step( clampResult172 , 0.0 ) ));
			o.Emission = lerpResult188.rgb;
			o.Alpha = 1;
		}

		ENDCG
	}
	Fallback "Diffuse"
	CustomEditor "ASEMaterialInspector"
}
/*ASEBEGIN
Version=17900
370;473;1715;559;1860.878;-1134.672;1;True;True
Node;AmplifyShaderEditor.ScreenPosInputsNode;152;-2965.355,-208.9185;Float;False;0;False;0;5;FLOAT4;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.RangedFloatNode;151;-2930.081,-311.0114;Inherit;False;Constant;_Float1;Float 1;8;0;Create;True;0;0;False;0;0.375;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.ScreenPosInputsNode;140;-2747.686,495.1108;Float;False;0;False;0;5;FLOAT4;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SimpleSubtractOpNode;153;-2726.115,-264.4218;Inherit;False;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;146;-2687.887,692.5754;Inherit;False;Constant;_Float0;Float 0;8;0;Create;True;0;0;False;0;-0.125;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.WorldPosInputsNode;88;-2459.857,921.5564;Inherit;False;0;4;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3
Node;AmplifyShaderEditor.SimpleSubtractOpNode;147;-2512.887,630.5754;Inherit;False;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;154;-2557.61,-242.2268;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;2;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;102;-2467.304,817.1094;Inherit;False;Property;_WaterLevel;Water Level;17;1;[HideInInspector];Create;True;0;0;False;0;0;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.OneMinusNode;156;-2726.742,-160.986;Inherit;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.WorldNormalVector;87;-2842.115,235.0249;Inherit;False;False;1;0;FLOAT3;0,0,1;False;4;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3
Node;AmplifyShaderEditor.WorldSpaceLightDirHlpNode;5;-2884.133,78.15619;Inherit;False;True;1;0;FLOAT;0;False;4;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3
Node;AmplifyShaderEditor.DotProductOpNode;6;-2562.132,183.156;Inherit;False;2;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;144;-2348.887,588.5754;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0.5;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleSubtractOpNode;155;-2397.998,-208.9924;Inherit;True;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleSubtractOpNode;105;-2148.924,805.8914;Inherit;False;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;163;-2354.598,2.053711;Inherit;False;Constant;_Float2;Float 2;9;0;Create;True;0;0;False;0;0.625;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;169;-2461.398,1252.09;Inherit;False;Property;_MountainLevel;Mountain Level;11;0;Create;True;0;0;False;0;1.5;3.54;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;164;-2149.802,-180.2992;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.ClampOpNode;109;-1946.469,805.1754;Inherit;False;3;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;1;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;15;-2529.12,304.4816;Inherit;False;Property;_ShadowStrength;ShadowStrength;3;0;Create;True;0;0;False;0;0.5;0.152;0;1;0;1;FLOAT;0
Node;AmplifyShaderEditor.ClampOpNode;9;-2392.24,179.5033;Inherit;False;3;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;1;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleSubtractOpNode;142;-2176.887,521.5754;Inherit;True;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;93;-2456.435,1073.744;Inherit;False;Property;_SeaLevel;Sea Level;16;1;[HideInInspector];Create;True;0;0;False;0;0;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.ColorNode;135;-1703.471,395.2732;Inherit;False;Property;_SandGradient;Sand Gradient;5;0;Create;True;0;0;False;0;1,0.6608717,0.5707547,1;1,0.6608717,0.5707547,1;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SimpleSubtractOpNode;92;-2125.49,981.4474;Inherit;False;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.ClampOpNode;145;-1935.971,524.7633;Inherit;False;3;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;1;False;1;FLOAT;0
Node;AmplifyShaderEditor.ColorNode;99;-1698.347,219.3272;Inherit;False;Property;_SandNormal;Sand Normal;4;0;Create;True;0;0;False;0;1,0.9019346,0.5801887,1;1,0.9019346,0.5801887,1;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.StepOpNode;110;-1757.004,804.8754;Inherit;False;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.ColorNode;14;-1955.634,-463.1247;Inherit;False;Property;_Normal;Normal;0;0;Create;True;0;0;False;0;0.5686275,1,0.427451,0;0.5686275,1,0.427451,0;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.ClampOpNode;159;-1900.912,-110.0299;Inherit;False;3;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;1;False;1;FLOAT;0
Node;AmplifyShaderEditor.StepOpNode;21;-2158.734,294.3703;Inherit;False;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.ColorNode;168;-1676.543,1084.235;Inherit;False;Property;_MountainNormal;Mountain Normal;8;0;Create;True;0;0;False;0;0.6969562,0.7735849,0.7713792,1;0.6969562,0.7735849,0.7713792,1;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.ColorNode;165;-1673.083,1251.88;Inherit;False;Property;_MountainGradient;Mountain Gradient;9;0;Create;True;0;0;False;0;0.5651032,0.7830189,0.7596708,1;0.5651032,0.7830189,0.7596708,1;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.ColorNode;149;-1954.144,-285.7794;Inherit;False;Property;_Gradient;Gradient;1;0;Create;True;0;0;False;0;0.1462264,1,0.7363989,1;0.1462264,1,0.7363989,1;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.ColorNode;180;-1760.3,2054.313;Inherit;False;Property;_SnowGradient;Snow Gradient;13;0;Create;True;0;0;False;0;0.5651032,0.7830189,0.7596708,1;0.5651032,0.7830189,0.7596708,1;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.ColorNode;185;-1763.759,1886.667;Inherit;False;Property;_SnowNornal;Snow Nornal;12;0;Create;True;0;0;False;0;0.6969562,0.7735849,0.7713792,1;1,1,1,1;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SimpleSubtractOpNode;171;-2194.272,1236.289;Inherit;False;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.LerpOp;176;-1347.995,964.3228;Inherit;False;3;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;2;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.ClampOpNode;96;-1944.969,979.8444;Inherit;False;3;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;1;False;1;FLOAT;0
Node;AmplifyShaderEditor.ColorNode;167;-1351.416,1250.202;Inherit;False;Property;_MountainShadow;Mountain Shadow;10;0;Create;True;0;0;False;0;0.3423372,0.418257,0.4622642,1;0.3423372,0.418257,0.4622642,1;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.LerpOp;100;-1364.793,476.3963;Inherit;False;3;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;2;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.ColorNode;101;-1622.485,609.6189;Inherit;False;Property;_SandShadow;Sand Shadow;6;0;Create;True;0;0;False;0;0.804,0.637513,0.4057925,1;0.804,0.637513,0.4057925,1;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.ColorNode;12;-1701.661,2.137023;Inherit;False;Property;_Shadow;Shadow;2;0;Create;True;0;0;False;0;0.4039216,1,0.6627451,0;0.4039216,1,0.6627451,0;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SimpleMaxOpNode;134;-1556.383,790.8383;Inherit;False;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.LerpOp;186;-1435.211,1766.754;Inherit;False;3;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;2;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.RangedFloatNode;94;-2102.167,1109.953;Inherit;False;Property;_SandLevel;SandLevel;7;0;Create;True;0;0;False;0;0;0.225;0;1;0;1;FLOAT;0
Node;AmplifyShaderEditor.LerpOp;150;-1274.677,-146.1331;Inherit;False;3;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;2;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.ClampOpNode;172;-1910.296,1503.784;Inherit;False;3;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;1;False;1;FLOAT;0
Node;AmplifyShaderEditor.ColorNode;183;-1444.168,2056.325;Inherit;False;Property;_SnowShadow;Snow Shadow;14;0;Create;True;0;0;False;0;0.3423372,0.418257,0.4622642,1;0.612985,0.8617717,0.8962264,1;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.StepOpNode;98;-1752.108,979.8444;Inherit;False;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.LerpOp;187;-1108.327,1768.564;Inherit;False;3;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;2;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.LerpOp;177;-1021.11,966.1328;Inherit;False;3;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;2;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.LerpOp;136;-1002.765,483.8592;Inherit;False;3;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;2;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.LerpOp;13;-1021.206,76.58572;Inherit;False;3;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;2;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.StepOpNode;173;-1679.179,1418.249;Inherit;False;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.LerpOp;97;-753.652,545.9581;Inherit;False;3;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;2;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.LerpOp;175;-669.3765,1274.602;Inherit;True;3;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;2;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.OneMinusNode;174;-1275.904,1415.157;Inherit;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;178;-1576.034,1609.171;Inherit;False;Property;_SnowLevel;Snow Level;15;0;Create;True;0;0;False;0;2.25;0;0;1;0;1;FLOAT;0
Node;AmplifyShaderEditor.OneMinusNode;190;-1277.596,1504.716;Inherit;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.LerpOp;188;-298.9673,946.7353;Inherit;False;3;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;2;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.StepOpNode;189;-1003.72,1502.892;Inherit;False;2;0;FLOAT;1;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.StandardSurfaceOutputNode;40;-57.30769,901.7614;Float;False;True;-1;6;ASEMaterialInspector;0;0;Unlit;CellShader/Ground;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;Back;0;False;-1;0;False;-1;False;0;False;-1;0;False;-1;False;0;Opaque;0.5;True;False;0;False;Opaque;;Geometry;All;14;all;True;True;True;True;0;False;-1;False;0;False;-1;255;False;-1;255;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;False;2;15;10;25;False;0.5;True;0;0;False;-1;0;False;-1;0;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;0;0,0,0,0;VertexOffset;True;False;Cylindrical;False;Relative;0;;-1;-1;-1;-1;0;False;0;0;False;-1;-1;0;False;-1;0;0;0;False;0.1;False;-1;0;False;-1;15;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;2;FLOAT3;0,0,0;False;3;FLOAT;0;False;4;FLOAT;0;False;6;FLOAT3;0,0,0;False;7;FLOAT3;0,0,0;False;8;FLOAT;0;False;9;FLOAT;0;False;10;FLOAT;0;False;13;FLOAT3;0,0,0;False;11;FLOAT3;0,0,0;False;12;FLOAT3;0,0,0;False;14;FLOAT4;0,0,0,0;False;15;FLOAT3;0,0,0;False;0
WireConnection;153;0;152;1
WireConnection;153;1;151;0
WireConnection;147;0;140;2
WireConnection;147;1;146;0
WireConnection;154;0;153;0
WireConnection;156;0;152;2
WireConnection;6;0;5;0
WireConnection;6;1;87;0
WireConnection;144;0;147;0
WireConnection;155;0;154;0
WireConnection;155;1;156;0
WireConnection;105;0;88;2
WireConnection;105;1;102;0
WireConnection;164;0;155;0
WireConnection;164;1;163;0
WireConnection;109;0;105;0
WireConnection;9;0;6;0
WireConnection;142;0;140;1
WireConnection;142;1;144;0
WireConnection;92;0;88;2
WireConnection;92;1;93;0
WireConnection;145;0;142;0
WireConnection;110;0;109;0
WireConnection;159;0;164;0
WireConnection;21;0;9;0
WireConnection;21;1;15;0
WireConnection;171;0;88;2
WireConnection;171;1;169;0
WireConnection;176;0;168;0
WireConnection;176;1;165;0
WireConnection;176;2;159;0
WireConnection;96;0;92;0
WireConnection;100;0;99;0
WireConnection;100;1;135;0
WireConnection;100;2;145;0
WireConnection;134;0;21;0
WireConnection;134;1;110;0
WireConnection;186;0;185;0
WireConnection;186;1;180;0
WireConnection;186;2;159;0
WireConnection;150;0;14;0
WireConnection;150;1;149;0
WireConnection;150;2;159;0
WireConnection;172;0;171;0
WireConnection;98;0;96;0
WireConnection;98;1;94;0
WireConnection;187;0;186;0
WireConnection;187;1;183;0
WireConnection;187;2;21;0
WireConnection;177;0;176;0
WireConnection;177;1;167;0
WireConnection;177;2;21;0
WireConnection;136;0;100;0
WireConnection;136;1;101;0
WireConnection;136;2;134;0
WireConnection;13;0;150;0
WireConnection;13;1;12;0
WireConnection;13;2;21;0
WireConnection;173;0;172;0
WireConnection;97;0;13;0
WireConnection;97;1;136;0
WireConnection;97;2;98;0
WireConnection;175;0;177;0
WireConnection;175;1;187;0
WireConnection;174;0;173;0
WireConnection;190;0;172;0
WireConnection;188;0;97;0
WireConnection;188;1;175;0
WireConnection;188;2;174;0
WireConnection;189;0;190;0
WireConnection;40;2;188;0
ASEEND*/
//CHKSM=CD4A1D68CFEDB385478ED831D9C3C5AFCBBF2AD2
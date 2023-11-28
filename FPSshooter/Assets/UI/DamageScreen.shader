Shader "Custom/CenterFadeShader"
{
    Properties
    {
        _Color("Main Color", Color) = (1, 1, 1, 1)
        _MainTex("Base (RGB)", 2D) = "white" { }
    }

        SubShader
    {
        Tags {"Queue" = "Overlay" }
        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma exclude_renderers gles xbox360 ps3
            ENDCG

            CGPROGRAM
            #pragma fragment frag
            fixed4 frag(v2f i) : COLOR
            {
            // Ekranýn ortasýndan dýþarý doðru opaklýðý artan bir gradient oluþtur
            float distance = length(i.uv - 0.5);
            float alpha = 1.0 - smoothstep(0.4, 0.5, distance);
            return _Color * alpha;
        }
        ENDCG
    }
    }
}

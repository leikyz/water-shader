﻿using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

namespace KWS
{
    internal class ShorelineFoamPass : WaterPass
    {
        ShorelineFoamPassCore _pass;

        public ShorelineFoamPass(RenderPassEvent passEvent) : base(passEvent)
        {
            _pass                   =  new ShorelineFoamPassCore();
            _pass.OnSetRenderTarget += OnSetRenderTarget;
            PassName                =  _pass.PassName;
        }

        public override void Execute(ScriptableRenderContext context, ref RenderingData renderingData)
        {
            ExecutePassCore(_pass, ref renderingData);
        }


        public override void ExecuteBeforeCameraRendering(Camera cam)
        {
            _pass.ExecuteBeforeCameraRendering(cam);
        }

        private void OnSetRenderTarget(WaterPassContext waterContext, RTHandle rt)
        {
            ConfigureTarget(rt);
            CoreUtils.SetRenderTarget(waterContext.cmd, rt, ClearFlag.Color, Color.clear);
        }


        public override void Release()
        {
            _pass.OnSetRenderTarget -= OnSetRenderTarget;
            _pass.Release();
        }
    }
}
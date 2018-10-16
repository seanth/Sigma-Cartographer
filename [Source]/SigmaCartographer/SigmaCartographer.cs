﻿using UnityEngine;
using System;


namespace SigmaCartographerPlugin
{
    [KSPAddon(KSPAddon.Startup.MainMenu, true)]
    class Cartographer : MonoBehaviour
    {
        void Start()
        {
            ConfigNode[] maps = UserSettings.ConfigNode.GetNodes("Maps");

            for (int i = 0; i < maps.Length; i++)
            {
                MapGenerator.LoadSettings(maps[i]);

                if (!MapGenerator.exportAny && !MapGenerator.exportBiomeMap) continue;

                MapGenerator.GeneratePQSMaps();
                MapGenerator.CleanUp();
            }

            ConfigNode[] pics = UserSettings.ConfigNode.GetNodes("Render");

            for (int i = 0; i < pics.Length; i++)
            {
                PlanetRenderer.LoadSettings(pics[i]);
                PlanetRenderer.GetTexture();
                PlanetRenderer.RenderPlanet();
                MapGenerator.CleanUp();
            }
        }
    }
}

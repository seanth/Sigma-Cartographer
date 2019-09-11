using UnityEngine;


namespace PsiCartographerPlugin
{
    [KSPAddon(KSPAddon.Startup.Instantly, true)]
    public class Version : MonoBehaviour
    {
        public static readonly System.Version number = new System.Version("0.4.0");

        void Awake()
        {
            UnityEngine.Debug.Log("[PsiLog] Version Check:   Psi Cartographer v" + number);
        }
    }
}

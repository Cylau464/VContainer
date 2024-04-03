using UnityEditor;
using UnityEngine;

namespace VContainer.Editor
{
    public static class VContainerTemplateSwitcher
    {
        private const string VCONTAINER_TEMPLATE_ENABLE_DEFINE_NAME = "VCONTAINER_SCRIPT_TEMPLATE_ENABLE";
        private const string MENU_TITLE = "Tools/VContainer/";
        private const string ENABLE_PATH = MENU_TITLE + "Enable Template";
        private const string DISABLE_PATH = MENU_TITLE + "Disable Template";

        [MenuItem(ENABLE_PATH)]
        private static void EnableTemplateDefine()
        {
            string defines = GetDefines();

            defines += $";{VCONTAINER_TEMPLATE_ENABLE_DEFINE_NAME}";
            BuildTargetGroup buildTargetGroup = GetBiuldTargetGroup();
            PlayerSettings.SetScriptingDefineSymbolsForGroup(buildTargetGroup, defines);
        }

        [MenuItem(DISABLE_PATH)]
        private static void DisableTemplateDefine()
        {
            string defines = GetDefines();
            defines = defines.Replace($";{VCONTAINER_TEMPLATE_ENABLE_DEFINE_NAME}", "");
            BuildTargetGroup buildTargetGroup = GetBiuldTargetGroup();
            PlayerSettings.SetScriptingDefineSymbolsForGroup(buildTargetGroup, defines);
        }

        [MenuItem(ENABLE_PATH, true)]
        private static bool IsDefineEnabled()
        {
            string defines = GetDefines();

            return !defines.Contains(VCONTAINER_TEMPLATE_ENABLE_DEFINE_NAME);
        }

        [MenuItem(DISABLE_PATH, true)]
        private static bool IsDefineDisabled()
        {
            string defines = GetDefines();

            return defines.Contains(VCONTAINER_TEMPLATE_ENABLE_DEFINE_NAME);
        }

        private static string GetDefines()
        {
            BuildTargetGroup buildTargetGroup = GetBiuldTargetGroup();

            return PlayerSettings.GetScriptingDefineSymbolsForGroup(buildTargetGroup);
        }

        private static BuildTargetGroup GetBiuldTargetGroup()
        {
            return EditorUserBuildSettings.selectedBuildTargetGroup;
        }
    }
}

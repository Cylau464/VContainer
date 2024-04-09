using UnityEditor;
using UnityEngine;

namespace VContainer.Editor
{
    public static class VContainerTemplateSwitcher
    {
        private const string VCONTAINER_TEMPLATE_ENABLE_DEFINE_NAME = "VCONTAINER_SCRIPT_TEMPLATE_ENABLE";
        private const string MENU_TITLE = "Tools/VContainer/LifetimeScope Template";

        [MenuItem(MENU_TITLE)]
        private static void SwitchTemplateDefine()
        {
            string defines = GetDefines();

            if(defines.Contains(VCONTAINER_TEMPLATE_ENABLE_DEFINE_NAME))
                defines = defines.Replace($";{VCONTAINER_TEMPLATE_ENABLE_DEFINE_NAME}", "");
            else
                defines += $";{VCONTAINER_TEMPLATE_ENABLE_DEFINE_NAME}";
            
            BuildTargetGroup buildTargetGroup = GetBiuldTargetGroup();
            PlayerSettings.SetScriptingDefineSymbolsForGroup(buildTargetGroup, defines);
        }

        [MenuItem(MENU_TITLE, true)]
        private static bool SwitchTemplateValidate()
        {
            string defines = GetDefines();
            Menu.SetChecked(MENU_TITLE, defines.Contains(VCONTAINER_TEMPLATE_ENABLE_DEFINE_NAME));

            return true;
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

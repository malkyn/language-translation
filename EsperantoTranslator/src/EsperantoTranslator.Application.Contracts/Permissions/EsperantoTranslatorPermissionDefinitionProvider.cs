using EsperantoTranslator.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace EsperantoTranslator.Permissions;

public class EsperantoTranslatorPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(EsperantoTranslatorPermissions.GroupName);
        //Define your own permissions here. Example:
        //myGroup.AddPermission(EsperantoTranslatorPermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<EsperantoTranslatorResource>(name);
    }
}

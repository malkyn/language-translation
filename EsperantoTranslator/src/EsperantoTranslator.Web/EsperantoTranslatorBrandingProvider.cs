using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace EsperantoTranslator.Web;

[Dependency(ReplaceServices = true)]
public class EsperantoTranslatorBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "EsperantoTranslator";
}

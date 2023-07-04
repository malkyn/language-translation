using Volo.Abp.Modularity;

namespace EsperantoTranslator;

[DependsOn(
    typeof(EsperantoTranslatorApplicationModule),
    typeof(EsperantoTranslatorDomainTestModule)
    )]
public class EsperantoTranslatorApplicationTestModule : AbpModule
{

}

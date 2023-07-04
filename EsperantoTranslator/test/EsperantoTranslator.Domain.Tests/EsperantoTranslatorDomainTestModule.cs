using EsperantoTranslator.MongoDB;
using Volo.Abp.Modularity;

namespace EsperantoTranslator;

[DependsOn(
    typeof(EsperantoTranslatorMongoDbTestModule)
    )]
public class EsperantoTranslatorDomainTestModule : AbpModule
{

}

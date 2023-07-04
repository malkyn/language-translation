using EsperantoTranslator.MongoDB;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace EsperantoTranslator.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(EsperantoTranslatorMongoDbModule),
    typeof(EsperantoTranslatorApplicationContractsModule)
    )]
public class EsperantoTranslatorDbMigratorModule : AbpModule
{

}

using System;
using Volo.Abp.Data;
using Volo.Abp.Modularity;

namespace EsperantoTranslator.MongoDB;

[DependsOn(
    typeof(EsperantoTranslatorTestBaseModule),
    typeof(EsperantoTranslatorMongoDbModule)
    )]
public class EsperantoTranslatorMongoDbTestModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        var stringArray = EsperantoTranslatorMongoDbFixture.ConnectionString.Split('?');
        var connectionString = stringArray[0].EnsureEndsWith('/') +
                                   "Db_" +
                               Guid.NewGuid().ToString("N") + "/?" + stringArray[1];

        Configure<AbpDbConnectionOptions>(options =>
        {
            options.ConnectionStrings.Default = connectionString;
        });
    }
}

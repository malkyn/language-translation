using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace EsperantoTranslator.Data;

/* This is used if database provider does't define
 * IEsperantoTranslatorDbSchemaMigrator implementation.
 */
public class NullEsperantoTranslatorDbSchemaMigrator : IEsperantoTranslatorDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}

using System.Threading.Tasks;

namespace EsperantoTranslator.Data;

public interface IEsperantoTranslatorDbSchemaMigrator
{
    Task MigrateAsync();
}

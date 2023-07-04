using EsperantoTranslator.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace EsperantoTranslator.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class EsperantoTranslatorController : AbpControllerBase
{
    protected EsperantoTranslatorController()
    {
        LocalizationResource = typeof(EsperantoTranslatorResource);
    }
}

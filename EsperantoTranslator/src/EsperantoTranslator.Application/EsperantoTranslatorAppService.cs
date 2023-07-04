using System;
using System.Collections.Generic;
using System.Text;
using EsperantoTranslator.Localization;
using Volo.Abp.Application.Services;

namespace EsperantoTranslator;

/* Inherit your application services from this class.
 */
public abstract class EsperantoTranslatorAppService : ApplicationService
{
    protected EsperantoTranslatorAppService()
    {
        LocalizationResource = typeof(EsperantoTranslatorResource);
    }
}

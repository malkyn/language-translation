using EsperantoTranslator.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace EsperantoTranslator.Web.Pages;

/* Inherit your PageModel classes from this class.
 */
public abstract class EsperantoTranslatorPageModel : AbpPageModel
{
    protected EsperantoTranslatorPageModel()
    {
        LocalizationResourceType = typeof(EsperantoTranslatorResource);
    }
}

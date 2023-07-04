using System.Threading.Tasks;
using Shouldly;
using Xunit;

namespace EsperantoTranslator.Pages;

[Collection(EsperantoTranslatorTestConsts.CollectionDefinitionName)]
public class Index_Tests : EsperantoTranslatorWebTestBase
{
    [Fact]
    public async Task Welcome_Page()
    {
        var response = await GetResponseAsStringAsync("/");
        response.ShouldNotBeNull();
    }
}

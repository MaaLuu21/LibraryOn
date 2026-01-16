using LibraryOn.Application.Services;
using Microsoft.AspNetCore.Localization;
using System.Globalization;

namespace LibraryOn.Api.Services;

public class HttpRegionProvider : IRegionProvider
{
    private readonly IHttpContextAccessor _httpContextAccessor;
 
    public HttpRegionProvider(IHttpContextAccessor httpContextAccessor) 
    { 
        _httpContextAccessor = httpContextAccessor; 
    }
    public string GetRegionCode() 
    {
        var effectiveCulture = CultureInfo.CurrentCulture; 
        return new RegionInfo(effectiveCulture.LCID).TwoLetterISORegionName;
    }
}

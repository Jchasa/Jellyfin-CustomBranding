using System;
using System.IO;
using System.Threading.Tasks;
using MediaBrowser.Common.Configuration;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CustomBranding
{
    [Route("logo")]
    public class WebController : ControllerBase
    {
        private readonly IApplicationPaths _appPaths;

        public WebController(IApplicationPaths appPaths)
        {
            _appPaths = appPaths;
        }

        [HttpPost("upload")]
        public async Task<IActionResult> UploadLogo()
        {
            var logo = Request.Form.Files["Logo"];
            var bannerDark = Request.Form.Files["BannerDark"];
            var bannerLight = Request.Form.Files["BannerLight"];

            try
                {
                    if (logo != null && logo.Length > 0) {
                        if (System.IO.File.Exists(_appPaths.WebPath + "assets/img/icon-transparent.png")) {
                            var path = Path.Combine(_appPaths.WebPath, "assets/img/icon-transparent.png");

                            using (var stream = new FileStream(path, FileMode.Create)) {
                                await logo.CopyToAsync(stream);
                            }

                            string[] files = Directory.GetFiles(_appPaths.WebPath, "icon-transparent*", SearchOption.AllDirectories);

                            foreach (string file in files)
                            {
                                using (var stream = new FileStream(file, FileMode.Create))
                                    {
                                        await logo.CopyToAsync(stream);
                                    }
                            }
                        }
                    }

                    if (bannerDark != null && bannerDark.Length > 0) {
                        if (System.IO.File.Exists(_appPaths.WebPath + "assets/img/banner-dark.png")) {
                            var path = Path.Combine(_appPaths.WebPath, "assets/img/banner-dark.png");
                            using (var stream = new FileStream(path, FileMode.Create)) {
                                await logo.CopyToAsync(stream);
                            }
                        }

                        string[] files = Directory.GetFiles(_appPaths.WebPath, "banner-dark*", SearchOption.AllDirectories);

                        foreach (string file in files)
                        {
                            using (var stream = new FileStream(file, FileMode.Create))
                                {
                                    await bannerDark.CopyToAsync(stream);
                                }
                        }
                    }

                    if (bannerLight != null && bannerLight.Length > 0) {
                        if (System.IO.File.Exists(_appPaths.WebPath + "assets/img/banner-light.png")) {
                            var path = Path.Combine(_appPaths.WebPath, "assets/img/banner-light.png");
                            using (var stream = new FileStream(path, FileMode.Create)) {
                                await logo.CopyToAsync(stream);
                            }
                        }

                        string[] files = Directory.GetFiles(_appPaths.WebPath, "banner-light*", SearchOption.AllDirectories);

                        foreach (string file in files)
                        {
                            using (var stream = new FileStream(file, FileMode.Create))
                                {
                                    await bannerLight.CopyToAsync(stream);
                                }
                        }
                    }
                }
            catch (UnauthorizedAccessException)
                {
                    return Content(
                        "<html><head></head><body>Jellyfin does not have write access. Please check the permissions and ensure the application has sufficient rights.<br><a href='/web/#/dashboard/plugins'>Retun to Jellyfin</a></body></html>",
                        "text/html");
                }

            return Content(
                "<html><head><meta http-equiv='refresh' content='0;url=/web/#/dashboard/plugins' /></head><body>Redirection...</body></html>",
                "text/html");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PuppeteerSharp;

namespace engine
{
    public class jeju
    {

        private string id { get; set; }
        private string pw { get; set; }

        public jeju(string id, string pw)
        {

            this.id = id;
            this.pw = pw;
            accessSite();

        }

        public async void accessSite(){
            BrowserFetcherOptions bo = new BrowserFetcherOptions();
            var browserFetcher = Puppeteer.CreateBrowserFetcher(bo);
            var revisionInfo = browserFetcher.RevisionInfo(BrowserFetcher.DefaultRevision);
            if (browserFetcher.LocalRevisions().Count() == 0)
            {
                revisionInfo = await browserFetcher.DownloadAsync(BrowserFetcher.DefaultRevision);
            }
        
            var browser = await Puppeteer.LaunchAsync(new LaunchOptions
            {
                ExecutablePath = revisionInfo.ExecutablePath,
                Headless = false
            });
            var page = await browser.NewPageAsync();//gnb_login_button0
            await page.GoToAsync("https://www.jejuair.net/jejuair/kr/main.do");
            await page.WaitForSelectorAsync("button.gnb_login_button0");
            await page.ClickAsync("button.gnb_login_button0");
        }
    }
}

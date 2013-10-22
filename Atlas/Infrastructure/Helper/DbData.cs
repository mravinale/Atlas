namespace Atlas.Infrastructure.Helper
{
    public class InitData
    { 
        public static string CommonContent
        {
            get
            {
                return "<p >Suspendisse potenti. Donec egestas metus quis mauris ullamcorper eu consequat enim vulputate. Duis dictum ornare ante at accumsan. Mauris ornare sodales pretium.</p>" +
                    "<p><a class='btn' href='/Blog'>Model details &raquo;</a></p> ";
            }
        }

        public static string PostContent
        {
            get
            {
                return "<p>Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur .</p></br>" +
                    "<p>Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur .</p>";
            }
        }

        public static string FeaturetteContent
        {
            get
            {
                return "<img class='featurette-image pull-left' src='http://getbootstrap.com/2.3.2/assets/img/examples/browser-icon-firefox.png'>" +
                    "<h2 class='featurette-heading'>Vestibulum id ligula porta felis. <span class='muted'>porta felis euismod.</span></h2>" +
                    "<p class='lead'>Donec ullamcorper nulla non metus auctor fringilla. Vestibulum id ligula porta felis euismod semper. Praesent commodo cursus magna, vel scelerisque nisl consectetur. Fusce dapibus, tellus ac cursus commodo.</p>";
            }
        }
    }     
     
}
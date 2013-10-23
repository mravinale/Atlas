namespace Atlas.Infrastructure.Helper
{
    public class InitData
    { 
        
        public static string PostContent
        {
            get
            {
                return "<p>Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur .</p></br>" +
                    "<p>Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur .</p>";
            }
        }

        public static string GetMarketingContent(string urlImage)
        {
            return "<img class='img-circle' ng-src='" + urlImage + "'>" +
                      "<h2>Heading</h2>" +
                      "<p>Donec sed odio dui. Etiam porta sem malesuada magna mollis euismod. Nullam id dolor id nibh ultricies vehicula ut id elit. Morbi leo risus, porta ac consectetur ac, vestibulum at eros. Praesent commodo cursus magna, vel scelerisque nisl consectetur et.</p>" +
                      "<p><a class='btn' href='#'>View details &raquo;</a></p>";
        }

        public static string GetFeaturetteContent(string urlImage, string cssClass)
        {
            return "<img class='featurette-image " + cssClass + "' src='" + urlImage + "'>" +
                   "<h2 class='featurette-heading'>Vestibulum id ligula porta felis. <span class='muted'>porta felis euismod.</span></h2>" +
                   "<p class='lead'>Donec ullamcorper nulla non metus auctor fringilla. Vestibulum id ligula porta felis euismod semper. Praesent commodo cursus magna, vel scelerisque nisl consectetur. Fusce dapibus, tellus ac cursus commodo.</p>";
        }
    }     
     
}
// --------------------------------------------------------------------------------
/*  Copyright © 2020, Yasgar Technology Group, Inc.

    Purpose: View Model for passing error information

    Description: 

*/
// --------------------------------------------------------------------------------



namespace YTG.MVC.Lookups.Models
{
    public class ErrorViewModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}

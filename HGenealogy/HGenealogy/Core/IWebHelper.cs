using System.Web;

namespace HGenealogy.Core
{
    /// <summary>
    /// Represents a common helper
    /// </summary>
    public partial interface IWebHelper
    {
        /// <summary>
        /// Maps a virtual path to a physical disk path.
        /// </summary>
        /// <param name="path">The path to map. E.g. "~/bin"</param>
        /// <returns>The physical path. E.g. "c:\inetpub\wwwroot\bin"</returns>
        string MapPath(string path);

    }
}

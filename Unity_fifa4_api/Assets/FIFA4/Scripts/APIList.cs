using System.IO;

/// <summary>
/// <see href="https://developers.nexon.com/fifaonline4/apiList"/>
/// </summary>
public static class APIList
{
    private static readonly string rootUrl = "https://api.nexon.co.kr";
    private static readonly string staticUrl = "https://static.api.nexon.co.kr";

    #region User information

    /// <summary>
    /// <see href="https://developers.nexon.com/fifaonline4/api/6/15"/>
    /// <para>
    /// Inquire the user's unique identifier with the user's nickname.
    ///     <br>
    ///     User-specific identifiers are used when inquiring user information in other APIs.
    ///     </br>
    /// </para>
    /// </summary>
    /// <param name="nickname"></param>
    /// <returns>https://api.nexon.co.kr/fifaonline4/v1.0/users?nickname={nickname}</returns>
    public static string GetUserInformationFromNickname(string nickname)
    {
        string url = Path.Combine(rootUrl, "fifaonline4/v1.0/users?nickname={0}");

        return string.Format(url, nickname);
    }

    /// <summary>
    /// <see href="https://developers.nexon.com/fifaonline4/api/6/16"/>
    /// <para>Inquire the user's information with a user-specific identifier {accessid}.</para>
    /// </summary>
    /// <param name="accessid"></param>
    /// <returns>https://api.nexon.co.kr/fifaonline4/v1.0/users/{accessid}</returns>
    public static string GetUserInformationFromAccessid(string accessid)
    {
        string url = Path.Combine(rootUrl, "fifaonline4/v1.0/users/{0}");

        return string.Format(url, accessid);
    }

    #endregion

    #region Match information

    #endregion

    #region Ranker information

    #endregion

    #region Meta information

    #endregion
}

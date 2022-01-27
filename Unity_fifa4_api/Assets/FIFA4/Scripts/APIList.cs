using System.IO;
using UnityEngine;

namespace FIFA4
{
    /// <summary>
    /// <see href="https://developers.nexon.com/fifaonline4/apiList"/>
    /// </summary>
    public static class APIList
    {
        private static readonly string rootUrl = "https://api.nexon.co.kr/";
        private static readonly string staticUrl = "https://static.api.nexon.co.kr/";
        private static readonly string resourcesUrl = "https://fo4.dn.nexoncdn.co.kr/";

        #region User information

        /// <summary>
        /// <see href="https://developers.nexon.com/fifaonline4/api/6/15"/>
        /// <para>Inquire the user's unique identifier with the user's nickname.
        /// <br>User-specific identifiers are used when inquiring user information in other APIs.</br></para>
        /// </summary>
        /// <param name="nickname"></param>
        /// <returns></returns>
        public static string GetUserInformationFromNickname(string nickname)
        {
            string url = Path.Combine(rootUrl, "fifaonline4/v1.0/users?nickname={0}");

            Debug.Log(url);

            return string.Format(url, nickname);
        }

        /// <summary>
        /// <see href="https://developers.nexon.com/fifaonline4/api/6/16"/>
        /// <para>Inquire the user's information with a user-specific identifier {accessid}.</para>
        /// </summary>
        /// <param name="accessid"></param>
        /// <returns></returns>
        public static string GetUserInformationFromAccessid(string accessid)
        {
            string url = Path.Combine(rootUrl, "fifaonline4/v1.0/users/{0}");

            return string.Format(url, accessid);
        }

        /// <summary>
        /// <see href="https://developers.nexon.com/fifaonline4/api/6/17"/>
        /// <para>User-specific identifier {accessid} checks the highest grade and achievement date ever for each user.</para>
        /// </summary>
        /// <param name="accessid"></param>
        /// <returns></returns>
        public static string GetHighestGradeEverFromAccessid(string accessid)
        {
            string url = Path.Combine(rootUrl, "fifaonline4/v1.0/users/{0}/maxdivision");

            return string.Format(url, accessid);
        }

        /// <summary>
        /// <see href="https://developers.nexon.com/fifaonline4/api/6/18"/>
        /// <para>Inquire the user's history by match type with user-specific identifier {accessid} and {match type}.</para>
        /// <br>A list of match-specific identifiers for the match played by the user is returned.</br>
        /// <br>The returned match information is in descending order from the most recent match played.</br>
        /// <br>Pagination is possible using {offset} and {limit}.</br>
        /// </summary>
        /// <param name="accessid"></param>
        /// <param name="matchType"></param>
        /// <param name="offset"></param>
        /// <param name="limit"></param>
        /// <returns>https://api.nexon.co.kr/fifaonline4/v1.0/users/{accessid}/matches?matchtype={matchtype}&offset={offset}&limit={limit}</returns>
        public static string GetMatchRecordFromAccessid(string accessid, int matchType, int offset = 0, int limit = 100)
        {
            string url = Path.Combine(rootUrl, "fifaonline4/v1.0/users/{0}/matches?matchtype={1}&offset={2}&limit={3}");

            return string.Format(url, accessid, matchType, offset, Mathf.Clamp(limit, 1, 100));
        }

        /// <summary>
        /// <see href="https://developers.nexon.com/fifaonline4/api/6/19"/>
        /// <para>The ID, grade, and value of the player traded by the user will be returned.
        /// <br>The returned match information is in descending order from the most recent transaction history.</br>
        /// <br>Pagination is possible using {offset} and {limit}.</br></para>
        /// </summary>
        /// <param name="accessid"></param>
        /// <param name="offset"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        public static string GetPurchaseRecordsFromAccessid(string accessid, int offset = 0, int limit = 100)
        {
            string url = Path.Combine(rootUrl, "fifaonline4/v1.0/users/{0}/markets?tradetype={1}&offset={2}&limit={3}");

            return string.Format(url, accessid, "buy", offset, Mathf.Clamp(limit, 1, 100));
        }

        /// <summary>
        /// <see href="https://developers.nexon.com/fifaonline4/api/6/19"/>
        /// <para>The ID, grade, and value of the player traded by the user will be returned.
        /// <br>The returned match information is in descending order from the most recent transaction history.</br>
        /// <br>Pagination is possible using {offset} and {limit}.</br></para>
        /// </summary>
        /// <param name="accessid"></param>
        /// <param name="offset"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        public static string GetSalesRecordFromAccessid(string accessid, int offset = 0, int limit = 100)
        {
            string url = Path.Combine(rootUrl, "fifaonline4/v1.0/users/{0}/markets?tradetype={1}&offset={2}&limit={3}");

            return string.Format(url, accessid, "sell", offset, Mathf.Clamp(limit, 1, 100));
        }

        #endregion

        #region Match information

        /// <summary>
        /// <see href="https://developers.nexon.com/fifaonline4/api/7/20"/>
        /// <para>Inquire the history of all matches by type with match type {matchtype}.</para>
        /// <br>A list of match-specific identifiers for all matches is returned.</br>
        /// <br>The returned match information is in descending order from the most recent match played.</br>
        /// <br>Pagination is possible using {offset} and {limit}.</br>
        /// </summary>
        /// <param name="matchType"></param>
        /// <param name="offset"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        public static string GetAllMatchRecords_Asc(int matchType, int offset = 0, int limit = 100)
        {
            string url = Path.Combine(rootUrl, "fifaonline4/v1.0/matches?matchtype={0}&offset={1}&limit={2}&orderby={3}");

            return string.Format(url, matchType, offset, limit, "asc");
        }

        /// <summary>
        /// <see href="https://developers.nexon.com/fifaonline4/api/7/20"/>
        /// <para>Inquire the history of all matches by type with match type {matchtype}.</para>
        /// <br>A list of match-specific identifiers for all matches is returned.</br>
        /// <br>The returned match information is in descending order from the most recent match played.</br>
        /// <br>Pagination is possible using {offset} and {limit}.</br>
        /// </summary>
        /// <param name="matchType"></param>
        /// <param name="offset"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        public static string GetAllMatchRecords_Desc(int matchType, int offset = 0, int limit = 100)
        {
            string url = Path.Combine(rootUrl, "fifaonline4/v1.0/matches?matchtype={0}&offset={1}&limit={2}&orderby={3}");

            return string.Format(url, matchType, offset, limit, "desc");
        }

        #endregion

        #region Ranker information



        #endregion

        #region Meta information

        /// <summary>
        /// <see href="https://developers.nexon.com/fifaonline4/api/10/23"/>
        /// <para>Inquire the match type metadata.</para>
        /// </summary>
        /// <returns></returns>
        public static string GetMatchType()
        {
            string url = Path.Combine(staticUrl, "fifaonline4/latest/matchtype.json");

            return url;
        }

        /// <summary>
        /// <see href="https://developers.nexon.com/fifaonline4/api/10/24"/>
        /// <para>Inquire the athlete's unique identifier (spid) metadata.</para>
        /// </summary>
        /// <returns></returns>
        public static string GetSpid()
        {
            string url = Path.Combine(staticUrl, "fifaonline4/latest/spid.json");

            return url;
        }

        /// <summary>
        /// <see href="https://developers.nexon.com/fifaonline4/api/10/25"/>
        /// <para>Inquire season ID metadata.
        /// <br>Season ID indicates the class to which the player belongs.</br></para>
        /// </summary>
        /// <returns></returns>
        public static string GetSeasonId()
        {
            string url = Path.Combine(staticUrl, "fifaonline4/latest/seasonid.json");

            return url;
        }

        /// <summary>
        /// <see href="https://developers.nexon.com/fifaonline4/api/10/26"/>
        /// <para>Inquire the player position metadata.</para>
        /// </summary>
        /// <returns></returns>
        public static string GetSpposition()
        {
            string url = Path.Combine(staticUrl, "fifaonline4/latest/spposition.json");

            return url;
        }

        /// <summary>
        /// <see href="https://developers.nexon.com/fifaonline4/api/10/27"/>
        /// <para>Inquire grade identifier metadata.</para>
        /// </summary>
        /// <returns></returns>
        public static string GetDivision()
        {
            string url = Path.Combine(staticUrl, "fifaonline4/latest/division.json");

            return url;
        }

        /// <summary>
        /// <see href="https://developers.nexon.com/fifaonline4/api/10/41"/>
        /// <para>Inquire the rating identifier metadata of the official Volta game.</para>
        /// </summary>
        /// <returns></returns>
        public static string GetDivision_Volta()
        {
            string url = Path.Combine(staticUrl, "fifaonline4/latest/division_volta.json");

            return url;
        }

        /// <summary>
        /// <see href="https://developers.nexon.com/fifaonline4/api/10/28"/>
        /// <para>Get the player's action shot image with the player's unique identifier (spid).</para>
        /// <para>* Certain players may not have images.</para>
        /// </summary>
        /// <param name="spid"></param>
        /// <returns>https://fo4.dn.nexoncdn.co.kr/live/externalAssets/common/playersAction/p{spid}.png</returns>
        public static string GetPlayerActionImageFromSpid(int spid)
        {
            string url = Path.Combine(resourcesUrl, "live/externalAssets/common/playersAction/p{0}.png");

            return string.Format(url, spid);
        }

        /// <summary>
        /// <see href="https://developers.nexon.com/fifaonline4/api/10/29"/>
        /// <para>Get the action shot image of the player with (pid).</para>
        /// <para>* Certain players may not have images.</para>
        /// </summary>
        /// <param name="pid"></param>
        /// <returns>https://fo4.dn.nexoncdn.co.kr/live/externalAssets/common/playersAction/p{pid}.png</returns>
        public static string GetPlayerActionImageFromPid(int pid)
        {
            string url = Path.Combine(resourcesUrl, "live/externalAssets/common/playersAction/p{0}.png");

            return string.Format(url, pid);
        }

        /// <summary>
        /// <see href="https://developers.nexon.com/fifaonline4/api/10/30"/>
        /// <para>Get the player's image with the player's unique identifier (spid).</para>
        /// <para>* Certain players may not have images.</para>
        /// </summary>
        /// <param name="spid"></param>
        /// <returns>https://fo4.dn.nexoncdn.co.kr/live/externalAssets/common/players/p{spid}.png</returns>
        public static string GetPlayerImageFromSpid(int spid)
        {
            string url = Path.Combine(resourcesUrl, "live/externalAssets/common/players/p{0}.png)");

            return string.Format(url, spid);
        }

        /// <summary>
        /// <see href="https://developers.nexon.com/fifaonline4/api/10/31"/>
        /// <para>Get the player's image with (pid).</para>
        /// <para>* Certain players may not have images.</para>
        /// </summary>
        /// <param name="pid"></param>
        /// <returns>https://fo4.dn.nexoncdn.co.kr/live/externalAssets/common/players/p{pid}.png</returns>
        public static string GetPlayerImageFromPid(int pid)
        {
            string url = Path.Combine(resourcesUrl, "live/externalAssets/common/players/p{0}.png");

            return string.Format(url, pid);
        }

        #endregion
    }
}

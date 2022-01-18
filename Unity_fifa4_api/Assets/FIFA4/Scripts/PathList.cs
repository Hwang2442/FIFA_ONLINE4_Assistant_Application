using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FIFA4
{
    public static class PathList
    {
        #region Directories
        public static string MetaDataPath
        {
            get { return Path.Combine(Application.persistentDataPath, "MetaInformations"); }
        }

        public static string ActionImagePath
        {
            get { return Path.Combine(Application.persistentDataPath, "PlayersAction"); }
        }
        public static string ImagePath
        {
            get { return Path.Combine(Application.persistentDataPath, "players"); }
        }
        #endregion

        #region Meta datas
        public static string DivisionPath
        {
            get { return Path.Combine(MetaDataPath, "division.json"); }
        }
        public static string Division_VoltaPath
        {
            get { return Path.Combine(MetaDataPath, "division_volta.json"); }
        }
        public static string MatchTypePath
        {
            get { return Path.Combine(MetaDataPath, "matchtype.json"); }
        }
        public static string SeasonidPath
        {
            get { return Path.Combine(MetaDataPath, "seasonid.json"); }
        }
        public static string SpidPath
        {
            get { return Path.Combine(MetaDataPath, "spid.json"); }
        }
        public static string SpposionPath
        {
            get { return Path.Combine(MetaDataPath, "spposition.json"); }
        }

        #endregion

        #region Images

        public static string GetPlayersActionImagePath(int spid)
        {
            return Path.Combine(ActionImagePath, string.Format("p{0}.png", spid));
        }
        public static string GetPlayerImagePath(int spid)
        {
            return Path.Combine(ImagePath, string.Format("p{0}.png", spid));
        }

        #endregion
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

namespace FIFA4
{
    #region User information

    [Serializable]
    public class UserInformation
    {
        [JsonProperty("accessId")] public readonly string accessId;
        [JsonProperty("nickname")] public readonly string nickname;

        [JsonProperty("level")] public readonly int level;

        [JsonConstructor]
        public UserInformation([JsonProperty("accessId")] string accessId, [JsonProperty("nickname")] string nickname, [JsonProperty("level")] int level)
        {
            this.accessId = accessId;
            this.nickname = nickname;

            this.level = level;
        }
    }

    [Serializable]
    public class HighestGradeEver
    {
        [JsonProperty("matchType")] public readonly int matchType;
        [JsonProperty("division")] public readonly int division;

        [JsonProperty("achievementDate")] public readonly DateTime achievementDate;

        [JsonConstructor]
        public HighestGradeEver([JsonProperty("matchType")] int matchType, [JsonProperty("division")] int division, [JsonProperty("achievementDate")] string achievementDate)
        {
            this.matchType = matchType;
            this.division = division;

            this.achievementDate = DateTime.Parse(achievementDate);
        }
    }

    [Serializable]
    public class TransactionRecords
    {
        [JsonProperty("tradeDate")] public readonly DateTime tradeDate;

        [JsonProperty("saleSn")] public readonly string saleSn;
        [JsonProperty("spid")] public readonly int spid;

        [JsonProperty("grade")] public readonly int grade;
        [JsonProperty("value")] public readonly ulong money;

        [JsonConstructor]
        public TransactionRecords([JsonProperty("tradeDate")] string tradeDate, [JsonProperty("saleSn")] string saleSn, [JsonProperty("spid")] int spid, [JsonProperty("grade")] int grade, [JsonProperty("value")] ulong money)
        {
            this.tradeDate = DateTime.Parse(tradeDate);

            this.saleSn = saleSn;
            this.spid = spid;

            this.grade = grade;
            this.money = money;
        }
    }


    #endregion

    #region Match information

    [Serializable]
    public class MatchDTO
    {
        [Serializable]
        public class MatchInfoDTO
        {
            [Serializable]
            public class MatchDetailDTO
            {
                [JsonProperty("seasonId")] public readonly int seasonId;

                [JsonProperty("matchResult")] public readonly string matchResult;
                [JsonProperty("matchEndType")] public readonly int matchEndType;

                [JsonProperty("systemPause")] public readonly int systemPause;

                [JsonProperty("foul")] public readonly int foul;
                [JsonProperty("injury")] public readonly int injury;
                [JsonProperty("redCards")] public readonly int redCards;
                [JsonProperty("yellowCards")] public readonly int yellowCards;
                [JsonProperty("dribble")] public readonly int dribble;
                [JsonProperty("cornerKick")] public readonly int cornerKick;
                [JsonProperty("possession")] public readonly int possession;
                [JsonProperty("OffsideCount")] public readonly int OffsideCount;
                
                [JsonProperty("averageRating")] public readonly int averageRating;
                
                [JsonProperty("controller")] public readonly string controller;

                [JsonConstructor]
                public MatchDetailDTO([JsonProperty("seasonId")] int seasonId,
                    [JsonProperty("matchResult")] string matchResult, [JsonProperty("matchEndType")] int matchEndType,
                    [JsonProperty("systemPause")] int systemPause,
                    [JsonProperty("foul")] int foul, [JsonProperty("injury")] int injury, [JsonProperty("redCards")] int redCards, [JsonProperty("yellowCards")] int yellowCards, [JsonProperty("dribble")] int dribble, [JsonProperty("cornerKick")] int cornerKick, [JsonProperty("possession")] int possession, [JsonProperty("OffsideCount")] int OffsideCount,
                    [JsonProperty("averageRating")] int averageRating,
                    [JsonProperty("controller")] string controller)
                {
                    this.seasonId = seasonId;

                    this.matchResult = matchResult;
                    this.matchEndType = matchEndType;

                    this.systemPause = systemPause;

                    this.foul = foul;
                    this.injury = injury;
                    this.redCards = redCards;
                    this.yellowCards = yellowCards;
                    this.dribble = dribble;
                    this.cornerKick = cornerKick;
                    this.possession = possession;
                    this.OffsideCount = OffsideCount;

                    this.averageRating = averageRating;

                    this.controller = controller;
                }
            }

            [Serializable]
            public class ShootDTO
            {
                [JsonProperty("shootTotal")] public readonly int shootTotal;
                [JsonProperty("effectiveShootTotal")] public readonly int effectiveShootTotal;
                [JsonProperty("shootOutScore")] public readonly int shootOutScore;

                [JsonProperty("goalTotal")] public readonly int goalTotal;
                [JsonProperty("goalTotalDisplay")] public readonly int goalTotalDisplay;

                [JsonProperty("ownGoal")] public readonly int ownGoal;

                [JsonProperty("shootHeading")] public readonly int shootHeading;
                [JsonProperty("goalHeading")] public readonly int goalHeading;

                [JsonProperty("shootFreekick")] public readonly int shootFreekick;
                [JsonProperty("goalFreekick")] public readonly int goalFreekick;

                [JsonProperty("shootInPenalty")] public readonly int shootInPenalty;
                [JsonProperty("goalInPenalty")] public readonly int goalInPenalty;
                
                [JsonProperty("shootOutPenalty")] public readonly int shootOutPenalty;
                [JsonProperty("goalOutPenalty")] public readonly int goalOutPenalty;

                [JsonProperty("shootPenaltyKick")] public readonly int shootPenaltyKick;
                [JsonProperty("goalPenaltyKick")] public readonly int goalPenaltyKick;

                [JsonConstructor]
                public ShootDTO([JsonProperty("shootTotal")] int shootTotal, [JsonProperty("effectiveShootTotal")] int effectiveShootTotal, [JsonProperty("shootOutScore")] int shootOutScore,
                    [JsonProperty("goalTotal")] int goalTotal, [JsonProperty("goalTotalDisplay")] int goalTotalDisplay,
                    [JsonProperty("ownGoal")] int ownGoal,
                    [JsonProperty("shootHeading")] int shootHeading, [JsonProperty("goalHeading")] int goalHeading,
                    [JsonProperty("shootFreekick")] int shootFreekick, [JsonProperty("goalFreekick")] int goalFreekick,
                    [JsonProperty("shootInPenalty")] int shootInPenalty, [JsonProperty("goalInPenalty")] int goalInPenalty,
                    [JsonProperty("shootOutPenalty")] int shootOutPenalty, [JsonProperty("goalOutPenalty")] int goalOutPenalty,
                    [JsonProperty("shootPenaltyKick")] int shootPenaltyKick, [JsonProperty("goalPenaltyKick")] int goalPenaltyKick)
                {
                    this.shootTotal = shootTotal;
                    this.effectiveShootTotal = effectiveShootTotal;
                    this.shootOutScore = shootOutScore;

                    this.goalTotal = goalTotal;
                    this.goalTotalDisplay = goalTotalDisplay;

                    this.ownGoal = ownGoal;

                    this.shootHeading = shootHeading;
                    this.goalHeading = goalHeading;

                    this.shootFreekick = shootFreekick;
                    this.goalFreekick = goalFreekick;

                    this.shootInPenalty = shootInPenalty;
                    this.goalInPenalty = goalInPenalty;

                    this.shootOutPenalty = shootOutPenalty;
                    this.goalOutPenalty = goalOutPenalty;

                    this.shootPenaltyKick = shootPenaltyKick;
                    this.goalPenaltyKick = goalPenaltyKick;
                }
            }

            [Serializable]
            public class ShootDetailDTO
            {
                [JsonProperty("goalTime")] public readonly int goalTime;

                [JsonProperty("x")] public readonly double x;
                [JsonProperty("y")] public readonly double y;
                [JsonProperty("type")] public readonly int type;
                [JsonProperty("result")] public readonly int result;
                [JsonProperty("spId")] public readonly int spId;
                [JsonProperty("spGrade")] public readonly int spGrade;
                [JsonProperty("spLevel")] public readonly int spLevel;
                [JsonProperty("spIdType")] public readonly bool spIdType;

                [JsonProperty("assist")] public readonly bool assist;
                [JsonProperty("assistSpId")] public readonly int assistSpId;
                [JsonProperty("assistX")] public readonly double assistX;
                [JsonProperty("assistY")] public readonly double assistY;

                [JsonProperty("hitPost")] public readonly bool hitPost;
                [JsonProperty("inPenalty")] public readonly bool inPenalty;

                [JsonConstructor]
                public ShootDetailDTO([JsonProperty("goalTime")] int goalTime, 
                    [JsonProperty("x")] double x, [JsonProperty("y")] double y, [JsonProperty("type")] int type, [JsonProperty("result")] int result, [JsonProperty("spId")] int spId, [JsonProperty("spGrade")] int spGrade, [JsonProperty("spLevel")] int spLevel, [JsonProperty("spIdType")] bool spIdType,
                    [JsonProperty("assist")] bool assist, [JsonProperty("assistSpId")] int assistSpId, [JsonProperty("assistX")] double assistX, [JsonProperty("assistY")] double assistY,
                    [JsonProperty("hitPost")] bool hitPost, [JsonProperty("inPenalty")] bool inPenalty)
                {
                    this.goalTime = goalTime;

                    this.x = x;
                    this.y = y;
                    this.type = type;
                    this.result = result;
                    this.spId = spId;
                    this.spGrade = spGrade;
                    this.spLevel = spLevel;
                    this.spIdType = spIdType;

                    this.assist = assist;
                    this.assistSpId = assistSpId;
                    this.assistX = assistX;
                    this.assistY = assistY;

                    this.hitPost = hitPost;
                    this.inPenalty = inPenalty;
                }
            }

            [Serializable]
            public class PassDTO
            {
                [JsonProperty("passTry")] public readonly int passTry;
                [JsonProperty("passSuccess")] public readonly int passSuccess;
                
                [JsonProperty("shortPassTry")] public readonly int shortPassTry;
                [JsonProperty("shortPassSuccess")] public readonly int shortPassSuccess;
                
                [JsonProperty("longPassTry")] public readonly int longPassTry;
                [JsonProperty("longPassSuccess")] public readonly int longPassSuccess;
                
                [JsonProperty("bouncingLobPassTry")] public readonly int bouncingLobPassTry;
                [JsonProperty("bouncingLobPassSuccess")] public readonly int bouncingLobPassSuccess;
                
                [JsonProperty("drivenGroundPassTry")] public readonly int drivenGroundPassTry;
                [JsonProperty("drivenGroundPassSuccess")] public readonly int drivenGroundPassSuccess;
                
                [JsonProperty("throughPassTry")] public readonly int throughPassTry;
                [JsonProperty("throughPassSuccess")] public readonly int throughPassSuccess;
                
                [JsonProperty("lobbedThroughPassTry")] public readonly int lobbedThroughPassTry;
                [JsonProperty("lobbedThroughPassSuccess")] public readonly int lobbedThroughPassSuccess;

                [JsonConstructor]
                public PassDTO([JsonProperty("passTry")] int passTry, [JsonProperty("passSuccess")] int passSuccess,
                    [JsonProperty("shortPassTry")] int shortPassTry, [JsonProperty("shortPassSuccess")] int shortPassSuccess,
                    [JsonProperty("longPassTry")] int longPassTry, [JsonProperty("longPassSuccess")] int longPassSuccess,
                    [JsonProperty("bouncingLobPassTry")] int bouncingLobPassTry, [JsonProperty("bouncingLobPassSuccess")] int bouncingLobPassSuccess,
                    [JsonProperty("drivenGroundPassTry")] int drivenGroundPassTry, [JsonProperty("drivenGroundPassSuccess")] int drivenGroundPassSuccess,
                    [JsonProperty("throughPassTry")] int throughPassTry, [JsonProperty("throughPassSuccess")] int throughPassSuccess,
                    [JsonProperty("lobbedThroughPassTry")] int lobbedThroughPassTry, [JsonProperty("lobbedThroughPassSuccess")] int lobbedThroughPassSuccess)
                {
                    this.passTry = passTry;
                    this.passSuccess = passSuccess;

                    this.shortPassTry = shortPassTry;
                    this.shortPassSuccess = shortPassSuccess;

                    this.longPassTry = longPassTry;
                    this.longPassSuccess = longPassSuccess;

                    this.bouncingLobPassTry = bouncingLobPassTry;
                    this.bouncingLobPassSuccess = bouncingLobPassSuccess;

                    this.drivenGroundPassTry = drivenGroundPassTry;
                    this.drivenGroundPassSuccess = drivenGroundPassSuccess;

                    this.throughPassTry = throughPassTry;
                    this.throughPassSuccess = throughPassSuccess;

                    this.lobbedThroughPassTry = lobbedThroughPassTry;
                    this.lobbedThroughPassSuccess = lobbedThroughPassSuccess;
                }
            }

            [Serializable]
            public class DefenceDTO
            {
                [JsonProperty("blockTry")] public readonly int blockTry;
                [JsonProperty("blockSuccess")] public readonly int blockSuccess;

                [JsonProperty("tackleTry")] public readonly int tackleTry;
                [JsonProperty("tackleSuccess")] public readonly int tackleSuccess;

                [JsonConstructor]
                public DefenceDTO([JsonProperty("blockTry")] int blockTry, [JsonProperty("blockSuccess")] int blockSuccess,
                    [JsonProperty("tackleTry")] int tackleTry, [JsonProperty("tackleSuccess")] int tackleSuccess)
                {
                    this.blockTry = blockTry;
                    this.blockSuccess = blockSuccess;

                    this.tackleTry = tackleTry;
                    this.tackleSuccess = tackleSuccess;
                }
            }

            [Serializable]
            public class PlayerDTO
            {
                [Serializable]
                public class StatusDTO
                {
                    [JsonProperty("shoot")] public readonly int shoot;
                    [JsonProperty("effectiveShoot")] public readonly int effectiveShoot;

                    [JsonProperty("assist")] public readonly int assist;
                    [JsonProperty("goal")] public readonly int goal;

                    [JsonProperty("dribble")] public readonly int dribble;

                    [JsonProperty("intercept")] public readonly int intercept;
                    [JsonProperty("defending")] public readonly int defending;

                    [JsonProperty("passTry")] public readonly int passTry;
                    [JsonProperty("passSuccess")] public readonly int passSuccess;

                    [JsonProperty("dribbleTry")] public readonly int dribbleTry;
                    [JsonProperty("dribbleSuccess")] public readonly int dribbleSuccess;

                    [JsonProperty("ballPossesionTry")] public readonly int ballPossesionTry;
                    [JsonProperty("ballPossesionSuccess")] public readonly int ballPossesionSuccess;

                    [JsonProperty("aerialTry")] public readonly int aerialTry;
                    [JsonProperty("aerialSuccess")] public readonly int aerialSuccess;

                    [JsonProperty("blockTry")] public readonly int blockTry;
                    [JsonProperty("block")] public readonly int block;

                    [JsonProperty("tackleTry")] public readonly int tackleTry;
                    [JsonProperty("tackle")] public readonly int tackle;

                    [JsonProperty("yellowCards")] public readonly int yellowCards;
                    [JsonProperty("redCards")] public readonly int redCards;

                    [JsonProperty("spRating")] public readonly float spRating;

                    [JsonConstructor]
                    public StatusDTO([JsonProperty("shoot")] int shoot, [JsonProperty("effectiveShoot")] int effectiveShoot,
                        [JsonProperty("assist")] int assist, [JsonProperty("goal")] int goal,
                        [JsonProperty("dribble")] int dribble,
                        [JsonProperty("intercept")] int intercept, [JsonProperty("defending")] int defending,
                        [JsonProperty("passTry")] int passTry, [JsonProperty("passSuccess")] int passSuccess,
                        [JsonProperty("dribbleTry")] int dribbleTry, [JsonProperty("dribbleSuccess")] int dribbleSuccess,
                        [JsonProperty("ballPossesionTry")] int ballPossesionTry, [JsonProperty("ballPossesionSuccess")] int ballPossesionSuccess,
                        [JsonProperty("aerialTry")] int aerialTry, [JsonProperty("aerialSuccess")] int aerialSuccess,
                        [JsonProperty("blockTry")] int blockTry, [JsonProperty("block")] int block,
                        [JsonProperty("tackleTry")] int tackleTry, [JsonProperty("tackle")] int tackle,
                        [JsonProperty("yellowCards")] int yellowCards, [JsonProperty("redCards")] int redCards,
                        [JsonProperty("spRating")] float spRating)
                    {
                        this.shoot = shoot;
                        this.effectiveShoot = effectiveShoot;

                        this.assist = assist;
                        this.goal = goal;

                        this.dribble = dribble;

                        this.intercept = intercept;
                        this.defending = defending;

                        this.passTry = passTry;
                        this.passSuccess = passSuccess;

                        this.dribbleTry = dribbleTry;
                        this.dribbleSuccess = dribbleSuccess;

                        this.ballPossesionTry = ballPossesionTry;
                        this.ballPossesionSuccess = ballPossesionSuccess;

                        this.aerialTry = aerialTry;
                        this.aerialSuccess = aerialSuccess;

                        this.blockTry = blockTry;
                        this.block = block;

                        this.tackleTry = tackleTry;
                        this.tackle = tackle;

                        this.yellowCards = yellowCards;
                        this.redCards = redCards;

                        this.spRating = spRating;
                    }
                }

                [JsonProperty("spId")] public readonly int spId;
                [JsonProperty("spPosition")] public readonly int spPosition;
                [JsonProperty("spGrade")] public readonly int spGrade;

                [JsonProperty("status")] public readonly StatusDTO[] statuses;

                [JsonConstructor]
                public PlayerDTO([JsonProperty("spId")] int spId, [JsonProperty("spPosition")] int spPosition, [JsonProperty("spGrade")] int spGrade, [JsonProperty("status")] StatusDTO[] statuses)
                {
                    this.spId = spId;
                    this.spPosition = spPosition;
                    this.spGrade = spGrade;

                    this.statuses = statuses;
                }
            }

            [JsonProperty("accessId")] public readonly string accessId;
            [JsonProperty("nickname")] public readonly string nickname;

            [JsonProperty("matchDetail")] public readonly MatchDetailDTO matchDetail;

            [JsonProperty("shoot")] public readonly ShootDTO shoot;
            [JsonProperty("shootDetail")] public readonly ShootDetailDTO[] shootDetails;

            [JsonProperty("pass")] public readonly PassDTO pass;
            [JsonProperty("defence")] public readonly DefenceDTO defence;

            [JsonProperty("player")] public readonly PlayerDTO[] players;

            [JsonConstructor]
            public MatchInfoDTO([JsonProperty("accessId")] string accessId, [JsonProperty("nickname")] string nickname,
                [JsonProperty("matchDetail")] MatchDetailDTO matchDetail,
                [JsonProperty("shoot")] ShootDTO shoot, [JsonProperty("shootDetail")] ShootDetailDTO[] shootDetails,
                [JsonProperty("pass")] PassDTO pass, [JsonProperty("defence")] DefenceDTO defence,
                [JsonProperty("player")] PlayerDTO[] players)
            {
                this.accessId = accessId;
                this.nickname = nickname;

                this.matchDetail = matchDetail;

                this.shoot = shoot;
                this.shootDetails = shootDetails;

                this.pass = pass;
                this.defence = defence;

                this.players = players;
            }
        }

        [JsonProperty("matchId")] public readonly string matchId;
        [JsonProperty("matchDate")] public readonly DateTime matchDate;
        [JsonProperty("matchType")] public readonly int matchType;
        [JsonProperty("matchInfo")] public readonly MatchInfoDTO[] matchInfos;

        [JsonConstructor]
        public MatchDTO([JsonProperty("matchId")] string matchId, [JsonProperty("matchDate")] DateTime matchDate, [JsonProperty("matchType")] int matchType, [JsonProperty("matchInfo")] MatchInfoDTO[] matchInfos)
        {
            this.matchId = matchId;
            this.matchDate = matchDate;
            this.matchType = matchType;
            this.matchInfos = matchInfos;
        }
    }

    #endregion

    #region Mata information

    [Serializable]
    public class MatchType
    {
        [JsonProperty("matchtype")] public readonly int matchType;
        [JsonProperty("desc")] public readonly string description;

        [JsonConstructor]
        public MatchType([JsonProperty("matchtype")] int matchType, [JsonProperty("desc")] string description)
        {
            this.matchType = matchType;
            this.description = description;
        }
    }

    [Serializable]
    public class Spid
    {
        [JsonProperty("id")] public readonly int id;
        [JsonProperty("name")] public readonly string name;

        [JsonConstructor]
        public Spid([JsonProperty("id")] int id, [JsonProperty("name")] string name)
        {
            this.id = id;
            this.name = name;
        }
    }

    [Serializable]
    public class SeasonId
    {
        [JsonProperty("seasonId")] public readonly int seasonId;
        [JsonProperty("className")] public readonly string className;

        [JsonProperty("seasonImg")] public readonly string seasonImgUrl;

        [JsonConstructor]
        public SeasonId([JsonProperty("seasonId")] int seasonId, [JsonProperty("className")] string className, [JsonProperty("seasonImg")] string seasonImgUrl)
        {
            this.seasonId = seasonId;
            this.className = className;

            this.seasonImgUrl = seasonImgUrl;
        }
    }

    [Serializable]
    public class SpPosition
    {
        [JsonProperty("spposition")] public readonly int spPosition;
        [JsonProperty("desc")] public readonly string desc;

        [JsonConstructor]
        public SpPosition([JsonProperty("spposition")] int spPosition, [JsonProperty("desc")] string desc)
        {
            this.spPosition = spPosition;
            this.desc = desc;
        }
    }

    [Serializable]
    public class Division
    {
        [JsonProperty("divisionId")] public readonly int divisionId;
        [JsonProperty("divisionName")] public readonly string divisionName;

        [JsonConstructor]
        public Division([JsonProperty("divisionId")] int divisionId, [JsonProperty("divisionName")] string divisionName)
        {
            this.divisionId = divisionId;
            this.divisionName = divisionName;
        }
    }

    #endregion
}

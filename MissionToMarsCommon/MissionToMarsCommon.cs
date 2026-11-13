namespace MissionToMarsCommon;

public enum TeamsPlaying {
    TEAM_1,
    TEAM_2
}

public enum AllTeams {
    MURCURY,
    VENUS,
    JUPITER,
    SATURN
}

public enum CommandFlags : byte {
    GET = 1 << 0, 
    PUBLISH = 1 << 1,
    URGENT = 1 << 2,
    NONE = 0
}
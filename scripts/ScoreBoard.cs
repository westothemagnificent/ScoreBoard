using Godot;
using System;

public partial class ScoreBoard : Panel {


    // vars

    [Export] private AllTeams team1 {
        get;

        set {
            updateTeam1(value);

            field = value;
        }
    }

    [Export] private AllTeams team2 {
        get;

        set {
            updateTeam2(value);

            field = value;
        }
    }
    

    // nodes

    private HBoxContainer teamsBanner;

    private Team team1UI;

    private Team team2UI;

    private PackedScene teamMurcuryScene;
    private PackedScene teamVenusScene;
    private PackedScene teamJupiterScene;
    private PackedScene teamSaturnScene;

    // api

    public void updateTeam1Score(int pScore) {
        if (!IsInstanceValid(team1UI)) { return; }

        team1UI.score = pScore;
    }

    public void updateTeam2Score(int pScore) {
        if (!IsInstanceValid(team2UI)) { return; }

        team2UI.score = pScore;
    }


    // functions

    public override void _Ready() {

        teamMurcuryScene = ResourceLoader.Load<PackedScene>("res://scenes/team_mercury.tscn");
        teamVenusScene = ResourceLoader.Load<PackedScene>("res://scenes/team_venus.tscn");
        teamJupiterScene = ResourceLoader.Load<PackedScene>("res://scenes/team_jupiter.tscn");
        teamSaturnScene = ResourceLoader.Load<PackedScene>("res://scenes/team_saturn.tscn");

        teamsBanner = GetNode<HBoxContainer>("%teamsBanner");

        updateTeam1(team1);
        updateTeam2(team2);
    }

    private void updateTeam1(AllTeams pTeam) {
        if (!IsInsideTree()) { return; }

        Team team = createTeamUI(pTeam);

        if (IsInstanceValid(team1UI)) {
            team1UI.Free();
        }

        team.useLeft = false;

        team1UI = team;
        
        teamsBanner.AddChild(team);
        teamsBanner.MoveChild(team, 0);
    }

    private void updateTeam2(AllTeams pTeam) {
        if (!IsInsideTree()) { return; }

        Team team = createTeamUI(pTeam);

        if (IsInstanceValid(team2UI)) {
            team2UI.Free();
        }
        team.useLeft = true;

        team2UI = team;
        
        teamsBanner.AddChild(team);
        teamsBanner.MoveChild(team, 2);
    }

    private Team createTeamUI(AllTeams pTeam) {
        PackedScene scene = null;

        switch (pTeam) {
            case AllTeams.MURCURY:
                scene = teamMurcuryScene;
                break;
    
            case AllTeams.VENUS:
                scene = teamVenusScene;
                break;
    
            case AllTeams.JUPITER:
                scene = teamJupiterScene;
                break;
    
            case AllTeams.SATURN:
                scene = teamSaturnScene;
                break;
        }

        if (scene == null) {
            GD.PushError($"No team scene loaded for {pTeam.ToString()}");
            return null;
        }

        Team teamUI = scene.Instantiate<Team>();

        return teamUI;
    }
    
    
    // types

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
}

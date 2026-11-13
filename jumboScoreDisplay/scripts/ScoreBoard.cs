using Godot;
using MissionToMarsCommon;
using System;

namespace ScoreBroad;

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

    public void startTeamTimer(TeamsPlaying pTeam) {
        switch (pTeam) {
            case TeamsPlaying.TEAM_1:
                if (IsInstanceValid(team1UI)) { team1UI.startTimer(); }
                break;
            case TeamsPlaying.TEAM_2:
                if (IsInstanceValid(team2UI)) { team2UI.startTimer(); }
                break;
        }
    }

    public void stopTeamTimer(TeamsPlaying pTeam) {
        switch (pTeam) {
            case TeamsPlaying.TEAM_1:
                if (IsInstanceValid(team1UI)) { team1UI.stopTimer(); }
                break;
            case TeamsPlaying.TEAM_2:
                if (IsInstanceValid(team2UI)) { team2UI.stopTimer(); }
                break;
        }
    }

    public void setDisplayedTeamScore(TeamsPlaying pTeam, int pScore) {
        switch (pTeam) {
            case TeamsPlaying.TEAM_1:
                if (IsInstanceValid(team1UI)) { team1UI.score = pScore; }
                break;
            case TeamsPlaying.TEAM_2:
                if (IsInstanceValid(team2UI)) { team2UI.score = pScore; }
                break;
        }
    }

    public int getDisplayedTeamScore(TeamsPlaying pTeam) {
        switch (pTeam) {
            case TeamsPlaying.TEAM_1:
                if (IsInstanceValid(team1UI)) { return team1UI.score; }
                break;
            case TeamsPlaying.TEAM_2:
                if (IsInstanceValid(team2UI)) { return team2UI.score; }
                break;
        }

        return 0;
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

        setDisplayedTeamScore(TeamsPlaying.TEAM_1, 30);
        setDisplayedTeamScore(TeamsPlaying.TEAM_2, 300);

        startTeamTimer(TeamsPlaying.TEAM_1);
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
}

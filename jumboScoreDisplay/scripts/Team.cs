using Godot;
using System;
using System.Diagnostics;

namespace ScoreBroad;

public partial class Team : PanelContainer {

    // exports


    // controls wether main content is display on the right or left
    [Export] public bool useLeft {
        get;

        set {
            updateLayout(value);

            field = value;
        }
    }

    [Export] public int score {
        get;

        set {
            updateScore(value);

            field = value;
        }
    }

    [Export] public string timerEsplasedTimeExportedString {
        get => timerEsplasedTimeString;

        set {}
    }

    [Export] public string name {
        get;

        set {
            updateName(value);

            field = value;
        }
    } = "NAME";

    // vars

    public TimeSpan timerEsplasedTime => timer.Elapsed;
    public string timerEsplasedTimeString => $"{timerEsplasedTime.Minutes:D2}:{timerEsplasedTime.Seconds:D2}";

    private Stopwatch timer = new Stopwatch();

    // nodes
    
    private HBoxContainer content;

    private Label teamNameLabel;
    private Label scoreLabel;
    private Label timerLabel;


    // api

    public void startTimer() {
        timer.Reset();
        timer.Start();
    }

    public void stopTimer() {
        timer.Stop();
    }

    // functions

    public override void _Process(double delta) {
        timerLabel.Text = timerEsplasedTimeString;
    }


    public override void _Ready() {
        content = GetNode<HBoxContainer>("%content");

        teamNameLabel = GetNode<Label>("%teamName");
        scoreLabel = GetNode<Label>("%score");
        timerLabel = GetNode<Label>("%timerDisplay");

        updateLayout(useLeft);
        updateScore(score);
        updateName(name);
    }

    private void updateLayout(bool pUseLeft) {
        if (!IsInsideTree()) { return; }

        if (pUseLeft) {
            content.LayoutDirection = LayoutDirectionEnum.Rtl;
        }
        else {
            content.LayoutDirection = LayoutDirectionEnum.Ltr;
        }
    }

    private void updateScore(int pScore) {
        if (!IsInsideTree()) { return; }

        scoreLabel.Text = pScore.ToString();
    }

    private void updateName(string pName) {
        if (!IsInsideTree()) { return; }

        teamNameLabel.Text = pName;
    }
}

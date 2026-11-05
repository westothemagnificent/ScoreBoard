using Godot;
using System;

[Tool] public partial class Team : PanelContainer {

    // exports


    // controls wether main content is display on the right or left
    [Export] public bool useLeft {
        get;

        set {
            updateLayout(value);

            field = value;
        }
    }

    // vars
    
    private HBoxContainer content;

    private Label teamNameLabel;
    private Label scoreLabel;


    // functions

    public override void _EnterTree() {
        content = GetNode<HBoxContainer>("%content");

        teamNameLabel = GetNode<Label>("%teamName");
        scoreLabel = GetNode<Label>("%score");


        updateLayout(useLeft);
    }

    private void updateLayout(bool pUseLeft) {
        if (content == null) return;

        if (pUseLeft) {
            content.LayoutDirection = LayoutDirectionEnum.Rtl;
        }
        else {
            content.LayoutDirection = LayoutDirectionEnum.Ltr;
        }
    }

}

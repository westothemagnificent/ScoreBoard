using Godot;
using System;

public partial class MatchFeedInitializer : Node {

    public override void _Ready() {
        CameraServer.MonitoringFeeds = true;

        Godot.Collections.Array<CameraFeed> feeds = CameraServer.Feeds();

        if (feeds.Count == 0) {
            GD.PrintErr("Unable to initialize match feed");
            GD.PrintErr("Note: camera feeds are not implemented on Windows see: https://docs.godotengine.org/en/stable/classes/class_cameraserver.html");
            CameraServer.MonitoringFeeds = false;
            return;
        }

        CameraFeed feed = feeds[0];

        feed.FeedIsActive = true;

        CameraServer.MonitoringFeeds = false;
    }
}

#reference "tools/AutoCake.Release/tools/AutoCake.Release.dll"
#load      "tools/AutoCake.Release/content/release-tasks.cake"
#load      "tools/AutoCake.Release/content/git-tasks.cake"

//////////////////////////////////////////////////////////////////////
// ARGUMENTS
//////////////////////////////////////////////////////////////////////

var target = Argument("target", "Default");
var configuration = Argument("configuration", "Release");

Task("Default")
    .IsDependentOn("Attempt-Release");

GitFlow.RunBuildTarget = () => 
{
  // See release-scripts/README.md for additional configuration options
  // and details on the syntax of this call.
  CakeRunnerAlias.RunCake(Context);
};

RunTarget(target);

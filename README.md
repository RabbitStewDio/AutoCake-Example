# GitVersion based automatic release scripts

This repository contains a set of release scripts that use Cake and GitVersion 
to fully automate the process of releasing software when using the GitFlow model.

The process assumes that you have the following two branches:

- master => contains all releases
- develop => contains all development commits for the next version.

In the best case, your develop branch will be always in a state so that you can 
start a release at any time. 

    build.ps1 -script release.cake -target Attempt-Release
   
This will create a new release branch (release-1.0.0). The version information for
this branch comes from GitVersion. 

The script will attempt to build the release in this branch. Building is done by 
invoking your "build.cake" script. You can configure this call via the 
"RunBuildTarget" action in the "release.cake" file.

If the release succeeds, the release-branch is merged into master, the version will
be tagged and the release is built one last time with the official version info for
this release. Once that is successfully done, the release branch is merged back into
develop and the version number in the assembly-info files will be increased.

If the release fails, the release-branch will remain open so that you can fix the build.

If your release process requires a stabilization phase before actually releasing the
software, you can open a new release-branch via 

    build.ps1 -script release.cake -target Create-Release-Branch

This will create a new release branch and will update the version information to 
make builds from this branch a release-candidate build.

Once you are satisfied with the changes and want to make the release, simply invoke

    build.ps1 -script release.cake -target Attempt-Release

from the release branch.

## Configuration options

### -release "master" -dev "develop"

Defines the branches from where releases are derived and where releases are published
to. 

"release" sets the target branch that will receive finished builds. This defaults to 
"master". Set it to "support-1.x" if you have a long-term support branch for the 1.x 
releases and want to build an update for this branch.

"dev" names the development branch from where to start releases. If you have a long-term
support branch named support-1.x, then this model assume you also have a branch 
"support-dev-1.x" on which to develop for this version. Change this argument to 
"support-dev-1.x" in that case. 
    
### -push "origin"

If the "push" argument is given, then the release process will push released tags and 
branch updates for the release and dev branches back to this git-remote when the build
succeeds. 

If a long-term release-branch is created via the "Create-Release-Branch" target, and
the push argument is not null, then this branch will also be pushed to the git-remote.


# Cake example repository

This repository is used as an minimal example of using the [Cake build system](http://cakebuild.net)

You can read more in the Cake [Getting Started guide](http://cakebuild.net/docs/tutorials/getting-started).



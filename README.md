# GitVersion based automatic release scripts

This repository is an example project for the AutoCake build- and release 
scripts.

[AutoCake](https://github.com/rabbitstewdio/AutoCake) gives you a fully 
automated release process that takes care of the build as well as the 
necessary branching, tagging and merging that normally happens during a release. 

The script relies on [GitVersion](https://github.com/GitTools/GitVersion) 
to solve the complex task of coming up with the current and next version 
number for the releases. 

The script allows you to keep your Continuous-Integration server 
configuration simple and allows your developers to recreate builds locally 
in an easy and repeatable manor.

The various options and settings for AutoCake are documented in the main project:

* [AutoCake.Build documentation](https://github.com/RabbitStewDio/AutoCake/blob/develop/src/AutoCake.Build/README.md)
* [AutoCake.Release documentation](https://github.com/RabbitStewDio/AutoCake/blob/develop/src/AutoCake.Release/README.md)

# The sample code

The project here is a really simple two-classes project. "Example" is a
MSIL (AnyCPU) library that is covered by a couple of tests. When loading
the project you'll notice that there are four test projects with pretty
much the same test code. This simply demonstrates the various test-frameworks
the AutoCake system supports. A sane development setup would pick one.

The Example.X86 project is an example of an platform dependent project.
The platform dependent code depends on the platform independent base
project "Example". This is a common scenario when dealing with shared
code that needs to support various platforms. 

When the project is built, you will see that the platform independent 
library is correctly built as MSIL library, while the X86 specific code
produces a platform dependent assembly with all the correct metadata.

# Building

To build the source code, use the standard cake script "build.cake".

To invoke the default actions, use:

    .\build.ps1 

Use 

    .\build.ps1 --showdescription

to see a list of available built targets. Targets that start with underscore
are internal targets.

# Releasing a new version

To build create a new release from the code, use the cake script "release.cake".
You need to invoke that action while on the "develop" branch or when on
a release branch (release-X.Y.Z).

The script will refuse to run if you have uncommited changes. Building a release
involves merges and commits, so having pending changes would destroy your pending 
work.

To invoke the default actions, use:

    .\build.ps1 -script release.cake

Use 

    .\build.ps1 -script release.cake --showdescription

to see a list of available built targets. Targets that start with underscore
are internal targets.

When a release is done, you will find the binaries and a set of NuGet packages 
in "build-artefacts/$version$. Your master-branch will have a new tag for the
release, and develop will have been updated with the next version number.

GitVersion allows you to increment versions manually (for instance to start
a new major release), please make sure you read the [documentation on this 
topic for GitVersion](http://gitversion.readthedocs.io/en/stable/more-info/version-increments/#manually-incrementing-the-version).


# Adapting AutoCake for your next project

To use AutoCake in your project, simply take the following files and add them
to the root of your project repository.

    # These are the standard Cake bootstrapper files
    ./build.sh
    ./build.ps1

    # The actual build scripts with all the necessary tools and references.
    ./tools/packages.config
    ./build.cake
    ./release.cake

    # Optionally, a GitVersion configuration template 
    ./GitVersion.yml


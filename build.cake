#tool "nuget:?package=OpenCover"
#tool "nuget:?package=NUnit.ConsoleRunner"
#tool "nuget:?package=ReportGenerator"

var target = Argument("target", "Default");
var projectName = "DesignByContract";

// Build Core

Task("BuildProjectsCore")
    .Does(() =>
    {
        foreach(var project in GetFiles("./core/src/**/*.csproj"))
        {
            MSBuild(project.GetDirectory().FullPath,
                new MSBuildSettings {
                    Verbosity = Verbosity.Minimal,
                    Configuration = "Debug"
                }
            );
        }
    });

Task("BuildProjectsCoreTests")
    .IsDependentOn("BuildProjectsCore")
    .Does(() =>
    {
        foreach(var test in GetFiles("./core/tests/**/*.csproj"))
        {
            MSBuild(test.GetDirectory().FullPath,
                new MSBuildSettings {
                    Verbosity = Verbosity.Minimal,
                    Configuration = "Debug"
                }
            );
        }
    });

// Build Domain

Task("BuildProjects")
    .IsDependentOn("BuildProjectsCoreTests")
    .Does(() =>
    {
        foreach(var project in GetFiles("./src/**/*.csproj"))
        {
            MSBuild(project.GetDirectory().FullPath,
                new MSBuildSettings {
                    Verbosity = Verbosity.Minimal,
                    Configuration = "Debug"
                }
            );
        }
    });

Task("BuildTests")
    .IsDependentOn("BuildProjects")
    .Does(() =>
    {
        foreach(var test in GetFiles("./tests/**/*.csproj"))
        {
            MSBuild(test.GetDirectory().FullPath,
                new MSBuildSettings {
                    Verbosity = Verbosity.Minimal,
                    Configuration = "Debug"
                }
            );
        }
    });

// OpenCover

Task("OpenCover")
    .IsDependentOn("BuildTests")
    .Does(() =>
    {
        var openCoverSettings = new OpenCoverSettings()
        {
            Register = "user",
            SkipAutoProps = true,
            ArgumentCustomization = args => args.Append("-coverbytest:*.Tests.*dll").Append("-mergebyhash")
        };

        var outputFile = new FilePath("./docs/testsResults/Reports/CodeCoverageReport.xml");

        OpenCover(tool => {
            var testAssemblies = GetFiles("./**/bin/Debug/*.Tests.*dll");
            tool.NUnit3(testAssemblies);
            },
            outputFile,
            openCoverSettings
                .WithFilter("+[" + projectName + "*]*")
                .WithFilter("-[" + projectName + ".*.Tests]*")
        );
    });

Task("ReportGenerator")
    .IsDependentOn("OpenCover")
    .Does(() =>{
        var reportGeneratorSettings = new ReportGeneratorSettings()
        {
            HistoryDirectory = new DirectoryPath("./docs/testsResults/Reports/ReportsHistory")
        };

        ReportGenerator("./docs/testsResults/Reports/CodeCoverageReport.xml", 
                        "./docs/testsResults/Reports/ReportGeneratorOutput",
                        reportGeneratorSettings);
    });

Task("Default")
    .IsDependentOn("ReportGenerator")
    .Does(() => {
        if (IsRunningOnWindows())
        {
            var reportFilePath = ".\\docs\\testsResults\\Reports\\ReportGeneratorOutput\\index.htm";

            StartProcess("explorer", reportFilePath);
        }
    });

RunTarget(target);
# TechDebt.Compat.SonarQube
SonarQube compatible c# tech debt attribute markup for code smells, and associated analyser.

## How to integrate 
 - Build these projects as a nuget package (recommend adding a nuget source to local package directory)
 - Build a sonarqube plugin for this analyzer using [the sonar-roslyn sdk](https://github.com/SonarSource/sonarqube-roslyn-sdk)
   - specify our sqale file like `RoslynSonarQubePluginGenerator.exe /a:TechDebt.Compat.SonarQube /sqale:Sqale.xml` 
 - Build the [custom sonar-csharp fork](https://github.com/flavourous/sonar-csharp/tree/topic/setGapInDiagnosticAnalyser) plugin (this enables setting the effort in sonar) 
 - Copy these plugin `jar`s to your sonarqube e.g. `/opt/sonarqube/extensions/plugins` (I recommend `docker pull sonarqube`), *replacing* the stock sonar-csharp plugin.
 - Restart your sonarqube instance, and go into quality profiles and ensure the rules are enabled for your project.
 - Use `TechDebtAttribute` in your projects, and reference both the analyzer and attribute nuget packages.
 - Build your project using [sonar-msbuild-scanner](https://github.com/SonarSource/sonar-scanner-msbuild) as [described in thier docs](https://docs.sonarqube.org/display/SCAN/Analyzing+with+SonarQube+Scanner+for+MSBuild)
 - Now your tech debt records will be in your sonarqube instance!

# cucumber-cannery

[![nuget](https://github.com/gman-au/cucumber-cannery/actions/workflows/nuget.yml/badge.svg)](https://github.com/gman-au/cucumber-cannery/actions/workflows/nuget.yml)

![GitHub Release](https://img.shields.io/github/v/release/gman-au/cucumber-cannery)

## Summary
It is a simple command line tool that can be installed from NuGet.

It is primarily used against [ReqnRoll](https://docs.reqnroll.net/latest/index.html) test assemblies;
when run, it will take a .NET assembly and document any ReqnRoll 
[step definitions](https://docs.reqnroll.net/latest/automation/step-definitions.html) 
that it finds.  

## Usage
### Installation
You can install the `cucumber-can` tool via the following .NET command
```
dotnet tool install -g Gman.Cucumber.Cannery
```
### Running the tool
The tool takes three arguments:
```
cucumber-can <PATH_TO_STEP_DEFINITION_ASSEMBLY> <STEP_DEFINITION_ASSEMBLY_FILE> <PATH_TO_OUTPUT_FILE>
```
- `PATH_TO_STEP_DEFINITION_ASSEMBLY` - this will be the location of the built .NET DLL containing the ReqnRoll step definitions.
- `STEP_DEFINITION_ASSEMBLY_FILE` - this will be the name of the step definition assembly file. Supports wildcards.
- `PATH_TO_OUTPUT_FILE` - this will be the path to the generated output file where the markdown should be generated; includes the full file name. The file _does not have to be a markdown_ (`.md`) file.

The above arguments are specified separately; in cases where a path to a given set of results or assemblies may *not be exactly known* at build time (i.e. CI/CD pipelines), the **first** file found matching the name in the given folder will be provided to the tool.

### XML .NET Documentation
This command supports binding help file documentation (in XML format) to the step definitions, if they are provided.

Be sure to configure the following property in your `csproj` file:
```
<PropertyGroup>
    <GenerateDocumentationFile>true</GenerateDocumentationFile>
</PropertyGroup>
```

The directory where the DLL is located will also be scanned for the equivalent `.xml` file;
if it exists, it will attempt to extract the associated documentation and bind it to each step.
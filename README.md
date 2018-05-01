# Sample Windows Service using OWIN

This playground is meant to show that [Cake](https://cakebuild.net/) can be used to build Windows Services.

## Dependencies

|Dependency|Description|
|----------|-----------|
|[TopShelf](http://topshelf-project.com/)|Makes development of Windows Service more development-friendly|
|[Serilog](https://serilog.net/)|Logs to the console|
|[ApplicationHealth.SelfHost](https://github.com/coolblue-development/net-utilities/tree/master/ApplicationHealth/ApplicationHealth.SelfHost)|The package this sample service uses to expose Health endpoints|
|libuv.dll|Required module for self-hosting a webservice, needs special configuration|

## Special configuration

### libuv.dll

Special configuration is needed for libuv.dll. The DLL needs to be in the output (`bin/debug`, `bin/release`) directory when the self-hosted webserver starts, but this is not the default behaviour when using the `LibUv` NuGet package.

For this, the following special configurations have been applied for the sample to work:
- The sample's project (`.csproj`) is configured to have a `Platform Target` of `x64` (instead of `AnyCPU`)
- The file `libuv.dll` under `net-utilities\ApplicationHealth\packages\Libuv.1.9.1\runtimes\win7-x64\native\libuv.dll` has been added as an existing item to the project
- The file `livuv.dll` has been marked as `Content` and `Copy Always`

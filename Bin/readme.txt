To create NuGet package from source:
1. Build a packege release version
2. Run nuget.exe pack <Path_To_*.nuspec>
	E.g.: nuget.exe pack N:\MethodDecorator.Fody.nuspec
3. NuGet package file will be created. E.g.:
	MethodDecorator.Fody.0.9.0.7.nupkg
4. Load the package to a VS project. E.g.:
	Install-Package N:\MethodDecorator.Fody.0.9.0.7.nupkg -Project SomeProjectName